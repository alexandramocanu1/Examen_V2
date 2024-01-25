using Microsoft.AspNetCore.Mvc;

namespace Examen_V2.Models
{
    public class AutorCarte
    {
        public int AutorId { get; set; }
        public Autor? Autor { get; set; }
        public int CarteId { get; set; }
        public Carte? Carte { get; set; }
    }

}
