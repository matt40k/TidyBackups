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
    /// Work Class - contains most of the logic
    /// </summary>
    internal class Work
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="days"></param>
        /// <param name="preserve"></param>
        /// <param name="archive"></param>
        /// <param name="safe"></param>
        protected internal static void Begin(string path, int days, int preserve, bool archive, bool safe)
        {
            Message.Print("Beginning");
            try
            {
                // Remove corrupt zips (unless /SAFE is used).
                if (safe)
                {
                    Safe.Clean(path, true);
                }

                // Gets a list of files
                ArrayList files = Filter.Filtered(path, preserve);

#if MS_TEST
                foreach (string File in Files)
                {
                    Message.print(File);
                }
#endif

                // Will delete the old files files - free's disc space up for us to use (assuming /DAYS is used)
                Tidy.Clean(files, days);

                // Compresses any uncompressed backups (assuming /ZIP is used)
                if (archive)
                {
                    Compress.Archive(path, safe);
                }
            }
            finally
            {
                Exit.End(0);
            }
        }
    }
}