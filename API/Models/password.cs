using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Password
  {
    [Key]
    public int PasswordId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public byte[] EncryptedPassword { get; set; }

    [Required]
    public byte[] Salt { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
  }

}
