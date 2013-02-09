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

// TODO: 
//  1. Measure:
//      Include previous measurement/availablesize/value to allow measurement to reuse previous measurement?

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace FGrid
{
    public enum FilterOperator
    {
        EqualTo         ,
        NotEqualTo      ,
    }

    public abstract partial class FGridView_Object : DependencyObject
    {
        internal FGridView GridView;
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

        protected abstract void OnRenderHeaderBackground    (DrawingContext dc, Size size, object row);        
        protected abstract void OnRenderHeaderOverlay       (DrawingContext dc, Size size, object row, bool isSelected);        

        protected abstract Size?    MeasureRowQuick         (Size availableSize, Size innerSize, object row);
        protected abstract Size?    MeasureRowExact         (Size availableSize, Size innerSize, object row);

        protected abstract Size?    MeasureHeaderQuick      (Size availableSize, Size innerSize, object row);
        protected abstract Size?    MeasureHeaderExact      (Size availableSize, Size innerSize, object row);
    }

    public partial class FGridView_Row_Default : FGridView_Row
    {

    }

    public abstract partial class FGridView_Column : FGridView_Object
    {
        protected abstract void OnRenderRowBackground       (DrawingContext dc, Size size, object row);
        protected abstract void OnRenderRowOverlay          (DrawingContext dc, Size size, object row, bool hasFocus);

        protected abstract void OnRenderHeaderBackground    (DrawingContext dc, Size size, object row);
        protected abstract void OnRenderHeaderOverlay       (DrawingContext dc, Size size, object row, bool hasFocus);

        protected abstract FGridView_Object OnCreateEditControl (object row);

        protected abstract Size?    MeasureRowQuick    (Size availableSize, object row);
        protected abstract Size?    MeasureRowExact    (Size availableSize, object row);

        protected abstract Size?    MeasureHeaderQuick  (Size availableSize);
        protected abstract Size?    MeasureHeaderExact  (Size availableSize);
    }

    public partial class FGridView_Column_Text : FGridView_Column
    {
    }

    public partial class FGridView : FrameworkElement
    {
        double m_offsetX;
        double m_offsetY;

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

        void UpdateObjects(IEnumerable<FGridView_Object> oldValue, IEnumerable<FGridView_Object> newValue)
        {
            DisconnectObjects(oldValue);
            ConnectObjects(newValue);
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

        sealed partial class Row
        {
            Drawing     m_background;
            Drawing[]   m_columns   ;
            Drawing     m_overlay   ;
            Drawing     m_combined  ;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            var background = Background;
            if (background != null)
            {
                drawingContext.DrawRectangle(background, null, new Rect (RenderSize));
            }
        }
    }
}

