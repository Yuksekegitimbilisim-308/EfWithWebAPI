namespace EfWithWebAPI
{
    public class Result<T> where T : class, new()
    {
        public int StatusCode { get; set; }
        public bool IsShow { get; set; }
        public string Message { get; set; }
        public int Count { get; set; }
        public T Data { get; set; }

        public static Result<T> Success(T data,int statusCode,string Message,int count = 1)
        {
            return new Result<T>()
            {
                Count = count,
                Data = data,
                Message = Message,
                StatusCode = statusCode,
            };
        }
        public static Result<T> Error(int statusCode,string message,bool isShow)
        {

            //var result = new Result<T>()
            //{
            //    StatusCode = statusCode,
            //    Count = 0,
            //    Data = null
            //};
            //if (isShow)
            //    result.Message = message;
            //else
            //    result.Message = "Bilinmeyen Bir Hata Oluştu. Lütfen tekrar deneyiniz.";
            //return result;

            return new Result<T>()
            {
                StatusCode = statusCode,
                Count = 0,
                Data = null,
                Message = message,
                IsShow = isShow
            };
        }
    }
}
