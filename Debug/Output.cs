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
using TidyBackups.Item;

namespace TidyBackups.Debug
{
    /// <summary>
    /// Output class for Debugging
    /// </summary>
    internal class Output
    {
        /// <summary>
        /// Outputs useful information to Message class for output
        /// </summary>  
        /// <param name="args"></param>
        /// <param name="compress"></param>
        /// <param name="days"></param>
        /// <param name="path"></param>
        /// <param name="preserve"></param>
        /// <param name="safe"></param>
        internal static void Info(string[] args, bool compress, int days, string path, int preserve, bool safe)
        {
            Message.Print(Assembly.Title + " - " + Assembly.Version);
            Message.Print("Admin: " + Admin.IsAdmin);
            Message.Print("OS Version: " + Os.Version);
            Message.Print("Disc letter: " + Disc.GetDriveName(path));
            Message.Print("Disc label: " + Disc.Label(path));
            Message.Print("Disc format: " + Disc.Format(path));
            Message.Print("Local disc: " + Disc.IsLocalDrive(Disc.GetDriveName(path)));
            Message.Print("Disc type: " + Disc.Type(path));
            Message.Print("Disc ready: " + Disc.Ready(path));
            Message.Print("Disc size: " + Disc.TotalSpace(path));
            Message.Print("Free space: " + Disc.FreeSpace(path));
            Message.Print("Username: " + Environment.UserName);
            Message.Print("Domain: " + Environment.UserDomainName);
            Message.Print("Arguments:" + StrArg(args));
            Message.Print("Days: " + days);
            Message.Print("Path: " + path);
            Files.Filtered(path);
            Message.Print("Path permission: " + Permissions.View(path));
            Message.Print("Preserve: " + preserve);
            Message.Print("Safe: " + safe);
            Message.Print("Archive: " + compress);
            bool boolLog = true;
            if (Message.Logfile == "")
            {
                boolLog = false;
            }
            Message.Print("Log: " + boolLog);
            if (boolLog)
            {
                Message.Print("Log path: " + Message.Logfile);
                Message.Print("Log permission: " + Permissions.View(Message.Logfile));
            }
        }


        private static string StrArg(string[] args)
        {
            string value = "";
            for (int i = 0; i < args.Length; i++)
            {
                string str = args[i].ToUpper();
                value = value + " " + str;
            }
            return value;
        }
    }
}