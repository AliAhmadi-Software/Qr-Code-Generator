using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.QrCodeNet.Encoding;
using ZXing;

namespace Qr_Code_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            qr.Text = txtText.Text;
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                qr.Image = Bitmap.FromFile(open.FileName);
                IBarcodeReader Reader = new BarcodeReader();
                var BarcodeBitmap = (Bitmap)Bitmap.FromFile(open.FileName);
                var Result = Reader.Decode(BarcodeBitmap);
                txtText.Text = Result.Text;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog Save = new SaveFileDialog();
            Save.Filter = " Jpeg File(*.jpg)|*.jpg | Bitmap File (*.bmp) |*.bmp | Png File )(*.png)|*.png";
            if (Save.ShowDialog() == DialogResult.OK)
            {
                Bitmap b = new Bitmap(qr.Image, 500, 500);
                b.Save(Save.FileName);

            }
        }
    }
}
