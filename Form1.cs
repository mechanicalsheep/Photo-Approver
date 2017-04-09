using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photo_Approver
{
    public partial class Form1 : Form
    {
        string location;
        int index;
        string[] imageArray;
        
        public string[] fill_imageArray()
        {

            return imageArray;
        }
        public Form1()
        {
            InitializeComponent();
        }

   

        private void btn_Open_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                location = openFileDialog1.FileName;
            }
        }
    }
}
