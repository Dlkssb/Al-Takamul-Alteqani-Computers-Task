

namespace DataAccess.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
            _error = message;
        }

        public BadRequestException(string[] errors) : base("Multiple errors occurred. See error details.")
        {
            Errors = errors;
        }

        public override string StackTrace
        {
            get { return _error; }
        }

        public string[] Errors { get; set; }
        public string _error { get; set; }
    }
}
