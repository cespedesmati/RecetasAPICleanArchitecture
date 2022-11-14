using Application.DTOs.Recipe;
using Application.DTOs.Review;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.User
{
    public class UserResponseDto
    {
        public Guid idUser { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public IList<RecipeResponseDto>? recipes { get; set; }
        public IList<ReviewResponseDto>? reviews { get; set; }
        public IList<Bookmark>? bookmarks { get; set; }
    }
}
