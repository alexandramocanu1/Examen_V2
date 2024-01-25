using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Examen_V2.Models
{
    public class Autor
    {
        public string? Nume { get; set; }
        public int EdituraId { get; set; }
        public Editura? Editura { get; set; }
        public ICollection<AutorCarte>? AutorCarti { get; set; }
    }

}
