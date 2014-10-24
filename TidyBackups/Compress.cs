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
using TidyBackups.Item;
using TidyBackups.SharpZipLib.Zip;

namespace TidyBackups
{
    /// <summary>
    /// Class for the Compression logic
    /// </summary>
    internal class Compress
    {
        protected internal static void Archive(string path, bool safe)
        {
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                if (Name.ToCompress(file))
                {
                    CompressZip(file, safe);
                }
            }
        }

        /// <summary>
        /// Runs logic for creating zip, it'll do a bit of last min checking first.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="safe"></param>
        protected internal static void CompressZip(string path, bool safe)
        {
            string dir = Name.GetDir(path);
            string nam = Name.GetName(path);
            string ext = Name.GetExt(path);
            DateTime created = Stamp.Get(path);
            string name = path.Replace(ext, ".zip");
            if (!File.Exists(name))
            {
                Write(name, dir, nam);
                Stamp.Set(name, created);
                Message.Print("  COMPRESSED: " + path);
                Rename.Delete(path);
            }
            else
            {
                if (Read(name, path, safe))
                {
                    Rename.Delete(path);
                }
                else
                {
                    // If the compressed file is not corrupt. We'll give it a new name, based on the time. 
                    string dt = String.Format("_{0:yyyy-MM-dd_hh-mm-ss}.zip", DateTime.Now);
                    string newname = path.Replace(ext, dt);
                    Write(newname, dir, nam);
                    Stamp.Set(newname, created);
                    Message.Print("  COMPRESSED " + path);
                    Message.Print("    AS - " + newname);
                    Rename.Delete(path);
                }
            }
        }

        /// <summary>
        /// Checks zip is able to be opened and valid.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <param name="safe"></param>
        /// <returns></returns>
        protected internal static bool Read(string path, string name, bool safe)
        {
            bool value = false;
            try
            {
                using (var s = new ZipInputStream(File.OpenRead(path)))
                {
                    ZipEntry theEntry;
                    while ((theEntry = s.GetNextEntry()) != null)
                    {
                        if (name != null)
                        {
#if MS_TEST
                            Message.print(theEntry.Name);
                            Message.print(File.Name.GetUncompress(path));
#endif
                            if (theEntry.Name == Name.GetUncompress(path))
                            {
                                // Checks (uncompressed) file size is the same
#if MS_TEST
                                Message.print(theEntry.Size.ToString());
                                Message.print(File.Size.get(name).ToString());
#endif
                                if (theEntry.Size == Size.Get(name))
                                {
                                    value = true;
                                }
                            }
                            // TODO theEntry.DateTime
                            // TODO theEntry.CompressedSize
                        }
                    }
                }
            }
            catch (Exception)
            {
                Message.Print("  CORRUPT: " + path);
                if (!safe)
                {
                    Rename.Delete(path);
                }
            }
            return value;
        }

        /// <summary>
        /// Creates the zip
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="dir"></param>
        /// <param name="file"></param>
        private static void Write(string filename, string dir, string file)
        {
            if (!Global.Debug)
            {
                try
                {
                    var zip2 = new FastZip();
                    zip2.CreateZip(filename, dir, false, file);
                }
                catch (ZipException)
                {
                    // Error
                    Message.Print("compression error");
                }
            }
        }
    }
}