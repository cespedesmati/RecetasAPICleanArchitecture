using Application.DTOs.Recipe;
using Application.DTOs.User;
using Application.Helpers;
using Application.Services.Interfaces;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<Guid>> CreateUser(UserRequestDto userDTO)
        {
            var response = new BaseResponse<Guid>();
            var userExist = await unitOfWork.UserRepository.GetByMail(userDTO.email);
            if (userExist is not null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXISTS;
            }
            User user = mapper.Map<User>(userDTO);
            await unitOfWork.UserRepository.Insert(user);
            int result = await unitOfWork.SaveChangesAsync();
            if (result > 0)
            {
                response.IsSuccess = true;
                response.Data = user.idUser;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> DeleteUser(Guid id)
        {
            var user = await unitOfWork.UserRepository.GetById(id);
            await unitOfWork.UserRepository.Delete(user);
            int result = await unitOfWork.SaveChangesAsync();
            var response = new BaseResponse<bool>();
            if (result > 0)
            {
                response.IsSuccess = true;
                response.Data = true;
                response.Message = ReplyMessage.MESSAGE_DELETE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }

        public async Task<BaseResponse<UserResponseDto>> GetUserById(Guid id)
        {
            var response = new BaseResponse<UserResponseDto>();
            var recipe = await unitOfWork.UserRepository.GetById(id);
            if (recipe is not null)
            {
                response.IsSuccess = true;
                response.Data = mapper.Map<UserResponseDto>(recipe);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }

        public async Task<BaseResponse<IEnumerable<UserResponseDto>>> GetUsers()
        {
            var response = new BaseResponse<IEnumerable<UserResponseDto>>();
            var users = await unitOfWork.UserRepository.GetAll();
            if (users is not null)
            {
                response.IsSuccess = true;
                response.Data = mapper.Map<IEnumerable<UserResponseDto>>(users);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }

        public async Task UpdateUser(UserUpdateRequestDto userDto, Guid id)
        {
            User user = await unitOfWork.UserRepository.GetById(id);
            user.firstName = userDto.firstName ?? user.firstName;
            user.lastName = userDto.lastName ?? user.lastName;
            user.email = userDto.email ?? user.email;
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<BaseResponse<bool>> AddBookmark(Guid idUser, Guid idRecipe)
        {
            var response = new BaseResponse<bool>();
            var user = await unitOfWork.UserRepository.GetById(idUser);
            var recipe = await unitOfWork.RecipeRepository.GetById(idRecipe);
            var exists = user.bookmarks!.Where(x => x.idRecipe == idRecipe).FirstOrDefault();
            if (exists is not null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXISTS;
            }
            user.bookmarks = user.bookmarks!.Concat(new[] { new Bookmark { recipe = recipe, user = user } }).ToArray();
            //user.bookmarks!.Add(new Bookmark { recipe = recipe, user = user });

            int result = await unitOfWork.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Data = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> DeleteBookmark(Guid idUser, Guid idRecipe)
        {
            var response = new BaseResponse<bool>();
            var recipe = await unitOfWork.RecipeRepository.GetById(idRecipe);
            var user = await unitOfWork.UserRepository.GetAllBookmarks(idUser);
            var exists = user.bookmarks!.Where(x => x.idRecipe == idRecipe).FirstOrDefault();
            if (exists is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            user.bookmarks = user.bookmarks!.Where(x => x.idRecipe != idRecipe).ToList(); 
            //user.bookmarks.Remove(exists!);
            int result = await unitOfWork.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Data = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }

        public async Task<BaseResponse<IEnumerable<RecipeResponseDto>>> GetBookmarksByUser(Guid idUser)
        {
            var response = new BaseResponse<IEnumerable<RecipeResponseDto>>();

            var recipes = (await unitOfWork.UserRepository.GetAllBookmarks(idUser))
                .bookmarks!.Select(x => x.recipe);

            if (recipes is null || !recipes.Any())
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            else
            {
                response.IsSuccess = true;
                response.Data = recipes.Select(x => new RecipeResponseDto { IdRecipe = x.idRecipe, nameRecipe = x.nameRecipe }).ToList();
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            return response;
        }
    }
}