using GamesAPI.Core.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace GamesAPI.Core.Services;

public class MailService : IMailService {
    private readonly MailSettings _mailSettings;
    private readonly ILogger<MailService> _logger;

    public MailService(IOptions<MailSettings> mailSettingsOptions, ILogger<MailService> logger) {
        this._logger = logger;
        this._mailSettings = mailSettingsOptions.Value;
    }

    public async Task<bool> Send(IMailData mailData) { 
        try {
            using (MimeMessage emailMessage = new MimeMessage()) {
                this.AddSender(emailMessage);
                this.AddRecipients(emailMessage, mailData);
                this.AddSubject(emailMessage, mailData);


                await this.BuildBody(emailMessage, mailData);
                
                using (SmtpClient mailClient = new SmtpClient()) {
                    await mailClient.ConnectAsync(_mailSettings.Server, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                    await mailClient.AuthenticateAsync(_mailSettings.UserName, _mailSettings.Password);
                    await mailClient.SendAsync(emailMessage);
                    await mailClient.DisconnectAsync(true);
                }
            }
            return true;
        }
        catch (Exception exception) {
            this._logger.LogError($"Error sending mail {mailData}: {exception}");
            return false;
        }
    }

    
    public void AddSender(MimeMessage emailMessage) {
        MailboxAddress emailFrom = new MailboxAddress(_mailSettings.SenderName, _mailSettings.SenderEmail);
        emailMessage.From.Add(emailFrom);
    }

    public void AddRecipients(MimeMessage emailMessage, IMailData mailData) {
        foreach (MailRecipient MailRecipientTo in mailData.Header.Recipients) {
            if (MailRecipientTo.Address == "")
                throw new ArgumentException("RecipientEmail address not provided.");

            if (MailRecipientTo.FullName == "")
                MailRecipientTo.FullName = MailRecipientTo.Address;

            emailMessage.To.Add(new MailboxAddress(MailRecipientTo.FullName, MailRecipientTo.Address));
        }

        // cc and bcc
        if (mailData.Header.Ccs is not null) {
            foreach (MailRecipient MailRecipientCc in mailData.Header.Ccs) {
                if (MailRecipientCc.Address == "")
                    throw new ArgumentException("Cc Email address not provided.");

                emailMessage.Cc.Add(new MailboxAddress("Cc Receiver", MailRecipientCc.Address));
            }
        }
        if (mailData.Header.Bccs is not null) {
            foreach (MailRecipient MailRecipientBcc in mailData.Header.Bccs) {
                if (MailRecipientBcc.Address == "")
                    throw new ArgumentException("Bcc Email address not provided.");

                emailMessage.Bcc.Add(new MailboxAddress("Bcc Receiver", MailRecipientBcc.Address));
            }
        }
    }

    public void AddSubject(MimeMessage emailMessage, IMailData mailData) {
        emailMessage.Subject = mailData.Subject;
    }


    public virtual Task BuildBody(MimeMessage emailMessage, IMailData mailData) {
        emailMessage.Body = mailData.GetBody();
        return Task.CompletedTask;
    }
}