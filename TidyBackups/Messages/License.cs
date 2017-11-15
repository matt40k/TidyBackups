namespace TidyBackups
{
    using System;
    public partial class Messages
    {
        public void License()
        {
            Console.WriteLine("TidyBackups");
            Console.WriteLine("Created by Matt Smith (matt@matt40k.uk)");
            Console.WriteLine(string.Empty);
            Console.WriteLine("TidyBackups is free software: you can redistribute it and/or modify");
            Console.WriteLine("it under the terms of the GNU Lesser General Public License as published by");
            Console.WriteLine("the Free Software Foundation, either version 3 of the License, or");
            Console.WriteLine("(at your option) any later version.");
            Console.WriteLine(string.Empty);
            Console.WriteLine("TidyBackups is distributed in the hope that it will be useful,");
            Console.WriteLine("but WITHOUT ANY WARRANTY; without even the implied warranty of");
            Console.WriteLine("MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the");
            Console.WriteLine("GNU Lesser General Public License for more details.");
            Console.WriteLine(string.Empty);
            Console.WriteLine("You should have received a copy of the GNU Lesser General Public License");
            Console.WriteLine("along with TidyBackups.  If not, see <http://www.gnu.org/licenses/>.");
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            _logger.Exit(6);
        }
    }
}
