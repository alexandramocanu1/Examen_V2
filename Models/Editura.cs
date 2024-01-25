using System;
using System.Collections.Generic;

namespace Examen_V2.Models
{
    public class Editura
    {
        public Guid Id { get; set; }
        public string? Nume { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastModified { get; set; }
        public ICollection<Autor>? Autori { get; set; }
    }
}
