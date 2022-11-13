using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Application.Helpers;
using Application.DTOs.User;
using Application.Services.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<UserResponseDto>>>> GetUsers()
        {
            var response = await userService.GetUsers();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<IEnumerable<UserResponseDto>>>> GetUserById(Guid id)
        {
            var response = await userService.GetUserById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Guid>>> CreateUser([FromBody] UserRequestDto userDto)
        {
            var response = await userService.CreateUser(userDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser([FromBody] UserUpdateRequestDto userUpdate, Guid id)
        {
            if(!ModelState.IsValid) { return BadRequest("Datos invalidos"); }
            await userService.UpdateUser(userUpdate, id);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var response = await userService.DeleteUser(id);
            return Ok(response);
        }
    }
}
