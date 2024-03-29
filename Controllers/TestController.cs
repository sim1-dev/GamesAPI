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
            Recipients = new List<MailRecipient>() {
                new MailRecipient("test@test.com", "Test Emailed")
            },
            Ccs = new List<MailRecipient>(),
            Bccs = new List<MailRecipient>()
        };
        MailData mailData = new MailData(header, "Subject", "This is a test mail");
        
        return await _mailService.Send(mailData);
    }

    [HttpPost]
    [Route("html-mail/send")]
    public async Task<bool> SendHtmlMail() {
        MailHeader header = new MailHeader {
            Recipients = new List<MailRecipient>() {
                new MailRecipient("test@test.com", "Test Emailed")
            },
            Ccs = new List<MailRecipient>(),
            Bccs = new List<MailRecipient>()
        };
        HTMLMailData mailData = new TestHTMLMailData(header);

        return await _mailService.Send(mailData);
    }


    [HttpPost]
    [Route("attachments-html-mail/send")]
    public async Task<bool> SendAttachmentsHtmlMail() {
        MailHeader header = new MailHeader {
            Recipients = new List<MailRecipient>() {
                new MailRecipient("test@test.com", "Test Emailed")
            },
            Ccs = new List<MailRecipient>(),
            Bccs = new List<MailRecipient>()
        };
        HTMLMailData mailData = new TestHTMLMailData(header);
        mailData.AddAttachmentFromPath(Directory.GetCurrentDirectory() + "\\Controllers\\TestController.cs");

        return await _mailService.Send(mailData);
    }

}