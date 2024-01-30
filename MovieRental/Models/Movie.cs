using System;   
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRental.Models;

public class Movie{
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    [Display(Name = "Tytuł")]
    public required string Name { get; set; }
    [Required]
    [StringLength(20)]
    [Display(Name = "Gatunek")]
    public required string Genre { get; set; }
    [Range(1, 100)]
    [Display(Name = "Cena")]
    [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
    public decimal Price { get; set; }
    [Display(Name = "Data premiery")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    [Display(Name = "Aktorzy")]
    public required string Actors { get; set; }
    [Display(Name = "Opis")]
    public required string Description {  get; set; }
    //[Url]
    [StringLength(100)]
    public required string ImageUri { get; set; }

}
