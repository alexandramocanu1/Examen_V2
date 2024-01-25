using System;

namespace Examen_V2.DTOs
{
    public class EdituraDTO
    {
        public Guid Id { get; set; }
        public string? Nume { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
