using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen_V2.DTOs;
using Examen_V2.Models;
using Examen_V2.Models.Base;
using Examen_V2.Data;

namespace Examen_V2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("AllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var cartiDTO = _context.Carti
                    .Select(c => new CarteDTO
                    {
                        Id = c.Id,
                        Titlu = c.Titlu,
                        Autori = c.AutoriCartiRelatii.Select(ac => new AutorDTO
                        {
                            Id = ac.Autor.Id,
                            Nume = ac.Autor.Nume,
                        }).ToList(),
                        DateCreated = c.DateCreated,
                        LastModified = c.LastModified,
                    })
                    .ToList();

                return Ok(cartiDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateBook")]
        public async Task<IActionResult> CreateBook([FromBody] CarteDTO carteDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

              var carte = new Carte
                {
                    Titlu = carteDTO.Titlu,
                    DateCreated = DateTime.Now,
                    LastModified = null,
                };

                carteDTO.Autori.ForEach(autorDTO =>
                {
                    var autor = new Autor
                    {
                        Nume = autorDTO.Nume,
                    };

                    carte.AutoriCartiRelatii.Add(new AutorCarteRelatie
                    {
                        Autor = autor,
                        Carte = carte
                    });
                });
            
                _context.Carti.Add(carte);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAllBooks), new { id = carte.Id }, carte);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
