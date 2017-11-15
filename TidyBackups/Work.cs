namespace TidyBackups
{
	using System;
	using System.Collections;

    public class Work
    {
		private Logger _logger { get; set; }

	    public void Begin(Settings settings)
	    {
	        _logger = settings.GetLogger;
            //string path, int? days, int? preserve, bool archive, bool safe

            _logger.Output("Beginning", Logger.LogLevel.Info);
		    try
		    {
				// TODO SAFE

				// FILTEREDLIST
				FilteredList _filterList = new FilteredList(_logger);
			    var list = _filterList.GetList(settings.GetPath, settings.GetPreserve);

			    // TIDY
                Tidy(list, settings.GetDays);

			    // COMPRESSION
                Compress _compress = new Compress(_logger, settings.GetPassword);
                _compress.Archive(list, settings.GetSafe);
		    }
		    catch (Exception exception)
		    {
				_logger.Output(exception.Message, Logger.LogLevel.Error);
		    }
	    }

        private void Tidy(ArrayList path, int maxage)
        {
            foreach (string file in path)
            {
                var TBfileAge = Common.GetFileAge(file);
                if (TBfileAge > maxage)
                {
                    Common.Remove(file);
                }
            }
        }
    }
}
