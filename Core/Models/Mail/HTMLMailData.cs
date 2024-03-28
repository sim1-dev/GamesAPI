using MimeKit;

namespace GamesAPI.Core.Models;
/*
    Extend this class and override processTemplateParams() to parse custom params
*/
public class HTMLMailData : MailData {
    public string MailPath = CoreMailTemplates.BASE;

    public HTMLMailData(MailHeader header, string subject, MimeEntity body) : base(header, subject) { }

    public HTMLMailData(MailHeader header, string subject, string mailPath = CoreMailTemplates.BASE): base(header, subject) {
        this.MailPath = mailPath;

        this.AddBodyFromTemplate(mailPath).Wait();
    }

    public async Task AddBodyFromTemplate(string template = CoreMailTemplates.BASE) {
        string templateBody = await File.ReadAllTextAsync(Path.Combine(Directory.GetCurrentDirectory(), template));

        this.BodyBuilder.HtmlBody = this.processTemplateParams(templateBody);
    }

    public virtual string processTemplateParams(string templateBody) {
        return string.Format(templateBody, "parameter 1, the next one will be today's date", DateTime.Today.Date.ToShortDateString());
    }
}