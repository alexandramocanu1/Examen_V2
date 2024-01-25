using System;

namespace Examen_V2.DTOs
{
    public class CarteDTO
    {
        public Guid Id { get; set; }
        public string? Titlu { get; set; }
        public string? Descriere { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
