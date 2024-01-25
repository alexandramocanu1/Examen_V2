// UserDTOs.cs
using System;

namespace Examen_V2.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
    }

    public class UserProfileDTO
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
    }
} 
