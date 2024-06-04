using AForge.Imaging.Filters;
using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XRayImageProcessor.Logic
{
    internal class FourierTransformationManager
    {
        public Bitmap applyLowPassFilterAndSharpen(Bitmap inputImage)
        {
            // Convert the input image to grayscale
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayscaleImage = filter.Apply(inputImage);

            // Resize to the next power of two dimensions for FFT optimization
            int width = NextPowerOfTwo(grayscaleImage.Width);
            int height = NextPowerOfTwo(grayscaleImage.Height);
            ResizeBilinear resizeFilter = new ResizeBilinear(width, height);
            Bitmap resizedImage = resizeFilter.Apply(grayscaleImage);

            // Apply FFT to the resized grayscale image
            ComplexImage complexImage = ComplexImage.FromBitmap(resizedImage);
            complexImage.ForwardFourierTransform();

            // Create a low-pass filter mask
            int radius = 10; // Set the radius for your low-pass filter
            int cx = width / 2;
            int cy = height / 2;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if ((x - cx) * (x - cx) + (y - cy) * (y - cy) > radius * radius)
                    {
                        complexImage.Data[y, x].Re = 0;
                        complexImage.Data[y, x].Im = 0;
                    }
                }
            }

            // Apply the inverse FFT to convert back to the spatial domain
            complexImage.BackwardFourierTransform();

            // Get the low-pass filtered image
            Bitmap lowPassImage = complexImage.ToBitmap();

            // Resize the low-pass filtered image back to the original dimensions
            ResizeBilinear resizeFilterOriginal = new ResizeBilinear(inputImage.Width, inputImage.Height);
            Bitmap lowPassResizedImage = resizeFilterOriginal.Apply(lowPassImage);

            // (Optional) Combine the low-pass filtered image with the original image for a smoothing effect
            // Here we use a weighted average to blend the low-pass image with the original
            Bitmap finalImage = CombineWithOriginal(inputImage, lowPassResizedImage, 0.5);

            // Return the low-pass filtered image
            return finalImage;
        }
        public Bitmap applyHighPassFilterAndSharpen(Bitmap inputImage)
        {
            // Convert the input image to grayscale
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayscaleImage = filter.Apply(inputImage);

            // Resize to the next power of two dimensions for FFT optimization
            int width = NextPowerOfTwo(grayscaleImage.Width);
            int height = NextPowerOfTwo(grayscaleImage.Height);
            ResizeBilinear resizeFilter = new ResizeBilinear(width, height);
            Bitmap resizedImage = resizeFilter.Apply(grayscaleImage);

            // Apply FFT to the resized grayscale image
            ComplexImage complexImage = ComplexImage.FromBitmap(resizedImage);
            complexImage.ForwardFourierTransform();

            // Create a high-pass filter mask
            int radius = 10; // Set the radius for your high-pass filter
            int cx = width / 2;
            int cy = height / 2;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if ((x - cx) * (x - cx) + (y - cy) * (y - cy) <= radius * radius)
                    {
                        complexImage.Data[y, x].Re = 0;
                        complexImage.Data[y, x].Im = 0;
                    }
                }
            }

            // Apply the inverse FFT to convert back to the spatial domain
            complexImage.BackwardFourierTransform();

            // Get the high-pass filtered image
            Bitmap highPassImage = complexImage.ToBitmap();

            // Resize the high-pass filtered image back to the original dimensions
            ResizeBilinear resizeFilterOriginal = new ResizeBilinear(inputImage.Width, inputImage.Height);
            Bitmap highPassResizedImage = resizeFilterOriginal.Apply(highPassImage);

            // Combine the high-pass filtered image with the original image
            Bitmap finalImage = CombineWithOriginal(inputImage, highPassResizedImage);

            // Return the high-pass filtered image
            return finalImage;
        }
        private int NextPowerOfTwo(int n)
        {
            int power = 1;
            while (power < n)
            {
                power *= 2;
            }
            return power;
        }

        private Bitmap CombineWithOriginal(Bitmap original, Bitmap lowPass, double alpha)
        {
            Bitmap result = new Bitmap(original.Width, original.Height);
            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color originalColor = original.GetPixel(x, y);
                    Color lowPassColor = lowPass.GetPixel(x, y);

                    int r = Clip((int)(alpha * originalColor.R + (1 - alpha) * lowPassColor.R));
                    int g = Clip((int)(alpha * originalColor.G + (1 - alpha) * lowPassColor.G));
                    int b = Clip((int)(alpha * originalColor.B + (1 - alpha) * lowPassColor.B));

                    result.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return result;
        }
        private Bitmap CombineWithOriginal(Bitmap original, Bitmap highPass)
        {
            Bitmap result = new Bitmap(original.Width, original.Height);
            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color originalColor = original.GetPixel(x, y);
                    Color highPassColor = highPass.GetPixel(x, y);

                    int r = Clip(originalColor.R + highPassColor.R);
                    int g = Clip(originalColor.G + highPassColor.G);
                    int b = Clip(originalColor.B + highPassColor.B);

                    result.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return result;
        }

        private int Clip(int value)
        {
            return Math.Max(0, Math.Min(255, value));
        }

    }
}
