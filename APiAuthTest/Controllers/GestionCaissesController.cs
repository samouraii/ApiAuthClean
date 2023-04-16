using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APiAuthTest.Model;
using APiAuthTest.Model.ApplicationClient;
using AutoMapper;
using APiAuthTest.Services.UserService;
using Microsoft.AspNetCore.Authorization;

namespace APiAuthTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "GestionCaisse")]
    public class GestionCaissesController : ControllerBase
    {
        private readonly UserContext _context;
        private readonly IMapper _mapper;
        private readonly ISocieteService _societe;
        private readonly IUserService _userService;
        public GestionCaissesController(UserContext context, IMapper mapper, ISocieteService societe, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _societe = societe;
            _userService = userService;
        }

        // GET: api/GestionCaisses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GestionCaisse>>> GetgestionCaisses()
        {
          if (_context.gestionCaisses == null)
          {
              return NotFound();
          }
            return await _context.gestionCaisses.ToListAsync();
        }

        // GET: api/GestionCaisses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GestionCaisse>> GetGestionCaisse(long id)
        {
          if (_context.gestionCaisses == null)
          {
              return NotFound();
          }
            var gestionCaisse = await _context.gestionCaisses.FindAsync(id);

            if (gestionCaisse == null)
            {
                return NotFound();
            }

            return gestionCaisse;
        }

        // PUT: api/GestionCaisses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGestionCaisse(long id, GestionCaisse gestionCaisse)
        {
            /*if (id != gestionCaisse.Id)
            {
                return BadRequest();
            }*/

            _context.Entry(gestionCaisse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GestionCaisseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GestionCaisses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GestionCaisse>> PostGestionCaisse(GestionCaisseDto gestionCaisse)
        {
          if (_context.gestionCaisses == null)
          {
              return Problem("Entity set 'UserContext.gestionCaisses'  is null.");
          }
            var newGestionCaisse = _mapper.Map<GestionCaisse>(gestionCaisse);
           
            newGestionCaisse.societe = _societe.GetSociete(gestionCaisse.societe);
            newGestionCaisse.EncoderPar = _userService.GetUser(1);
            _context.gestionCaisses.Add(newGestionCaisse);
            await _context.SaveChangesAsync();

            return Ok(newGestionCaisse);
        }

        // DELETE: api/GestionCaisses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGestionCaisse(long id)
        {
            if (_context.gestionCaisses == null)
            {
                return NotFound();
            }
            var gestionCaisse = await _context.gestionCaisses.FindAsync(id);
            if (gestionCaisse == null)
            {
                return NotFound();
            }

            _context.gestionCaisses.Remove(gestionCaisse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GestionCaisseExists(long id)
        {
            // return (_context.gestionCaisses?.Any(e => e.Id == id)).GetValueOrDefault();
            return false;
        }
    }
}
