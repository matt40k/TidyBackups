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
using TidyBackups;
using TidyBackups.Item;

namespace TidyBackups.Debug
{
    internal class Output
    {
        internal static void Info(string[] args, bool compress, int days, string path, int preserve, bool safe)
        {
            Message.Print(Assembly.Title + " - " + Assembly.Version);
            Message.Print("Admin: " + (object)(bool)(Admin.IsAdmin ? 1 : 0));
            Message.Print("OS Version: " + Os.Version);
            Message.Print("Disc letter: " + Disc.GetDriveName(path));
            Message.Print("Disc label: " + Disc.Label(path));
            Message.Print("Disc format: " + Disc.Format(path));
            Message.Print("Local disc: " + (object)(bool)(Disc.IsLocalDrive(Disc.GetDriveName(path)) ? 1 : 0));
            Message.Print("Disc type: " + Disc.Type(path));
            Message.Print("Disc ready: " + Disc.Ready(path));
            Message.Print("Disc size: " + Disc.TotalSpace(path));
            Message.Print("Free space: " + Disc.FreeSpace(path));
            Message.Print("Username: " + Environment.UserName);
            Message.Print("Domain: " + Environment.UserDomainName);
            Message.Print("Arguments:" + Output.StrArg(args));
            Message.Print("Days: " + (object)days);
            Message.Print("Path: " + path);
            Files.Filtered(path);
            Message.Print("Path permission: " + Permissions.View(path));
            Message.Print("Preserve: " + (object)preserve);
            Message.Print("Safe: " + (object)(bool)(safe ? 1 : 0));
            Message.Print("Archive: " + (object)(bool)(compress ? 1 : 0));
            bool flag = true;
            if (Message.Logfile == "")
                flag = false;
            Message.Print("Log: " + (object)(bool)(flag ? 1 : 0));
            if (!flag)
                return;
            Message.Print("Log path: " + Message.Logfile);
            Message.Print("Log permission: " + Permissions.View(Message.Logfile));
        }

        private static string StrArg(string[] args)
        {
            string str1 = "";
            for (int index = 0; index < args.Length; ++index)
            {
                string str2 = args[index].ToUpper();
                str1 = str1 + " " + str2;
            }
            return str1;
        }
    }
}
