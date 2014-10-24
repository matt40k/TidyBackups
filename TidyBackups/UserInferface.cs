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
using TidyBackups.Debug;

namespace TidyBackups
{
    /// <summary>
    /// Main entry class for application.
    /// </summary>
    internal class UserInferface
    {
        /// <summary>
        /// Main entry for application.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                bool arch = false;
                string path = null;
                int days = -1;
                int preserve = -1;
                bool safe = false;

#if MS_TEST
            // TODO Build NUNIT test from this
            //string filename = File.Name.GetName(path);
            //string database = Naming.Default.Database(filename);
#endif

                if (args.Length == 0)
                {
                    Help();
                    Exit.End(1);
                }
                else
                {
                    for (int i = 0; i < args.Length; i++)
                    {
                        string str = args[i].ToUpper();
                        if (str.StartsWith("/?"))
                        {
                            Help();
                        }
                        if (str.StartsWith("/HELP"))
                        {
                            Help();
                        }
                        if (str.StartsWith("/DEBUG"))
                        {
                            Global.Debug = true;
                        }
                        if (str.StartsWith("/LICENSE"))
                        {
                            License.Print();
                        }
                        if (str.StartsWith("/PATH"))
                        {
                            path = GetParameterValue(args, "/PATH");
                        }
                        if (str.StartsWith("/DAYS"))
                        {
                            days = ToInt.Days(GetParameterValue(args, "/DAYS"));
                        }
                        if (str.StartsWith("/ZIP"))
                        {
                            arch = true;
                        }
                        if (str.StartsWith("/ARCHIVE"))
                        {
                            arch = true;
                        }
                        if (str.StartsWith("/LOG"))
                        {
                            Message.File(GetParameterValue(args, "/LOG"));
                        }
                        if (str.StartsWith("/SAFE"))
                        {
                            safe = true;
                        }
                        if (str.StartsWith("/PRESERVE"))
                        {
                            preserve = ToInt.Preserve(GetParameterValue(args, "/PRESERVE"));
                        }
                        if (str.StartsWith("/CONVENTION"))
                        {
                            // TODO Non-default naming convention
                        }
                    }
                }
                Validation validation = new Validation();
                path = validation.Path(path);
                if (path != null)
                {
                    int chk1 = preserve + days;
                    if (chk1 > -1)
                    {
                        if (Global.Debug)
                        {
                            Output.Info(args, arch, days, path, preserve, safe);
                        }
                        Work.Begin(path, days, preserve, arch, safe);
                    }
                    else
                    {
                        Message.Print("No days specified"); // TODO To be amended
                        Exit.End(2);
                    }
                }
                else
                {
                    Message.Print("No path specified");
                    Exit.End(3);
                }
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("System is out of memory");
            }           
        }

        /// <summary>
        /// Prints help information to Console.
        /// This information is displayed if no switches are supplied or if the /? switch is used.
        /// </summary>
        internal static void Help()
        {
#if !MS_TEST
            Console.Clear();
#endif
            Console.WriteLine("The syntax of this command is:");
            Console.WriteLine();
            Console.WriteLine("tidybackups /path:[path] /days:[days] [ [/zip | /log:[path] ]");
            Console.WriteLine();
            Console.WriteLine("   Options:");
            Console.WriteLine("     /?                    - Displays this help message");
            Console.WriteLine("     /LICENSE              - Displays license information");
            Console.WriteLine("     /PATH:[PATH]          - Path to the backup folder");
            Console.WriteLine("     /DAYS:[NO]          - Backups over this age will be deleted");
            Console.WriteLine();
            Console.WriteLine("   Optional:");
            Console.WriteLine("     /ZIP                  - Compression all uncompressed backups (.bak)");
            Console.WriteLine("     /LOG:[PATH]           - Will output to a text log file - path optional");
            Console.WriteLine("     /DEBUG                - Will output debugging information");
            Console.WriteLine("     /SAFE                 - Will not remove corrupt zips");
            Console.WriteLine("     /PRESERVE:[NO]        - Minimum backups to be kept");
            Console.WriteLine();
            Console.WriteLine("     /CONVENTION           - Not currently used");
/*                                                              Don't like leaving it open
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
 */
            Exit.End(1);
        }

        /// <summary>
        /// Gets the setting from the command line.
        /// </summary>
        /// <param name="commandParameters"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        private static string GetParameterValue(string[] commandParameters, string parameterName)
        {
            try
            {
                for (int i = 0; i < commandParameters.Length; i++)
                {
                    string str = commandParameters[i];
                    if (str.ToUpper().StartsWith(parameterName.ToUpper()))
                    {
                        if (parameterName == str)
                        {
                            return "";
                        }
                        return str.Substring(parameterName.Length + 1);
                    }
                }
            }
            catch (Exception e)
            {
                Message.Print(e.ToString());
            }
            return "";
        }
    }
}