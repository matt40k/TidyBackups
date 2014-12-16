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

namespace TidyBackups
{
    /// <summary>
    ///     Exit class
    /// </summary>
    internal class Exit
    {
        /// <summary>
        ///     Exits safely, will produce exit message and exit code.
        /// </summary>
        /// <param name="code"></param>
        protected internal static void End(int code)
        {
            switch (code)
            {
                case 0:
                    Message.Print("Finishing");
                    break;
                case 1:
                    break;
                default:
                    Message.Print("Aborting - " + Clean(code));
                    break;
            }
            Environment.Exit(code);
        }

        /// <summary>
        ///     Makes exit codes friendly.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string Clean(int code)
        {
            switch (code)
            {
                case 1:
                    return "No args";
                case 2:
                    return "No days";
                case 3:
                    return "No path";
                case 4:
                    return "Path specified invalid";
                case 5:
                    return "Days specified invalid";
                case 6:
                    return "Licensing";
                case 7:
                    return "Invalid log path";
                case 8:
                    return "Preserve days specified valid";
                default:
                    return "Generic error";
            }
        }
    }
}