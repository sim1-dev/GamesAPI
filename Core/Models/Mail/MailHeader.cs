
namespace GamesAPI.Core.Models;

public class MailHeader {
    public List<MailRecipientData> Recipients { get; set; } = new List<MailRecipientData>();
    public List<MailRecipientData>? Ccs { get; set; } = new List<MailRecipientData>();
    public List<MailRecipientData>? Bccs { get; set; } = new List<MailRecipientData>();
}