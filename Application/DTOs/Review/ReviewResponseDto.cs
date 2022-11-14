using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Review
{
    public class ReviewResponseDto
    {
        public Guid? idReview { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public int? score { get; set; }
        public Guid? idUser { get; set; }
        public Guid? idRecipe { get; set; }
    }
}
