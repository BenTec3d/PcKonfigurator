using PcKonfigurator.Shared.Models;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Globalization;

namespace PcKonfigurator.Client.Services
{
    public class PdfService : IPdfService
    {
        public PdfService()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        public void PcBuildAsPdf(PcBuildBase pcBuild, Employee employee)
        {
            string timestamp = DateTime.Now.ToString();
            timestamp = timestamp.Replace(":", ".");

            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            gfx.DrawString("Ihre Medium Markt PC Konfiguration", new XFont("Arial", 32, XFontStyle.Bold), XBrushes.Red, new XRect(0,50,page.Width, page.Height), XStringFormats.TopCenter);
            gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.Red), 2), new XPoint(0, 85), new XPoint(600, 85));

            gfx.DrawString("Artikelnummer", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Red, new XPoint(25, 200));
            gfx.DrawString("Artikelbezeichnung", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Red, new XPoint(150, 200));
            gfx.DrawString("Preis", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Red, new XPoint(500, 200));

            gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.Red)), new XPoint(0, 205), new XPoint(600, 205));

            gfx.DrawString($"{pcBuild.Cpu.InventoryId}", new XFont("Arial", 12), XBrushes.Black, new XPoint(25, 220));
            gfx.DrawString($"{pcBuild.Cpu.Name}", new XFont("Arial", 12), XBrushes.Black, new XPoint(150, 220));
            gfx.DrawString(pcBuild.Cpu.InventoryItem.Price.ToString("C", CultureInfo.CurrentCulture), new XFont("Arial", 12), XBrushes.Black, new XPoint(500, 220));

            gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.Black), 0.5), new XPoint(0, 225), new XPoint(600, 225));

            gfx.DrawString($"{pcBuild.CpuCooler.InventoryId}", new XFont("Arial", 12), XBrushes.Black, new XPoint(25, 240));
            gfx.DrawString($"{pcBuild.CpuCooler.Name}", new XFont("Arial", 12), XBrushes.Black, new XPoint(150, 240));
            gfx.DrawString(pcBuild.CpuCooler.InventoryItem.Price.ToString("C", CultureInfo.CurrentCulture), new XFont("Arial", 12), XBrushes.Black, new XPoint(500, 240));

            gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.Black), 0.5), new XPoint(0, 245), new XPoint(600, 245));

            gfx.DrawString($"{pcBuild.Motherboard.InventoryId}", new XFont("Arial", 12), XBrushes.Black, new XPoint(25, 260));
            gfx.DrawString($"{pcBuild.Motherboard.Name}", new XFont("Arial", 12), XBrushes.Black, new XPoint(150, 260));
            gfx.DrawString(pcBuild.Motherboard.InventoryItem.Price.ToString("C", CultureInfo.CurrentCulture), new XFont("Arial", 12), XBrushes.Black, new XPoint(500, 260));

            gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.Black), 0.5), new XPoint(0, 265), new XPoint(600, 265));

            gfx.DrawString($"{pcBuild.Ram.InventoryId}", new XFont("Arial", 12), XBrushes.Black, new XPoint(25, 280));
            gfx.DrawString($"{pcBuild.Ram.Name}", new XFont("Arial", 12), XBrushes.Black, new XPoint(150, 280));
            gfx.DrawString(pcBuild.Ram.InventoryItem.Price.ToString("C", CultureInfo.CurrentCulture), new XFont("Arial", 12), XBrushes.Black, new XPoint(500, 280));

            gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.Black), 0.5), new XPoint(0, 285), new XPoint(600, 285));

            gfx.DrawString($"{pcBuild.Gpu.InventoryId}", new XFont("Arial", 12), XBrushes.Black, new XPoint(25, 300));
            gfx.DrawString($"{pcBuild.Gpu.Name}", new XFont("Arial", 12), XBrushes.Black, new XPoint(150, 300));
            gfx.DrawString(pcBuild.Gpu.InventoryItem.Price.ToString("C", CultureInfo.CurrentCulture), new XFont("Arial", 12), XBrushes.Black, new XPoint(500, 300));

            gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.Black), 0.5), new XPoint(0, 305), new XPoint(600, 305));

            gfx.DrawString($"{pcBuild.Case.InventoryId}", new XFont("Arial", 12), XBrushes.Black, new XPoint(25, 320));
            gfx.DrawString($"{pcBuild.Case.Name}", new XFont("Arial", 12), XBrushes.Black, new XPoint(150, 320));
            gfx.DrawString(pcBuild.Case.InventoryItem.Price.ToString("C", CultureInfo.CurrentCulture), new XFont("Arial", 12), XBrushes.Black, new XPoint(500, 320));

            gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.Black), 0.5), new XPoint(0, 325), new XPoint(600, 325));

            gfx.DrawString($"{pcBuild.Psu.InventoryId}", new XFont("Arial", 12), XBrushes.Black, new XPoint(25, 340));
            gfx.DrawString($"{pcBuild.Psu.Name}", new XFont("Arial", 12), XBrushes.Black, new XPoint(150, 340));
            gfx.DrawString(pcBuild.Psu.InventoryItem.Price.ToString("C", CultureInfo.CurrentCulture), new XFont("Arial", 12), XBrushes.Black, new XPoint(500, 340));

            gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.Black), 0.5), new XPoint(0, 345), new XPoint(600, 345));

            gfx.DrawString($"{pcBuild.Storage.InventoryId}", new XFont("Arial", 12), XBrushes.Black, new XPoint(25, 360));
            gfx.DrawString($"{pcBuild.Storage.Name}", new XFont("Arial", 12), XBrushes.Black, new XPoint(150, 360));
            gfx.DrawString(pcBuild.Storage.InventoryItem.Price.ToString("C", CultureInfo.CurrentCulture), new XFont("Arial", 12), XBrushes.Black, new XPoint(500, 360));

            gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.Red)), new XPoint(0, 365), new XPoint(600, 365));

            gfx.DrawString(pcBuild.TotalPrice.ToString("C", CultureInfo.CurrentCulture), new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Red, new XPoint(500, 380));

            gfx.DrawString($"Sie wurden heute bedient von: {employee.FullName}", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Red, new XRect(0, 0, page.Width, page.Height-25), XStringFormats.BottomCenter);

            document.Save(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                $"{employee.FullName}-{timestamp}.pdf"));
        }
    }
}
