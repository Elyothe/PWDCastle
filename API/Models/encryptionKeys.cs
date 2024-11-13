using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class EncryptionKey
  {
    [Key]
    public int KeyId { get; set; }

    // La clé de chiffrement utilisée pour chiffrer les mots de passe
    [Required]
    public byte[] Key { get; set; }

    // La date de création de la clé
    [Required]
    public DateTime CreatedAt { get; set; }

    // Identifiant de l'utilisateur auquel cette clé appartient
    [Required]
    public int UserId { get; set; }

    // Clé maîtresse pour chiffrer la clé de chiffrement
    [Required]
    public byte[] MasterKeyHash { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
  }
}


