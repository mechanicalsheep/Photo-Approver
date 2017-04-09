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
using System.Configuration;

namespace Photo_Approver
{
    public partial class Form1 : Form
    {
        string location;
        int index=0;
        string[] imageArray;
        

        public string[] fill_ImageArray(string location)
        {
            int count = 0;
            DirectoryInfo di = new DirectoryInfo(location);
            imageArray = new string[di.GetFiles().Length];
            foreach(FileInfo fi in di.GetFiles())
            {
                imageArray[count] = fi.FullName;
                count++;
            }
            return imageArray;
        }

        public int getIndex()
        {
            return index;
        }
        public void next()
        {
            if (index < imageArray.Length-1)
            {
                index++;
                Console.WriteLine("Index is: " + index);
            }
        }
        public void previous()
        {
            if(index>0)
            index--;
        }
        public void showImage()
        {
            pictureBox1.Image = System.Drawing.Image.FromFile(imageArray[index]);
        }

        public Form1()
        {
            InitializeComponent();
        }

   public void testing()
        {
            for(int i=0; i<imageArray.Length; i++)
            {
                Console.WriteLine("imageArray[" + i + "] is: " + imageArray[i]);
            }
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if(dlg.ShowDialog()==DialogResult.OK)
            {
                location = dlg.SelectedPath;
                //fill the array with the images from the path selected.
                fill_ImageArray(location);

                //show the first image in the path
                showImage();



                //testing environment
                testing();
            }
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            
                next();
                showImage();
           
        }

        private void btn_Previous_Click(object sender, EventArgs e)
        {
           
                previous();
                showImage();

           
        }
    }
}
