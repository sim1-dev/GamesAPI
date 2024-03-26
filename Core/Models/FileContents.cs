public class FileContents {
    public byte[] Bytes { get; set; }
    public string MimeType { get; set; }
    public string FileName { get; set; }

    public FileContents(string fileName, byte[] bytes, string mimeType) {
        this.FileName = fileName;
        this.Bytes = bytes;
        this.MimeType = mimeType;
    }

    public FileContents(string fileName, string filePath, string mimeType) {
        this.FileName = fileName;
        this.Bytes = File.ReadAllBytes(filePath);
        this.MimeType = mimeType;
    }
}