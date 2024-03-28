using MimeKit;

namespace GamesAPI.Core.Models;

public class MailData: IMailData {
    public MailHeader Header { get; set; }
    public string Subject { get; set; } = "";
    public MimeEntity? Body { get; set; } = null;

    public MailData(MailHeader header, string subject) {
        this.Header = header;
        this.Subject = subject;
    }

    public MailData(MailHeader header, string subject, MimeEntity body) {
        this.Header = header;
        this.Subject = subject;
        this.Body = body;
    }

    public MailData(MailHeader header, string subject, string body, BodyBuilder bodyBuilder) {
        this.Header = header;
        this.Subject = subject;
        this.BodyToMimeEntity(bodyBuilder, body);
    }


    public MailData BodyToMimeEntity(BodyBuilder bodyBuilder, string body) {
        bodyBuilder.TextBody = body;

        this.Body = bodyBuilder.ToMessageBody();
        return this;
    }
}