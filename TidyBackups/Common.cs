namespace TidyBackups
{
    using System;
    using System.IO;

    public class Common
    {
        public static string Remove(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return "  DELETED: " + path;
                }
            }
            catch (UnauthorizedAccessException)
            {
                return "Error - Deleting - Access is denied - " + path;
            }
            catch (IOException)
            {
                return "Error - Deleting - File in use - " + path;
            }
            catch (Exception)
            {
                return "Error - Deleting - " + path;
            }
            return "Error";
        }

        public static int GetFileAge(string filePath)
        {
            var fileDateTime = new DateTime(9999, 12, 30, 12, 59, 59);
            var today = DateTime.Now;

            if (File.Exists(filePath))
            {
                fileDateTime = File.GetCreationTime(filePath);
                var diff = today.Subtract(fileDateTime);
                return diff.Days;
            }

            return 99999;
        }
        public static bool ToCompress(string path)
        {
            var ext = Path.GetExtension(path);
            switch (ext)
            {
                case ".dbk":
                    return true;
                case ".bak":
                    return true;
                default:
                    return false;
            }
        }
    }
}
