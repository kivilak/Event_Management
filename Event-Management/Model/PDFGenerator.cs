using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Event_Management.Model
{
    public class PDFGenerator
    {
        public void Generate(string filepath, List<dynamic> NewList)
        {
            QuestPDF.Settings.License = LicenseType.Community;
         
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);

                    
                });
            });
        }
    }
}
