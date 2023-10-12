using AutoMapper;
using RéservationApp.Dto;
using RéservationApp.Models;

namespace RéservationApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();
            CreateMap<Nature_Marchandise, Nature_MarchandiseDto>();
            CreateMap<Nature_MarchandiseDto, Nature_Marchandise>();
            CreateMap<Marchandise,  MarchandiseDto>().ForMember(d => d.Libelle, a => a.MapFrom(s => s.Nature_Marchandise.Libelle));
            CreateMap<MarchandiseDto, Marchandise>();
            CreateMap<Vol, VolDto>();
            CreateMap<VolDto, Vol>();
            CreateMap<Reservation, ReservationDto>().ForMember(d => d.IDClient, a => a.MapFrom(s => s.Client.IDClient)).
                ForMember(d => d.IDMarchandise, a => a.MapFrom(s => s.Marchandise.IDMarchandise)).
                ForMember(d => d.NumVol, a => a.MapFrom(s => s.Vol.NumVol));
            CreateMap<ReservationDto, Reservation>();
            CreateMap<Vente, VenteDto>();
            CreateMap<LTA, LtaDto>();
            CreateMap<Tarif, TarifDto>();

            /**/
        }
    }
}
