﻿using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using API.ApiDbContexts;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class challengeController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public challengeController(ApiDbContext context)
        {
            _context = context;
        }

        /**
         * 
         * Get all 
         * 
         */

        [HttpGet]
        public async Task<ActionResult<challenge>> getAllUsers()
        {
            var challenge = await _context.Challenges

                .ToListAsync();

            if (challenge == null)
            {
                return NotFound();
            }

            return Ok(challenge);
        }
        /**
         * 
         * Take only one User
         * 
         */
        [HttpGet("{id}")]
        public async Task<ActionResult<challenge>> getChallengeFromId(int id)
        {
            var users = await _context.Challenges
                .FirstOrDefaultAsync(u => u.idChal == id); // Utiliser '==' pour la comparaison

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpPost("create")]
        public async Task<ActionResult<challenge>> PostChallenge(ChallengeCreateDTO newChallDto)
        {
            // Vérification de la validité du modèle
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Créer un nouvel utilisateur à partir du DTO, sans les propriétés de navigation
            var challenge = new challenge
            {
                c_Status = newChallDto.c_Status,
                c_Desc = newChallDto.c_Desc,
                c_libelle = newChallDto.c_libelle,
                c_NbPoint = newChallDto.c_NbPoint,
                c_step = newChallDto.c_step
            };

            // Ajout de l'utilisateur à la base de données
            _context.Challenges.Add(challenge);
            await _context.SaveChangesAsync();

            // Renvoie un code 201 Created avec l'utilisateur créé
            return CreatedAtAction(nameof(getChallengeFromId), new { id = challenge.idChal }, challenge);
        }

        // DELETE: api/Users/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteChallenge(int id)
        {
            // Recherche de l'utilisateur par ID
            var chall = await _context.Challenges.FindAsync(id);
            if (chall == null)
            {
                return NotFound();
            }

            // Suppression de l'utilisateur de la base de données
            _context.Challenges.Remove(chall);
            await _context.SaveChangesAsync();

            // Renvoie un code 204 No Content
            return NoContent();
        }



        // faire le faite de programmer un challenge ...
        // rajouter un datetime avec tout ce qu'il faut
        // CE N'EST PAS LA PRIORITE 
    }
}