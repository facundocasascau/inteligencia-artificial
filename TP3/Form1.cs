using System;
using System.Drawing;
using System.Windows.Forms;

namespace TP3;

public partial class Form1 : Form
{
    private HopfieldNetwork hopfieldNetwork;
    private ImageProcessor imageProcessor;
    private int imageSize = 128;

    public Form1()
    {
        InitializeComponent();
    }

    private void btnLoadImage_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imageProcessor = new ImageProcessor(openFileDialog.FileName, imageSize);
                imageProcessor.LoadImage();
                imageProcessor.ProcessImage();

                pbOriginal.Image = new Bitmap(openFileDialog.FileName);
            }
        }
    }

    private void btnTrain_Click(object sender, EventArgs e)
    {
        if (imageProcessor != null)
        {
            hopfieldNetwork = new HopfieldNetwork(imageSize * imageSize);
            hopfieldNetwork.Train(new double[][] { imageProcessor.GetVectorizedImage() });
            MessageBox.Show("Training completed!");
        }
    }

    private void btnPredict_Click(object sender, EventArgs e)
    {
        if (imageProcessor != null && hopfieldNetwork != null)
        {
            double[] predicted = hopfieldNetwork.Predict(imageProcessor.GetVectorizedImage());
            Bitmap reconstructed = imageProcessor.ReconstructImage(predicted);
            pbReconstructed.Image = reconstructed;
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }
}
