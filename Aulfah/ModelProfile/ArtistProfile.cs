using Aulfah.DAL.Model;
using Aulfah.Models;
using AutoMapper;

namespace Aulfah.PL.ModelProfile
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            CreateMap<ApplicationUser, Artist>();
        }
    }
}
