using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorWebAppMovies.Models;

public class Movie
{
    // Required by EF Core (Entity framework) and db to track records
    // Id is the primary key
    public int Id { get; set; }

    // the ? indicates this property is nullable
    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string? Title { get; set; }

    public DateOnly ReleaseDate { get; set; }

    [Required]
    [StringLength(30)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z()\s\s-]*$")]
    public string? Genre { get; set; }

    [Range(0, 100)]
    [DataType(DataType.Currency)]
    // Database column is a decimal of 18 digits and 2 decimal places
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    // @ means C# treats it as a verbatim string literal and backslashes are
    // treated as literal characters
    // ^ beginning of string
    // $ end of string
    // () grouping to look for one of the options inside the block
    [Required]
    [RegularExpression(@"^(G|PG|PG-13|R|NC-17)$")]
    public string? Rating { get; set; }
}