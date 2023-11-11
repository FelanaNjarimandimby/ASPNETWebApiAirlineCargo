using AutoMapper;
using RéservationApp.Dto;
using RéservationApp.Models;

namespace RéservationApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Aeroport, AeroportDto>().ForMember(d => d.CompagnieID, a => a.MapFrom(s => s.Compagnie.id));
            CreateMap<AeroportDto, Aeroport>();
            CreateMap<Agent, AgentDto>();
            CreateMap<AgentDto, Agent>();
            CreateMap<AvionCargo, AvionCargoDto>();
            CreateMap<AvionCargoDto, AvionCargo>();
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();
            CreateMap<Compagnie, CompagnieDto>();
            CreateMap<CompagnieDto, Compagnie>();
            CreateMap<CoutFret, CoutFretDto>().ForMember(d => d.AgentID, a => a.MapFrom(s => s.Agent.id)); 
            CreateMap<CoutFretDto, CoutFret>();
            CreateMap<CoutFret, CoutDto>();
            CreateMap<Escale, EscaleDto>().ForMember(d => d.VolID, a => a.MapFrom(s => s.VolCargo.id));
            CreateMap<EscaleDto, Escale>();
            CreateMap<Itineraire, ItineraireDto>();
            CreateMap<ItineraireDto, Itineraire>();
            CreateMap<LTA, LtaDto>().ForMember(d => d.DateVente, a => a.MapFrom(s => s.Vente.VenteDate))
                .ForMember(d => d.AgentNom, a => a.MapFrom(s => s.Vente.Agent.AgentNom))
                .ForMember(d => d.AgentContact, a => a.MapFrom(s => s.Vente.Agent.AgentContact))
                .ForMember(d => d.Destinataire, a => a.MapFrom(s => s.Vente.Reservation.NomDestinataire))
                .ForMember(d => d.ClientNom, a => a.MapFrom(s => s.Vente.Reservation.Client.ClientNom))
                .ForMember(d => d.ClientContact, a => a.MapFrom(s => s.Vente.Reservation.Client.ClientContact))
                .ForMember(d => d.MarchandiseDesignation, a => a.MapFrom(s => s.Vente.Reservation.Marchandise.MarchandiseDesignation))
                .ForMember(d => d.MarchandiseNombre, a => a.MapFrom(s => s.Vente.Reservation.Marchandise.MarchandiseNombre))
                .ForMember(d => d.MarchandisePoids, a => a.MapFrom(s => s.Vente.Reservation.Marchandise.MarchandisePoids))
                .ForMember(d => d.MarchandiseVolume, a => a.MapFrom(s => s.Vente.Reservation.Marchandise.MarchandiseVolume))
                .ForMember(d => d.Nature, a => a.MapFrom(s => s.Vente.Reservation.Marchandise.Nature_Marchandise.NatureMarchandiseLibelle))
                .ForMember(d => d.Tarif, a => a.MapFrom(s => s.Vente.Reservation.Marchandise.Nature_Marchandise.TypeTarif.TarifLibelle))
                .ForMember(d => d.VolNumero, a => a.MapFrom(s => s.Vente.Reservation.VolCargo.VolNumero))
                .ForMember(d => d.DateHeureDepart, a => a.MapFrom(s => s.Vente.Reservation.VolCargo.VolDateHeureDepart))
                .ForMember(d => d.DateHeureArrive, a => a.MapFrom(s => s.Vente.Reservation.VolCargo.VolDateHeureArrivee))
                .ForMember(d => d.ItineraireDepart, a => a.MapFrom(s => s.Vente.Reservation.VolCargo.Itineraire.ItineraireDepart))
                .ForMember(d => d.ItineraireArrive, a => a.MapFrom(s => s.Vente.Reservation.VolCargo.Itineraire.ItineraireArrive))
                .ForMember(d => d.AvionModele, a => a.MapFrom(s => s.Vente.Reservation.VolCargo.AvionCargo.AvionModele))
                .ForMember(d => d.AvionCapacite, a => a.MapFrom(s => s.Vente.Reservation.VolCargo.AvionCargo.AvionCapacite))
                .ForMember(d => d.AeroportNom, a => a.MapFrom(s => s.Vente.Reservation.VolCargo.Aeroport.AeroportNom))
                .ForMember(d => d.AeroportContact, a => a.MapFrom(s => s.Vente.Reservation.VolCargo.Aeroport.AeroportContact))
                .ForMember(d => d.AeroportLocalisation, a => a.MapFrom(s => s.Vente.Reservation.VolCargo.Aeroport.AeroportLocalisation))
                .ForMember(d => d.CompagnieNom, a => a.MapFrom(s => s.Vente.Reservation.VolCargo.Aeroport.Compagnie.CompagnieNom));
            CreateMap<LtaDto, LTA>();
            CreateMap<LTA, LtaAdminDto>();
            CreateMap<LtaAdminDto, LTA>();
            CreateMap<Marchandise,  MarchandiseDto>().ForMember(d => d.NatureMarchandiseLibelle, a => a.MapFrom(s => s.Nature_Marchandise.NatureMarchandiseLibelle));
            CreateMap<MarchandiseDto, Marchandise>();
            CreateMap<Nature_Marchandise, Nature_MarchandiseDto>().ForMember(d => d.TarifLibelle, a => a.MapFrom(s => s.TypeTarif.TarifLibelle));
            CreateMap<Nature_MarchandiseDto, Nature_Marchandise>();
            CreateMap<Reservation, ReservationDto>().ForMember(d => d.ClientID, a => a.MapFrom(s => s.Client.id)).
                ForMember(d => d.MarchandiseID, a => a.MapFrom(s => s.Marchandise.id)).
                ForMember(d => d.VolID, a => a.MapFrom(s => s.VolCargo.id)).
                ForMember(d => d.ItineraireID, a => a.MapFrom(s => s.Itineraire.id));
            CreateMap<ReservationDto, Reservation>();
            CreateMap<TypeTarif, TypeTarifDto>();
            CreateMap<TypeTarifDto, TypeTarif>();
            CreateMap<Vente, VenteDto>().ForMember(d => d.ReservationID, a => a.MapFrom(s => s.Reservation.id))
                .ForMember(d => d.AgentID, a => a.MapFrom(s => s.Agent.id));
            CreateMap<VenteDto, Vente>();
            CreateMap<VolCargo, VolCargoDto>().ForMember(d => d.AvionID, a => a.MapFrom(s => s.AvionCargo.id))
                .ForMember(d => d.AeroportID, a => a.MapFrom(s => s.Aeroport.id))
                .ForMember(d => d.ItineraireID, a => a.MapFrom(s => s.Itineraire.id));
            CreateMap<VolCargoDto, VolCargo>();

            CreateMap<Reservation, ReservationClientDto>().ForMember(d => d.ClientID, a => a.MapFrom(s => s.Client.id)).
                ForMember(d => d.Designation, a => a.MapFrom(s => s.Marchandise.MarchandiseDesignation)).
                ForMember(d => d.NombreColis, a => a.MapFrom(s => s.Marchandise.MarchandiseNombre)).
                ForMember(d => d.Poids, a => a.MapFrom(s => s.Marchandise.MarchandisePoids)).
                ForMember(d => d.Volume, a => a.MapFrom(s => s.Marchandise.MarchandiseVolume)).
                ForMember(d => d.Nature, a => a.MapFrom(s => s.Marchandise.Nature_Marchandise.NatureMarchandiseLibelle)).
                ForMember(d => d.Tarif, a => a.MapFrom(s => s.Marchandise.Nature_Marchandise.TypeTarif.TarifLibelle)).
                ForMember(d => d.VolID, a => a.MapFrom(s => s.VolCargo.id)).
                ForMember(d => d.ItineraireDepart, a => a.MapFrom(s => s.Itineraire.ItineraireDepart)).
                ForMember(d => d.ItineraireArrive, a => a.MapFrom(s => s.Itineraire.ItineraireArrive));
            CreateMap<ReservationClientDto, Reservation>();

            CreateMap<Notification, NotificationDto>().ForMember(d => d.ReservationID, a => a.MapFrom(s => s.Reservation.id))
    .ForMember(d => d.ClientNom, a => a.MapFrom(s => s.Client.ClientNom))
    .ForMember(d => d.ClientID, a => a.MapFrom(s => s.Client.id)); ;
            CreateMap<NotificationDto, Notification>();
            
            /**/
        }
    }
}

