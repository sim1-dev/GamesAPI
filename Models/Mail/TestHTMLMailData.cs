using System.Text;
using GamesAPI.Models;

namespace GamesAPI.Core.Models;

public class TestHTMLMailData : HTMLMailData {
    public TestHTMLMailData(MailHeader header, string subject = "Test subject HTML", string mailPath = MailTemplates.TEST) : base(header, subject, mailPath) {

    }
    
    // Simple example of a manual loop implementation. 
    // It is not recommended to use this in a production environment. Rendering Razor templates would be better
    public override string processTemplateParams(string templateBody) {
        var categoriesPlaceholder = "{categories}";

        var categories = new List<Category>() { 
            new Category() { Name = "Test category 1" }, 
            new Category() { Name = "Test category 2" } 
        };

        int index = templateBody.IndexOf(categoriesPlaceholder);

        if(index == -1)
            return templateBody;

        StringBuilder categoriesBuilder = new StringBuilder();

        foreach(Category category in categories) {
            categoriesBuilder.AppendLine($"<li>{category.Name}</li>");
        }

        // Insert the list of categories into the template body
        templateBody = templateBody
            .Remove(index, categoriesPlaceholder.Length)
            .Insert(index, categoriesBuilder.ToString())
        ;

        return templateBody;
    }
}