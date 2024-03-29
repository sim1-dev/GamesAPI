using GamesAPI.Core.Models;
using MimeKit;

public interface IMailData {
    MailHeader Header { get; set; }
    string Subject { get; set; }
    BodyBuilder BodyBuilder { get; set; }

    MailData AddAttachment(MimePart attachment);
    MailData AddAttachmentFromPath(string filePath);
    MimeEntity? GetBody();
}