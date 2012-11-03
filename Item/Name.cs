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

using System.IO;

namespace TidyBackups.Item
{
    /// <summary>
    /// 
    /// </summary>
    internal class Name
    {
        /// <summary>
        /// Gets the file name from the file path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected internal static string GetName(string path)
        {
            return Path.GetFileName(path);
        }

        /// <summary>
        /// Gets the file extension from the file path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected internal static string GetExt(string path)
        {
            return Path.GetExtension(path);
        }

        /// <summary>
        /// Gets the directory from the file path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected internal static string GetDir(string path)
        {
            return Path.GetDirectoryName(path);
        }

        protected internal static string GetUncompress(string name)
        {
            string value = GetName(name);
            return value.Replace(".zip", ".bak");
        }

        /// <summary>
        /// Checks the file type.
        /// </summary>
        /// <param name="ext"></param>
        /// <returns></returns>
        protected internal static bool Type(string path)
        {
            string ext = Path.GetExtension(path);
            switch (ext)
            {
                case ".dbk":
                    return true;
                case ".bak":
                    return true;
                case ".zip":
                    return true;
                default:
                    return false;
            }
        }

        protected internal static bool ToCompress(string path)
        {
            string ext = Path.GetExtension(path);
            switch (ext)
            {
                case ".dbk":
                    return true;
                case ".bak":
                    return true;
                default:
                    return false;
            }
        }
    }
}