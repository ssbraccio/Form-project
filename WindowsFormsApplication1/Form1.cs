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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string ImageDir = desktopPath + "\\IMAGE_PATH\\"; 

            DirectoryInfo di = new DirectoryInfo(ImageDir);
            if (di.Exists)
            {
                System.IO.DirectoryInfo[] dirInfos = di.GetDirectories();
                
                foreach (System.IO.DirectoryInfo d in dirInfos)
                {
                    lbOne.DataSource = dirInfos;
                }

                for (int i = 0; i < this.lbOne.Items.Count; i++)
                {
                    this.lbOne.SetSelected(i, true);

                    String item = lbOne.SelectedItem.ToString();

    
                    string destfilename =   item + "-0000.tif";
      
          

  
                    DirectoryInfo d = new DirectoryInfo(desktopPath);

                    string sourceFile = desktopPath + "\\IMAGE_FILE\\" + sMFName.Text + ".TIF";
                    string destFile = desktopPath +  "\\IMAGE_PATH\\" + item + "\\"  + destfilename;           
               

                    Directory.SetCurrentDirectory(ImageDir + item);

                    // sMFName = 413-044 entered by user 

                    string sMF = "";
                    String sLMF = "";
                    Boolean bIncrement = true;



                    if (File.Exists(item + @"-0000.tif"))
                    {
                        System.Diagnostics.Debug.WriteLine("source" + sourceFile);

                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Dest" + destFile);

                        // convert to number - increment and convert back to string 
                        if (String.IsNullOrEmpty(sMFName.Text))
                        {
                            MessageBox.Show("Please enter the next file name", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                           
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(sMFName.Text))
                            {
                                sMFName.Text = "000-0000";
                            }


                            sourceFile = Path.GetFullPath(sourceFile);
                            destFile = Path.GetFullPath(destFile) ;
                            if (System.IO.File.Exists(destFile))
                            {
                                bIncrement = false;
                            }
                            else
                            {
                                File.Move(sourceFile, destFile);
                                bIncrement = true;

                            }
                        }
                    }
                    if (bIncrement == true)
                    {
                        if (sMFName.Text.Length >= 8)
                        {
                            sMF = sMFName.Text.Substring(4, 4);
                            sLMF = sMFName.Text.Substring(0, 3);
                        }
                        // sMF = 004                 
                        // nMF = 5
                        Int32 nMF = Convert.ToInt32(sMF) + 1;
                        // sMF = 0005
                        sMF = "000" + Convert.ToString(nMF);
                        if (sMF.Length > 4)
                        {
                            sMF = sMF.Substring(sMF.Length-4);
    //                            sMF = sMF.Remove(0, 1);
                         }
                           
                         
                        // 
                        sMFName.Text = sLMF + @"-" + sMF;
                    }
                }
            }
        }

         

    }


}
        
        

    


