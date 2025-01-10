﻿namespace MoverAndStore.WebApp.Models
{
    public class UserDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }

    public class UserDtoApiResponse
    {
        public List<UserDto> Data { get; set; }
    }
    public class DeleteUserRequest
    {
        public string UserId { get; set; }
    }


}
