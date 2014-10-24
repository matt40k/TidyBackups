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
using System.Management;

namespace TidyBackups.Item
{
    /// <summary>
    /// Local disc
    /// </summary>
    internal class Disc
    {
        /// <summary>
        /// Format of the drive
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        protected internal static string Format(string file)
        {
            var drv = new DriveInfo(file);
            return drv.DriveFormat;
        }


        /// <summary>
        /// Type of drive (Fixed, removable etc)
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        protected internal static string Type(string file)
        {
            var drv = new DriveInfo(file);
            return drv.DriveType.ToString();
        }

        /// <summary>
        /// Label of the disc
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        protected internal static string Label(string file)
        {
            var drv = new DriveInfo(file);
            return drv.VolumeLabel;
        }

        /// <summary>
        /// Is the drive ready for use
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        protected internal static string Ready(string file)
        {
            var drv = new DriveInfo(file);
            return drv.IsReady.ToString();
        }


        /// <summary>
        /// Free disc space on disc (in MegaBytes)
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        protected internal static string FreeSpace(string file)
        {
            var drv = new DriveInfo(file);
            long size = drv.AvailableFreeSpace/1024/1024;
            return size + " MB";
        }

        /// <summary>
        /// Total disc space on disc (in MegaBytes)
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        protected internal static string TotalSpace(string file)
        {
            var drv = new DriveInfo(file);
            long size = drv.TotalSize/1024/1024;
            return size + " MB";
        }

        /// <summary>
        /// Drive name
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        protected internal static string GetDriveName(string fileName)
        {
            int index = fileName.IndexOf(Path.VolumeSeparatorChar);
            if (index > 0)
            {
                return fileName.Substring(0, index + 1);
            }
            return fileName;
        }

        /// <summary>
        /// Is the drive locally attached (not a network drive)
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        protected internal static bool IsLocalDrive(string descriptor)
        {
            string queryString = "SELECT * From Win32_LogicalDisk where name = '" + descriptor + "' and DriveType = 3";
            DateTime now = DateTime.Now;
            ManagementObjectCollection objects = new ManagementObjectSearcher(queryString).Get();
            DateTime.Now.Subtract(now);
            foreach (ManagementObject obj2 in objects)
            {
                if (obj2["name"].ToString().ToUpper() == descriptor.ToUpper())
                {
                    return true;
                }
            }
            return false;
        }
    }
}