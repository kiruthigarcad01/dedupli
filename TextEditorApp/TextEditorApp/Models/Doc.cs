﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TextEditorApp.Models
{
    public class Doc
    {
        public int Id { get; set; }

        public string Tittle { get; set; }

        public string Content { get; set; }

        [Required]
        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }
    }
}
