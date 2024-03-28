using GamesAPI.Core.Models;
using MimeKit;

namespace GamesAPI.Core.Services;

public interface IMailService {
    public void AddSender(MimeMessage emailMessage);
    public void AddRecipients(MimeMessage emailMessage, IMailData mailData);
    public void AddSubject(MimeMessage emailMessage, IMailData mailData);
    public Task AddBody(MimeMessage emailMessage, IMailData mailData);
    public Task<bool> Send(IMailData mailData);
}