using NAudio.Wave;
using System;
using System.IO;
using System.Windows.Forms;

namespace XRayImageProcessor.Helpers
{
    public class AudioRecorder
    {
        public byte[] RecordAudio()
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
                        //waveFileWriter?.Dispose();
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
    }
}
