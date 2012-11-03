using System;
using System.IO;

namespace TidyBackups
{
    static class Days
    {
        static public int Age(string TBfile)
        {
            // Sets default
            int value = 99999;
            DateTime TBfileTS = new DateTime(9999, 12, 30, 12, 59, 59);
            DateTime Today = DateTime.Now;

            if (File.Exists(TBfile))
            {
                TBfileTS = Item.Stamp.Get(TBfile);
                TimeSpan diff = Today.Subtract(TBfileTS);
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
