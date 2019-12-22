using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace handwritten_text_recognition
{
    public partial class Form1 : Form
    {

        Image<Bgr, byte> imgInput;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialogObject = new OpenFileDialog();

            if (openFileDialogObject.ShowDialog() == DialogResult.OK)
            {
                imgInput = new Image<Bgr, byte>(openFileDialogObject.FileName);
                pictureBox1.Image = imgInput.Bitmap;
            }
        }
    }
}
