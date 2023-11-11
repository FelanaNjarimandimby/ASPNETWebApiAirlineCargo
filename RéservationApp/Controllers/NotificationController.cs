using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RéservationApp.Data;
using RéservationApp.Dto;
using RéservationApp.Interfaces;
using RéservationApp.Models;
using RéservationApp.Repository;

namespace RéservationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController: Controller
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public NotificationController(INotificationRepository notificationRepository, 
            IClientRepository clientRepository,
            IReservationRepository reservationRepository,
            IMapper mapper,
            DataContext context)
        {
            _notificationRepository = notificationRepository;
            _clientRepository = clientRepository;
            _reservationRepository = reservationRepository;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Notification>))]

        public IActionResult Notifications()
        {
            var notifications = _notificationRepository.GetNotifications();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(notifications);
        }


        [HttpGet("reservation/{ReservationID}")]
        [ProducesResponseType(200, Type = typeof(Notification))]
        [ProducesResponseType(400)]

        public IActionResult GetNotificationByReservation(int ReservationID)
        {
            var notif = _mapper.Map<NotificationDto>(_notificationRepository.GetNotification(ReservationID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(notif);
        }


        [HttpGet("Notification")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Notification>))]

        public IActionResult NotificationsByVue()
        {
            var notifications = _mapper.Map<List<NotificationDto>>(_notificationRepository.GetAllNotification("Non"));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(notifications);

        }

        [HttpGet("{notID}")]
        [ProducesResponseType(200, Type = typeof(Notification))]
        [ProducesResponseType(400)]

        public IActionResult GetNotification(int notID)
        {
            if (!_notificationRepository.NotificationExists(notID))
                return NotFound();

            var notification = _notificationRepository.GetNotificationID(notID);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(notification);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateNotification([FromBody] NotificationDto notificationDto)
        {
            
            
            var client = _clientRepository.GetClient(notificationDto.ClientID);
            var reservation = _reservationRepository.GetReservation(notificationDto.ReservationID);
            if(_context.Notifications.Any(n => n.Reservation.id == notificationDto.ReservationID))
            {
                ModelState.AddModelError("", "La confirmation de cette réservation est déjà envoyée");
                return StatusCode(422, ModelState);
            }

                var notification = new Notification
            {
                Vue = "Non",
                Client = client,
                Reservation = reservation,
            };
            _notificationRepository.CreateNotification(notification);
            

            return Ok("Notification ajouté avec succès");
        }


        [HttpPut("{notificationID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateNotification(int notificationID, [FromBody] NotificationDto updatedNotification)
        {
            if (updatedNotification == null)
                return BadRequest(ModelState);

            if (notificationID != updatedNotification.id)
                return BadRequest(ModelState);

            if (!_notificationRepository.NotificationExists(notificationID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var notification = _notificationRepository.GetNotifications().Where(
            c => c.id == notificationID).FirstOrDefault();

            if (notification != null)
            {
                notification.Vue = "Oui";
                notification.Client = notification.Client;
                notification.Reservation = notification.Reservation;

                _context.SaveChanges();

            };
            return Ok("Modification avec succès");
        }

        [HttpDelete("{notificationID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult DeleteNotification(int notificationID)
        {
            if (!_notificationRepository.NotificationExists(notificationID))
                return NotFound();

            var notificationDelete = _notificationRepository.GetNotificationID(notificationID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_notificationRepository.DeleteNotification(notificationDelete))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
            }

            return Ok("Notification supprimé avec succès");
        }

    }
}
