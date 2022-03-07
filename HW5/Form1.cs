namespace HW5
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void load_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg;*.jpeg; *.gif; *.bmp; *.png)| *.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                image.Image = new Bitmap(ofd.FileName);
                image.Size = image.Image.Size;
            }

            this.Width = image.Width + 100;
            this.Height = image.Height + 50;
        }

        Bitmap get_grayscale(Bitmap og)
        {
            Bitmap gray = new Bitmap(image.Width, image.Height);
            for (int y = 0; y < gray.Height; y++)
            {
                for (int x = 0; x < gray.Width; x++)
                {
                    Color c = og.GetPixel(x, y);
                    int Y = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
                    gray.SetPixel(x, y, Color.FromArgb(Y, Y, Y));
                }
            }
            return gray;
        }

        private void grayscale_Click(object sender, EventArgs e)
        {
            if (image == null || image.Image == null)
                return;

            Bitmap gray = get_grayscale((Bitmap)image.Image);
            Form wn = new Form2();
            wn.Text = "Grayscale of Original Image";
            PictureBox pict = new PictureBox();
            pict.Image = gray;
            pict.Size = gray.Size;
            wn.Controls.Add(pict);
            wn.Show();
        }

        float[] cdf;
        int[] f;
        int m;

        private int[,] equilization(int[,] img, int w, int h, bool newCDF)
        {
            if (newCDF)
            {
                m = 0;
                cdf = new float[256];
                f = new int[256];
                for (int i = 0; i < 256; i++)
                {
                    cdf[i] = 0f;
                    f[i] = 0;
                }

                for (int x = 0; x < w; x++)
                {
                    for (int y = 0; y < h; y++)
                    {
                        f[img[x, y]]++;
                        m = Math.Max(m, img[x, y]);
                    }
                }

                cdf[0] = f[0];
                for (int j = 1; j < 256; j++)
                    cdf[j] = cdf[j - 1] + f[j];
                for (int j = 0; j < 256; j++)
                    cdf[j] = cdf[j] / cdf[255];
            }

            int[,] result = new int[w, h];
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    result[x, y] = (int)((float)(m - 1) * cdf[img[x, y]]);
                }
            }

            return result;
        }

        private void histogram_Click(object sender, EventArgs e)
        {
            Bitmap img = (Bitmap)image.Image;

            // perform for the grayscale histogram equilization
            int[,] values = new int[img.Width, img.Height];
            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    values[x, y] = img.GetPixel(x, y).R;
                }
            }

            int[,] nValues = equilization(values, img.Width, img.Height, true);

            if (grayscale_check.Checked)
            {
                Bitmap gray = get_grayscale((Bitmap)image.Image);
                for (int x = 0; x < gray.Width; x++)
                {
                    for (int y = 0; y < gray.Height; y++)
                    {
                        gray.SetPixel(x, y, Color.FromArgb(nValues[x, y], nValues[x, y], nValues[x, y]));
                    }
                }

                Form wn = new Form2();
                wn.Text = "Histogram Equilization of Grayscale Image";
                PictureBox pict = new PictureBox();
                pict.Image = gray;
                pict.Size = gray.Size;
                wn.Controls.Add(pict);
                wn.Show();
            }

            // perform for the RGB histogram equilization
            if (original_check.Checked)
            {
                Bitmap rgb = new Bitmap(image.Image.Width, image.Image.Height);
                Bitmap picture = (Bitmap)image.Image;
                int[,] Rvalues = new int[rgb.Width, rgb.Height];
                int[,] Gvalues = new int[rgb.Width, rgb.Height];
                int[,] Bvalues = new int[rgb.Width, rgb.Height];
                for (int x = 0; x < rgb.Width; x++)
                {
                    for (int y = 0; y < rgb.Height; y++)
                    {
                        Color c = picture.GetPixel(x, y);
                        Rvalues[x, y] = c.R;
                        Gvalues[x, y] = c.G;
                        Bvalues[x, y] = c.B;
                    }
                }

                int[,] nRvalues = equilization(Rvalues, rgb.Width, rgb.Height, false);
                int[,] nGvalues = equilization(Gvalues, rgb.Width, rgb.Height, false);
                int[,] nBvalues = equilization(Bvalues, rgb.Width, rgb.Height, false);

                for (int x = 0; x < rgb.Width; x++)
                {
                    for (int y = 0; y < rgb.Height; y++)
                    {
                        rgb.SetPixel(x, y, Color.FromArgb(nRvalues[x, y], nGvalues[x, y], nBvalues[x, y]));
                    }
                }

                Form wn2 = new Form2();
                wn2.Text = "Histogram Equilization of Image";
                PictureBox pict2 = new PictureBox();
                pict2.Image = rgb;
                pict2.Size = rgb.Size;
                wn2.Controls.Add(pict2);
                wn2.Show(); 
            }
        }

        private void close_results_Click(object sender, EventArgs e)
        {
            Application.OpenForms
                .OfType<Form2>()
                .Where(form => form.Name == "Form2")
                .ToList()
                .ForEach(form => form.Close());
        }
    }
}