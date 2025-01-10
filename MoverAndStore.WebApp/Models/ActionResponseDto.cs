using Newtonsoft.Json;

namespace MoverAndStore.WebApp.Models
{
    public class ActionResponseDto<T>
    {
        public ActionResponseDto(bool isSuccess = true)
        {
            IsSuccess = isSuccess;
            Type type = typeof(T);

            if (type.FullName != "System.String")
            {
                Data = Activator.CreateInstance<T>();
            }
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }

        public void SetSuccess(T data)
        {
            IsSuccess = true;
            Data = data;
        }

        public void SetSuccess(string message)
        {
            IsSuccess = true;
            Message = message;
        }

        public void SetSuccess(string message, T data)
        {
            IsSuccess = true;
            Message = message;
            Data = data;
        }

        public void SetError(string message)
        {
            IsSuccess = false;
            Message = message;
        }

        public void SetError(string message, T data)
        {
            IsSuccess = false;
            Message = message;
            Data = data;
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
