using System;
using System.IO;
using System.IO.Compression;

namespace XRayImageProcessor.Helpers
{
    public class ZipCompressor
    {
        public byte[] CompressToZip(byte[] image, byte[] report, MemoryStream voice)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    if (image != null)
                    {
                        var imageEntry = archive.CreateEntry("image.jpg");
                        using (var entryStream = imageEntry.Open())
                        using (var imageStream = new MemoryStream(image))
                        {
                            imageStream.CopyTo(entryStream);
                        }
                    }

                    if (report != null)
                    {
                        var reportEntry = archive.CreateEntry("report.pdf");
                        using (var entryStream = reportEntry.Open())
                        using (var reportStream = new MemoryStream(report))
                        {
                            reportStream.CopyTo(entryStream);
                        }
                    }

                    if (voice != null)
                    {
                        var voiceEntry = archive.CreateEntry("voice.wav");
                        using (var entryStream = voiceEntry.Open())
                        using (var voiceStream = voice)
                        {
                            voiceStream.Position = 0;
                            voiceStream.CopyTo(entryStream);
                        }
                    }
                }
                return memoryStream.ToArray();
            }
        }
    }
}
