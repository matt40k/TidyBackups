namespace TidyBackups
{
	using System;
	using System.Collections;
	using System.ComponentModel.DataAnnotations;
	using System.IO;

	public class FilteredList
    {
	    private Logger _logger { get; set; }

	    public FilteredList(Logger logger)
	    {
		    _logger = logger;
	    }

	    public ArrayList GetList(string path, int? preserve)
	    {
			var unfilteredFiles = new ArrayList();

		    var files = Directory.GetFiles(path);
		    foreach (var file in files)
		    {
			    if (IsTidyFile(file))
			    {
				    unfilteredFiles.Add(file);
			    }
		    }
            
		    if (preserve.HasValue && preserve.Value > -1)
		    {
                Console.WriteLine(preserve.ToString());
				var filteredFiles = new ArrayList(); // The final list of files

			    var safeFiles = new ArrayList();

			    var dbs = new Hashtable();

			    // Popular the database Hashtable
			    foreach (string file in unfilteredFiles)
			    {
				    var db = GetBackupObject(file);
				    if (db != null)
				    {
					    // Adds db to the dbs Hashtable
					    dbs[db] = null;
				    }
			    }

			    // Temp ArrayList
			    var tmp = new ArrayList();
			    foreach (DictionaryEntry db in dbs)
			    {
				    foreach (string file in unfilteredFiles)
				    {
					    var t1 = GetBackupObject(file);
					    var t2 = db.Key.ToString();
					    if (t1 == t2)
					    {
						    tmp.Add(File.GetCreationTime(file) + @"|" + file);
					    }
				    }
				    tmp.Reverse();
				    for (var i = 0; i < tmp.Count; i++)
				    {
					    var c = i + 1;
					    var value = tmp[i] as string;
					    if (c > preserve)
					    {
						    filteredFiles.Add(Clean(value));
					    }
					    else
					    {
						    safeFiles.Add(Clean(value));
					    }
				    }
				    tmp.Clear();
			    }

			    foreach (string file in safeFiles)
			    {
					_logger.Output("  PRESERVED: " + file, Logger.LogLevel.Info);
			    }

			    return filteredFiles;
			}

	        Console.WriteLine("NoPreserve");

            return unfilteredFiles;
	    }

	    private bool IsTidyFile(string fileName)
	    {
			var ext = Path.GetExtension(fileName);
		    switch (ext)
		    {
			    case ".dbk":
				    return true;
			    case ".bak":
				    return true;
			    case ".zip":
				    return true;
			    default:
				    return false;
		    }
		}

	    private string GetBackupObject(string filePath)
	    {
		    string fileName = Path.GetFileName(filePath);
		    int nameEnd = fileName.IndexOf("_");
		    if (nameEnd < 1)
		    {
			    nameEnd = fileName.Length;
		    }
		    return fileName.Substring(0, nameEnd);
	    }

	    private string Clean(string value)
	    {
		    var parts = value.Split('|');
		    return parts[1];
	    }
	}
}
