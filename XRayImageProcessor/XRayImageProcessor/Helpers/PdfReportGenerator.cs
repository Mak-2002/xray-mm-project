using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.IO;

namespace XRayImageProcessor.Helpers
{
    public class PdfReportGenerator
    {
        public byte[] GenerateReport(Dictionary<string, string> reportContent)
        {
            using (var document = new PdfDocument())
            {
                var page = document.AddPage();
                using (var gfx = XGraphics.FromPdfPage(page))
                {
                    var fontBold = new XFont("Verdana", 20);
                    gfx.DrawString("Case Report", fontBold, XBrushes.Black,
                        new XRect(0, 0, page.Width, page.Height),
                        XStringFormats.TopCenter);

                    var fontRegular = new XFont("Verdana", 14);
                    int yPosition = 60;

                    foreach (var entry in reportContent)
                    {
                        gfx.DrawString($"{entry.Key}: {entry.Value}", fontRegular, XBrushes.Black,
                            new XRect(40, yPosition, page.Width, page.Height),
                            XStringFormats.TopLeft);
                        yPosition += 40;
                    }
                }

                using (var memoryStream = new MemoryStream())
                {
                    document.Save(memoryStream, false);
                    return memoryStream.ToArray();
                }
            }
        }
    }
}
