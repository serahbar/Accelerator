using Accelerator.Core.Domain.Autors.Dtoes;
using Accelerator.Core.Domain.Autors.Entities;
using Accelerator.Framework.Extentions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accelerator.Core.Domain.Autors.Profiles
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
