namespace TidyBackups
{
    using System;
    public partial class Messages
    {
        public void Help()
        {
            Console.WriteLine("The syntax of this command is:");
            Console.WriteLine(string.Empty);
            Console.WriteLine("tidybackups /path:[path] /days:[days] [ [/zip | /log:[path] ]");
            Console.WriteLine(string.Empty);
            Console.WriteLine("   Options:");
            Console.WriteLine("     /?                    - Displays this help message");
            Console.WriteLine("     /LICENSE              - Displays license information");
            Console.WriteLine("     /PATH:[PATH]          - Path to the backup folder");
            Console.WriteLine("     /DAYS:[NO]          - Backups over this age will be deleted");
            Console.WriteLine(string.Empty);
            Console.WriteLine("   Optional:");
            Console.WriteLine("     /ZIP                  - Compression all uncompressed backups (.bak)");
            Console.WriteLine("     /LOG:[PATH]           - Will output to a text log file - path optional");
            Console.WriteLine("     /DEBUG                - Will output debugging information");
            Console.WriteLine("     /SAFE                 - Will not remove corrupt zips");
            Console.WriteLine("     /PRESERVE:[NO]        - Minimum backups to be kept");
            Console.WriteLine(string.Empty);
            Console.WriteLine("     /CONVENTION           - Not currently used");
            _logger.Exit(1);
        }
    }
}
