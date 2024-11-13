using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using API.ApiDbContexts;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public usersController(ApiDbContext context)
        {
            _context = context;
        }

        /**
         * 
         * Get all 
         * 
         */
        
        [HttpGet]
        public async Task<ActionResult<users>> getAllUsers()
        {
            var users = await _context.Users
                               
                .ToListAsync();

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }
        /**
         * 
         * Take only one User
         * 
         */
        [HttpGet("{id}")]
        public async Task<ActionResult<users>> getAllOneUser(int id)
        {
            var users = await _context.Users
                .Include(c => c.status)
                .Include(c => c.challenge_Done)
                .FirstOrDefaultAsync(u => u.idUser == id); // Utiliser '==' pour la comparaison

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpPost("create")]
        public async Task<ActionResult<users>> PostUser(UserCreateDTO newUserDto)
        {
            // Vérification de la validité du modèle
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Créer un nouvel utilisateur à partir du DTO, sans les propriétés de navigation
            var newUser = new users
            {
                u_Nom = newUserDto.u_Nom,
                u_Mail = newUserDto.u_Mail,
                u_Password = newUserDto.u_Password,
                idgroupe = newUserDto.idgroupe,
                u_NbPoint = newUserDto.u_NbPoint,
                u_idEtab = newUserDto.u_idEtab
            };

            // Ajout de l'utilisateur à la base de données
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            // Renvoie un code 201 Created avec l'utilisateur créé
            return CreatedAtAction(nameof(getAllOneUser), new { id = newUser.idUser }, newUser);
        }

        // DELETE: api/Users/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            // Recherche de l'utilisateur par ID
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // Suppression de l'utilisateur de la base de données
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            // Renvoie un code 204 No Content
            return NoContent();
        }


    }
}
