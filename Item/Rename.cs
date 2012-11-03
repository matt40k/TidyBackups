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
    /// Delete class.
    /// </summary>
    internal class Rename
    {
        /// <summary>
        /// Actually deletes the file.
        /// </summary>
        /// <param name="path"></param>
        protected internal static void Delete(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    if (!Global.Debug)
                    {
                        File.Delete(path);
                    }
                    Message.Print("  DELETED: " + path);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Message.Print("Error - Deleting - Access is denied - " + path);
            }
            catch (IOException)
            {
                Message.Print("Error - Deleting - File in use - " + path);
            }
            catch (Exception)
            {
                Message.Print("Error - Deleting - " + path);
            }
        }
    }
}