using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Photo_Approver
{
    public partial class Form2 : Form1
    {
        List<Button> buttons = new List<Button>();
        public Form2()
        {
            InitializeComponent();
           
        }
        
        DirectoryInfo di = new DirectoryInfo(@"D:\playground\to be approved\");
        
        private void Form2_Load(object sender, EventArgs e)
        {
       
        }
        private void buttons_Click(object sender, EventArgs e)
        {
           
            foreach (Button bu in buttons)
            {
                if(sender == bu)
                {
                    
                    //MessageBox.Show("success!");
                }
            }
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            
           
            foreach(DirectoryInfo dir in di.GetDirectories())
            {
                Button b = new Button();
                b.Text = dir.Name;
                b.Click += new EventHandler(buttons_Click);
                flowLayout.Controls.Add(b);
                buttons.Add(b);
               
            }

            
            
        }
    }
}
