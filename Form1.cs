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
using System.Collections.Specialized;

namespace Photo_Approver
{
    public partial class Form1 : Form
    {
        string location;
        int index = 0;
        string[] imageArray;
        string str_approved = "D:\\playground\\approved";
        string str_not_approved = "D:\\playground\\not approved";
        string resalaLogo = "D:\\resalalogo.png";
        // string str_to_be_approved = @"D:\playground\to be approved\";
     string str_to_be_approved = ConfigurationManager.AppSettings.Get("path");
        
 
        
        //string str_to_be_approved =
        public Form1 Parent { get; set; }
        
        public string getFileName()
        {
            
            FileInfo currfile = new FileInfo(imageArray[index]);
            Console.WriteLine(currfile.Name);
            return currfile.Name;
        }



        public string[] fill_ImageArray(string location)
        {
            int count = 0;
          

            DirectoryInfo di = new DirectoryInfo(location);
            imageArray = new string[di.GetFiles().Length];
            foreach (FileInfo fi in di.GetFiles())
            {
                imageArray[count] = fi.FullName;
                count++;
            }
            if (imageArray.Length < 1 || imageArray == null)
            {
                index = -1;
                MessageBox.Show("there are no images to be approved");
                showImage();
                try
                {
                    di.Delete();
                }
                catch(IOException e)
                {
                    MessageBox.Show("No images in this folder.");
                }
            }
            else
            {
                index = 0;
            }
            return imageArray;
        }

        public int getIndex()
        {
            return index;
        }
        public void next()
        {
            if (index < imageArray.Length - 1)
            {
                index++;
                Console.WriteLine("Index is: " + index);
                showImage();
            }
        }

        public void test2()
        {
            MessageBox.Show("SUCCESS");
        }
        public void previous()
        {
            if (index > 0)
            {
                index--;
                showImage();
            }
        }
        public void showImage(int ind)
        {
            index = ind;
            showImage();
        }
        public void showImage()
        {
            if (index == -1 || imageArray == null)
            {
                using (FileStream fs = new FileStream(resalaLogo, FileMode.Open))
                {
                    pictureBox1.Image = System.Drawing.Image.FromStream(fs);
                    lbl_photoCounter.Text = imageArray.Length + " Photo(s) Left.";
                }
               
            }



            else
            {
                using (FileStream fs = new FileStream(imageArray[index], FileMode.Open))
                {
                    pictureBox1.Image = System.Drawing.Image.FromStream(fs);
                    
                }
           

            }
            lbl_photoCounter.Text = imageArray.Length + " Photo(s) Left.";
        }

        public Form1()
        {
            InitializeComponent();
            //Console.WriteLine("HELLO");
            //  WORKING APP.CONFIG GET
          // string test = ConfigurationManager.AppSettings.Get(0);
          //  Console.WriteLine(" "+test);
        }

        public void testing()
        {
            for (int i = 0; i < imageArray.Length; i++)
            {
                Console.WriteLine("imageArray[" + i + "] is: " + imageArray[i]);
            }
        }

        public void open_Folder(string path)
        {
            location = path;
            fill_ImageArray(location);
            showImage();
        }
        public void open_Folder()
        {
            lbl_photoCounter.Text = " ";
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.RootFolder = Environment.SpecialFolder.MyComputer;

            // dlg.RootFolder = str_to_be_approved;
            
            dlg.SelectedPath = str_to_be_approved;
            if (dlg.ShowDialog() == DialogResult.OK)
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
        private void btn_Open_Click(object sender, EventArgs e)
        {
            open_Folder();
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {

            next();
         

        }

        private void btn_Previous_Click(object sender, EventArgs e)
        {

            previous();
      


        }

        private void btn_Approve_Click(object sender, EventArgs e)
        {
            if (index != -1 || imageArray!=null)
            {
                DirectoryInfo dir = new DirectoryInfo(str_approved);
                FileInfo file = new FileInfo(imageArray[index]);
                string getfilename = getFileName();

                if (File.Exists(Path.Combine(str_approved, getfilename))) 
                {
                    Console.WriteLine("File already Exists");
                    int temp = index;
                    if(index==imageArray.Length-1)
                    previous();
                    else {
                        next();
                    }
                    showImage();

                    File.Delete(imageArray[temp]);
                    imageArray = fill_ImageArray(location);
                    lbl_photoCounter.Text = imageArray.Length + " Photo(s) Left.";


                }
                else
                {
                    File.Copy(imageArray[index], Path.Combine(str_approved, getfilename));
                    int temp = index;
                    if (index == imageArray.Length - 1)
                        previous();
                    else
                    {
                        next();
                    }
                    


                    File.Delete(imageArray[temp]);
                    imageArray = fill_ImageArray(location);
                    lbl_photoCounter.Text = imageArray.Length + " Photo(s) Left.";
                }
            }
            else
            {
                MessageBox.Show("No more Photos");
            }
            
        }

        private void btn_x_Click(object sender, EventArgs e)
        {
            if (index != -1)
            {
                DirectoryInfo dir = new DirectoryInfo(str_not_approved);
                FileInfo file = new FileInfo(imageArray[index]);
                string getfilename = getFileName();

                if (File.Exists(Path.Combine(str_not_approved, getfilename))) 
                {
                    Console.WriteLine("File already Exists");
                    int temp = index;
                    if (index == imageArray.Length - 1)
                        previous();
                    else
                    {
                        next();
                    }
                    showImage();
                    File.Delete(imageArray[temp]);
                    imageArray = fill_ImageArray(location);
                    lbl_photoCounter.Text = imageArray.Length + " Photo(s) Left.";
                }
                else
                {
                    File.Copy(imageArray[index], Path.Combine(str_not_approved, getfilename));
                    int temp = index;
                    if (index == imageArray.Length - 1)
                        previous();
                    else
                    {
                        next();
                    }



                    File.Delete(imageArray[temp]);
                    imageArray = fill_ImageArray(location);
                    lbl_photoCounter.Text = imageArray.Length + " Photo(s) Left.";
                }
            }
            else
            {
                MessageBox.Show("No more Photos");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.superForm = this;
            //f2.Updated += (se, ev) => btn_Approve.Text = "test success";
            f2.ShowDialog();

            
        }
    }
}
