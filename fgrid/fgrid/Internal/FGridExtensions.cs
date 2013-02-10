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

using System.Windows;

namespace FGrid.Internal
{
    static class FGridExtensions
    {
        public static double AreaOf(this Size size)
        {
            return size.Height*size.Width;
        }

        public static Vector ToVector(this Size size)
        {
            return new Vector(size.Width, size.Height);
        }

        public static Vector ToVector(this Point point)
        {
            return new Vector(point.X, point.Y);
        }
    }
}
