

using Flunt.Notifications;

namespace IGotUScraper.Domain.Base
{
    public class Result<T>
    {
        public T Object { get; }
        public string Message { get; }

        private Result(T obj) => Object = obj;

        public Result(string message) => Message = message;

        public static Result<T> Ok(T obj) => new Result<T>(obj);

        public static Result<T> Error(T message) => new(message);
    }
}
