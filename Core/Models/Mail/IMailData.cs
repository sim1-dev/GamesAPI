using GamesAPI.Core.Models;
using MimeKit;

public interface IMailData {
    MailHeader Header { get; set; }
    string Subject { get; set; }
    MimeEntity? Body { get; set; }
}