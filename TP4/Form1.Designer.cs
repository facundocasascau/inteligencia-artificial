namespace TP4;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

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
        this.btnLoadImage = new System.Windows.Forms.Button();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.comboBox1 = new System.Windows.Forms.ComboBox();
        this.btnProcessImage = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        this.SuspendLayout();
        // 
        // btnLoadImage
        // 
        this.btnLoadImage.Location = new System.Drawing.Point(12, 12);
        this.btnLoadImage.Name = "btnLoadImage";
        this.btnLoadImage.Size = new System.Drawing.Size(120, 29);
        this.btnLoadImage.TabIndex = 0;
        this.btnLoadImage.Text = "Cargar Imagen";
        this.btnLoadImage.UseVisualStyleBackColor = true;
        this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
        // 
        // pictureBox1
        // 
        this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.pictureBox1.Location = new System.Drawing.Point(12, 86);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(776, 352);
        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom; // Cambia el tamaño de la imagen para llenar el PictureBox y mantener la relación de aspecto
        this.pictureBox1.TabIndex = 1;
        this.pictureBox1.TabStop = false;
        // 
        // comboBox1
        // 
        this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBox1.FormattingEnabled = true;
        this.comboBox1.Items.AddRange(new object[] {
            "HoughCircle",
            "HoughLine"});
        this.comboBox1.Location = new System.Drawing.Point(138, 12);
        this.comboBox1.Name = "comboBox1";
        this.comboBox1.Size = new System.Drawing.Size(151, 28);
        this.comboBox1.TabIndex = 2;
        // 
        // btnProcessImage
        // 
        this.btnProcessImage.Location = new System.Drawing.Point(295, 12);
        this.btnProcessImage.Name = "btnProcessImage";
        this.btnProcessImage.Size = new System.Drawing.Size(120, 29);
        this.btnProcessImage.TabIndex = 3;
        this.btnProcessImage.Text = "Procesar Imagen";
        this.btnProcessImage.UseVisualStyleBackColor = true;
        this.btnProcessImage.Click += new System.EventHandler(this.btnProcessImage_Click);
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Controls.Add(this.btnProcessImage);
        this.Controls.Add(this.comboBox1);
        this.Controls.Add(this.pictureBox1);
        this.Controls.Add(this.btnLoadImage);
        this.Name = "Form1";
        this.Text = "Detección de Hough";
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Button btnLoadImage;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Button btnProcessImage;
}