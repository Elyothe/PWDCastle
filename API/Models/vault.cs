using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Vault
    {
        [Key]
        public int VaultId { get; set; } // Identifiant unique du coffre-fort

        [Required]
        public int UserId { get; set; } // Référence à l'utilisateur propriétaire du coffre-fort

        [Required, MaxLength(100)]
        public string VaultName { get; set; } // Nom du coffre-fort (ex : "Mon coffre", "Mes mots de passe")

        public DateTime CreatedAt { get; set; } // Date de création du coffre-fort

        public DateTime? LastAccessedAt { get; set; } // Date du dernier accès au coffre-fort (nullable)

        // Lien vers l'utilisateur propriétaire du coffre-fort
        public virtual User User { get; set; }
        
        
    }
}
