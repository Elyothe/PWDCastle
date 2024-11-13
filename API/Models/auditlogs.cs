using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ConnectionLog
    {
        [Key]
        public int LogId { get; set; } // Identifiant unique pour chaque log

        [Required]
        public int UserId { get; set; } // L'ID de l'utilisateur qui se connecte

        [Required]
        [MaxLength(100)]
        public string UserName { get; set; } // Le nom de l'utilisateur qui se connecte

        [Required]
        public DateTime ConnectionDate { get; set; } // Date et heure de la connexion

        // Lien vers l'utilisateur, si vous avez une relation avec la table User
        public virtual User User { get; set; }
    }
}
