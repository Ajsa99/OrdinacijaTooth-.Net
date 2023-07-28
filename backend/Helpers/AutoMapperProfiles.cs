using AutoMapper;
using backend.Dtos;
using backend.Model;

namespace backend.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Korisnik, GetKorisnikDto>();

            CreateMap<Pacijent, GetPacijentDto>();
            CreateMap<PacijentDto, Pacijent>().ReverseMap();
            CreateMap<UpdatePacijentDto, Pacijent>();

            CreateMap<Pregled, GetPregledDto>();
            CreateMap<PregledDto, Pregled>().ReverseMap();

            CreateMap<Termin, GetTerminiDto>();
            CreateMap<TerminDto, Termin>().ReverseMap();
        }
    }
}
