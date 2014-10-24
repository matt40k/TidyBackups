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
    /// 
    /// </summary>
    internal class License
    {
        /// <summary>
        /// Prints license information to Console
        /// </summary>
        protected internal static void Print()
        {
            Console.Clear();
            Console.WriteLine("TidyBackups");
            Console.WriteLine("Created by Matt Smith (matt@matt40k.co.uk)");
            Console.WriteLine("");
            Console.WriteLine("TidyBackups is free software: you can redistribute it and/or modify");
            Console.WriteLine("it under the terms of the GNU Lesser General Public License as published by");
            Console.WriteLine("the Free Software Foundation, either version 3 of the License, or");
            Console.WriteLine("(at your option) any later version.");
            Console.WriteLine("");
            Console.WriteLine("TidyBackups is distributed in the hope that it will be useful,");
            Console.WriteLine("but WITHOUT ANY WARRANTY; without even the implied warranty of");
            Console.WriteLine("MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the");
            Console.WriteLine("GNU Lesser General Public License for more details.");
            Console.WriteLine("");
            Console.WriteLine("You should have received a copy of the GNU Lesser General Public License");
            Console.WriteLine("along with TidyBackups.  If not, see <http://www.gnu.org/licenses/>.");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Environment.Exit(6);
        }
    }
}