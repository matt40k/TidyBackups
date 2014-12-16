using System;
using System.IO;
using TidyBackups.Item;

namespace TidyBackups
{
    internal static class Days
    {
        public static int Age(string TBfile)
        {
            // Sets default
            var value = 99999;
            var TBfileTS = new DateTime(9999, 12, 30, 12, 59, 59);
            var Today = DateTime.Now;

            if (File.Exists(TBfile))
            {
                TBfileTS = Stamp.Get(TBfile);
                var diff = Today.Subtract(TBfileTS);
                value = diff.Days;
            }
            else
            {
                // For debug only
                Console.WriteLine(TBfile + " does not exist - Error at Tidybackups.Days.Age");
            }

#if MS_TEST
    // DEBUG
            Console.WriteLine(value);
            Console.ReadLine();
#endif

            return value;
        }
    }
}