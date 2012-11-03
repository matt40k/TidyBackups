/*
 * This file is part of TidyBackups
 *
 * TidyBackups is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * TidyBackups is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public License
 * along with TidyBackups.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;

namespace TidyBackups
{
    internal class ToInt
    {
        /// <summary>
        /// Converts the string into an integer for days
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        protected internal static int Days(string str)
        {
            int value = 0;
            try
            {
                value = Convert.ToInt16(str);
            }
            catch (Exception)
            {
                Exit.End(5);
            }
            return value;
        }

        /// <summary>
        /// Converts the string into an integer for preserve
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        protected internal static int Preserve(string str)
        {
            int value;
            try
            {
                value = Convert.ToInt16(str);
            }
            catch (Exception)
            {
                value = 6;
            }
            return value;
        }

        protected internal static int Database(string str)
        {
            int value = 0;
            try
            {
                value = Convert.ToInt16(str);
            }
            catch (Exception)
            {
                // Error
            }
            return value;
        }
    }
}