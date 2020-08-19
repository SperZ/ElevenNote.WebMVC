using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models.CategoryModels
{
    public class CategoryCreate
    {
        [Required]
        [MinLength(8, ErrorMessage ="The title must be at least 8 characters long" )] 
        [MaxLength(100, ErrorMessage ="The title is too long")]
        public string Title { get; set; }
    }
}
