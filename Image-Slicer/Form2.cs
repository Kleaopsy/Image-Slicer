using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        OpenFileDialog ResimSeç = new OpenFileDialog();
        private void Form2_Load(object sender, EventArgs e)
        {
            menuStrip1.Items[1].Enabled = false;
            ResimSeç.Title = "Select Image";
            ResimSeç.Filter = "Image|*.jpg;*.jpeg;*.png";
            ResimSeç.RestoreDirectory = false;
            ResimSeç.InitialDirectory = @"C:\Users\LAB4\Desktop";            
        }

        private void resimSeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ResimSeç.ShowDialog() == DialogResult.OK)
            {        
                

                groupBox1.Controls.Clear();
                menuStrip1.Items[1].Enabled = true;
                PictureBox pbx = new PictureBox();
                pbx.Name = "pbx1";
                pbx.Size = new Size(200,200);
                pbx.Location = new Point(0,0);
                pbx.BackgroundImageLayout = ImageLayout.Zoom;
                pbx.BackgroundImage = Image.FromFile(ResimSeç.FileName);
                Resim = Image.FromFile(ResimSeç.FileName) as Bitmap;
                groupBox1.Controls.Add(pbx);

                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                button1.Visible = true;
            }
            else
            {
                MessageBox.Show("Select an image!");
            }
        }

        int a;
        FolderBrowserDialog Dizi = new FolderBrowserDialog();
        private void CikartilacakDiziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (a==0)
            {
                MessageBox.Show("we'll create 'newImages' folder ");
                a++;
            }
            if (Dizi.ShowDialog()==DialogResult.OK)
            {
                label1.Visible = true;
                label2.Visible = true;
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                button1.Visible = true;
            }
        }

        int X, Y;
        int ResimX, ResimY;
        
        Bitmap Parcabitmap;
        void Parçala(int g, int y)
        {
            ResimX = Resim.Width; ResimY = Resim.Height;
            İmage.Clear();
            
            for (int f1 = 1; f1 <= g*y; f1++)
            {
               
                    Rectangle Kesme = new Rectangle(X, Y, ResimX / g, ResimY / y);
                
                    Parcabitmap=Resim.Clone(Kesme,Resim.PixelFormat);
                
                İmage.Add(Parcabitmap);
                    X += ResimX / g;
                if (f1%g==0)
                {
                    Y += ResimY/y;
                    X = 0;
                }
            }
            X = 0;
            Y = 0;

            Directory.CreateDirectory(Dizi.SelectedPath+@"\newImages");
            for (int i=1;i<=g*y;i++)
            {
                İmage[i - 1].Save(Dizi.SelectedPath + @"\newImages\" + i.ToString() + ".jpg");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Parçala(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value));
        }    


        Bitmap Resim;
        List<Image> İmage = new List<Image>();
    }
}
