namespace e_commerce.Services.IService;

public interface IEmailService
{
    Task SendEmailAsync(string email, string subject, string htmlMessage);
}
