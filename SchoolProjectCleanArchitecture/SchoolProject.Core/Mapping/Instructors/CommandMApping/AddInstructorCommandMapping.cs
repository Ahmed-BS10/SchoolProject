using SchoolProject.Core.Features.Instructor.Command.Modlue;
using SchoolProject.Data.Entities;


namespace SchoolProject.Core.Mapping.Instructors
{
    public partial class InstructorProfile
    {
        public void AddInstructorCommandMapping()
        {
            CreateMap<AddInstructorCommand, Instructor>()
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.Image));

        }

    }
}
