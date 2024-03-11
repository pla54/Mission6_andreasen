﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_andreasen.Models
{
    public class Movie
    {

        //This is the model for the Movies being added to the database that also uses the category model.
        //Specific Title, Year, Edited and CopiedToPlex are required and/or have other restraints
        [Key]
        [Required]
        public int MovieID { get; set; }

        [ForeignKey("CategoryId")]
        [Required(ErrorMessage = "You Must Pick a Category")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        public string Title { get; set; }

        [Range(1888, 2024, ErrorMessage = "You must enter a valid year.")]
        public int Year { get; set; }

        public string? Director { get; set; }
        public string? Rating { get; set; }

        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        public bool CopiedToPlex { get; set; }
        public string? Notes { get; set; }
    }
}
