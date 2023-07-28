﻿using System.ComponentModel.DataAnnotations;

namespace backend.Dtos
{
    public class UpdatePacijentDto
    {
        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string Pol { get; set; }
        [Required]
        public string DatumRodjenja { get; set; }
        [Required]
        public int Telefon { get; set; }
        [Required]
        public string Drzava { get; set; }
        [Required]
        public string Grad { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
