public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [MaxLength(100)]  // Par exemple, limite de longueur pour le nom d'utilisateur
    public string UserName { get; set; }

    [Required]
    public byte[] MasterKeyHash { get; set; } // Clé maîtresse de l'utilisateur (chiffrée)

    // Cette propriété est utilisée pour la relation avec la table Password
    public virtual ICollection<Password> Passwords { get; set; }

    public DateTime CreatedAt { get; set; } // Date de création de l'utilisateur

    public DateTime LastLogin { get; set; } // Date de dernier login
}   
