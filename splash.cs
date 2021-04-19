using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Sistema_de_deciciones_de_Funeraria
{

    public partial class splash : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
        int nLeftRect,
        int nTopRect,
        int RightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHeightEllipse
        );

        public splash()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            progressbar.Value = 0;
        }
        public void timer1_Tick(object sender, EventArgs e)
        {
            progressbar.Value++;
            progressbar.Text = progressbar.Value.ToString() + "%"; ;

            if (progressbar.Value == 100)
            {
                timer1.Enabled = false;
                Paquetes a = new Paquetes();
                a.Show();
                this.Hide();
            }
        }

        private void splash_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
