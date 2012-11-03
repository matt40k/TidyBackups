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

namespace TidyBackups.Naming
{
    /// <summary>
    /// Class for the default naming conventions 
    /// </summary>
    internal class Default
    {
        /// <summary>
        /// TidyBackups.Naming.Default.Database returns a string.
        /// It gets the database name from the file name, it splits the string up by underscores (_) and uses the first 
        /// sub string assuming there is more then 3.
        /// 
        /// Default: DATABASENAME_YYYYMMDD_HHMMSS.zip
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        protected internal static string Database(string filename)
        {
            string value = null;
            string[] parts = filename.Split('_');
#if MS_TEST
            Console.WriteLine(parts.Length.ToString());
#endif
            if (parts.Length >= 3)
            {
                value = parts[0];
            }
            return value;
        }
    }
}