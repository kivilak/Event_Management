using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Event_Management.Model
{
    public class PDFGenerator
    {
        public void Generate(string filePath, List<EventSummary> eventSummary, List<GuestAttendance> guestAttendance)
        {
            QuestPDF.Settings.License = LicenseType.Community;
         
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1.5f, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header()
                    .Column(column =>
                    {
                        column.Item().Text("Event Management System Report")
                            .FontSize(24)
                            .Bold()
                            .FontColor(Colors.Blue.Darken2);

                        column.Item().Text($"Generated on: {DateTime.Now:MMM dd, yyyy}")
                            .FontSize(10)
                            .FontColor(Colors.Grey.Medium);

                        column.Item().PaddingVertical(10).LineHorizontal(1).LineColor(Colors.Grey.Lighten1);
                    });

                    page.Content()
                    .PaddingVertical(10)
                    .Column(column =>
                    {
                        column.Item().Element(container => CreateEventSummaryTable(container, eventSummary));
                        column.Item().PageBreak();
                        //column.Item().PaddingTop(20);
                        column.Item().Element(container => CreateGuestAttendanceTable(container, guestAttendance));
                    });

                    page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Page ");
                        x.CurrentPageNumber();
                        x.Span(" of ");
                        x.TotalPages();
                    });
                });
            }).GeneratePdf(filePath);
        }

        public void CreateEventSummaryTable(IContainer container, List<EventSummary> eventSummary)
        {
            container.Column(column =>
            {
                column.Item().Text("Event Summary Report")
               .FontSize(18)
               .Bold();

                column.Item().PaddingTop(10).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(3);
                        columns.RelativeColumn(2);
                        columns.RelativeColumn(1.5f);
                        columns.RelativeColumn(2);
                        columns.RelativeColumn(2);
                        columns.RelativeColumn(2);
                    });

                    table.Header(header =>
                    {
                        header.Cell().Element(CellStyle).Text("EventName").Bold();
                        header.Cell().Element(CellStyle).Text("Status").Bold();
                        header.Cell().Element(CellStyle).Text("Guests").Bold();
                        header.Cell().Element(CellStyle).Text("Budget").Bold();
                        header.Cell().Element(CellStyle).Text("Spent").Bold();
                        header.Cell().Element(CellStyle).Text("Remaining").Bold();
                    });

                    foreach (var item in eventSummary)
                    {
                        table.Cell().Element(CellStyle).Text(item.EventName);
                        table.Cell().Element(CellStyle).Text(item.Status);
                        table.Cell().Element(CellStyle).Text((item.Guests).ToString());
                        table.Cell().Element(CellStyle).Text("$ " + (item.Budget).ToString());
                        table.Cell().Element(CellStyle).Text("$ " + (item.Spent).ToString());
                        table.Cell().Element(CellStyle).Text("$ " + (item.Remaining).ToString());
                    }
                });
            });
        }

        public void CreateGuestAttendanceTable(IContainer container, List<GuestAttendance> guestAttendance)
        {
            container.Column(column =>
            {
                column.Item().Text("Guest Attendance Report")
               .FontSize(18)
               .Bold();

                column.Item().PaddingTop(10).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(3);
                        columns.RelativeColumn(1.5f);
                        columns.RelativeColumn(1.5f);
                        columns.RelativeColumn(1.5f);
                        columns.RelativeColumn(1.5f);
                        columns.RelativeColumn(2);
                    });

                    table.Header(header =>
                    {
                        header.Cell().Element(CellStyle).Text("Event Name").Bold();
                        header.Cell().Element(CellStyle).Text("Invited").Bold();
                        header.Cell().Element(CellStyle).Text("Confirmed").Bold();
                        header.Cell().Element(CellStyle).Text("Declined").Bold();
                        header.Cell().Element(CellStyle).Text("Pending").Bold();
                        header.Cell().Element(CellStyle).Text("Response Rate").Bold();
                    });

                    foreach (var item in guestAttendance)
                    {
                        table.Cell().Element(CellStyle).Text(item.EventName ?? "");
                        table.Cell().Element(CellStyle).Text(item.Invited.ToString());
                        table.Cell().Element(CellStyle).Text(item.Confirmed.ToString());
                        table.Cell().Element(CellStyle).Text(item.Declined.ToString());
                        table.Cell().Element(CellStyle).Text(item.Pending.ToString());
                        table.Cell().Element(CellStyle).Text(GetResponseRateText(item));
                    }
                });
            });
        }

        private static string GetResponseRateText(GuestAttendance item)
        {
            if (item.Invited == 0)
            {
                return "N/A";
            }
            return $"{item.ResponseRate:F1}%";
        }

        static IContainer CellStyle(IContainer container)
        {
            return container
                .BorderBottom(1)
                .BorderColor(Colors.Grey.Lighten2)
                .PaddingVertical(8)
                .PaddingHorizontal(5);
        }
    }
}
