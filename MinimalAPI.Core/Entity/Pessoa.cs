using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPI.Core.Entity;

[Table("Pessoas")]
public class Pessoa
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }    public int IdPessoa { get; set; }
    [Required]
    public string? Name { get; set; }
    [EmailAddress]
    [Required]
    public string? Email { get; set; }
    public DateTime CreatedAt { get; set; }
}
