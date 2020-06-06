using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace WindowsFormsApp2
{
    public partial class MainForm : Form
    {
        string filePath = "";
        bool needsSaving = false;
        
        public MainForm()
        {
            InitializeComponent();
            saveFileDialog1.FileOk += (s,e) => WriteToFile(saveFileDialog1.FileName);             
        }


        private void WriteToFile(string fileName)
        {
            if (Path.GetExtension(fileName) == ".rtf")
            {
                richTextBox1.SaveFile(fileName);
            }
            else
            {
                var output = new StreamWriter(File.OpenWrite(fileName));
                output.Write(richTextBox1.Text);
                output.Close();
            }
            filePath = fileName;
            needsSaving = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                richTextBox1.Clear();

                if (Path.GetExtension(filePath) == ".rtf")
                {
                    richTextBox1.LoadFile(filePath);
                }
                else
                {
                    var input = File.OpenText(openFileDialog1.FileName);                
                    richTextBox1.Text = input.ReadToEnd();
                    input.Close();
                }

                richTextBox1.Enabled = true;
                needsSaving = false;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (needsSaving)
            {
                saveFileDialog1.FileName = filePath;
                saveFileDialog1.ShowDialog();
            } else
            {
                WriteToFile(filePath);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newFileDialog = new NewFileForm();
            if (newFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                richTextBox1.Enabled = true;
                filePath = newFileDialog.FileName;
                needsSaving = true;
                richTextBox1.Clear();
            }
        }    
    }
}
