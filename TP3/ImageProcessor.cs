using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;


namespace TP3;

public class ImageProcessor
{
    private string imagePath;
    private int compress;
    private Bitmap image;
    private double[,] imageArray;
    private double[] vectorizedImage;

    public ImageProcessor(string imagePath, int compress = 128)
    {
        this.imagePath = imagePath;
        this.compress = compress;
    }

    public void LoadImage()
    {
        using (var originalImage = new Bitmap(imagePath))
        {
            image = new Bitmap(originalImage, new Size(compress, compress));
        }

        imageArray = new double[compress, compress];
        for (int x = 0; x < compress; x++)
        {
            for (int y = 0; y < compress; y++)
            {
                Color pixel = image.GetPixel(x, y);
                double grayValue = (pixel.R + pixel.G + pixel.B) / 3.0;
                imageArray[x, y] = grayValue;
            }
        }
    }

    public void ProcessImage()
    {
        for (int x = 0; x < compress; x++)
        {
            for (int y = 0; y < compress; y++)
            {
                imageArray[x, y] /= 255.0;
                imageArray[x, y] = (imageArray[x, y] - 0.5) * 2.0;
                imageArray[x, y] = imageArray[x, y] > 0 ? 1 : -1;
            }
        }

        vectorizedImage = imageArray.Cast<double>().ToArray();
    }

    public double[] GetVectorizedImage()
    {
        return vectorizedImage;
    }

    public Bitmap ReconstructImage(double[] vector)
    {
        double[,] reconstructedArray = new double[compress, compress];
        Buffer.BlockCopy(vector, 0, reconstructedArray, 0, vector.Length * sizeof(double));

        Bitmap reconstructedImage = new Bitmap(compress, compress);
        for (int x = 0; x < compress; x++)
        {
            for (int y = 0; y < compress; y++)
            {
                int grayValue = (int)((reconstructedArray[x, y] + 1) / 2.0 * 255.0);
                reconstructedImage.SetPixel(x, y, Color.FromArgb(grayValue, grayValue, grayValue));
            }
        }
        return reconstructedImage;
    }
}
