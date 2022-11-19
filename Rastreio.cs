using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RastreioAPI
{
    public partial class Rastreio : Form
    {
        public Rastreio()
        {
            InitializeComponent();
        }

        private void PROCURAR_Click(object sender, EventArgs e)
        {
            API_Manager apiManager = new API_Manager();
            
            if(textBox1.Text == "")
            {
                MessageBox.Show("Favor colocar codigo de rastreio","RASTREIO",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                apiManager.Run(textBox1.Text);
            }
            
        }
    }
}
