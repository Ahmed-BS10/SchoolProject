using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Users.Command.Modle;
using SchoolProject.Core.Features.Users.Command.Moudles;
using SchoolProject.Core.Features.Users.Query.Moudles;
using SchoolProject.Core.Features.Users.Responses;
using SchoolProject.Core.Wapper;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Users.Command.Handler
{
    public class UserCommandHandler : ResponseHandler 
                              ,IRequestHandler<AddUserCommand,Response<string>>
                              ,IRequestHandler<EditUserCommand, Response<string>>
                              ,IRequestHandler<DeleteUserCommand , Response<string>>
                              ,IRequestHandler<ChangedPasswordUserCommand , Response<string>>


    {
        #region Field
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;


        #endregion

        #region Constrcutor(s)
        public UserCommandHandler(UserManager<ApplicationUser> userManager, IMapper mapper, IUserService userService)
        {
            _userManager=userManager;
            _mapper=mapper;
            _userService=userService;
        }


        #endregion

        #region Funcation Handler
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            // Mapping 
            var userMapper = _mapper.Map<ApplicationUser>(request);
            var addResult = await _userService.AddUserAsync(userMapper, request.Password);

            switch (addResult)
            {
                case "EmailAlreadyExists": return NotFound<string>("FailedToSendEmail");
                case "UserNameAlreadyExists": return NotFound<string>("EmailAlreadyExists");
                case "FailedToSendEmail": return BadRequest<string>("FailedToSendEmail");
                case "Failed": return BadRequest<string>("Failed");
                case "Success": return Success<string>("");
            }

            return BadRequest<string>(addResult);

            //// if email is exist
            //var user = await _userManager.FindByEmailAsync(request.Email);
            //if (user != null) return BadRequest<string>("the email is already register");

            //// if name if exist 
            //var userName = await _userManager.FindByNameAsync(request.UserName);
            //if (userName != null) return BadRequest<string>("the name is already exist ");

            //// Mapping 
            //var userMapper = _mapper.Map<ApplicationUser>(request);

            //// create
            // var createResult = await _userManager.CreateAsync(userMapper, request.Password);
            ////Succeeded

            ////Add Default Role
            //await _userManager.AddToRoleAsync(userMapper, "User");
            //if (createResult.Succeeded)
            //    return Created("Add");
            ////Failed
            //return BadRequest<string>(createResult.Errors.FirstOrDefault().Description);



        }

        public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
          
            var oldUser = await _userManager.FindByIdAsync(request.UserId);
            if (oldUser == null) return NotFound<string>();
            var newUser = _mapper.Map(request,oldUser);
            var result =   await _userManager.UpdateAsync(newUser);
            if (!result.Succeeded) return BadRequest<string>();

            return Success("");
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null) return NotFound<string>();
           var resulte = await _userManager.DeleteAsync(user);
            if (!resulte.Succeeded) return BadRequest<string>();
            return Deleted<string>();
        }

        public async Task<Response<string>> Handle(ChangedPasswordUserCommand request, CancellationToken cancellationToken)
        {
           var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
            if (user == null) return NotFound<string>("no user here");
            var result = await _userManager.ChangePasswordAsync(user, request.CurretPassword, request.NewPassword);
            if(!result.Succeeded) return BadRequest<string>();
            return Success("changePassword doen -)_(-");
        }


        #endregion
    }
}
