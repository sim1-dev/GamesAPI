using MimeKit;

namespace GamesAPI.Core.Models;

public class MailData: IMailData {
    public MailHeader Header { get; set; }
    public string Subject { get; set; } = "";
    public IFormFileCollection Attachments { get; set; } = new FormFileCollection();


    public BodyBuilder BodyBuilder { get; set; }

    public MailData(MailHeader header, string subject) {
        this.Header = header;
        this.Subject = subject;

        this.BodyBuilder = new BodyBuilder();
    }

    public MailData(MailHeader header, string subject, BodyBuilder bodyBuilder) {
        this.Header = header;
        this.Subject = subject;
        this.BodyBuilder = bodyBuilder;
    }

    public MailData(MailHeader header, string subject, string body) {
        this.Header = header;
        this.Subject = subject;
        this.BodyBuilder = new BodyBuilder {
            TextBody = body
        };
    }
    

    public MailData AddAttachment(MimePart attachment) {
        this.BodyBuilder.Attachments.Add(attachment);
        return this;
    }

    public MailData AddAttachmentFromPath(string filePath) {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("File not found", filePath);

        byte[] fileBytes = File.ReadAllBytes(filePath);

        MimePart attachment = new MimePart {
            Content = new MimeContent(new MemoryStream(fileBytes)),
            ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
            ContentTransferEncoding = ContentEncoding.Base64,
            FileName = Path.GetFileName(filePath)
        };

        // using(FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
        //     MimePart attachment = new MimePart {
        //         Content = new MimeContent(fileStream),
        //         ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
        //         ContentTransferEncoding = ContentEncoding.Base64,
        //         FileName = Path.GetFileName(filePath)
        //     };

        this.AddAttachment(attachment);

        return this;
    }

    public MimeEntity? GetBody() {
        return this.BodyBuilder.ToMessageBody();
    }
}