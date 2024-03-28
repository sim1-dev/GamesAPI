namespace GamesAPI.Core.Models;

public class TestHTMLMailData : HTMLMailData
{
    public TestHTMLMailData(MailHeader header, string subject = "Test subject HTML", string mailPath = MailTemplates.TEST) : base(header, subject, mailPath) {

    }

    public override string processTemplateParams(string templateBody) {
        return string.Format(templateBody, "testParam1");
    }
}