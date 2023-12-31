﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RéservationApp.Data;
using RéservationApp.Dto;
using RéservationApp.Interfaces;
using RéservationApp.Migrations;
using RéservationApp.Models;
using RéservationApp.Repository;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace RéservationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : Controller
    {
        private readonly IReservationRepository _reservationRespository;
        private readonly IClientRepository _clientRepository;
        private readonly IMarchandiseRepository _marchandiseRepository;
        private readonly IVolCargoRepository _volCargoRepository;
        private readonly IItineraireRepository _itineraireRepository;
        private readonly INature_MarchandiseRepository _nature_MarchandiseRepository;
        private readonly IReservationClientRepository _reservationClientRepository;
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ReservationController(
            IReservationRepository reservationRepository,
            IClientRepository clientRepository,
            IMarchandiseRepository marchandiseRepository,
            IVolCargoRepository volCargoRepository,
            IItineraireRepository itineraireRepository,
            INature_MarchandiseRepository nature_MarchandiseRepository,
            IReservationClientRepository reservationClientRepository,
            DataContext context,
            IMapper mapper)
        {
            _reservationRespository = reservationRepository;
            _clientRepository = clientRepository;
            _marchandiseRepository = marchandiseRepository;
            _volCargoRepository = volCargoRepository;
            _itineraireRepository = itineraireRepository;
            _nature_MarchandiseRepository = nature_MarchandiseRepository;
            _reservationClientRepository = reservationClientRepository;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reservation>))]
        public IActionResult GetReservationsClient()
        {
            var reservations = _mapper.Map<List<ReservationClientDto>>(_reservationClientRepository.GetReservations());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reservations);
        }

        [HttpGet("Reservation")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reservation>))]
        public IActionResult GetReservations()
        {
            var reservations = _mapper.Map<List<ReservationDto>>(_reservationClientRepository.GetReservations());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reservations);
        }

        [HttpGet("{reservationID}")]
        [ProducesResponseType(200, Type = typeof(Reservation))]
        [ProducesResponseType(400)]

        public IActionResult GetReservation(int reservationID)
        {
            if (!_reservationRespository.ReservationExists(reservationID))
                return NotFound();

            var reservation = _mapper.Map<ReservationDto>(_reservationRespository.GetReservation(reservationID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reservation);
        }

        [HttpGet("clientAdmin/{ClientID}")]
        [ProducesResponseType(200, Type = typeof(Reservation))]
        [ProducesResponseType(400)]

        public IActionResult GetReservationsofClient(int ClientID)
        {
            var reservations = _mapper.Map<List<ReservationDto>>(_reservationRespository.GetReservationsofClient(ClientID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reservations);
        }

        [HttpGet("client/{ClientID}")]
        [ProducesResponseType(200, Type = typeof(Reservation))]
        [ProducesResponseType(400)]

        public IActionResult GetClientReservations(int ClientID)
        {
            var reservations = _mapper.Map<List<ReservationClientDto>>(_reservationClientRepository.GetReservationsofClient(ClientID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reservations);
        }

        [HttpGet("confirme")]
        [ProducesResponseType(200, Type = typeof(Reservation))]
        [ProducesResponseType(400)]

        public IActionResult GetReservationsConfirme()
        {
            var reservations = _mapper.Map<List<ReservationClientDto>>(_reservationRespository.GetReservationByEtat("Confirmé"));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reservations);
        }

        [HttpGet("reserve")]
        [ProducesResponseType(200, Type = typeof(Reservation))]
        [ProducesResponseType(400)]

        public IActionResult GetReservationsReserve()
        {
            var reservations = _mapper.Map<List<ReservationClientDto>>(_reservationRespository.GetReservationByEtat("Reservé"));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reservations);
        }

        [HttpGet("reservationNonConfirme")]
        [ProducesResponseType(200, Type = typeof(Reservation))]
        [ProducesResponseType(400)]

        public IActionResult GetReservationNonConfirme()
        {
            var reservationByNotification = _mapper.Map<List<ReservationDto>>(_reservationRespository.GetReservationByVue("Oui"));

            var reservationMap = reservationByNotification.Where(r => r.ReservationEtat == "Reservé");
            

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(reservationMap);
        }
        

        [HttpPost("ClientReservation")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public IActionResult CreateReservationClient([FromBody] ReservationClientDto reservationCreate)
        {
            if (reservationCreate == null)
                return StatusCode(422, ModelState);



            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var itineraire = _itineraireRepository.GetItineraire(reservationCreate.ItineraireDepart, reservationCreate.ItineraireArrive);
            var vol = _volCargoRepository.GetVolByItineraire(itineraire.id);
            
            var client = _clientRepository.GetClient(reservationCreate.ClientID);
            var nature = _nature_MarchandiseRepository.GetNature(reservationCreate.Nature);

            var marchandiseCreate = new Marchandise
            {
                MarchandiseDesignation = reservationCreate.Designation,
                MarchandiseNombre = reservationCreate.NombreColis,
                MarchandisePoids = reservationCreate.Poids,
                MarchandiseVolume = reservationCreate.Volume,
                Nature_Marchandise = nature,
            };
            _marchandiseRepository.CreateMarchandise(marchandiseCreate);

            var marchandiseget = _marchandiseRepository.GetMarchandises().Where(
            m => m.MarchandiseDesignation == reservationCreate.Designation
             && m.MarchandiseNombre == reservationCreate.NombreColis
             && m.MarchandisePoids == reservationCreate.Poids
             && m.MarchandiseVolume == reservationCreate.Volume
             && m.Nature_Marchandise.NatureMarchandiseLibelle == nature.NatureMarchandiseLibelle)
             .FirstOrDefault();


            var marchandise = _marchandiseRepository.GetMarchandise(marchandiseget.id); 

            var reservationMap = new Reservation
            {
                NomDestinataire = reservationCreate.NomDestinataire,
                DateExpeditionSouhaite = reservationCreate.DateExpeditionSouhaite,
                ReservationExigences = reservationCreate.ReservationExigences,
                ReservationEtat = "Reservé",
                ReservationDate = DateTime.UtcNow,
                Itineraire = itineraire,
                VolCargo = vol,
                Marchandise = marchandise,
                Client = client,
            };

            //Récuperation du client

            if (!_clientRepository.ClientExists(reservationCreate.ClientID))
            {
                ModelState.AddModelError("", "Ce client existe pas!");
                return StatusCode(422, ModelState);
            }

            //Récuperation du vol
            if (vol == null)
            {
                ModelState.AddModelError("", "Pas de vol disponible pour votre itinéraire!");
                return StatusCode(422, ModelState);
            }

            if (!_reservationRespository.CreateReservation(reservationMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Réservation ajoutée avec succès");

        }

        [HttpPut("{reservationID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateReservation(int reservationID, [FromBody] ReservationDto reservationUpdate)
        {
            if (reservationUpdate == null)
                return BadRequest(ModelState);

            if (reservationID != reservationUpdate.id)
                return BadRequest(ModelState);

            if (!_reservationRespository.ReservationExists(reservationID))
                return NotFound();

            if(!ModelState.IsValid) 
                return BadRequest();

            var reservationMap = _mapper.Map<Reservation>(reservationUpdate);

            if(!_reservationRespository.UpdateReservation(reservationMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Modification de la réservation avec succès");
        }

        [HttpPut("Confirmer/{reservationID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateConfirmReservation(int reservationID, [FromBody] ReservationClientDto reservationUpdate)
        {
            if (reservationUpdate == null)
                return BadRequest(ModelState);

            if (reservationID != reservationUpdate.id)
                return BadRequest(ModelState);

            if (!_reservationRespository.ReservationExists(reservationID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();



            var reservation = _reservationClientRepository.GetReservations().Where(
            c => c.id == reservationID).FirstOrDefault();

            var marchandise = reservation.Marchandise;

            if (marchandise != null)
            {
                marchandise.MarchandiseDesignation = reservationUpdate.Designation;
                marchandise.MarchandiseNombre = reservationUpdate.NombreColis;
                marchandise.MarchandisePoids = reservationUpdate.Poids;
                marchandise.MarchandiseVolume = reservationUpdate.Volume;
                marchandise.Nature_Marchandise.NatureMarchandiseLibelle = reservationUpdate.Nature;

                _context.SaveChanges();

            };

            var itineraire = reservation.Itineraire;




            var vol = _volCargoRepository.GetVolByItineraire(itineraire.id);

            if (reservation != null)
            {
                reservation.NomDestinataire = reservationUpdate.NomDestinataire;
                reservation.ReservationExigences = reservationUpdate.ReservationExigences;
                reservation.DateExpeditionSouhaite = reservationUpdate.DateExpeditionSouhaite;
                reservation.ReservationEtat = reservationUpdate.ReservationEtat;
                reservation.ReservationDate = reservation.ReservationDate;
                reservation.Itineraire = itineraire;
                reservation.VolCargo = vol;
                reservation.Marchandise = marchandise;
                reservation.Client = reservation.Client;

                _context.SaveChanges();

            };


            return Ok("Modification de la réservation avec succès");


        }

        [HttpPut("Modifier/{reservationID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateReservationClient(int reservationID, [FromBody] ReservationClientDto reservationUpdate)
        {
            if (reservationUpdate == null)
                return BadRequest(ModelState);

            if (reservationID != reservationUpdate.id)
                return BadRequest(ModelState);

            if (!_reservationRespository.ReservationExists(reservationID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            

            var reservation = _reservationClientRepository.GetReservations().Where(
            c => c.id == reservationID).FirstOrDefault();

            var marchandise = reservation.Marchandise;

            if (marchandise != null)
            {
                marchandise.MarchandiseDesignation = reservationUpdate.Designation;
                marchandise.MarchandiseNombre = reservationUpdate.NombreColis;
                marchandise.MarchandisePoids = reservationUpdate.Poids;
                marchandise.MarchandiseVolume = reservationUpdate.Volume;
                marchandise.Nature_Marchandise.NatureMarchandiseLibelle = reservationUpdate.Nature;

                _context.SaveChanges();

            };

            var itineraire = reservation.Itineraire;




            var vol = _volCargoRepository.GetVolByItineraire(itineraire.id);

            if (reservation != null)
            {
                reservation.NomDestinataire = reservationUpdate.NomDestinataire;
                reservation.ReservationExigences = reservationUpdate.ReservationExigences;
                reservation.DateExpeditionSouhaite = reservationUpdate.DateExpeditionSouhaite;
                reservation.ReservationEtat = "Reservé";
                reservation.ReservationDate = reservation.ReservationDate;
                reservation.Itineraire = itineraire;
                reservation.VolCargo = vol;
                reservation.Marchandise = marchandise;
                reservation.Client = reservation.Client;

                _context.SaveChanges();

            };


            return Ok("Modification de la réservation avec succès");

        }

        [HttpDelete("{reservationID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult DeleteReservation(int reservationID)
        {
            if (!_reservationRespository.ReservationExists(reservationID))
            {
                return NotFound();
            }

            var reservationDelete = _reservationRespository.GetReservation(reservationID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_reservationRespository.DeleteReservation(reservationDelete))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
            }

            return Ok("Agent supprimé avec succès");
        }
    }
}

