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
}