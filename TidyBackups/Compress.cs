namespace TidyBackups
{
    using System;
    using System.Collections;
    using System.IO;
    using ICSharpCode.SharpZipLib;
    using ICSharpCode.SharpZipLib.Zip;

    public class Compress
    {
        private Logger _logger;

        private string _password;

        public Compress(Logger logger, string password)
        {
            this._logger = logger;
            this._password = password;
        }

        /// <summary>
        /// Check we can actually open the zip
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <param name="safe"></param>
        /// <returns></returns>
        public bool IsReadableZip(string path, string name, bool safe)
        {
            var value = false;
            try
            {
                using (var s = new ZipInputStream(File.OpenRead(path)))
                {
                    ZipEntry theEntry;
                    while ((theEntry = s.GetNextEntry()) != null)
                    {
                        if (name != null)
                        {
                            if (Path.GetFileNameWithoutExtension(theEntry.Name)
                                == Path.GetFileNameWithoutExtension(path))
                            {
                                // Checks (uncompressed) file size is the same
                                if (theEntry.Size == new FileInfo(name).Length)
                                {
                                    value = true;
                                }
                            }
                            // TODO theEntry.DateTime
                            // TODO theEntry.CompressedSize
                        }
                    }
                }
            }
            catch (Exception)
            {
                this._logger.Output("  CORRUPT: " + path, Logger.LogLevel.Info);
                if (!safe)
                {
                    string result = Common.Remove(path);
                    if (result.ToUpper().StartsWith("ERROR"))
                    {
                        this._logger.Output(result, Logger.LogLevel.Error);
                    }
                    else
                    {
                        this._logger.Output(result, Logger.LogLevel.Info);
                    }
                }
            }
            return value;
        }

        private void CreateZip(string filePath, string password)
        {
            var dir = Path.GetDirectoryName(filePath);
            var nam = Path.GetFileName(filePath);
            var ext = Path.GetExtension(filePath);
            var created = File.GetCreationTime(filePath);
            var name = filePath.Replace(ext, ".zip");

            if (!File.Exists(name))
            {
                Zip(name, dir, nam, password);
                File.SetCreationTime(name, created);
                this._logger.Output("  COMPRESSED: " + filePath, Logger.LogLevel.Info);
                Common.Remove(filePath);
            }
            else
            {
                var dt = string.Format("_{0:yyyy-MM-dd_hh-mm-ss}.zip", DateTime.Now);
                var newname = filePath.Replace(ext, dt);
                Zip(newname, dir, nam, password);
                File.SetCreationTime(newname, created);
                this._logger.Output("  COMPRESSED " + filePath, Logger.LogLevel.Info);
                this._logger.Output("    AS - " + newname, Logger.LogLevel.Info);
                Common.Remove(filePath);
            }
        }

        private void Zip(string filename, string dir, string file, string password)
        {
            var zip2 = new FastZip();
            if (!string.IsNullOrWhiteSpace(password))
            {
                zip2.Password = password;
            }
            zip2.CreateZip(filename, dir, false, file);
        }

        public void Archive(ArrayList fileList, bool safe)
        {
            foreach (string filePath in fileList)
            {
                if (Common.ToCompress(filePath))
                {
                    CreateZip(filePath, this._password);
                }
            }
        }
    }
}
