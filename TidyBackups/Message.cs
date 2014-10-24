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

namespace TidyBackups
{
    /// <summary>
    /// Class for outputting real-time information
    /// </summary>
    internal class Message
    {
        /// <summary>
        /// The log file path
        /// </summary>
        protected internal static string Logfile = "";

        /// <summary>
        /// Prints message to Console
        /// </summary>
        /// <param name="mess"></param>
        protected internal static void Print(string mess)
        {
            DateTime currTime = DateTime.Now;
            mess = currTime + " - " + mess;
            Console.WriteLine(mess);
            try
            {
                if (Logfile != "")
                {
                    Log(mess);
                }
            }
            catch (Exception)
            {
                Logfile = ""; // Sets logfile to null to prevent loop. NB: Not working.
                Console.WriteLine("{0:G}", currTime + " - Error writing to log file.");
            }
        }


        /// <summary>
        /// Print message to log file.
        /// </summary>
        /// <param name="mess"></param>
        private static void Log(string mess)
        {
            try
            {
                var aLog = new FileStream(Logfile, FileMode.Append);
                var sw = new StreamWriter(aLog);
                sw.WriteLine(mess);
                sw.Close();
            }
            catch (Exception)
            {
                Console.WriteLine(Logfile);
                Logfile = ""; // Sets logfile to null to prevent loop.
                Exit.End(7);
                throw;
            }
        }

        /// <summary>
        /// Makes the file path a full path
        /// </summary>
        /// <param name="path"></param>
        protected internal static void File(string path)
        {
            path = path.Replace("\"", ""); // Remove quotes (")
            if (path == "")
            {
                // No path or name is specified, so we'll use the default.
                path = Directory.GetCurrentDirectory() + @"\tidybackups_log.txt";
            }
            else
            {
                if (path == Name.GetName(path))
                {
                    // No path is specified, so we'll use the current directory.
                    path = Directory.GetCurrentDirectory() + @"\" + path;
                }
                else
                {
                    if (Directory.Exists(path))
                    {
                        // No filename is specified, so we'll use the default.
                        path = path + @"\tidybackups_log.txt";
                    }
                }
            }
            path = path.Replace("\\\\", "\\"); // Remove double slashes(\\)
            Logfile = path;
        }
    }
}