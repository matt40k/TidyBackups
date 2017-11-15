namespace TidyBackups
{
    using System;
    using System.IO;
    using System.Security;

    class Program
    {
        static void Main(string[] args)
        {
            /*
	        string msg = "Hello World!";

			Logger logger = new Logger(null, true);
			logger.Output(msg, Logger.LogLevel.Info);

			Work _work = new Work(logger);
			_work.Begin(@"C:\git\test", null, null, true, false);

	        Console.ReadKey();
            */

            Settings settings = new Settings();

            Messages messages = new Messages(settings.GetLogger);

            try
            {
                if (args.Length == 0)
                {
                    messages.Help();
                }
                else
                {
                    for (var i = 0; i < args.Length; i++)
                    {
                        var str = args[i].ToUpper();
                        if (str.StartsWith("/?"))
                        {
                            messages.Help();
                        }
                        if (str.StartsWith("/HELP"))
                        {
                            messages.Help();
                        }
                        if (str.StartsWith("/DEBUG"))
                        {
                            settings.SetDebugMode = true;
                        }
                        if (str.StartsWith("/LICENSE"))
                        {
                            messages.License();
                        }
                        if (str.StartsWith("/PATH"))
                        {
                            settings.SetPath = Parameters.GetParameterValue(args, "/PATH");
                        }
                        if (str.StartsWith("/DAYS"))
                        {
                            settings.SetDays = Parameters.GetParameterValue(args, "/DAYS");
                        }
                        if (str.StartsWith("/ZIP"))
                        {
                            settings.SetZip = true;
                        }
                        if (str.StartsWith("/ARCHIVE"))
                        {
                            settings.SetZip = true;
                        }
                        if (str.StartsWith("/LOG"))
                        {
                            settings.SetLogPath = Parameters.GetParameterValue(args, "/LOG");
                        }
                        if (str.StartsWith("/SAFE"))
                        {
                            settings.SetSafe = true;
                        }
                        if (str.StartsWith("/PRESERVE"))
                        {
                            settings.SetPreserve = Parameters.GetParameterValue(args, "/PRESERVE");
                        }
                        if (str.StartsWith("/PASSWORD"))
                        {
                            settings.SetPassword = Parameters.GetParameterValue(args, "/PASSWORD");
                        }

                    }
                }

                Work work = new Work();
                work.Begin(settings);
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("System is out of memory");
            }
        }
    }
}
