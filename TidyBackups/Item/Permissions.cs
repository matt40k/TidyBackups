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
using System.Security.AccessControl;
using System.Security.Principal;

namespace TidyBackups.Item
{
    /// <summary>
    ///     Permission class
    /// </summary>
    internal class Permissions
    {
        /// <summary>
        ///     Displays the permissions of defined path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected internal static string View(string path)
        {
            var value = "";
            var folderSecurity = Directory.GetAccessControl(path);
            foreach (
                FileSystemAccessRule fileSystemAccessRule in
                    folderSecurity.GetAccessRules(true, true, typeof (NTAccount)))
            {
                if (value != "Full Control")
                {
                    var userRights = fileSystemAccessRule.FileSystemRights.ToString();
                    // Message.print(userRights.ToUpper());   // DEBUG
                    switch (userRights.ToLower())
                    {
                        case "fullcontrol":
                            value = "Full Control";
                            break;
                        case "write":
                            if (value != "Full Control") // This shouldn't be needed.
                            {
                                value = "Write";
                            }
                            break;
                        default:
                            if (value != "Write" | value != "Full Control")
                            {
                                value = "No write permissions!";
                            }
                            break;
                    }
                }
            }
            return value;
        }
    }
}