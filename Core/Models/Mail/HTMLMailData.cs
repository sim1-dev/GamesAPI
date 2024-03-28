using MimeKit;

namespace GamesAPI.Core.Models;
/*
    Extend this class and override processTemplateParams() to parse custom params
*/
public class HTMLMailData : IMailData {
    public MailHeader Header { get; set; }
    public string Subject { get; set; } = "";
    public MimeEntity? Body { get; set; }
    public string MailPath = CoreMailTemplates.BASE;

    public HTMLMailData(MailHeader header, string subject, MimeEntity body) {
        this.Header = header;
        this.Subject = subject;
        this.Body = body;
    }

    public HTMLMailData(MailHeader header, string subject, string mailPath = CoreMailTemplates.BASE) {
        this.Header = header;
        this.Subject = subject;
        this.MailPath = mailPath;

        this.BuildBodyFromTemplate(mailPath).Wait();
    }

    public async Task BuildBodyFromTemplate(string template = CoreMailTemplates.BASE) {
        string templateBody = await File.ReadAllTextAsync(Path.Combine(Directory.GetCurrentDirectory(), template));

        templateBody = this.processTemplateParams(templateBody);

        this.Body = new TextPart(MimeKit.Text.TextFormat.Html) {
            Text = templateBody
        };
    }

    public virtual string processTemplateParams(string templateBody) {
        return string.Format(templateBody, "parameter 1, the next one will be today's date", DateTime.Today.Date.ToShortDateString());
    }
}