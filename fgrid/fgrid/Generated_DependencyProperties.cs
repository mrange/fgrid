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

using System.Collections.Generic;
using System.Globalization;


// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # template file (.tt)                                                      #
// ############################################################################





// ReSharper disable InconsistentNaming
// ReSharper disable InvocationIsSkipped
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantAssignment
// ReSharper disable RedundantUsingDirective

namespace FGrid
{
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;

    using System.Windows;
    using System.Windows.Media;

    // ------------------------------------------------------------------------
    // FGridView_FilterRule
    // ------------------------------------------------------------------------
    partial class FGridView_FilterRule
    {
        #region Uninteresting generated code
        public static readonly DependencyProperty ValuePathProperty = DependencyProperty.Register (
            "ValuePath",
            typeof (string),
            typeof (FGridView_FilterRule),
            new FrameworkPropertyMetadata (
                default (string),
                FrameworkPropertyMetadataOptions.None,
                Changed_ValuePath,
                Coerce_ValuePath          
            ));

        static void Changed_ValuePath (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView_FilterRule;
            if (instance != null)
            {
                var oldValue = (string)eventArgs.OldValue;
                var newValue = (string)eventArgs.NewValue;

                instance.Changed_ValuePath (oldValue, newValue);
            }
        }


        static object Coerce_ValuePath (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView_FilterRule;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (string)basevalue;
            var newValue = oldValue;

            instance.Coerce_ValuePath (oldValue, ref newValue);


            return newValue;
        }

        #endregion

        // --------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------
        public FGridView_FilterRule ()
        {
            CoerceAllProperties ();
            Constructed__FGridView_FilterRule ();
        }
        // --------------------------------------------------------------------
        partial void Constructed__FGridView_FilterRule ();
        // --------------------------------------------------------------------
        void CoerceAllProperties ()
        {
            CoerceValue (ValuePathProperty);
        }


        // --------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------

           
        // --------------------------------------------------------------------
        public string ValuePath
        {
            get
            {
                return (string)GetValue (ValuePathProperty);
            }
            set
            {
                if (ValuePath != value)
                {
                    SetValue (ValuePathProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_ValuePath (string value, ref string coercedValue);
        partial void Changed_ValuePath (string oldValue, string newValue);
        // --------------------------------------------------------------------


    }
    // ------------------------------------------------------------------------

    // ------------------------------------------------------------------------
    // FGridView_FilterRule_Simple
    // ------------------------------------------------------------------------
    partial class FGridView_FilterRule_Simple
    {
        #region Uninteresting generated code
        public static readonly DependencyProperty CultureProperty = DependencyProperty.Register (
            "Culture",
            typeof (CultureInfo),
            typeof (FGridView_FilterRule_Simple),
            new FrameworkPropertyMetadata (
                default (CultureInfo),
                FrameworkPropertyMetadataOptions.None,
                Changed_Culture,
                Coerce_Culture          
            ));

        static void Changed_Culture (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView_FilterRule_Simple;
            if (instance != null)
            {
                var oldValue = (CultureInfo)eventArgs.OldValue;
                var newValue = (CultureInfo)eventArgs.NewValue;

                instance.Changed_Culture (oldValue, newValue);
            }
        }


        static object Coerce_Culture (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView_FilterRule_Simple;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (CultureInfo)basevalue;
            var newValue = oldValue;

            instance.Coerce_Culture (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty OperatorProperty = DependencyProperty.Register (
            "Operator",
            typeof (FilterOperator),
            typeof (FGridView_FilterRule_Simple),
            new FrameworkPropertyMetadata (
                default (FilterOperator),
                FrameworkPropertyMetadataOptions.None,
                Changed_Operator,
                Coerce_Operator          
            ));

        static void Changed_Operator (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView_FilterRule_Simple;
            if (instance != null)
            {
                var oldValue = (FilterOperator)eventArgs.OldValue;
                var newValue = (FilterOperator)eventArgs.NewValue;

                instance.Changed_Operator (oldValue, newValue);
            }
        }


        static object Coerce_Operator (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView_FilterRule_Simple;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (FilterOperator)basevalue;
            var newValue = oldValue;

            instance.Coerce_Operator (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty CompareWithProperty = DependencyProperty.Register (
            "CompareWith",
            typeof (object),
            typeof (FGridView_FilterRule_Simple),
            new FrameworkPropertyMetadata (
                default (object),
                FrameworkPropertyMetadataOptions.None,
                Changed_CompareWith,
                Coerce_CompareWith          
            ));

        static void Changed_CompareWith (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView_FilterRule_Simple;
            if (instance != null)
            {
                var oldValue = (object)eventArgs.OldValue;
                var newValue = (object)eventArgs.NewValue;

                instance.Changed_CompareWith (oldValue, newValue);
            }
        }


        static object Coerce_CompareWith (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView_FilterRule_Simple;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (object)basevalue;
            var newValue = oldValue;

            instance.Coerce_CompareWith (oldValue, ref newValue);


            return newValue;
        }

        #endregion

        // --------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------
        public FGridView_FilterRule_Simple ()
        {
            CoerceAllProperties ();
            Constructed__FGridView_FilterRule_Simple ();
        }
        // --------------------------------------------------------------------
        partial void Constructed__FGridView_FilterRule_Simple ();
        // --------------------------------------------------------------------
        void CoerceAllProperties ()
        {
            CoerceValue (CultureProperty);
            CoerceValue (OperatorProperty);
            CoerceValue (CompareWithProperty);
        }


        // --------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------

           
        // --------------------------------------------------------------------
        public CultureInfo Culture
        {
            get
            {
                return (CultureInfo)GetValue (CultureProperty);
            }
            set
            {
                if (Culture != value)
                {
                    SetValue (CultureProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_Culture (CultureInfo value, ref CultureInfo coercedValue);
        partial void Changed_Culture (CultureInfo oldValue, CultureInfo newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public FilterOperator Operator
        {
            get
            {
                return (FilterOperator)GetValue (OperatorProperty);
            }
            set
            {
                if (Operator != value)
                {
                    SetValue (OperatorProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_Operator (FilterOperator value, ref FilterOperator coercedValue);
        partial void Changed_Operator (FilterOperator oldValue, FilterOperator newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public object CompareWith
        {
            get
            {
                return (object)GetValue (CompareWithProperty);
            }
            set
            {
                if (CompareWith != value)
                {
                    SetValue (CompareWithProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_CompareWith (object value, ref object coercedValue);
        partial void Changed_CompareWith (object oldValue, object newValue);
        // --------------------------------------------------------------------


    }
    // ------------------------------------------------------------------------

    // ------------------------------------------------------------------------
    // FGridView_SortRule
    // ------------------------------------------------------------------------
    partial class FGridView_SortRule
    {
        #region Uninteresting generated code
        public static readonly DependencyProperty ValuePathProperty = DependencyProperty.Register (
            "ValuePath",
            typeof (string),
            typeof (FGridView_SortRule),
            new FrameworkPropertyMetadata (
                default (string),
                FrameworkPropertyMetadataOptions.None,
                Changed_ValuePath,
                Coerce_ValuePath          
            ));

        static void Changed_ValuePath (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView_SortRule;
            if (instance != null)
            {
                var oldValue = (string)eventArgs.OldValue;
                var newValue = (string)eventArgs.NewValue;

                instance.Changed_ValuePath (oldValue, newValue);
            }
        }


        static object Coerce_ValuePath (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView_SortRule;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (string)basevalue;
            var newValue = oldValue;

            instance.Coerce_ValuePath (oldValue, ref newValue);


            return newValue;
        }

        #endregion

        // --------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------
        public FGridView_SortRule ()
        {
            CoerceAllProperties ();
            Constructed__FGridView_SortRule ();
        }
        // --------------------------------------------------------------------
        partial void Constructed__FGridView_SortRule ();
        // --------------------------------------------------------------------
        void CoerceAllProperties ()
        {
            CoerceValue (ValuePathProperty);
        }


        // --------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------

           
        // --------------------------------------------------------------------
        public string ValuePath
        {
            get
            {
                return (string)GetValue (ValuePathProperty);
            }
            set
            {
                if (ValuePath != value)
                {
                    SetValue (ValuePathProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_ValuePath (string value, ref string coercedValue);
        partial void Changed_ValuePath (string oldValue, string newValue);
        // --------------------------------------------------------------------


    }
    // ------------------------------------------------------------------------

    // ------------------------------------------------------------------------
    // FGridView_SortRule_Simple
    // ------------------------------------------------------------------------
    partial class FGridView_SortRule_Simple
    {
        #region Uninteresting generated code
        public static readonly DependencyProperty CultureProperty = DependencyProperty.Register (
            "Culture",
            typeof (CultureInfo),
            typeof (FGridView_SortRule_Simple),
            new FrameworkPropertyMetadata (
                default (CultureInfo),
                FrameworkPropertyMetadataOptions.None,
                Changed_Culture,
                Coerce_Culture          
            ));

        static void Changed_Culture (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView_SortRule_Simple;
            if (instance != null)
            {
                var oldValue = (CultureInfo)eventArgs.OldValue;
                var newValue = (CultureInfo)eventArgs.NewValue;

                instance.Changed_Culture (oldValue, newValue);
            }
        }


        static object Coerce_Culture (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView_SortRule_Simple;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (CultureInfo)basevalue;
            var newValue = oldValue;

            instance.Coerce_Culture (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty SortDescendingProperty = DependencyProperty.Register (
            "SortDescending",
            typeof (bool),
            typeof (FGridView_SortRule_Simple),
            new FrameworkPropertyMetadata (
                default (bool),
                FrameworkPropertyMetadataOptions.None,
                Changed_SortDescending,
                Coerce_SortDescending          
            ));

        static void Changed_SortDescending (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView_SortRule_Simple;
            if (instance != null)
            {
                var oldValue = (bool)eventArgs.OldValue;
                var newValue = (bool)eventArgs.NewValue;

                instance.Changed_SortDescending (oldValue, newValue);
            }
        }


        static object Coerce_SortDescending (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView_SortRule_Simple;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (bool)basevalue;
            var newValue = oldValue;

            instance.Coerce_SortDescending (oldValue, ref newValue);


            return newValue;
        }

        #endregion

        // --------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------
        public FGridView_SortRule_Simple ()
        {
            CoerceAllProperties ();
            Constructed__FGridView_SortRule_Simple ();
        }
        // --------------------------------------------------------------------
        partial void Constructed__FGridView_SortRule_Simple ();
        // --------------------------------------------------------------------
        void CoerceAllProperties ()
        {
            CoerceValue (CultureProperty);
            CoerceValue (SortDescendingProperty);
        }


        // --------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------

           
        // --------------------------------------------------------------------
        public CultureInfo Culture
        {
            get
            {
                return (CultureInfo)GetValue (CultureProperty);
            }
            set
            {
                if (Culture != value)
                {
                    SetValue (CultureProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_Culture (CultureInfo value, ref CultureInfo coercedValue);
        partial void Changed_Culture (CultureInfo oldValue, CultureInfo newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public bool SortDescending
        {
            get
            {
                return (bool)GetValue (SortDescendingProperty);
            }
            set
            {
                if (SortDescending != value)
                {
                    SetValue (SortDescendingProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_SortDescending (bool value, ref bool coercedValue);
        partial void Changed_SortDescending (bool oldValue, bool newValue);
        // --------------------------------------------------------------------


    }
    // ------------------------------------------------------------------------

    // ------------------------------------------------------------------------
    // FGridView_Row
    // ------------------------------------------------------------------------
    partial class FGridView_Row
    {
        #region Uninteresting generated code
        public static readonly DependencyProperty NonMeasuredHeightProperty = DependencyProperty.Register (
            "NonMeasuredHeight",
            typeof (double),
            typeof (FGridView_Row),
            new FrameworkPropertyMetadata (
                default (double),
                FrameworkPropertyMetadataOptions.None,
                Changed_NonMeasuredHeight,
                Coerce_NonMeasuredHeight          
            ));

        static void Changed_NonMeasuredHeight (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView_Row;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_NonMeasuredHeight (oldValue, newValue);
            }
        }


        static object Coerce_NonMeasuredHeight (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView_Row;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (double)basevalue;
            var newValue = oldValue;

            instance.Coerce_NonMeasuredHeight (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty MinHeightProperty = DependencyProperty.Register (
            "MinHeight",
            typeof (double),
            typeof (FGridView_Row),
            new FrameworkPropertyMetadata (
                default (double),
                FrameworkPropertyMetadataOptions.None,
                Changed_MinHeight,
                Coerce_MinHeight          
            ));

        static void Changed_MinHeight (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView_Row;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_MinHeight (oldValue, newValue);
            }
        }


        static object Coerce_MinHeight (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView_Row;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (double)basevalue;
            var newValue = oldValue;

            instance.Coerce_MinHeight (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty MaxHeightProperty = DependencyProperty.Register (
            "MaxHeight",
            typeof (double),
            typeof (FGridView_Row),
            new FrameworkPropertyMetadata (
                default (double),
                FrameworkPropertyMetadataOptions.None,
                Changed_MaxHeight,
                Coerce_MaxHeight          
            ));

        static void Changed_MaxHeight (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView_Row;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_MaxHeight (oldValue, newValue);
            }
        }


        static object Coerce_MaxHeight (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView_Row;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (double)basevalue;
            var newValue = oldValue;

            instance.Coerce_MaxHeight (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty HeightProperty = DependencyProperty.Register (
            "Height",
            typeof (GridLength),
            typeof (FGridView_Row),
            new FrameworkPropertyMetadata (
                default (GridLength),
                FrameworkPropertyMetadataOptions.None,
                Changed_Height,
                Coerce_Height          
            ));

        static void Changed_Height (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView_Row;
            if (instance != null)
            {
                var oldValue = (GridLength)eventArgs.OldValue;
                var newValue = (GridLength)eventArgs.NewValue;

                instance.Changed_Height (oldValue, newValue);
            }
        }


        static object Coerce_Height (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView_Row;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (GridLength)basevalue;
            var newValue = oldValue;

            instance.Coerce_Height (oldValue, ref newValue);


            return newValue;
        }

        #endregion

        // --------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------
        public FGridView_Row ()
        {
            CoerceAllProperties ();
            Constructed__FGridView_Row ();
        }
        // --------------------------------------------------------------------
        partial void Constructed__FGridView_Row ();
        // --------------------------------------------------------------------
        void CoerceAllProperties ()
        {
            CoerceValue (NonMeasuredHeightProperty);
            CoerceValue (MinHeightProperty);
            CoerceValue (MaxHeightProperty);
            CoerceValue (HeightProperty);
        }


        // --------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------

           
        // --------------------------------------------------------------------
        public double NonMeasuredHeight
        {
            get
            {
                return (double)GetValue (NonMeasuredHeightProperty);
            }
            set
            {
                if (NonMeasuredHeight != value)
                {
                    SetValue (NonMeasuredHeightProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_NonMeasuredHeight (double value, ref double coercedValue);
        partial void Changed_NonMeasuredHeight (double oldValue, double newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public double MinHeight
        {
            get
            {
                return (double)GetValue (MinHeightProperty);
            }
            set
            {
                if (MinHeight != value)
                {
                    SetValue (MinHeightProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_MinHeight (double value, ref double coercedValue);
        partial void Changed_MinHeight (double oldValue, double newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public double MaxHeight
        {
            get
            {
                return (double)GetValue (MaxHeightProperty);
            }
            set
            {
                if (MaxHeight != value)
                {
                    SetValue (MaxHeightProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_MaxHeight (double value, ref double coercedValue);
        partial void Changed_MaxHeight (double oldValue, double newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public GridLength Height
        {
            get
            {
                return (GridLength)GetValue (HeightProperty);
            }
            set
            {
                if (Height != value)
                {
                    SetValue (HeightProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_Height (GridLength value, ref GridLength coercedValue);
        partial void Changed_Height (GridLength oldValue, GridLength newValue);
        // --------------------------------------------------------------------


    }
    // ------------------------------------------------------------------------

    // ------------------------------------------------------------------------
    // FGridView_Row_Default
    // ------------------------------------------------------------------------
    partial class FGridView_Row_Default
    {
        #region Uninteresting generated code
        #endregion

        // --------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------
        public FGridView_Row_Default ()
        {
            CoerceAllProperties ();
            Constructed__FGridView_Row_Default ();
        }
        // --------------------------------------------------------------------
        partial void Constructed__FGridView_Row_Default ();
        // --------------------------------------------------------------------
        void CoerceAllProperties ()
        {
        }


        // --------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------

    }
    // ------------------------------------------------------------------------

    // ------------------------------------------------------------------------
    // FGridView_Column
    // ------------------------------------------------------------------------
    partial class FGridView_Column
    {
        #region Uninteresting generated code
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register (
            "Header",
            typeof (string),
            typeof (FGridView_Column),
            new FrameworkPropertyMetadata (
                default (string),
                FrameworkPropertyMetadataOptions.None,
                Changed_Header,
                Coerce_Header          
            ));

        static void Changed_Header (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView_Column;
            if (instance != null)
            {
                var oldValue = (string)eventArgs.OldValue;
                var newValue = (string)eventArgs.NewValue;

                instance.Changed_Header (oldValue, newValue);
            }
        }


        static object Coerce_Header (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView_Column;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (string)basevalue;
            var newValue = oldValue;

            instance.Coerce_Header (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty ToolTipPathProperty = DependencyProperty.Register (
            "ToolTipPath",
            typeof (string),
            typeof (FGridView_Column),
            new FrameworkPropertyMetadata (
                default (string),
                FrameworkPropertyMetadataOptions.None,
                Changed_ToolTipPath,
                Coerce_ToolTipPath          
            ));

        static void Changed_ToolTipPath (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView_Column;
            if (instance != null)
            {
                var oldValue = (string)eventArgs.OldValue;
                var newValue = (string)eventArgs.NewValue;

                instance.Changed_ToolTipPath (oldValue, newValue);
            }
        }


        static object Coerce_ToolTipPath (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView_Column;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (string)basevalue;
            var newValue = oldValue;

            instance.Coerce_ToolTipPath (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty ActualWidthProperty = DependencyProperty.Register (
            "ActualWidth",
            typeof (double),
            typeof (FGridView_Column),
            new FrameworkPropertyMetadata (
                default (double),
                FrameworkPropertyMetadataOptions.None,
                Changed_ActualWidth,
                Coerce_ActualWidth          
            ));

        static void Changed_ActualWidth (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView_Column;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_ActualWidth (oldValue, newValue);
            }
        }


        static object Coerce_ActualWidth (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView_Column;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (double)basevalue;
            var newValue = oldValue;

            instance.Coerce_ActualWidth (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty MinWidthProperty = DependencyProperty.Register (
            "MinWidth",
            typeof (double),
            typeof (FGridView_Column),
            new FrameworkPropertyMetadata (
                default (double),
                FrameworkPropertyMetadataOptions.None,
                Changed_MinWidth,
                Coerce_MinWidth          
            ));

        static void Changed_MinWidth (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView_Column;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_MinWidth (oldValue, newValue);
            }
        }


        static object Coerce_MinWidth (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView_Column;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (double)basevalue;
            var newValue = oldValue;

            instance.Coerce_MinWidth (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty MaxWidthProperty = DependencyProperty.Register (
            "MaxWidth",
            typeof (double),
            typeof (FGridView_Column),
            new FrameworkPropertyMetadata (
                default (double),
                FrameworkPropertyMetadataOptions.None,
                Changed_MaxWidth,
                Coerce_MaxWidth          
            ));

        static void Changed_MaxWidth (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView_Column;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_MaxWidth (oldValue, newValue);
            }
        }


        static object Coerce_MaxWidth (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView_Column;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (double)basevalue;
            var newValue = oldValue;

            instance.Coerce_MaxWidth (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty WidthProperty = DependencyProperty.Register (
            "Width",
            typeof (GridLength),
            typeof (FGridView_Column),
            new FrameworkPropertyMetadata (
                default (GridLength),
                FrameworkPropertyMetadataOptions.None,
                Changed_Width,
                Coerce_Width          
            ));

        static void Changed_Width (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView_Column;
            if (instance != null)
            {
                var oldValue = (GridLength)eventArgs.OldValue;
                var newValue = (GridLength)eventArgs.NewValue;

                instance.Changed_Width (oldValue, newValue);
            }
        }


        static object Coerce_Width (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView_Column;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (GridLength)basevalue;
            var newValue = oldValue;

            instance.Coerce_Width (oldValue, ref newValue);


            return newValue;
        }

        #endregion

        // --------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------
        public FGridView_Column ()
        {
            CoerceAllProperties ();
            Constructed__FGridView_Column ();
        }
        // --------------------------------------------------------------------
        partial void Constructed__FGridView_Column ();
        // --------------------------------------------------------------------
        void CoerceAllProperties ()
        {
            CoerceValue (HeaderProperty);
            CoerceValue (ToolTipPathProperty);
            CoerceValue (ActualWidthProperty);
            CoerceValue (MinWidthProperty);
            CoerceValue (MaxWidthProperty);
            CoerceValue (WidthProperty);
        }


        // --------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------

           
        // --------------------------------------------------------------------
        public string Header
        {
            get
            {
                return (string)GetValue (HeaderProperty);
            }
            set
            {
                if (Header != value)
                {
                    SetValue (HeaderProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_Header (string value, ref string coercedValue);
        partial void Changed_Header (string oldValue, string newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public string ToolTipPath
        {
            get
            {
                return (string)GetValue (ToolTipPathProperty);
            }
            set
            {
                if (ToolTipPath != value)
                {
                    SetValue (ToolTipPathProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_ToolTipPath (string value, ref string coercedValue);
        partial void Changed_ToolTipPath (string oldValue, string newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public double ActualWidth
        {
            get
            {
                return (double)GetValue (ActualWidthProperty);
            }
            set
            {
                if (ActualWidth != value)
                {
                    SetValue (ActualWidthProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_ActualWidth (double value, ref double coercedValue);
        partial void Changed_ActualWidth (double oldValue, double newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public double MinWidth
        {
            get
            {
                return (double)GetValue (MinWidthProperty);
            }
            set
            {
                if (MinWidth != value)
                {
                    SetValue (MinWidthProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_MinWidth (double value, ref double coercedValue);
        partial void Changed_MinWidth (double oldValue, double newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public double MaxWidth
        {
            get
            {
                return (double)GetValue (MaxWidthProperty);
            }
            set
            {
                if (MaxWidth != value)
                {
                    SetValue (MaxWidthProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_MaxWidth (double value, ref double coercedValue);
        partial void Changed_MaxWidth (double oldValue, double newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public GridLength Width
        {
            get
            {
                return (GridLength)GetValue (WidthProperty);
            }
            set
            {
                if (Width != value)
                {
                    SetValue (WidthProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_Width (GridLength value, ref GridLength coercedValue);
        partial void Changed_Width (GridLength oldValue, GridLength newValue);
        // --------------------------------------------------------------------


    }
    // ------------------------------------------------------------------------

    // ------------------------------------------------------------------------
    // FGridView_Column_Text
    // ------------------------------------------------------------------------
    partial class FGridView_Column_Text
    {
        #region Uninteresting generated code
        public static readonly DependencyProperty ValuePathProperty = DependencyProperty.Register (
            "ValuePath",
            typeof (string),
            typeof (FGridView_Column_Text),
            new FrameworkPropertyMetadata (
                default (string),
                FrameworkPropertyMetadataOptions.None,
                Changed_ValuePath,
                Coerce_ValuePath          
            ));

        static void Changed_ValuePath (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView_Column_Text;
            if (instance != null)
            {
                var oldValue = (string)eventArgs.OldValue;
                var newValue = (string)eventArgs.NewValue;

                instance.Changed_ValuePath (oldValue, newValue);
            }
        }


        static object Coerce_ValuePath (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView_Column_Text;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (string)basevalue;
            var newValue = oldValue;

            instance.Coerce_ValuePath (oldValue, ref newValue);


            return newValue;
        }

        #endregion

        // --------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------
        public FGridView_Column_Text ()
        {
            CoerceAllProperties ();
            Constructed__FGridView_Column_Text ();
        }
        // --------------------------------------------------------------------
        partial void Constructed__FGridView_Column_Text ();
        // --------------------------------------------------------------------
        void CoerceAllProperties ()
        {
            CoerceValue (ValuePathProperty);
        }


        // --------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------

           
        // --------------------------------------------------------------------
        public string ValuePath
        {
            get
            {
                return (string)GetValue (ValuePathProperty);
            }
            set
            {
                if (ValuePath != value)
                {
                    SetValue (ValuePathProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_ValuePath (string value, ref string coercedValue);
        partial void Changed_ValuePath (string oldValue, string newValue);
        // --------------------------------------------------------------------


    }
    // ------------------------------------------------------------------------

    // ------------------------------------------------------------------------
    // FGridView
    // ------------------------------------------------------------------------
    partial class FGridView
    {
        #region Uninteresting generated code
        public static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register (
            "Background",
            typeof (Brush),
            typeof (FGridView),
            new FrameworkPropertyMetadata (
                default (Brush),
                FrameworkPropertyMetadataOptions.None,
                Changed_Background,
                Coerce_Background          
            ));

        static void Changed_Background (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView;
            if (instance != null)
            {
                var oldValue = (Brush)eventArgs.OldValue;
                var newValue = (Brush)eventArgs.NewValue;

                instance.Changed_Background (oldValue, newValue);
            }
        }


        static object Coerce_Background (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (Brush)basevalue;
            var newValue = oldValue;

            instance.Coerce_Background (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register (
            "Foreground",
            typeof (Brush),
            typeof (FGridView),
            new FrameworkPropertyMetadata (
                default (Brush),
                FrameworkPropertyMetadataOptions.None,
                Changed_Foreground,
                Coerce_Foreground          
            ));

        static void Changed_Foreground (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView;
            if (instance != null)
            {
                var oldValue = (Brush)eventArgs.OldValue;
                var newValue = (Brush)eventArgs.NewValue;

                instance.Changed_Foreground (oldValue, newValue);
            }
        }


        static object Coerce_Foreground (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (Brush)basevalue;
            var newValue = oldValue;

            instance.Coerce_Foreground (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty ShowHeaderRow_TopProperty = DependencyProperty.Register (
            "ShowHeaderRow_Top",
            typeof (bool),
            typeof (FGridView),
            new FrameworkPropertyMetadata (
                default (bool),
                FrameworkPropertyMetadataOptions.None,
                Changed_ShowHeaderRow_Top,
                Coerce_ShowHeaderRow_Top          
            ));

        static void Changed_ShowHeaderRow_Top (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView;
            if (instance != null)
            {
                var oldValue = (bool)eventArgs.OldValue;
                var newValue = (bool)eventArgs.NewValue;

                instance.Changed_ShowHeaderRow_Top (oldValue, newValue);
            }
        }


        static object Coerce_ShowHeaderRow_Top (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (bool)basevalue;
            var newValue = oldValue;

            instance.Coerce_ShowHeaderRow_Top (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty ShowHeaderRow_BottomProperty = DependencyProperty.Register (
            "ShowHeaderRow_Bottom",
            typeof (bool),
            typeof (FGridView),
            new FrameworkPropertyMetadata (
                default (bool),
                FrameworkPropertyMetadataOptions.None,
                Changed_ShowHeaderRow_Bottom,
                Coerce_ShowHeaderRow_Bottom          
            ));

        static void Changed_ShowHeaderRow_Bottom (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView;
            if (instance != null)
            {
                var oldValue = (bool)eventArgs.OldValue;
                var newValue = (bool)eventArgs.NewValue;

                instance.Changed_ShowHeaderRow_Bottom (oldValue, newValue);
            }
        }


        static object Coerce_ShowHeaderRow_Bottom (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (bool)basevalue;
            var newValue = oldValue;

            instance.Coerce_ShowHeaderRow_Bottom (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty ShowSearchRow_TopProperty = DependencyProperty.Register (
            "ShowSearchRow_Top",
            typeof (bool),
            typeof (FGridView),
            new FrameworkPropertyMetadata (
                default (bool),
                FrameworkPropertyMetadataOptions.None,
                Changed_ShowSearchRow_Top,
                Coerce_ShowSearchRow_Top          
            ));

        static void Changed_ShowSearchRow_Top (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView;
            if (instance != null)
            {
                var oldValue = (bool)eventArgs.OldValue;
                var newValue = (bool)eventArgs.NewValue;

                instance.Changed_ShowSearchRow_Top (oldValue, newValue);
            }
        }


        static object Coerce_ShowSearchRow_Top (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (bool)basevalue;
            var newValue = oldValue;

            instance.Coerce_ShowSearchRow_Top (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty ShowSearchRow_BottomProperty = DependencyProperty.Register (
            "ShowSearchRow_Bottom",
            typeof (bool),
            typeof (FGridView),
            new FrameworkPropertyMetadata (
                default (bool),
                FrameworkPropertyMetadataOptions.None,
                Changed_ShowSearchRow_Bottom,
                Coerce_ShowSearchRow_Bottom          
            ));

        static void Changed_ShowSearchRow_Bottom (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView;
            if (instance != null)
            {
                var oldValue = (bool)eventArgs.OldValue;
                var newValue = (bool)eventArgs.NewValue;

                instance.Changed_ShowSearchRow_Bottom (oldValue, newValue);
            }
        }


        static object Coerce_ShowSearchRow_Bottom (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (bool)basevalue;
            var newValue = oldValue;

            instance.Coerce_ShowSearchRow_Bottom (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty RowsProperty = DependencyProperty.Register (
            "Rows",
            typeof (IEnumerable<object>),
            typeof (FGridView),
            new FrameworkPropertyMetadata (
                default (IEnumerable<object>),
                FrameworkPropertyMetadataOptions.None,
                Changed_Rows,
                Coerce_Rows          
            ));

        static void Changed_Rows (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView;
            if (instance != null)
            {
                var oldValue = (IEnumerable<object>)eventArgs.OldValue;
                var newValue = (IEnumerable<object>)eventArgs.NewValue;

                instance.Changed_Rows (oldValue, newValue);
            }
        }


        static object Coerce_Rows (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (IEnumerable<object>)basevalue;
            var newValue = oldValue;

            instance.Coerce_Rows (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty ColumnDefinitionsProperty = DependencyProperty.Register (
            "ColumnDefinitions",
            typeof (ObservableCollection<FGridView_Column>),
            typeof (FGridView),
            new FrameworkPropertyMetadata (
                null,
                FrameworkPropertyMetadataOptions.None,
                Changed_ColumnDefinitions,
                Coerce_ColumnDefinitions          
            ));

        static void Changed_ColumnDefinitions (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView;
            if (instance != null)
            {
                var oldValue = (ObservableCollection<FGridView_Column>)eventArgs.OldValue;
                var newValue = (ObservableCollection<FGridView_Column>)eventArgs.NewValue;

                if (oldValue != null)
                {
                    oldValue.CollectionChanged -= instance.CollectionChanged_ColumnDefinitions;
                }

                if (newValue != null)
                {
                    newValue.CollectionChanged += instance.CollectionChanged_ColumnDefinitions;
                }

                instance.Changed_ColumnDefinitions (oldValue, newValue);
            }
        }

        void CollectionChanged_ColumnDefinitions(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged_ColumnDefinitions (
                sender, 
                e.Action,
                e.OldStartingIndex,
                e.OldItems,
                e.NewStartingIndex,
                e.NewItems
                );
        }

        static object Coerce_ColumnDefinitions (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (ObservableCollection<FGridView_Column>)basevalue;
            var newValue = oldValue;

            instance.Coerce_ColumnDefinitions (oldValue, ref newValue);

            if (newValue == null)
            {
               newValue = new ObservableCollection<FGridView_Column> ();
            }

            return newValue;
        }

        public static readonly DependencyProperty RowDefinitionProperty = DependencyProperty.Register (
            "RowDefinition",
            typeof (FGridView_Row),
            typeof (FGridView),
            new FrameworkPropertyMetadata (
                default (FGridView_Row),
                FrameworkPropertyMetadataOptions.None,
                Changed_RowDefinition,
                Coerce_RowDefinition          
            ));

        static void Changed_RowDefinition (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView;
            if (instance != null)
            {
                var oldValue = (FGridView_Row)eventArgs.OldValue;
                var newValue = (FGridView_Row)eventArgs.NewValue;

                instance.Changed_RowDefinition (oldValue, newValue);
            }
        }


        static object Coerce_RowDefinition (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (FGridView_Row)basevalue;
            var newValue = oldValue;

            instance.Coerce_RowDefinition (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty FilterRulesProperty = DependencyProperty.Register (
            "FilterRules",
            typeof (ObservableCollection<FGridView_FilterRule>),
            typeof (FGridView),
            new FrameworkPropertyMetadata (
                null,
                FrameworkPropertyMetadataOptions.None,
                Changed_FilterRules,
                Coerce_FilterRules          
            ));

        static void Changed_FilterRules (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView;
            if (instance != null)
            {
                var oldValue = (ObservableCollection<FGridView_FilterRule>)eventArgs.OldValue;
                var newValue = (ObservableCollection<FGridView_FilterRule>)eventArgs.NewValue;

                if (oldValue != null)
                {
                    oldValue.CollectionChanged -= instance.CollectionChanged_FilterRules;
                }

                if (newValue != null)
                {
                    newValue.CollectionChanged += instance.CollectionChanged_FilterRules;
                }

                instance.Changed_FilterRules (oldValue, newValue);
            }
        }

        void CollectionChanged_FilterRules(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged_FilterRules (
                sender, 
                e.Action,
                e.OldStartingIndex,
                e.OldItems,
                e.NewStartingIndex,
                e.NewItems
                );
        }

        static object Coerce_FilterRules (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (ObservableCollection<FGridView_FilterRule>)basevalue;
            var newValue = oldValue;

            instance.Coerce_FilterRules (oldValue, ref newValue);

            if (newValue == null)
            {
               newValue = new ObservableCollection<FGridView_FilterRule> ();
            }

            return newValue;
        }

        public static readonly DependencyProperty SortRulesProperty = DependencyProperty.Register (
            "SortRules",
            typeof (ObservableCollection<FGridView_SortRule>),
            typeof (FGridView),
            new FrameworkPropertyMetadata (
                null,
                FrameworkPropertyMetadataOptions.None,
                Changed_SortRules,
                Coerce_SortRules          
            ));

        static void Changed_SortRules (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as FGridView;
            if (instance != null)
            {
                var oldValue = (ObservableCollection<FGridView_SortRule>)eventArgs.OldValue;
                var newValue = (ObservableCollection<FGridView_SortRule>)eventArgs.NewValue;

                if (oldValue != null)
                {
                    oldValue.CollectionChanged -= instance.CollectionChanged_SortRules;
                }

                if (newValue != null)
                {
                    newValue.CollectionChanged += instance.CollectionChanged_SortRules;
                }

                instance.Changed_SortRules (oldValue, newValue);
            }
        }

        void CollectionChanged_SortRules(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged_SortRules (
                sender, 
                e.Action,
                e.OldStartingIndex,
                e.OldItems,
                e.NewStartingIndex,
                e.NewItems
                );
        }

        static object Coerce_SortRules (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as FGridView;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (ObservableCollection<FGridView_SortRule>)basevalue;
            var newValue = oldValue;

            instance.Coerce_SortRules (oldValue, ref newValue);

            if (newValue == null)
            {
               newValue = new ObservableCollection<FGridView_SortRule> ();
            }

            return newValue;
        }

        #endregion

        // --------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------
        public FGridView ()
        {
            CoerceAllProperties ();
            Constructed__FGridView ();
        }
        // --------------------------------------------------------------------
        partial void Constructed__FGridView ();
        // --------------------------------------------------------------------
        void CoerceAllProperties ()
        {
            CoerceValue (BackgroundProperty);
            CoerceValue (ForegroundProperty);
            CoerceValue (ShowHeaderRow_TopProperty);
            CoerceValue (ShowHeaderRow_BottomProperty);
            CoerceValue (ShowSearchRow_TopProperty);
            CoerceValue (ShowSearchRow_BottomProperty);
            CoerceValue (RowsProperty);
            CoerceValue (ColumnDefinitionsProperty);
            CoerceValue (RowDefinitionProperty);
            CoerceValue (FilterRulesProperty);
            CoerceValue (SortRulesProperty);
        }


        // --------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------

           
        // --------------------------------------------------------------------
        public Brush Background
        {
            get
            {
                return (Brush)GetValue (BackgroundProperty);
            }
            set
            {
                if (Background != value)
                {
                    SetValue (BackgroundProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_Background (Brush value, ref Brush coercedValue);
        partial void Changed_Background (Brush oldValue, Brush newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public Brush Foreground
        {
            get
            {
                return (Brush)GetValue (ForegroundProperty);
            }
            set
            {
                if (Foreground != value)
                {
                    SetValue (ForegroundProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_Foreground (Brush value, ref Brush coercedValue);
        partial void Changed_Foreground (Brush oldValue, Brush newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public bool ShowHeaderRow_Top
        {
            get
            {
                return (bool)GetValue (ShowHeaderRow_TopProperty);
            }
            set
            {
                if (ShowHeaderRow_Top != value)
                {
                    SetValue (ShowHeaderRow_TopProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_ShowHeaderRow_Top (bool value, ref bool coercedValue);
        partial void Changed_ShowHeaderRow_Top (bool oldValue, bool newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public bool ShowHeaderRow_Bottom
        {
            get
            {
                return (bool)GetValue (ShowHeaderRow_BottomProperty);
            }
            set
            {
                if (ShowHeaderRow_Bottom != value)
                {
                    SetValue (ShowHeaderRow_BottomProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_ShowHeaderRow_Bottom (bool value, ref bool coercedValue);
        partial void Changed_ShowHeaderRow_Bottom (bool oldValue, bool newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public bool ShowSearchRow_Top
        {
            get
            {
                return (bool)GetValue (ShowSearchRow_TopProperty);
            }
            set
            {
                if (ShowSearchRow_Top != value)
                {
                    SetValue (ShowSearchRow_TopProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_ShowSearchRow_Top (bool value, ref bool coercedValue);
        partial void Changed_ShowSearchRow_Top (bool oldValue, bool newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public bool ShowSearchRow_Bottom
        {
            get
            {
                return (bool)GetValue (ShowSearchRow_BottomProperty);
            }
            set
            {
                if (ShowSearchRow_Bottom != value)
                {
                    SetValue (ShowSearchRow_BottomProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_ShowSearchRow_Bottom (bool value, ref bool coercedValue);
        partial void Changed_ShowSearchRow_Bottom (bool oldValue, bool newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public IEnumerable<object> Rows
        {
            get
            {
                return (IEnumerable<object>)GetValue (RowsProperty);
            }
            set
            {
                if (Rows != value)
                {
                    SetValue (RowsProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_Rows (IEnumerable<object> value, ref IEnumerable<object> coercedValue);
        partial void Changed_Rows (IEnumerable<object> oldValue, IEnumerable<object> newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public ObservableCollection<FGridView_Column> ColumnDefinitions
        {
            get
            {
                return (ObservableCollection<FGridView_Column>)GetValue (ColumnDefinitionsProperty);
            }
            set
            {
                if (ColumnDefinitions != value)
                {
                    SetValue (ColumnDefinitionsProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_ColumnDefinitions (ObservableCollection<FGridView_Column> value, ref ObservableCollection<FGridView_Column> coercedValue);
        partial void Changed_ColumnDefinitions (ObservableCollection<FGridView_Column> oldValue, ObservableCollection<FGridView_Column> newValue);
        partial void CollectionChanged_ColumnDefinitions (object sender, NotifyCollectionChangedAction action, int oldStartingIndex, IList oldItems, int newStartingIndex, IList newItems);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public FGridView_Row RowDefinition
        {
            get
            {
                return (FGridView_Row)GetValue (RowDefinitionProperty);
            }
            set
            {
                if (RowDefinition != value)
                {
                    SetValue (RowDefinitionProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_RowDefinition (FGridView_Row value, ref FGridView_Row coercedValue);
        partial void Changed_RowDefinition (FGridView_Row oldValue, FGridView_Row newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public ObservableCollection<FGridView_FilterRule> FilterRules
        {
            get
            {
                return (ObservableCollection<FGridView_FilterRule>)GetValue (FilterRulesProperty);
            }
            set
            {
                if (FilterRules != value)
                {
                    SetValue (FilterRulesProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_FilterRules (ObservableCollection<FGridView_FilterRule> value, ref ObservableCollection<FGridView_FilterRule> coercedValue);
        partial void Changed_FilterRules (ObservableCollection<FGridView_FilterRule> oldValue, ObservableCollection<FGridView_FilterRule> newValue);
        partial void CollectionChanged_FilterRules (object sender, NotifyCollectionChangedAction action, int oldStartingIndex, IList oldItems, int newStartingIndex, IList newItems);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public ObservableCollection<FGridView_SortRule> SortRules
        {
            get
            {
                return (ObservableCollection<FGridView_SortRule>)GetValue (SortRulesProperty);
            }
            set
            {
                if (SortRules != value)
                {
                    SetValue (SortRulesProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_SortRules (ObservableCollection<FGridView_SortRule> value, ref ObservableCollection<FGridView_SortRule> coercedValue);
        partial void Changed_SortRules (ObservableCollection<FGridView_SortRule> oldValue, ObservableCollection<FGridView_SortRule> newValue);
        partial void CollectionChanged_SortRules (object sender, NotifyCollectionChangedAction action, int oldStartingIndex, IList oldItems, int newStartingIndex, IList newItems);
        // --------------------------------------------------------------------


    }
    // ------------------------------------------------------------------------

}



