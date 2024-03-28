namespace GamesAPI.Core.Models;
public class MailRecipientData {
    public string Address { get; set; }
    public string FullName { get; set; } = "";

    public MailRecipientData(string address) {
        this.Address = address;
    }

    public MailRecipientData(string address, string fullName) {
        this.Address = address;
        this.FullName = fullName;
    }
}