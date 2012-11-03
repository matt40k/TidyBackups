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

using System.IO;
using System.Reflection;

namespace TidyBackups.Debug
{
    /// <summary>
    /// Debug.Version class
    /// </summary>
    internal class Assembly
    {
        /// <summary>
        /// Gets the application version
        /// </summary>
        protected internal static string Version
        {
            get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }

        /// <summary>
        /// Gets the applications Title.
        /// </summary>
        protected internal static string Title
        {
            get
            {
                object[] attributes =
                    System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(
                        typeof (AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    var titleAttribute = (AssemblyTitleAttribute) attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            }
        }
    }
}