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

using System.Windows;
using System.Windows.Media;

namespace FGrid
{
    public enum FilterOperator
    {
        
    }

    public abstract partial class FGridView_FilterRule : DependencyObject
    {
        protected abstract bool TestAccordingToRule (object row);
    }

    public partial class FGridView_FilterRule_Simple : FGridView_FilterRule
    {

    }

    public abstract partial class FGridView_SortRule : DependencyObject
    {
        protected abstract int CompareAccordingToRole (object leftRow, object rightRow);
    }

    public partial class FGridView_SortRule_Simple : FGridView_FilterRule
    {

    }

    public abstract partial class FGridView_Row : DependencyObject
    {
        protected abstract bool AppliesTo           (object row);
        protected abstract void OnRenderBackground  (DrawingContext dc, Size size, object row);        
        protected abstract void OnRenderOverlay     (DrawingContext dc, Size size, object row, bool isSelected);        

        protected abstract Size?    MeasureQuick    (Size availableSize, object row);
        protected abstract Size?    MeasureExact    (Size availableSize, object row);
    }

    public partial class FGridView_Row_Default : FGridView_Row
    {

    }

    public abstract partial class FGridView_Column : DependencyObject
    {
        protected abstract void OnRenderBackground  (DrawingContext dc, Size size, object row);
        protected abstract void OnRenderOverlay     (DrawingContext dc, Size size, object row, bool hasFocus);
        protected abstract DependencyObject OnCreateEditControl (object row);

        protected abstract Size?    MeasureQuick    (Size availableSize, object row);
        protected abstract Size?    MeasureExact    (Size availableSize, object row);
    }

    public partial class FGridView_Column_Text : FGridView_Column
    {
    }

    public partial class FGridView : FrameworkElement
    {
    }
}
