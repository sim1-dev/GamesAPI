namespace GamesAPI.Core.Models;
public class MailRecipient {
    public string Address { get; set; }
    public string FullName { get; set; } = "";

    public MailRecipient(string address) {
        this.Address = address;
    }

    public MailRecipient(string address, string fullName) {
        this.Address = address;
        this.FullName = fullName;
    }
}