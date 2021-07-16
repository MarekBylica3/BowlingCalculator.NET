namespace Common.Validation
{
    public class Result<T> : Result where T : new()
    {
        public T Model { get; set; }

        public Result()
        {
            Model = new T();
        }
    }

    public class Result
    {
        public bool IsValid
        {
            get
            {
                return string.IsNullOrWhiteSpace(ErrorMessage);
            }
        }
        public string ErrorMessage { get; set; }

        public void AddError(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
