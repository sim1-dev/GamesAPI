using GamesAPI.Core.Models;
using GamesAPI.Core.Services;
using Microsoft.AspNetCore.Mvc;

public class TestController : ControllerBase {
    private readonly IMailService _mailService;

    public TestController(IMailService mailService) {
        this._mailService = mailService;
    }

    [HttpGet]
    public IActionResult Test() {
        return Ok();
    }

    [HttpPost]
    [Route("mail/send")]
    public async Task<bool> SendMail() {
        MailHeader header = new MailHeader {
            Recipients = new List<MailRecipientData>() {
                new MailRecipientData("test@test.com", "Test Emailed")
            },
            Ccs = new List<MailRecipientData>(),
            Bccs = new List<MailRecipientData>()
        };
        MailData mailData = new MailData(header, "Subject", "This is a test mail", new MimeKit.BodyBuilder());

        return await _mailService.Send(mailData);
    }

    [HttpPost]
    [Route("html-mail/send")]
    public async Task<bool> SendHtmlMail() {
        MailHeader header = new MailHeader {
            Recipients = new List<MailRecipientData>() {
                new MailRecipientData("test@test.com", "Test Emailed")
            },
            Ccs = new List<MailRecipientData>(),
            Bccs = new List<MailRecipientData>()
        };
        HTMLMailData mailData = new TestHTMLMailData(header);

        return await _mailService.Send(mailData);
    }

}