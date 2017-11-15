namespace TidyBackups
{
    public partial class Messages
    {
        private Logger _logger { get; set; }
        public Messages(Logger logger)
        {
            _logger = logger;
        }
    }
}
