﻿namespace MoverAndStore.WebApp.Models
{
    public class LoginResponse
    {
        public string Success { get; set; }

        public string Message { get; set; }

        public Guid userId { get; set; }
    }
}
