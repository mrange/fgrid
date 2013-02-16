// ----------------------------------------------------------------------------------------------
// Copyright (c) Mårten Rånge.
// ----------------------------------------------------------------------------------------------
// This source code is subject to terms and conditions of the Microsoft Public License. A 
// copy of the license can be found in the License.html file at the root of this distribution. 
// If you cannot locate the  Microsoft Public License, please send an email to 
// dlr@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
//  by the terms of the Microsoft Public License.
// ----------------------------------------------------------------------------------------------
// You must not remove this notice, or any other, from this software.
// ----------------------------------------------------------------------------------------------

// ReSharper disable InconsistentNaming

// ----------------------------===>> G O A L S <<===----------------------------
// 0. Good default behavior, possible to override
// 1. Fast loading times
// 2. Fast rendering times
// 2.1. Chose simpler layout schemes for good performance
// 2.2. Cache rendering result to avoid rerendering
// 3. Includable
// 3.1. No ResX or XAML files
// 4. Small size
// 5. No paging
// 6. Filters are applied on demand not continously
// 6.1. Performance
// 6.2. Continous applies are confusing (rows are disappearing/appearing for "no" reason)
// 7. No automatic column resizing (but automatic column sizing)
// 7.1. Performance
// 7.2. Also confusing when columns are resized on scroll
// 8. Support custom new row operations
// 8.1. Existing grids often doesn't allow new row to be precisely controlled
// ----------------------------===>> G O A L S <<===----------------------------


// ----------------------------===>> T O D O S <<===----------------------------
//  1. Measure:
//      Include previous measurement/availablesize/value to allow measurement to reuse previous measurement?
//  2. Once done remove Include dependency
//  3. ValuePath should support paths IE not just members
// ----------------------------===>> T O D O S <<===----------------------------

#define FGRID__DYNAMIC_IS_SUPPORTED

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FGrid.Internal;
using FGrid.Source.Extensions;
using Microsoft.CSharp.RuntimeBinder;

namespace FGrid
{
    public enum FilterOperator
    {
        EqualTo         ,
        NotEqualTo      ,
    }

    public abstract partial class FGridView_Object : DependencyObject
    {
        FGridView m_gridView;

        internal FGridView GridView
        {
            get
            {
                return m_gridView;
            }
            set
            {
                if (ReferenceEquals(m_gridView, value))
                {
                    return;
                }

                Debug.Assert(!(m_gridView != null && value != null));

                m_gridView = value;

                if (m_gridView != null)
                {
                    m_gridView.Invalidate();
                }
            }
        }
    }

    public abstract partial class FGridView_FilterRule : FGridView_Object
    {
        protected abstract bool TestAccordingToRule (object row);
    }

    public partial class FGridView_FilterRule_Simple : FGridView_FilterRule
    {
        protected override bool TestAccordingToRule(object row)
        {
#if FGRID__DYNAMIC_IS_SUPPORTED
            // TODO: Cache
            dynamic comparand   = Comparand;
            dynamic value       = row.GetMemberValue(ValuePath);

            switch (Operator)
            {
                case FilterOperator.EqualTo:
                    return value == comparand;
                case FilterOperator.NotEqualTo:
                    return value != comparand;
                default:
                    return false;
            }
#else
            return NOT_IMPLEMENTED_YET;
#endif
        }
    }

    public abstract partial class FGridView_SortRule : FGridView_Object
    {
        protected abstract int CompareAccordingToRole (object leftRow, object rightRow);
    }

    public partial class FGridView_SortRule_Simple : FGridView_SortRule
    {
        protected override int CompareAccordingToRole(object leftRow, object rightRow)
        {
#if FGRID__DYNAMIC_IS_SUPPORTED
            // TODO: Cache
            dynamic left    = leftRow.GetMemberValue(ValuePath);
            dynamic right   = rightRow.GetMemberValue(ValuePath);

            if (SortDescending)
            {
                return right < left;
            }
            else
            {
                return left < right;
            }

#else
            return NOT_IMPLEMENTED_YET;
#endif
        }
    }

    public abstract partial class FGridView_Row : FGridView_Object
    {
        const double Default_ContentHeight      = 24.0;
        const double Default_AdditionalHeight   = 0.0;
        const double Default_Height             = Default_ContentHeight + Default_AdditionalHeight;

        protected abstract void OnRenderRowBackground       (DrawingContext dc, Size size, object row);        
        protected abstract void OnRenderRowOverlay          (DrawingContext dc, Size size, object row, bool isSelected);        

        protected abstract void OnRenderHeaderBackground    (DrawingContext dc, Size size);        
        protected abstract void OnRenderHeaderOverlay       (DrawingContext dc, Size size);        
    }

    public partial class FGridView_Row_Default : FGridView_Row
    {
        protected override void OnRenderRowBackground(DrawingContext dc, Size size, object row)
        {
            dc.DrawRectangle(Brushes.White, null, size.ToRect());
        }

        protected override void OnRenderRowOverlay(DrawingContext dc, Size size, object row, bool isSelected)
        {
            if (isSelected)
            {
                dc.PushOpacity(0.25);
                dc.DrawRectangle(Brushes.Blue, null, size.ToRect());
                dc.Pop();
            }
        }

        protected override void OnRenderHeaderBackground(DrawingContext dc, Size size)
        {
            dc.DrawRectangle(Brushes.LightGray, null, size.ToRect());
        }

        protected override void OnRenderHeaderOverlay(DrawingContext dc, Size size)
        {
        }
    }

    public abstract partial class FGridView_Column : FGridView_Object
    {
        const double Default_ActualWidth            = 24.0;
        const double Default_MinWidth               = 24.0;
        const double Default_MaxWidth               = double.MaxValue;

        static GridLength Default_Width
        {
            get { return GridLength.Auto; }
        }

        partial void Coerce_Header(string value, ref string coercedValue)
        {
            coercedValue = value ?? "";
        }

        protected abstract void OnRenderRowBackground       (DrawingContext dc, Size size, object row);
        protected abstract void OnRenderRowOverlay          (DrawingContext dc, Size size, object row, bool hasFocus);

        protected abstract void OnRenderHeaderBackground    (DrawingContext dc, Size size);
        protected abstract void OnRenderHeaderOverlay       (DrawingContext dc, Size size);

        protected abstract FGridView_Object OnCreateEditControl (object row);

        protected abstract double   OnMeasureRowQuick   (object row);
        protected abstract double   OnMeasureRowExact   (object row);

        protected abstract double   OnMeasureHeaderQuick();
        protected abstract double   OnMeasureHeaderExact();

        protected abstract void     OnApplySort         (bool? sortDescending);
        protected abstract void     OnPresentFilterPopup();
    }

    public partial class FGridView_Column_Text : FGridView_Column
    {
        protected override void OnRenderRowBackground(DrawingContext dc, Size size, object row)
        {
            var val                     = row.GetMemberValue(ValuePath).ToText(FormatWith, GridView.Culture);
            var formattedText           = GridView.GetFormattedText(val);
            formattedText.MaxTextWidth  = size.Width;
            formattedText.MaxTextHeight = size.Height;
            dc.DrawText(formattedText, new Point());
        }

        protected override void OnRenderRowOverlay(DrawingContext dc, Size size, object row, bool hasFocus)
        {
        }

        protected override void OnRenderHeaderBackground(DrawingContext dc, Size size)
        {
            var formattedText           = GridView.GetFormattedText(Header);
            formattedText.MaxTextWidth  = size.Width;
            formattedText.MaxTextHeight = size.Height;
            dc.DrawText(formattedText, new Point());
        }

        protected override void OnRenderHeaderOverlay(DrawingContext dc, Size size)
        {
        }

        protected override FGridView_Object OnCreateEditControl(object row)
        {
            throw new NotImplementedException();
        }

        protected override double OnMeasureRowQuick(object row)
        {
            var val = row.GetMemberValue(ValuePath);
            return val.MeasureQuick();
        }

        protected override double OnMeasureRowExact(object row)
        {
            var val             = row.GetMemberValue(ValuePath).ToText(FormatWith, GridView.Culture);
            var formattedText   = GridView.GetFormattedText(val);
            return  formattedText.Width;
        }

        protected override double OnMeasureHeaderQuick()
        {
            return Header.Length;
        }

        protected override double OnMeasureHeaderExact()
        {
            var formattedText = GridView.GetFormattedText(Header);
            return formattedText.Width;
        }

        protected override void OnApplySort(bool? sortDescending)
        {
            GridView.SortRules.Clear();
            if (sortDescending == null)
            {
                return;
            }

            GridView.SortRules.Add(new FGridView_SortRule_Simple
                                       {
                                           ValuePath        = ValuePath                 ,
                                           SortDescending   = sortDescending ?? false 
                                       });
        }

        protected override void OnPresentFilterPopup()
        {
            throw new NotImplementedException();
        }
    }

    public partial class FGridView : FrameworkElement
    {
        sealed class GridRows
        {
            public int RowOffset;
            public double RowHeight;

            public ContentGridRow[] AvailableRows;

            public void Render (
                DrawingContext drawingContext, 
                Vector offset, 
                Size renderSize
                )
            {
                if (renderSize.AreaOf() <= 0)
                {
                    return;
                }

                var startingRow = (int)Math.Floor(offset.Y / RowHeight - RowOffset);
                var adjustedStartingRow = Math.Max(startingRow, 0);

                var localOffset = offset - new Vector(adjustedStartingRow*RowHeight, 0);
                var localEnd    = renderSize.ToVector();

                var visibleRows = (int)Math.Ceiling((localEnd.Y - localOffset.Y)/RowHeight);
                var rows        = Math.Min(visibleRows, AvailableRows.Length);

                var transform   = new TranslateTransform();

                for (
                        var currentRowIndex = adjustedStartingRow
                    ;       currentRowIndex < rows
                    ;   ++currentRowIndex
                )
                {
                    var currentRow = AvailableRows[currentRowIndex];
                    if (currentRow == null)
                    {
                        continue;
                    }

                    transform.X = localOffset.X;
                    transform.Y = localOffset.Y;

                    drawingContext.PushTransform(transform);

                    currentRow.Render(drawingContext);

                    drawingContext.Pop();

                    localOffset.Y = localOffset.Y + RowHeight;

                }
            }
        }

        abstract class GridRow
        {
            public readonly FGridView   GridView     ;
            public Drawing              BackGround   ;
            public Drawing              Overlay      ;

            protected GridRow(FGridView gridView)
            {
                GridView = gridView;
            }

            public void Render (DrawingContext drawingContext)
            {
                if (BackGround != null)
                {
                    drawingContext.DrawDrawing(BackGround);
                }
                if (Overlay != null)
                {
                    drawingContext.DrawDrawing(Overlay);
                }
            }


        }

        sealed class ContentGridRow : GridRow
        {
            public object Row;

            public ContentGridRow(FGridView gridView) : base(gridView)
            {
            }

            public void Detach()
            {
                var row         = Row;
                Row             = null;

                InvalidateRow();

                if (row != null)
                {
                    var notifyPropertyChanged = row as INotifyPropertyChanged;
                    if (notifyPropertyChanged != null)
                    {
                        notifyPropertyChanged.PropertyChanged -= Row_PropertyChanged;
                    }
                }

            }

            public void Attach(object row)
            {
                Detach();
                if (row != null)
                {
                    var notifyPropertyChanged = row as INotifyPropertyChanged;
                    if (notifyPropertyChanged != null)
                    {
                        notifyPropertyChanged.PropertyChanged += Row_PropertyChanged;
                    }

                }
            }

            void Row_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                InvalidateRow();
                GridView.Invalidate();
            }

            void InvalidateRow()
            {
                BackGround  = null;
                Overlay     = null;
            }

        }

        sealed class HeaderGridRow : GridRow
        {
            public HeaderGridRow(FGridView gridView) : base(gridView)
            {
            }
        }

        readonly static FontFamily      s_fallbackFont          = new FontFamily ("Calibri");

        HeaderGridRow                   m_headerRow             ;
        GridRows                        m_gridRows              ;
        Vector                          m_gridOffset            ;
        Typeface                        m_typeFace              ;
        Func<string, FormattedText>     m_formattedTextCreator  ;

        internal Typeface Typeface
        {
            get
            {
                if (m_typeFace == null)
                {
                    m_typeFace = new Typeface (FontFamily, FontStyle, FontWeight, FontStretch, s_fallbackFont);
                }
                return m_typeFace;
            }
        }

        internal Func<string, FormattedText> FormattedTextCreator
        {
            get
            {
                if (m_formattedTextCreator == null)
                {
                    var culture             = Culture ?? Thread.CurrentThread.CurrentCulture;
                    var flowDirection       = FlowDirection;
                    var typeface            = Typeface;
                    var fontSize            = FontSize;
                    var foreground          = Foreground ?? Brushes.Black;
                    var numberSubstitution  = NumberSubstitution;
                    var textFormattingMode  = TextFormattingMode;
                    m_formattedTextCreator  = str => new FormattedText(
                        str ?? "",
                        culture,
                        flowDirection,
                        typeface,
                        fontSize,
                        foreground,
                        numberSubstitution,
                        textFormattingMode
                        );
                }
                return m_formattedTextCreator;
            }
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            return availableSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            // TODO:
            return base.ArrangeOverride(finalSize);
        }


        void DisconnectObjects(IEnumerable<FGridView_Object> values)
        {
            if (values != null)
            {
                foreach (var v in values)
                {
                    if (v != null)
                    {
                        v.GridView = null;
                    }
                }
            }
        }

        void ConnectObjects(IEnumerable<FGridView_Object> values)
        {
            if (values != null)
            {
                foreach (var v in values)
                {
                    if (v != null)
                    {
                        v.GridView = this;
                    }
                }
            }
        }

        void ValidateObjects(IEnumerable<FGridView_Object> values)
        {
            if (values != null)
            {
                var connectedToOthers = values
                    .Where(TestConnectionToOtherGridView)
                    .ToArray()
                    ;
                if (connectedToOthers.Length > 0)
                {
                    throw Exception_ObjectsCanNotBeReusedBetweenGridViews();
                }
            }
        }

        static Exception Exception_ObjectsCanNotBeReusedBetweenGridViews()
        {
            return new InvalidOperationException(
                "FGridView_Objects can't be reused between several FGridViews. If you wish to move them you have to detach and attach the objects");
        }

        bool TestConnectionToOtherGridView(FGridView_Object v)
        {
            return v != null && v.GridView != null && !ReferenceEquals(v.GridView, this);
        }

        void UpdateObjects(IEnumerable<FGridView_Object> oldValue, IEnumerable<FGridView_Object> newValue)
        {
            var oldObjects = oldValue as FGridView_Object[] ?? oldValue.ToArray();
            var newObjects = newValue as FGridView_Object[] ?? newValue.ToArray();
            ValidateObjects(newObjects);
            DisconnectObjects(oldObjects);
            ConnectObjects(newObjects);
        }


        IEnumerable<FGridView_Object> GetObjects(IList newItems)
        {
            if (newItems == null)
            {
                return new FGridView_Object[0];
            }

            return newItems.OfType<FGridView_Object>();
        }

        void UpdateObjects(NotifyCollectionChangedAction action, int oldStartingIndex, IList oldItems, int newStartingIndex, IList newItems)
        {
            switch (action)
            {
                case NotifyCollectionChangedAction.Add:
                    ConnectObjects(GetObjects(newItems));
                    break;
                case NotifyCollectionChangedAction.Remove:
                    DisconnectObjects(GetObjects(oldItems));
                    break;
                case NotifyCollectionChangedAction.Replace:
                    DisconnectObjects(GetObjects(oldItems));
                    ConnectObjects(GetObjects(newItems));
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    DisconnectObjects(GetObjects(oldItems));
                    ConnectObjects(GetObjects(newItems));
                    break;
                default:
                    break;
            }
        }

        partial void Coerce_ColumnDefinitions(ObservableCollection<FGridView_Column> value, ref ObservableCollection<FGridView_Column> coercedValue)
        {
            coercedValue = coercedValue ?? new ObservableCollection<FGridView_Column>();
        }
        partial void Changed_ColumnDefinitions(ObservableCollection<FGridView_Column> oldValue, ObservableCollection<FGridView_Column> newValue)
        {
            UpdateObjects(oldValue, newValue);
        }
        partial void CollectionChanged_ColumnDefinitions(object sender, NotifyCollectionChangedAction action, int oldStartingIndex, IList oldItems, int newStartingIndex, IList newItems)
        {
            UpdateObjects(action, oldStartingIndex, oldItems, newStartingIndex, newItems);
        }

        partial void Coerce_FilterRules(ObservableCollection<FGridView_FilterRule> value, ref ObservableCollection<FGridView_FilterRule> coercedValue)
        {
            coercedValue = coercedValue ?? new ObservableCollection<FGridView_FilterRule>();
        }
        partial void Changed_FilterRules(ObservableCollection<FGridView_FilterRule> oldValue, ObservableCollection<FGridView_FilterRule> newValue)
        {
            UpdateObjects(oldValue, newValue);
        }
        partial void CollectionChanged_FilterRules(object sender, NotifyCollectionChangedAction action, int oldStartingIndex, IList oldItems, int newStartingIndex, IList newItems)
        {
            UpdateObjects(action, oldStartingIndex, oldItems, newStartingIndex, newItems);
        }

        partial void Coerce_SortRules(ObservableCollection<FGridView_SortRule> value, ref ObservableCollection<FGridView_SortRule> coercedValue)
        {
            coercedValue = coercedValue ?? new ObservableCollection<FGridView_SortRule>();
        }
        partial void Changed_SortRules(ObservableCollection<FGridView_SortRule> oldValue, ObservableCollection<FGridView_SortRule> newValue)
        {
            UpdateObjects(oldValue, newValue);
        }
        partial void CollectionChanged_SortRules(object sender, NotifyCollectionChangedAction action, int oldStartingIndex, IList oldItems, int newStartingIndex, IList newItems)
        {
            UpdateObjects(action, oldStartingIndex, oldItems, newStartingIndex, newItems);
        }

        partial void Coerce_RowDefinition(FGridView_Row value, ref FGridView_Row coercedValue)
        {
            coercedValue = coercedValue ?? new FGridView_Row_Default();
        }
        partial void Changed_RowDefinition(FGridView_Row oldValue, FGridView_Row newValue)
        {
            if (TestConnectionToOtherGridView(newValue))
            {
                throw Exception_ObjectsCanNotBeReusedBetweenGridViews();
            }

            if (oldValue != null)
            {
                oldValue.GridView = null;
            }

            if (newValue != null)
            {
                newValue.GridView = this;
            }
        }
        

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            var background = Background;
            var renderSize = RenderSize;
            var showHeaderRowTop = ShowHeaderRow_Top;
            var showHeaderRowBottom = ShowHeaderRow_Bottom;

            var contentSize = renderSize;

            var translateContent = new TranslateTransform();

            var rowHeight = RowDefinition.Height;

            if (m_headerRow != null)
            {
                if (showHeaderRowTop)
                {
                    contentSize.Height -= rowHeight;
                    translateContent.Y = rowHeight;
                }
                if (showHeaderRowBottom)
                {
                    contentSize.Height -= rowHeight;
                }
            }

            drawingContext.DrawRectangle(background, null, new Rect (renderSize));

            if (m_gridRows != null)
            {
                drawingContext.PushTransform(translateContent);
                m_gridRows.Render(drawingContext, m_gridOffset, renderSize);
                drawingContext.Pop();
            }

            if (m_headerRow != null)
            {
                if (showHeaderRowBottom)
                {
                    var translateBottomHeader =
                        new TranslateTransform
                            {
                                Y = renderSize.Height - rowHeight,
                            };
                    drawingContext.PushTransform(translateBottomHeader);

                    m_headerRow.Render(drawingContext);

                    drawingContext.Pop();
                }

                if (showHeaderRowTop)
                {
                    m_headerRow.Render(drawingContext);                    
                }
            }

        }

        internal FormattedText GetFormattedText(string val)
        {
            return FormattedTextCreator(val);
        }


        internal void Invalidate()
        {
            m_typeFace              = null;
            m_formattedTextCreator  = null;
            InvalidateVisual();
        }
    }
}
namespace FGrid.Internal
{
    static class FGridExtensions
    {
        public static string ToText(this object obj, string format, CultureInfo cultureInfo)
        {
            if (obj == null)
            {
                return "";
            }

            var stringValue = obj as string;

            if (stringValue != null)
            {
                return stringValue;
            }

            var formattable = obj as IFormattable;
            if (formattable != null)
            {
                return formattable.ToString(format ?? "", cultureInfo ?? Thread.CurrentThread.CurrentCulture);
            }

            return obj.ToString();
        }
        public static int MeasureQuick(this object obj)
        {
            if (obj == null)
            {
                return 0;
            }

            var stringValue = obj as string;
            if (stringValue != null)
            {
                return stringValue.Length;
            }
            else
            {
                return obj.ToString().Length;
            }


        }

        public static double AreaOf(this Size size)
        {
            return size.Height * size.Width;
        }

        public static Vector ToVector(this Size size)
        {
            return new Vector(size.Width, size.Height);
        }

        public static Vector ToVector(this Point point)
        {
            return new Vector(point.X, point.Y);
        }

        public static Rect ToRect(this Size size)
        {
            return new Rect(size);
        }

#if FGRID__DYNAMIC_IS_SUPPORTED
        static readonly ConcurrentDictionary<string,CallSite<Func<CallSite, object, object>>> s_getMember = new ConcurrentDictionary<string, CallSite<Func<CallSite, object, object>>>(); 
#endif
        public static object GetMemberValue(this object instance, string memberName, object defaultValue = null)
        {
            if (instance == null)
            {
                return defaultValue;
            }

            if (memberName.IsNullOrEmpty())
            {
                return defaultValue;
            }            

#if FGRID__DYNAMIC_IS_SUPPORTED
            CallSite<Func<CallSite, object, object>> callSite;

            // Avoiding GetOrAdd as it will be only be on first round we get cache misses
            // The next rounds we won't. GetOrAdd adds the overhead of creating 
            // closures. While cheap it's an unnecessary cost

            if (!s_getMember.TryGetValue(memberName, out callSite))
            {
                // This is what dynamic keyword uses under the hood
                // Let's leverage that
                callSite = CallSite<Func<CallSite, object, object>>.Create(
                    Binder.GetMember(
                        CSharpBinderFlags.None,
                        memberName,
                        typeof(FGridExtensions),
                        new[]
                        {
                            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
                        }));

                // Ignore the result, don't care if we get duplicates
                s_getMember.TryAdd(memberName, callSite);
            }

            var value = callSite.Target(callSite, instance);

            return value;

#else
            return NOT_IMPLEMENTED_YET;
#endif
        }
    }
}

