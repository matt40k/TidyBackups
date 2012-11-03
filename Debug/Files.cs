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

namespace TidyBackups.Debug
{
    internal class Files
    {
        protected internal static void Filtered(string path)
        {
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                if (Name.Type(file))
                {
                    Message.Print("  " + file + " - Age:"+ Days.Age(file) +"days");
                }
                else
                {
                    Message.Print("  IGNORING: " + file);
                }
            }
        }
    }
}