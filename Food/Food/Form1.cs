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

namespace Food
{
    public partial class Form1 : Form
    {
        const string fileName = "places.txt";
        string[] all;
        public Form1()
        {
            InitializeComponent();

            string line;
            StreamReader read;
            read = File.OpenText(fileName);
            while (!read.EndOfStream)
            {
                //Read Line
                line = read.ReadLine();
                //Split at comma
                all = line.Split(',');
                foreach(string name in all)
                {
                    checkedListBox1.Items.Add(name);
                }
            }
            read.Close();
            
        }

        private void buttonRoll_Click(object sender, EventArgs e)
        {
            //Clearing pb
            pictureBox1.Refresh();

            //Rng
            var random = new Random();

            //Index
            int index = random.Next(0, checkedListBox1.CheckedItems.Count);

            //Creating graphics
            Graphics graphics = pictureBox1.CreateGraphics();

            //Displaying option
            using (Font myFont = new Font("Arial", 14))
            {
                graphics.DrawString(checkedListBox1.CheckedItems[index].ToString(), myFont, Brushes.Black, new Point(2, 2));
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //Adding items sp[ecified by text box to list
            checkedListBox1.Items.Add(textBoxAdd.Text);

            StreamWriter write;
            write = File.AppendText(fileName);
            write.Write(","+textBoxAdd.Text);
            write.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxAdd.Clear();
            pictureBox1.Refresh();
        }

        private void buttonListClear_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach(string s in checkedListBox1.CheckedItems)
            {
                all.Where(x => !s.Equals(x)).ToArray();
            }
            StreamWriter write;
            File.WriteAllText(fileName, string.Empty);
            write = File.AppendText(fileName);
            write.Write(all[0]);
            for(int i = 1; i < all.Length; i++)
            {
                write = File.AppendText(","+all[i]);
            }
            write.Close(); 
        }
    }
}
