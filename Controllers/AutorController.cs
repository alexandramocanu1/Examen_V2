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
    public class AutorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AutorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("AllAuthors")]
        public async Task<IActionResult> GetAllAuthors()
        {
            try
            {
                var autoriDTO = _context.Autori
                    .Select(a => new AutorDTO
                    {
                        Id = a.Id,
                        Nume = a.Nume,
                        DateCreated = a.DateCreated,
                        LastModified = a.LastModified,
                    })
                    .ToList();

                return Ok(autoriDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateAutor")]
        public async Task<IActionResult> CreateAutor([FromBody] AutorDTO autorDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var autor = new Examen_V2.Autor
                {
                    Nume = autorDTO.Nume,
                    DateCreated = DateTime.Now,
                    LastModified = null,
                };

                _context.Autori.Add(autor);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAllAuthors), new { id = autor.Id }, autor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
