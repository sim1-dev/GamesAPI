
namespace GamesAPI.Core.Models;

public class MailHeader {
    public List<MailRecipient> Recipients { get; set; } = new List<MailRecipient>();
    public List<MailRecipient>? Ccs { get; set; } = new List<MailRecipient>();
    public List<MailRecipient>? Bccs { get; set; } = new List<MailRecipient>();
}