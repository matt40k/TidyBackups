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
using System.IO;

namespace TidyBackups.Item
{
    /// <summary>
    /// 
    /// </summary>
    internal class Stamp
    {
        /// <summary>
        /// Gets the file creation date.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected internal static DateTime Get(string path)
        {
            return File.GetCreationTime(path);
        }

        /// <summary>
        /// Sets the file creation date.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        protected internal static bool Set(string path, DateTime date)
        {
            bool value = false;
            if (!Global.Debug)
            {
                try
                {
                    File.SetCreationTime(path, date);
                }
                catch (Exception)
                {
                    value = true;
                }
            }
            return value;
        }
    }
}