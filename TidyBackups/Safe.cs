﻿/*
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
using TidyBackups.Item;

namespace TidyBackups
{
    /// <summary>
    /// </summary>
    internal class Safe
    {
        /// <summary>
        /// </summary>
        /// <param name="path"></param>
        /// <param name="safe"></param>
        protected internal static void Clean(string path, bool safe)
        {
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                if (Name.GetExt(file) == ".zip")
                {
                    Compress.Read(path, null, safe);
                }
            }
        }
    }
}