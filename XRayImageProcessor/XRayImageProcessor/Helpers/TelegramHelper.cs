using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace XRayImageProcessor.Helpers
{
    public class TelegramHelper
    {
        public async Task ShareVoiceOnTelegram(string botToken, string chatId, byte[] voiceData)
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

        public async Task ShareImageOnTelegram(string botToken, string chatId, byte[] imageData)
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

        public async Task ShareReportOnTelegram(string botToken, string chatId, byte[] reportData)
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
