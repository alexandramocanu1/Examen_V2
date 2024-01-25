using Microsoft.AspNetCore.Mvc;

namespace Examen_V2.Models
{
    public class Carte
    {
        public string? Titlu { get; set; }
        public ICollection<AutorCarte>? AutorCarti { get; set; }
    }

}
