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
using System.IO;
using TidyBackups.Item;
using TidyBackups.Naming;

namespace TidyBackups
{
    internal class Filter
    {
        /// <summary>
        ///     This is really messy.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="preserve"></param>
        /// <returns></returns>
        protected internal static ArrayList Filtered(string path, int preserve)
        {
            var unfilteredFiles = new ArrayList();

            var files = Directory.GetFiles(path);
            foreach (var file in files) // note: file is full path
            {
                if (Name.Type(file))
                {
                    unfilteredFiles.Add(file);
                }
            }
            if (preserve > -1)
            {
                #region Preserve

                var filteredFiles = new ArrayList(); // The final list of files

                var safeFiles = new ArrayList();

#if MS_TEST
                Message.print("True");
#endif
                var dbs = new Hashtable();

                // Popular the database Hashtable
                foreach (string file in unfilteredFiles)
                {
                    var filename = Name.GetName(file);
                    var db = Default.Database(filename);
                    if (db != null)
                    {
                        // Adds db to the dbs Hashtable
                        dbs[db] = null;
                    }
                }

                // Temp ArrayList
                var tmp = new ArrayList();
                foreach (DictionaryEntry db in dbs)
                {
                    foreach (string file in unfilteredFiles)
                    {
                        var t1 = Default.Database(Name.GetName(file));
                        var t2 = db.Key.ToString();
                        if (t1 == t2)
                        {
                            tmp.Add(Stamp.Get(file) + @"|" + file);
                        }
                    }
                    tmp.Reverse();
                    for (var i = 0; i < tmp.Count; i++)
                    {
                        var c = i + 1;
                        var value = tmp[i] as string;
                        if (c > preserve)
                        {
                            filteredFiles.Add(Clean(value));
                        }
                        else
                        {
                            safeFiles.Add(Clean(value));
                        }
                    }
                    tmp.Clear();
                }

                foreach (string file in safeFiles)
                {
                    Message.Print("  PRESERVED: " + file);
                }

                return filteredFiles;

                #endregion
            }
            return unfilteredFiles;
        }

        /// <summary>
        ///     clean
        ///     Because this is a messy way of working, we have to clean our faces as we go
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string Clean(string value)
        {
            var parts = value.Split('|');
            return parts[1];
        }
    }
}