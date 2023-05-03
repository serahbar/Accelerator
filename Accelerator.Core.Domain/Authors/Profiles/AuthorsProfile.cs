using Accelerator.Core.Domain.Authors.Dtoes;
using Accelerator.Core.Domain.Authors.Entities;
using Accelerator.Framework.Extentions;
using AutoMapper;

namespace Accelerator.Core.Domain.Authors.Profiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            CreateMap<Author,AuthorDto>()
                .ForMember(dest => dest.Name, opt =>
                    opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Age, opt =>
                    opt.MapFrom(src => src.DateOfBirth.GetCurrentAge(src.DateOfDeath)));

            CreateMap<AuthorForCreationDto, Entities.Author>();

            CreateMap<Author,AuthorFullDto>();

            CreateMap<AuthorForCreationWithDateOfDeathDto,Author>();
        }
    }
}
