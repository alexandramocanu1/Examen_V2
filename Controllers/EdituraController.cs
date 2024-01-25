using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Examen_V2.Data;
using Examen_V2.DTOs;
using Examen_V2.Models;


namespace Examen_V2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EdituraController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public EdituraController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("AllPublishers")]
        public IEnumerable<EdituraDTO> GetAllPublishers()
        {
            var edituriDTO = _context.Edituri
                .Select(e => new EdituraDTO
                {
                    Id = e.Id,
                    Nume = e.Nume,
                    DateCreated = e.DateCreated,
                    LastModified = e.LastModified,
                })
                .ToList();

            return edituriDTO;
        }

        [HttpPost("CreatePublisher")]
        public ActionResult CreatePublisher([FromBody] EdituraDTO edituraDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var editura = new Editura
                {
                    Nume = edituraDTO.Nume,
                    DateCreated = DateTime.Now,
                    LastModified = null,
                };

                _context.Edituri.Add(editura);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetAllPublishers), new { id = editura.Id }, editura);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
