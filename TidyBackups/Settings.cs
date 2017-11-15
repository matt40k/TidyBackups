namespace TidyBackups
{
    using System;
    using System.IO;
    using System.Security;

    public class Settings
    {
        private int days;

        private int preserve;

        private int database;

        private Logger logger;

        private bool zip = false;

        private bool safe = false;

        private string path;

        private string password;

        public Settings()
        {
            this.logger = new Logger(null, false);
        }

        public string SetDays
        {
            set
            {
                try
                {
                    this.days = Convert.ToInt16(value);
                }
                catch (Exception SetDaysException)
                {
                    Console.WriteLine(SetDaysException);
                    throw;
                }
            }
        }

        public int GetDays
        {
            get
            {
                return this.days;
            }
        }

        public string SetPreserve
        {
            set
            {
                try
                {
                    preserve = Convert.ToInt16(value);
                }
                catch (Exception)
                {
                    preserve = 6;
                }
            }
        }

        public int GetPreserve
        {
            get
            {
                return this.preserve;
            }
        }

        public string SetDatabase
        {
            set
            {
                try
                {
                    database = Convert.ToInt16(value);
                }
                catch (Exception SetDatabaseException)
                {
                    Console.WriteLine(SetDatabaseException);
                    throw;
                }
            }
        }

        public int GetDatabase
        {
            get
            {
                return this.database;
            }
            
        }

        public Logger GetLogger
        {
            get
            {
                return this.logger;
            }
        }

        public bool SetSafe
        {
            set
            {
                this.safe = value;
            }
        }

        public bool SetZip
        {
            set
            {
                this.zip = value;
            }
        }

        public bool GetSafe
        {
            get
            {
                return this.safe;
            }
        }

        public bool GetZip
        {
            get
            {
                return this.zip;
            }
        }

        public bool SetDebugMode
        {
            set
            {
                this.logger.SetDebug = value;
            }
        }

        public string GetPath
        {
            get
            {
                return this.path;
            }
        }

        public string SetPath
        {
            set
            {
                if (Directory.Exists(value))
                {
                    this.path = value;
                }
            }
        }

        public string SetLogPath
        {
            set
            {
                this.logger.SetLogPath = value;
            }
        }

        public string SetPassword
        {
            set
            {
                this.password = value;
            }
        }

        public bool IsEncrypt
        {
            get
            {
                return this.password.Length > 0;
            }
        }

        public string GetPassword
        {
            get
            {
                return this.password;
            }
        }
    }
}
