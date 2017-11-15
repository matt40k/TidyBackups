namespace TidyBackups
{
    using System;

    public class Parameters
    {
        /// <summary>
        ///     Gets the setting from the command line.
        /// </summary>
        /// <param name="commandParameters"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static string GetParameterValue(string[] commandParameters, string parameterName)
        {
            try
            {
                for (var i = 0; i < commandParameters.Length; i++)
                {
                    var str = commandParameters[i];
                    if (str.ToUpper().StartsWith(parameterName.ToUpper()))
                    {
                        if (parameterName == str)
                        {
                            return string.Empty;
                        }
                        return str.Substring(parameterName.Length + 1);
                    }
                }
            }
            catch (Exception) // GetParameterValueException)
            {
                
            }
            return string.Empty;
        }
    }
}
