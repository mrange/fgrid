﻿// ----------------------------------------------------------------------------------------------
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

// TODO: 
//  1. Measure:
//      Include previous measurement/availablesize/value to allow measurement to reuse previous measurement?

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
        protected abstract void OnRenderRowBackground       (DrawingContext dc, Size size, object row);        
        protected abstract void OnRenderRowOverlay          (DrawingContext dc, Size size, object row, bool isSelected);        

        protected abstract void OnRenderHeaderBackground    (DrawingContext dc, Size size);        
        protected abstract void OnRenderHeaderOverlay       (DrawingContext dc, Size size);        

        protected abstract Size     MeasureRowQuick         (Size contentSize, object row);
        protected abstract Size     MeasureRowExact         (Size contentSize, object row);

        protected abstract Size     MeasureHeaderQuick      (Size contentSize);
        protected abstract Size     MeasureHeaderExact      (Size contentSize);
    }

    public partial class FGridView_Row_Default : FGridView_Row
    {

    }

    public abstract partial class FGridView_Column : FGridView_Object
    {
        protected abstract void OnRenderRowBackground       (DrawingContext dc, Size size, object row);
        protected abstract void OnRenderRowOverlay          (DrawingContext dc, Size size, object row, bool hasFocus);

        protected abstract void OnRenderHeaderBackground    (DrawingContext dc, Size size);
        protected abstract void OnRenderHeaderOverlay       (DrawingContext dc, Size size);

        protected abstract FGridView_Object OnCreateEditControl (object row);

        protected abstract Size     MeasureRowQuick    (object row);
        protected abstract Size     MeasureRowExact    (object row);

        protected abstract Size     MeasureHeaderQuick  ();
        protected abstract Size     MeasureHeaderExact  ();
    }

    public partial class FGridView_Column_Text : FGridView_Column
    {
    }

    public partial class FGridView : FrameworkElement
    {
        sealed class GridRows
        {
            public ContentGridRow[] AvailableRows;

            public void Render (DrawingContext drawingContext, Vector offset, Size renderSize)
            {
                if (renderSize.AreaOf() <= 0)
                {
                    return;
                }

                var startingRow = FindFirstVisibleRow(offset);
                if (startingRow == null)
                {
                    return;
                }

                var end         = offset + renderSize.ToVector();
                var transform   = new TranslateTransform();

                for (
                        var currentRowIndex = startingRow.Value
                    ;       currentRowIndex < AvailableRows.Length
                    ;   ++currentRowIndex
                )
                {
                    var currentRow = AvailableRows[currentRowIndex];
                    if (currentRow == null)
                    {
                        continue;
                    }

                    if (currentRow.OffsetY > end.Y)
                    {
                        break;
                    }

                    transform.X = -offset.X;
                    transform.Y = -(offset.Y + currentRow.OffsetY);

                    drawingContext.PushTransform(transform);

                    currentRow.Render(drawingContext);

                    drawingContext.Pop();

                }
            }

            int? FindFirstVisibleRow(Vector offset)
            {
                // TODO: Replace with binary search?
                var availableRows = AvailableRows ?? new GridRow[0];
                for (int index = 0; index < availableRows.Length; index++)
                {
                    var row = availableRows[index];
                    if (row.OffsetY > offset.Y)
                    {
                        return Math.Max(index - 1, 0);
                    }
                }

                return null;
            }
        }


        abstract class GridRow
        {
            public double   OffsetY     ;
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
                    .Where(v => v != null && v.GridView != null && !ReferenceEquals(v.GridView, this))
                    .ToArray()
                    ;
                if (connectedToOthers.Length > 0)
                {
                    throw new InvalidOperationException("FGridView_Objects can't be reused between several FGridViews. If you wish to move them you have to detach and attach the objects");
                }
            }
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

        partial void Changed_ColumnDefinitions(ObservableCollection<FGridView_Column> oldValue, ObservableCollection<FGridView_Column> newValue)
        {
            UpdateObjects(oldValue, newValue);
        }
        partial void CollectionChanged_ColumnDefinitions(object sender, NotifyCollectionChangedAction action, int oldStartingIndex, IList oldItems, int newStartingIndex, IList newItems)
        {
            UpdateObjects(action, oldStartingIndex, oldItems, newStartingIndex, newItems);
        }

        partial void Changed_FilterRules(ObservableCollection<FGridView_FilterRule> oldValue, ObservableCollection<FGridView_FilterRule> newValue)
        {
            UpdateObjects(oldValue, newValue);
        }
        partial void CollectionChanged_FilterRules(object sender, NotifyCollectionChangedAction action, int oldStartingIndex, IList oldItems, int newStartingIndex, IList newItems)
        {
            UpdateObjects(action, oldStartingIndex, oldItems, newStartingIndex, newItems);
        }

        partial void Changed_SortRules(ObservableCollection<FGridView_SortRule> oldValue, ObservableCollection<FGridView_SortRule> newValue)
        {
            UpdateObjects(oldValue, newValue);
        }
        partial void CollectionChanged_SortRules(object sender, NotifyCollectionChangedAction action, int oldStartingIndex, IList oldItems, int newStartingIndex, IList newItems)
        {
            UpdateObjects(action, oldStartingIndex, oldItems, newStartingIndex, newItems);
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

