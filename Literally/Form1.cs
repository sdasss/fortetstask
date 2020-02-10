using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;



namespace Literally
{


    public partial class Form1 : Form
    {
        int h = 1;
        int z = -1;
        int vbn = 0;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.Save_text1;
            textBox2.Text = Properties.Settings.Default.Save_text2;
            textBox3.Text = Properties.Settings.Default.Save_text3;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;

        }

        private async void mayun()
        {
            bool bvn = false;
            List<string> puti = new List<string>();
            TreeNode LastNode = null;
        Bruacingtelo:
            if (vbn == 1)
            {
                treeView1.Nodes.Clear();
                vbn = 0;
                LastNode = null;
                puti.Clear();
            }


            Stopwatch sw = new Stopwatch();
            z = 0;


            Properties.Settings.Default.Save_text1 = textBox1.Text;
            Properties.Settings.Default.Save_text2 = textBox2.Text;
            Properties.Settings.Default.Save_text3 = textBox3.Text;
            Properties.Settings.Default.Save();


            textBox4.Text = Convert.ToString(z);
            string FileDire = textBox1.Text;
            string Tamplat = textBox2.Text;
            string FandTaxt = textBox3.Text;

            treeView1.Nodes.Clear();

                sw.Start();
            foreach (var findedFile in Directory.EnumerateFiles(FileDire, Tamplat, SearchOption.AllDirectories))
            {
                textBox6.Text = findedFile;
                var dt17 = DateTime.Now;
                while (h == 0)
                {
                    await Task.Delay(1);



                    TimeSpan ts1 = sw.Elapsed;
                    textBox5.Text = Convert.ToString(ts1);




                }


                textBox4.Text = Convert.ToString(z);
                if (vbn == 1) goto Bruacingtelo;

                TimeSpan ts = sw.Elapsed;

                textBox5.Text = Convert.ToString(ts);


                await Task.Delay(1);





                string tmp = File.ReadAllText(findedFile);
                if (tmp.Contains(FandTaxt))
                {

                    string PolnyPutj = string.Empty;
                    foreach (string Putj in findedFile.Split('\\'))
                    {

                        TimeSpan ts1 = sw.Elapsed;

                        textBox5.Text = Convert.ToString(ts1);
                        PolnyPutj = PolnyPutj + Putj + '\\';
                        bvn = false;
                        if (LastNode != null && puti.Contains(PolnyPutj))

                            bvn = true;


                        if (!puti.Contains(PolnyPutj)) puti.Add(PolnyPutj);
                        if (LastNode == null)
                            LastNode = treeView1.Nodes.Add(PolnyPutj, Putj);
                        else
                        {
                            if (bvn == true)
                            {
                                TreeNode[] Founded = treeView1.Nodes.Find(PolnyPutj, true);
                                LastNode = Founded[0];
                            }
                            else
                            {
                                LastNode = LastNode.Nodes.Add(PolnyPutj, Putj);
                            }
                        }




                    }

                }




                TimeSpan ts2 = sw.Elapsed;
                textBox5.Text = Convert.ToString(ts2);


                z += 1;

                textBox4.Text = z.ToString();


            }



            sw.Stop();

            TimeSpan ts3 = sw.Elapsed;
            textBox5.Text = Convert.ToString(ts3);
            z = -1;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;

        }


        private void Button3_Click(object sender, EventArgs e)
        {
            h = 1;
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = false;
            if (z == -1)
                mayun();
            else
            {
                vbn = 1;
                h = 1;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            h = 0;
            button3.Enabled = true;
            button2.Enabled = false;
            button1.Enabled = true;
        }





        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
