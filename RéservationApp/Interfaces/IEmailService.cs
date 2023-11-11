using RéservationApp.Dto;

namespace RéservationApp.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
