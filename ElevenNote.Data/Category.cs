﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [MinLength(8),MaxLength(50)]
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
