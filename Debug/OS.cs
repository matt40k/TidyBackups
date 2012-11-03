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

namespace TidyBackups.Debug
{
    /// <summary>
    /// Debug.OS class
    /// </summary>
    internal class Os
    {
        /// <summary>
        /// Gets the OS version (as a string)
        /// </summary>
        protected internal static string Version
        {
            get { return Environment.OSVersion.VersionString; }
        }
    }
}