using DinkToPdf;
using DinkToPdf.Contracts;
using System.IO;

public class PdfService
{
    private readonly IConverter _converter;

    public PdfService(IConverter converter)
    {
        _converter = converter;
    }

    public void SavePdfToFile(string htmlContent, string filePath)
    {
        var document = new HtmlToPdfDocument()
        {
            GlobalSettings = {
                PaperSize = PaperKind.A4,
                Orientation = Orientation.Portrait,
            },
            Objects = {
                new ObjectSettings() {
                    HtmlContent = htmlContent,
                }
            }
        };

        var pdfBytes = _converter.Convert(document);

        // Save the PDF to the specified file path
        File.WriteAllBytes(filePath, pdfBytes);
    }
}