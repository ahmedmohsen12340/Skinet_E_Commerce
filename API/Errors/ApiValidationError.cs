namespace API.Errors
{
    public class ApiValidationError : ApiResponse
    {
        public string[] Errors { get; }
        public ApiValidationError(string[] errors) : base(400)
        {
            Errors = errors;
        }

    }
}
