using Application.DTOs.User;
using Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponse<IEnumerable<UserResponseDto>>> GetUsers();
        Task<BaseResponse<UserResponseDto>> GetUserById(Guid id);
        Task<BaseResponse<Guid>> CreateUser(UserRequestDto requestDTO);
        Task UpdateUser(UserUpdateRequestDto userDto, Guid id);
        Task<BaseResponse<bool>> DeleteUser(Guid id);
    }
}
