using System;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace TP4;

public partial class Form1 : Form
{
    private Mat img;  // Variable para almacenar la imagen cargada

    public Form1()
    {
        InitializeComponent();
    }

    private void btnLoadImage_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string filePath = openFileDialog.FileName;
            img = Cv2.ImRead(filePath, ImreadModes.Grayscale);
            pictureBox1.Image = BitmapConverter.ToBitmap(img);
        }
    }

    private void btnProcessImage_Click(object sender, EventArgs e)
    {
        if (img == null)
        {
            MessageBox.Show("Please load an image first.");
            return;
        }

        Mat result;

        if (comboBox1.SelectedItem.ToString() == "HoughCircle")
        {
            result = HoughCircle.ProcessImage(img);
        }
        else if (comboBox1.SelectedItem.ToString() == "HoughLine")
        {
            result = HoughLine.ProcessImage(img);
        }
        else
        {
            MessageBox.Show("Please select a processing method.");
            return;
        }

        pictureBox1.Image = BitmapConverter.ToBitmap(result);
    }
}