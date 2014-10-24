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

using System.Collections;

namespace TidyBackups
{
    /// <summary>
    /// 
    /// </summary>
    internal class Global
    {
        /// <summary>
        /// Debug is a Boolean, it is used to hold wheither the application is in "debug" mode.
        /// If set to true, it will not perform any actual work, it will operate in report mode. It
        /// will output basic information about the system, what settings have been set, what it files
        /// it can "see", what files it's going to ignore. What files would to be compressed, if the 
        /// /ZIP switch is used, what the /LOG will be be, again, if set.
        /// </summary>
        protected internal static bool Debug;

        internal static ArrayList SafeFiles = new ArrayList();
    }
}