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

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace fgrid.app
{
    public sealed class Customer : INotifyPropertyChanged
    {
        public static ObservableCollection<Customer> CreateTestData()
        {
            var testData =
                new ObservableCollection<Customer>
                    {
                        new Customer
                            {
                                Id                  =   0001                , 
                                FirstName           =   "Test"              ,
                                LastName            =   "Customer1"         ,
                                BirthDate           =   new DateTime(1980, 01,01),
                                CreationDate        =   new DateTime(2001, 06,01),
                            }
                    };

            return testData;
        }

        public long     Id              { get; set; }
        public string   FirstName       { get; set; }
        public string   LastName        { get; set; }
        public DateTime BirthDate       { get; set; }
        public DateTime CreationDate    { get; set; }

        public int Age
        {
            get
            {
                // TODO: Cheating here
                return (int) ((DateTime.Now - BirthDate).TotalDays/365.25);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}