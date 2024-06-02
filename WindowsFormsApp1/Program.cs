using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace WindowsFormsApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var audioData = RecordAudio();
            if (audioData != null)
            {
                MessageBox.Show("Recording stopped. Audio data length: " + audioData.Length + " bytes.", "Voice Recorder");

                var reportContent = new Dictionary<string, string>
                {
                    { "Case Name", "Sample Case" },
                    { "State", "Completed" },
                    { "Description", "This is a detailed description of the case." },
                    { "Date", DateTime.Now.ToString("MM/dd/yyyy") }
                };

                var pdfReport = GenerateReport(reportContent);

                
                byte[] imageData = File.ReadAllBytes("C:\\Users\\CoOoL\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\example.jpg");

                var zipData = CompressToZip(imageData, pdfReport, audioData);

                File.WriteAllBytes("C:\\Users\\CoOoL\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\Report.zip", zipData);
                MessageBox.Show("Zip file generated and saved as 'Report.zip'.", "Voice Recorder");

                
                var botToken = "YOUR_TELEGRAM_BOT_API_TOKEN";
                var chatId = "YOUR_CHAT_ID";
                await ShareVoiceOnTelegram(botToken, chatId, audioData);
                await ShareImageOnTelegram(botToken, chatId, imageData);
                await ShareReportOnTelegram(botToken, chatId, pdfReport);

                MessageBox.Show("Files sent to Telegram.", "Voice Recorder");
            }
        }

        static byte[] RecordAudio()
        {
            byte[] recordedData = null;
            using (var waveIn = new WaveInEvent())
            {
                waveIn.WaveFormat = new WaveFormat(44100, 1); 
                using (var memoryStream = new MemoryStream())
                {
                    WaveFileWriter waveFileWriter = null;
                    waveIn.DataAvailable += (sender, e) =>
                    {
                        
                        if (waveFileWriter == null)
                        {
                            waveFileWriter = new WaveFileWriter(memoryStream, waveIn.WaveFormat);
                        }
                       
                        waveFileWriter.Write(e.Buffer, 0, e.BytesRecorded);
                    };

                    waveIn.RecordingStopped += (sender, e) =>
                    {
                        waveFileWriter?.Dispose();
                        recordedData = memoryStream.ToArray();
                    };

                   
                    waveIn.StartRecording();
                    MessageBox.Show("Recording... Press OK to stop.", "Voice Recorder");

                    
                    waveIn.StopRecording();
                    System.Threading.Thread.Sleep(500); 
                }
            }

            return recordedData;
        }

        static byte[] GenerateReport(Dictionary<string, string> reportContent)
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

        static byte[] CompressToZip(byte[] image, byte[] report, byte[] voice)
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
                        using (var voiceStream = new MemoryStream(voice))
                        {
                            voiceStream.CopyTo(entryStream);
                        }
                    }
                }

                return memoryStream.ToArray();
            }
        }

        static async Task ShareVoiceOnTelegram(string botToken, string chatId, byte[] voiceData)
        {
            using (var httpClient = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    content.Add(new ByteArrayContent(voiceData), "voice", "voice.wav");

                    var url = $"https://api.telegram.org/bot{botToken}/sendVoice?chat_id={chatId}";
                    var response = await httpClient.PostAsync(url, content);

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Failed to send voice message: " + response.ReasonPhrase);
                    }
                }
            }
        }

        static async Task ShareImageOnTelegram(string botToken, string chatId, byte[] imageData)
        {
            using (var httpClient = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    content.Add(new ByteArrayContent(imageData), "photo", "image.jpg");

                    var url = $"https://api.telegram.org/bot{botToken}/sendPhoto?chat_id={chatId}";
                    var response = await httpClient.PostAsync(url, content);

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Failed to send image: " + response.ReasonPhrase);
                    }
                }
            }
        }

        static async Task ShareReportOnTelegram(string botToken, string chatId, byte[] reportData)
        {
            using (var httpClient = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    content.Add(new ByteArrayContent(reportData), "document", "report.pdf");

                    var url = $"https://api.telegram.org/bot{botToken}/sendDocument?chat_id={chatId}";
                    var response = await httpClient.PostAsync(url, content);

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Failed to send report: " + response.ReasonPhrase);
                    }
                }
            }
        }
    }
}
