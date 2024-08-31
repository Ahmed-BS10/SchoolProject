using MediatR;
using SchoolProject.Core.Bases;

public class UpdatePasswordCommand : IRequest<Response<string>>
{
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string Email { get; set; }

}
