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
// ----------------------------===>> G O A L S <<===----------------------------


// ----------------------------===>> T O D O S <<===----------------------------
//  1. Measure:
//      Include previous measurement/availablesize/value to allow measurement to reuse previous measurement?
// ----------------------------===>> T O D O S <<===----------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using FGrid.Internal;

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

    }

    public abstract partial class FGridView_SortRule : FGridView_Object
    {
        protected abstract int CompareAccordingToRole (object leftRow, object rightRow);
    }

    public partial class FGridView_SortRule_Simple : FGridView_FilterRule
    {

    }

    public abstract partial class FGridView_Row : FGridView_Object
    {
        const double Default_ContentHeight      = 24.0;
        const double Default_AdditionalHeight   = 0.0;
        const double Default_Height             = Default_ContentHeight + Default_AdditionalHeight;

        protected abstract void OnRenderRowBackground(DrawingContext dc, Size size, object row);        
        protected abstract void OnRenderRowOverlay          (DrawingContext dc, Size size, object row, bool isSelected);        

        protected abstract void OnRenderHeaderBackground    (DrawingContext dc, Size size);        
        protected abstract void OnRenderHeaderOverlay       (DrawingContext dc, Size size);        
    }

    public partial class FGridView_Row_Default : FGridView_Row
    {

    }

    public abstract partial class FGridView_Column : FGridView_Object
    {
        const double Default_ActualWidth            = 24.0;
        const double Default_MinWidth               = 24.0;
        const double Default_MaxWidth               = double.MaxValue;

        static readonly GridLength Default_Width    = GridLength.Auto;     

        protected abstract void OnRenderRowBackground       (DrawingContext dc, Size size, object row);
        protected abstract void OnRenderRowOverlay          (DrawingContext dc, Size size, object row, bool hasFocus);

        protected abstract void OnRenderHeaderBackground    (DrawingContext dc, Size size);
        protected abstract void OnRenderHeaderOverlay       (DrawingContext dc, Size size);

        protected abstract FGridView_Object OnCreateEditControl (object row);

        protected abstract double   MeasureRowQuick    (object row);
        protected abstract double   MeasureRowExact    (object row);

        protected abstract double   MeasureHeaderQuick  ();
        protected abstract double   MeasureHeaderExact  ();
    }

    public partial class FGridView_Column_Text : FGridView_Column
    {
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

                var visibleRows = (int)Math.Ceiling(localEnd.Y - localOffset.Y)/RowHeight);
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
            public Size     MeasuredSize; 

            Drawing         BackGround  ;
            Drawing         Overlay     ;

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
        }

        sealed class HeaderGridRow : GridRow
        {
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

        HeaderGridRow   m_headerRow   ;
        GridRows        m_gridRows     ;
        Vector          m_gridOffset    ;

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

            if (m_headerRow != null)
            {
                if (showHeaderRowTop)
                {
                    contentSize.Height -= m_headerRow.MeasuredSize.Height;
                    translateContent.Y = m_headerRow.MeasuredSize.Height;
                }
                if (showHeaderRowBottom)
                {
                    contentSize.Height -= m_headerRow.MeasuredSize.Height;
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
                                Y = renderSize.Height - m_headerRow.MeasuredSize.Height,
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

        public void Invalidate()
        {
            InvalidateVisual();
        }
    }
}

