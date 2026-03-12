namespace Application.Commons;

public class Result
{
    public bool IsSuccess { get; }
    public string Error { get; }

    public Result(bool success, string error)
    {
        IsSuccess = success;
        Error = error;
    }

    public static Result Success() => new Result(true, null);
    public static Result Failed(string error) => new Result(false, error);

}

public class Result<T> : Result
{
    public T Value { get; }

    public Result(T value, bool success, string error) : base(success, error)
    {
        Value = value;
    }

    public static Result<T> Success(T value) => new Result<T>(value, true, null);
    public static Result<T> Failed(string error) => new Result<T>(default,false, error);
}