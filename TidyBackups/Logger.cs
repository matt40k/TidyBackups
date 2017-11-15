namespace TidyBackups
{
	using System;
	using System.IO;

	public class Logger
    {
		private string _logFile;

        private bool _debugMode;

	    public Logger(string logFile, bool DebugMode)
	    {
		    if (!string.IsNullOrWhiteSpace(logFile))
			{
				SetLogPath = logFile;
			}

	        this._debugMode = DebugMode;
	    }

	    public void Output(string message, LogLevel logLevel)
	    {
	        if (logLevel != LogLevel.Debug || _debugMode)
	        {
	            var currTime = DateTime.Now;
	            message = currTime + " - " + message;
	            Console.WriteLine(message);
	            WriteToDisk(message);
	        }
	    }

        public void Exit(int exitCode)
        {
            switch (exitCode)
            {
                case 0:
                    Output("Finishing", LogLevel.Info);
                    break;
                case 1:
                    break;
                default:
                    Output("Aborting - " + ExitCodeName(exitCode), LogLevel.Error);
                    break;
            }
            Environment.Exit(exitCode);
        }

	    public enum LogLevel
	    {
		    Info,
		    Debug,
		    Error
	    };

        private string ExitCodeName(int exitCode)
        {
            switch (exitCode)
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

        private void WriteToDisk(string message)
        {
            if (!string.IsNullOrWhiteSpace(_logFile))
            {
                try
                {
                    var aLog = new FileStream(this._logFile, FileMode.Append);
                    var sw = new StreamWriter(aLog);
                    sw.WriteLine(message);
                    sw.Close();
                }
                catch (Exception writeToDiskException)
                {
                    var currTime = DateTime.Now;
                    string exMessage = currTime + " - " + writeToDiskException.InnerException;
                    Console.WriteLine(exMessage);
                }
            }
        }

        public string SetLogPath
        {
            set
            {
                string path = value;
                path = path.Replace("\"", string.Empty); // Remove quotes (")
                if (path == string.Empty)
                {
                    // No path or name is specified, so we'll use the default.
                    path = Directory.GetCurrentDirectory() + @"\tidybackups_log.txt";
                }
                else
                {
                    if (path == Path.GetFileName(path))
                    {
                        // No path is specified, so we'll use the current directory.
                        path = Directory.GetCurrentDirectory() + @"\" + path;
                    }
                    else
                    {
                        if (Directory.Exists(path))
                        {
                            // No filename is specified, so we'll use the default.
                            path = path + @"\tidybackups_log.txt";
                        }
                    }
                }
                path = path.Replace("\\\\", "\\"); // Remove double slashes(\\)
                _logFile = path;
            }
        }

        public bool SetDebug
        {
            set
            {
                this._debugMode = value;
            }
        }
    }
}
