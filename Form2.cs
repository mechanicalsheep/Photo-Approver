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
    public partial class Form2 : Form
    {
        List<Button> buttons = new List<Button>();
        public event EventHandler Updated;
        public Form1 superForm{ get; set; }
      /*public Form2(Form fm)
        {
            this.Parent = fm;
        
        }*/
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
                    //WORKING TEST!!!!!!!!!!!!!!!!!!
                    //superForm.test2();

                    //Console.WriteLine("Path: "+ Path.Combine(@"D:\playground\to be approved\", bu.Name.ToString()));
                   superForm.open_Folder(Path.Combine(@"D:\playground\to be approved\",bu.Text));
                   this.Close();
                    //MessageBox.Show("success!");
                }
            }
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            /* if (Updated != null)
              {
                  Updated(sender, new EventArgs()); //Raise a change.
              }
              */
           
     
            foreach (DirectoryInfo dir in di.GetDirectories())
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
