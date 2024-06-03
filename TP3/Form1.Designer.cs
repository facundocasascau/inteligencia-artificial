namespace TP3;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private Button btnLoadImage;
    private Button btnTrain;
    private Button btnPredict;
    private PictureBox pbOriginal;
    private PictureBox pbReconstructed;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        btnLoadImage = new Button();
        btnTrain = new Button();
        btnPredict = new Button();
        pbOriginal = new PictureBox();
        pbReconstructed = new PictureBox();
        ((System.ComponentModel.ISupportInitialize)pbOriginal).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbReconstructed).BeginInit();
        SuspendLayout();
        // 
        // btnLoadImage
        // 
        btnLoadImage.Location = new Point(10, 12);
        btnLoadImage.Name = "btnLoadImage";
        btnLoadImage.Size = new Size(88, 23);
        btnLoadImage.TabIndex = 0;
        btnLoadImage.Text = "Load Image";
        btnLoadImage.UseVisualStyleBackColor = true;
        btnLoadImage.Click += btnLoadImage_Click;
        // 
        // btnTrain
        // 
        btnTrain.Location = new Point(103, 12);
        btnTrain.Name = "btnTrain";
        btnTrain.Size = new Size(88, 23);
        btnTrain.TabIndex = 1;
        btnTrain.Text = "Train";
        btnTrain.UseVisualStyleBackColor = true;
        btnTrain.Click += btnTrain_Click;
        // 
        // btnPredict
        // 
        btnPredict.Location = new Point(196, 12);
        btnPredict.Name = "btnPredict";
        btnPredict.Size = new Size(88, 23);
        btnPredict.TabIndex = 2;
        btnPredict.Text = "Predict";
        btnPredict.UseVisualStyleBackColor = true;
        btnPredict.Click += btnPredict_Click;
        // 
        // pbOriginal
        // 
        pbOriginal.BorderStyle = BorderStyle.FixedSingle;
        pbOriginal.Location = new Point(10, 41);
        pbOriginal.Name = "pbOriginal";
        pbOriginal.Size = new Size(224, 256);
        pbOriginal.SizeMode = PictureBoxSizeMode.Zoom;
        pbOriginal.TabIndex = 3;
        pbOriginal.TabStop = false;
        // 
        // pbReconstructed
        // 
        pbReconstructed.BorderStyle = BorderStyle.FixedSingle;
        pbReconstructed.Location = new Point(240, 41);
        pbReconstructed.Name = "pbReconstructed";
        pbReconstructed.Size = new Size(224, 256);
        pbReconstructed.SizeMode = PictureBoxSizeMode.Zoom;
        pbReconstructed.TabIndex = 4;
        pbReconstructed.TabStop = false;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(476, 311);
        Controls.Add(pbReconstructed);
        Controls.Add(pbOriginal);
        Controls.Add(btnPredict);
        Controls.Add(btnTrain);
        Controls.Add(btnLoadImage);
        Name = "Form1";
        Text = "Hopfield Image Recognition";
        Load += Form1_Load;
        ((System.ComponentModel.ISupportInitialize)pbOriginal).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbReconstructed).EndInit();
        ResumeLayout(false);
    }
}
