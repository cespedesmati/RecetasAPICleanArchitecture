using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Review
{
    public class ReviewRequestDto
    {
        public string? title { get; set; }
        public string? description { get; set; }
        public int? score { get; set; }
    }
}
