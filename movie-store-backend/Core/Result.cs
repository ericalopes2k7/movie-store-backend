namespace movie_store_backend.Core
{
    public class Result<T> where T : class
    {
        public bool isSuccess { get; }
        public string? errorMessage { get; }
        public T? value { get; }

        public Result(bool isSuccess, string? errorMessage, T? value)
        {
            this.isSuccess = isSuccess;
            this.errorMessage = errorMessage;
            this.value = value;
        }

        public static Result<T> Ok(T value)
        {
            return new Result<T>(true, null, value);
        }

        public static Result<T> Fail(string errorMessage)
        {
            return new Result<T>(false, errorMessage, null);
        }
    }
}
