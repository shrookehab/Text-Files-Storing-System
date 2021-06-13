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
using System.Xml;
using System.Xml.Serialization;

namespace File_Project
{
    [Serializable]
    public partial class Form1 : Form
    {
        bool kywd = false, cteg = false, filenam = false, reprt = false, categories = true, Suarch = false;
        string category, filename, repwrt, keywrd = "", keywd;
        public Form1()
        {
            InitializeComponent();
            side.Height = button1.Height; side.Top = button1.Top; replace.Hide(); ca.Hide(); rep.Hide();
            kw.Hide(); arrow1.Hide(); arrow2.Hide(); replace1.Hide(); Cat.Hide(); keey.Hide(); fn.Hide(); filname.Hide(); categ.Hide(); arrow3.Hide(); arrow4.Hide();
            Cate.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e)
        {
            arrow1.Hide(); arrow2.Hide(); arrow3.Hide(); arrow4.Hide(); categ.Hide(); filname.Hide();
            side.Height = button1.Height; side.Top = button1.Top; Cate.Show(); highlight.Show(); search1.Show();
            categories = true; Suarch = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (categories)
            {
                label12.Text = "Old Category";
                label13.Text = "New Category";
                Cat.Show(); Cat.Text = category; cteg = true; replace.Show(); replace1.Hide(); old.Text = ""; New.Text = ""; keey.Text = ""; keey.Hide();
            }
            else if (Suarch) { searchfile.Show(); searchCat.Show(); searchfcat.Hide(); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            side.Height = button4.Height; side.Top = button4.Top; Cate.Hide();
            categories = false; Suarch = true; 
            timer2.Stop(); timer1.Stop();
            rep.Hide(); fn.Hide(); ca.Hide(); kw.Hide(); arrow1.Hide(); arrow2.Hide();
            searchfile.Hide(); highlight.Show(); search1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        int c = 0, l = 0, x = 0, z = 0, v = 0, m = 0;

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (categories) { z++; l = 0; arrow1.Hide(); arrow2.Hide(); timer2.Stop(); timer1.Start(); }
            else if (Suarch) { v++; timer1.Start(); }
        }

        private void button12_Click(object sender, EventArgs e)
        {


        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
        private void panel3_Paint(object sender, PaintEventArgs e) { }

        int h = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (categories)
            {
                if (z % 2 != 0)
                {
                    h++;
                    if (h == 1) { ca.Show(); }
                    else if (h == 2) { kw.Show(); }
                    else if (h == 3) { fn.Show(); }
                    else { rep.Show(); h = 0; timer1.Stop(); }
                }
                else
                {
                    h++;
                    if (h == 1) { rep.Hide(); }
                    else if (h == 2) { fn.Hide(); }
                    else if (h == 3) { kw.Hide(); }
                    else { ca.Hide(); h = 0; timer1.Stop(); }
                }
            }
            else if (Suarch)
            {
                if (v % 2 != 0)
                {
                    if (h == 0) { ca.Show(); h++; }
                    else if (h == 1) { kw.Show(); h++; }
                    else { fn.Show(); h = 0; timer1.Stop(); }
                }
                else
                {
                    h++;
                    if (h == 1) { filname.Hide(); }
                    else if (h == 2) { arrow4.Hide(); }
                    else if (h == 3) { categ.Hide(); }
                    else if (h == 4) { arrow3.Hide(); }
                    else if (h == 5) { fn.Hide(); }
                    else if (h == 6) { kw.Hide(); }
                    else { ca.Hide(); h = 0; timer1.Stop(); }
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (l % 2 == 0) { arrow1.Show(); arrow2.Hide(); l++; }
            else { arrow1.Hide(); arrow2.Show(); l++; }
        }

        private void fn_Click(object sender, EventArgs e)
        {
            if (categories)
            {
                label12.Text = "Old File";
                label13.Text = "New File";
                Cat.Show(); Cat.Text = filename; filenam = true; replace.Show(); replace1.Hide(); old.Text = ""; New.Text = ""; keey.Text = ""; keey.Hide();
            }
            else if (Suarch) timer3.Start();
        }

        private void rep_Click(object sender, EventArgs e)
        {
            old.Enabled = false;
            label14.Text = "New Report";
            label15.Text = "Old Report";
            keey.Show(); keey.Text = repwrt; reprt = true; replace1.Show();
            replace.Hide(); od.Text = ""; nw.Text = ""; Cat.Text = ""; Cat.Hide();
        }

        private void kw_Click(object sender, EventArgs e)
        {
            if (categories)
            {
                label14.Text = "New Key";
                label15.Text = "Old Key";
                Cat.Text = ""; Cat.Hide();
                replace.Hide(); od.Text = ""; nw.Text = "";
                old.Enabled = true;
                string[] arr = keywrd.Split('@');
                keey.Show(); keey.Text = "";
                for (int i = 0; i < arr.Length; i++)
                {
                    if (c % 4 != 0)
                        keey.Text += arr[i] + "   ";
                    else if (c % 4 == 0 && i != 0)
                        keey.Text += "\n" + arr[i] + "   ";
                    c++;
                }
                kywd = true; replace1.Show();
            }
            else if (Suarch)
            {
                searchfile.Hide();
            }
        }
        private void richTextBox2_TextChanged(object sender, EventArgs e) { }

        private void EditCat_Click(object sender, EventArgs e)
        {
            side.Height = EditCat.Height; side.Top = EditCat.Top; Cate.Hide(); search1.Hide();
            categories = false; Suarch = false;
            timer2.Stop(); timer1.Stop(); highlight.Hide();
            rep.Hide(); fn.Hide(); ca.Hide(); kw.Hide(); arrow1.Hide(); arrow2.Hide(); arrow3.Hide(); arrow4.Hide(); categ.Hide(); filname.Hide();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "Category" && textBox3.Text != "File Name" && richTextBox1.Text != "Report")
            {
                category = textBox1.Text;
                filename = textBox3.Text;
                repwrt = richTextBox1.Text;
            }
            if (category != null && filename != null && repwrt != null && x != 0)
            {
                invaled.Text = "";
                keywd = keywrd;
                textBox1.Text = "";
                textBox3.Text = "";
                richTextBox1.Text = "";
                if (richTextBox1.Text == "") { richTextBox1.Text = "Report"; invalr.Text = ""; richTextBox1.ForeColor = Color.Silver; }
                if (textBox1.Text == "") { textBox1.Text = "Category"; invalcat.Text = ""; textBox1.ForeColor = Color.Silver; }
                if (textBox3.Text == "") { textBox3.Text = "File Name"; invalf.Text = ""; textBox3.ForeColor = Color.Silver; }
                string[] arr = keywd.Split('@');
                DialogResult result = MessageBox.Show("Do You Wanna Edit anything before Saving ?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) timer2.Start();
                else if (result == DialogResult.No)
                {
                    x = 0;
                    notifications.Text = "";
                    keywd = keywrd;
                    x = 0;
                    notifications.Text = "";
                    keywd = keywrd;
                    string[] keeyword = keywd.Split('@');
                    keywd = ""; keywrd = "";
                    //Categories categ = new Categories(category);
                    List<string> categ = new List<string>();
                    for (int i = 0; i < keeyword.Length; i++)
                    {
                        categ.Add(keeyword[i]);
                    }
                    //Write information to xml file
                    string filenam = @filename;
                    string filePath = AppDomain.CurrentDomain.BaseDirectory + filename;
                    FileInfo file = new FileInfo(filenam, filePath);
                    file.CategoryList.Add(category, categ);
                    if (!File.Exists("FileInfo.xml"))
                    {
                        // Console.WriteLine(filePath);
                        XmlDocument doc = new XmlDocument();
                        XmlWriter Writer = XmlWriter.Create("FileInfo.xml");
                        Writer.WriteStartDocument();
                        Writer.WriteStartElement("FileInformation");
                        Writer.WriteStartElement("CategoryInfo");
                        Writer.WriteStartElement("File");
                        Writer.WriteAttributeString("Name", filenam);
                        //Writer.WriteString(file.FileName);
                        
                        Writer.WriteStartElement("FilePath");
                        Writer.WriteString(file.FilePath);
                        Writer.WriteEndElement();
                        Writer.WriteStartElement("Category");
                        Writer.WriteAttributeString("Name", category);
                        //Writer.WriteString(category);
                        
                        for (int i = 0; i < file.CategoryList.Count; i++)
                        {
                            for (int j = 0; j < file.CategoryList.ElementAt(i).Value.Count - 1; j++)
                            {
                                Writer.WriteStartElement("Keyword");
                                Writer.WriteString(file.CategoryList.ElementAt(i).Value[j]);
                                Writer.WriteEndElement();
                            }

                        }
                        Writer.WriteEndElement();
                        Writer.WriteEndElement();
                        Writer.WriteEndElement();
                        Writer.WriteEndElement();
                        Writer.WriteEndDocument();
                        Writer.Close();
                        string fna = filename + ".txt";
                        FileStream fs = new FileStream(fna, FileMode.Append);
                        StreamWriter sw = new StreamWriter(fs);
                        repwrt = "  " + repwrt;
                        sw.WriteLine(repwrt);
                        sw.Close();
                        fs.Close();
                    }
                    else
                    {
                        XmlDocument doc = new XmlDocument();
                        XmlElement fileinfo = doc.CreateElement("CategoryInfo");
                        XmlElement fname = doc.CreateElement("FileName");
                        fname.InnerText = file.FileName;
                        fileinfo.AppendChild(fname);
                        XmlElement fpath = doc.CreateElement("Filepath");
                        fpath.InnerText = file.FilePath;
                        fileinfo.AppendChild(fpath);
                        XmlElement cname = doc.CreateElement("CategoryName");
                        cname.InnerText = category;
                        fileinfo.AppendChild(cname);
                        for (int i = 0; i < file.CategoryList.Count; i++)
                        {
                            for (int j = 0; j < file.CategoryList.ElementAt(i).Value.Count - 1; j++)
                            {
                                XmlElement node = doc.CreateElement("Keyword");
                                node.InnerText = file.CategoryList.ElementAt(i).Value.ElementAt(j);
                                fileinfo.AppendChild(node);
                            }

                        }
                        doc.Load("FileInfo.xml");
                        XmlElement root = doc.DocumentElement;
                        root.AppendChild(fileinfo);
                        doc.Save("FileInfo.xml");

                        List<FileInfo> FileInformation = new List<FileInfo>();
                        XmlNodeList list = doc.GetElementsByTagName("CategoryInfo");
                        for (int i = 0; i < list.Count; i++)
                        {
                            Dictionary<string, List<string>> CategList = new Dictionary<string, List<string>>();
                            XmlNodeList children = list[i].ChildNodes;
                            string z = children[0].InnerText;
                            string y = children[1].InnerText;
                            string name = children[2].InnerText;
                            richTextBox7.Text += z;
                            richTextBox7.Text += "        ";
                            richTextBox7.Text += y;
                            richTextBox7.Text += "       ";
                            richTextBox7.Text += name;
                            richTextBox7.Text += "      ";
                            List<string> ana = new List<string>();
                            for (int j = 3; j < children.Count; j++)
                            {
                                string c = children[j].InnerText;
                                richTextBox7.Text += c;
                                richTextBox7.Text += "      ";
                                ana.Add(c);
                            }
                            FileInfo a = new FileInfo(z, y);
                            CategList.Add(name, ana);
                            FileInformation.Add(a);
                        }

                    }
                    category = null;
                    filename = null;
                    repwrt = null;
                    MessageBox.Show("File is Saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (richTextBox1.Text == "Report") invalr.Text = "InValid";
                else { richTextBox1.Text = ""; richTextBox1.Text = "Report"; richTextBox1.ForeColor = Color.Silver; }

                if (textBox1.Text == "Category") invalcat.Text = "InValid";
                else { textBox1.Text = ""; textBox1.Text = "Category"; textBox1.ForeColor = Color.Silver; }

                if (textBox3.Text == "File Name") invalf.Text = "InValid";
                else { textBox3.Text = ""; textBox3.Text = "File Name"; textBox3.ForeColor = Color.Silver; }

                if (x == 0) invalkey.Text = "InValid";
            }
        }

        private void keyword_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Key Word") invalkey.Text = "InValid";
            else
            {
                x++;
                notifications.Text = x.ToString();
                keywrd += textBox2.Text + "@";
                textBox2.Text = "";
                textBox2.Text = "Key Word";
                textBox2.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Key Word") { textBox2.Text = ""; invalkey.Text = ""; textBox2.ForeColor = Color.Black; }
        }

        private void textBox2_Leave_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "") { textBox2.Text = "Key Word"; invalkey.Text = ""; textBox2.ForeColor = Color.Silver; }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Category") { textBox1.Text = ""; invalcat.Text = ""; textBox1.ForeColor = Color.Black; }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { textBox1.Text = "Category"; invalcat.Text = ""; textBox1.ForeColor = Color.Silver; }
        }

        private void textBox3_Enter_1(object sender, EventArgs e)
        {
            if (textBox3.Text == "File Name") { textBox3.Text = ""; invalf.Text = ""; textBox3.ForeColor = Color.Black; }
        }

        private void textBox3_Leave_1(object sender, EventArgs e)
        {
            if (textBox3.Text == "") { textBox3.Text = "File Name"; invalf.Text = ""; textBox3.ForeColor = Color.Silver; }
        }

        private void richTextBox1_Enter_1(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "Report") { richTextBox1.Text = ""; invalr.Text = ""; richTextBox1.ForeColor = Color.Black; }
        }

        private void richTextBox1_Leave_1(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "") { richTextBox1.Text = "Report"; invalr.Text = ""; richTextBox1.ForeColor = Color.Silver; }
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            if (filenam) { if (od.Text != "" && nw.Text != "") { filename = nw.Text; Cat.Text = ""; Cat.Hide(); } }
            else if (cteg) { if (od.Text != "" && nw.Text != "") { category = nw.Text; Cat.Text = ""; Cat.Hide(); } }
            replace.Hide(); od.Text = ""; nw.Text = ""; Cat.Hide();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            if (kywd)
            {
                if (old.Text != "" && New.Text != "")
                {
                    string[] arr = keywrd.Split('@'); keywrd = "";
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] == old.Text) keywrd += New.Text + "@";
                        else keywrd += arr[i] + "@";
                    }
                }
            }
            else if (reprt)
            {
                if (New.Text != "")
                {
                    repwrt = New.Text; keey.Text = ""; keey.Hide();
                }
            }
            keey.Text = ""; keey.Hide(); replace1.Hide(); old.Text = ""; New.Text = "";
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            old.Enabled = false;
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            old.Enabled = true;
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Category")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Category";
                textBox5.ForeColor = Color.Silver;
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "Category")
            {
                textBox6.Text = "";
                textBox6.ForeColor = Color.Black;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.Text = "Category";
                textBox6.ForeColor = Color.Silver;
            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textBox7.Text == "File Name")
            {
                textBox7.Text = "";
                textBox7.ForeColor = Color.Black;
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                textBox7.Text = "File Name";
                textBox7.ForeColor = Color.Silver;
            }
        }

        private void richTextBox3_Enter(object sender, EventArgs e)
        {
            if (richTextBox3.Text == "Report")
            {
                richTextBox3.Text = "";
                richTextBox3.ForeColor = Color.Black;
            }

        }

        private void richTextBox3_Leave(object sender, EventArgs e)
        {
            if (richTextBox3.Text == "")
            {
                richTextBox3.Text = "Report";
                richTextBox3.ForeColor = Color.Silver;
            }
        }

        private void richTextBox2_Enter(object sender, EventArgs e)
        {
            if (richTextBox2.Text == "KeyWord")
            {
                richTextBox2.Text = "";
                richTextBox2.ForeColor = Color.Black;
            }
        }

        private void richTextBox2_Leave(object sender, EventArgs e)
        {
            if (richTextBox2.Text == "")
            {
                richTextBox2.Text = "KeyWord";
                richTextBox2.ForeColor = Color.Silver;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "KeyWord")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "KeyWord";
                textBox4.ForeColor = Color.Silver;
            }
        }

        private void flatClose1_Click(object sender, EventArgs e)
        {
            replace.Hide();
            od.Text = "";
            nw.Text = "";
        }

        private void replace_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flatClose2_Click(object sender, EventArgs e)
        {
            replace1.Hide();
            old.Text = "";
            New.Text = "";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            side.Height = button5.Height; side.Top = button5.Top;
            Suarch = false; categories = false;
            rep.Hide(); fn.Hide(); ca.Hide(); kw.Hide(); arrow1.Hide(); arrow2.Hide(); arrow3.Hide(); arrow4.Hide(); categ.Hide(); filname.Hide();
            highlight.Show();
            search1.Hide();
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            if (textBox8.Text == "KeyWord")
            {
                textBox8.Text = "";
                textBox8.ForeColor = Color.Black;
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                textBox8.Text = "KeyWord";
                textBox8.ForeColor = Color.Silver;
            }
        }

        private void textBox4_Enter_1(object sender, EventArgs e)
        {
            if (textBox4.Text == "Category")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave_1(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Category";
                textBox4.ForeColor = Color.Silver;
            }
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            if (textBox9.Text == "File Name")
            {
                textBox9.Text = "";
                textBox9.ForeColor = Color.Black;
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                textBox9.Text = "File Name";
                textBox9.ForeColor = Color.Silver;
            }
        }

        private void textBox10_Enter(object sender, EventArgs e)
        {
            if (textBox10.Text == "Category")
            {
                textBox10.Text = "";
                textBox10.ForeColor = Color.Black;
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                textBox10.Text = "Category";
                textBox10.ForeColor = Color.Silver;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            m++;
            if (m == 1) { arrow3.Show(); }
            else if (m == 2) { categ.Show(); }
            else if (m == 3) { arrow4.Show(); }
            else if (m == 4) { filname.Show(); m = 0; timer3.Stop(); }
        }

        private void filname_Click(object sender, EventArgs e)
        {
            searchCat.Hide(); searchfile.Show();
            filname.Hide(); categ.Hide(); arrow3.Hide(); arrow4.Hide();
        }

        private void categ_Click(object sender, EventArgs e)
        {
            searchfile.Show(); searchCat.Show(); searchfcat.Show();
            filname.Hide(); categ.Hide(); arrow3.Hide(); arrow4.Hide();

        }

        private void textBox11_Enter(object sender, EventArgs e)
        {
            if (textBox11.Text == "Category") { textBox11.Text = ""; textBox11.ForeColor = Color.Black; }
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (textBox11.Text == "") { textBox11.Text = "Category"; textBox11.ForeColor = Color.Silver; }
        }

        private void textBox12_Enter(object sender, EventArgs e)
        {
            if (textBox12.Text == "Category") { textBox12.Text = ""; textBox12.ForeColor = Color.Black; }
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            if (textBox12.Text == "") { textBox12.Text = "Category"; textBox12.ForeColor = Color.Silver; }
        }

        private void textBox13_Enter(object sender, EventArgs e)
        {
            if (textBox13.Text == "File Name") { textBox13.Text = ""; textBox13.ForeColor = Color.Black; }
        }

        private void textBox13_Leave_1(object sender, EventArgs e)
        {
            if (textBox13.Text == "") { textBox13.Text = "File Name"; textBox13.ForeColor = Color.Silver; }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox8.Text = "";
            FileStream f = new FileStream(textBox13.Text + ".txt", FileMode.Open);
            StreamReader read = new StreamReader(f);
            while (read.Peek() != -1)
            {
                richTextBox8.Text +=read.ReadLine()+" .\t";
            }
            read.Close();
            f.Close();
            /// Highlight \\\
            
            XmlDocument doc = new XmlDocument();
            doc.Load("FileInfo.xml");
            XmlNodeList list = doc.GetElementsByTagName("CategoryInfo");
            for (int i = 0; i < list.Count; i++)
            {
                XmlNodeList childerin = list[i].ChildNodes;
                if (textBox12.Text == childerin[2].InnerText)
                {
                    for (int j = 3; j < childerin.Count; j++)
                    {
                        int index = 0;

                        while (index < richTextBox8.Text.LastIndexOf(childerin[j].InnerText))
                        {
                            richTextBox8.Find(childerin[j].InnerText, index, richTextBox8.TextLength, RichTextBoxFinds.None);
                            richTextBox8.SelectionBackColor = Color.Yellow;
                            index = richTextBox8.Text.IndexOf(childerin[j].InnerText, index) + 1;
                        }
                        
                    }
                }
            }
        
        }

        private void searchF_Click(object sender, EventArgs e)
        {
            richTextBox5.Text = "";
            XmlDocument doc = new XmlDocument();
            doc.Load("FileInfo.xml");
            XmlNodeList list = doc.GetElementsByTagName("CategoryInfo");
            for (int i = 0; i < list.Count; i++)
            {
                XmlNodeList child = list[i].ChildNodes;
                if (textBox9.Text == child[0].InnerText)
                {
                    richTextBox5.Text += "File Path \n";
                    richTextBox5.Text += child[1].InnerText + "\n\n";
                    break;
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                XmlNodeList childerin = list[i].ChildNodes;
                if (textBox9.Text == childerin[0].InnerText)
                {
                    for (int j = 2; j < childerin.Count; j++)
                    {
                        if (j == 2)
                        {
                            richTextBox5.Text += "Category Name\n";
                            richTextBox5.Text += childerin[j].InnerText + "\n\n";
                        }
                        else
                        {
                            if (j == 3)
                                richTextBox5.Text += "KeyWords\n";
                            richTextBox5.Text += childerin[j].InnerText + "\t";
                        }
                    }
                    richTextBox5.Text += "\n\n";
                }
            }
        }

        private void searchC_Click(object sender, EventArgs e)
        {
            richTextBox6.Text = "";
            XmlDocument doc = new XmlDocument();
            doc.Load("FileInfo.xml");
            XmlNodeList list = doc.GetElementsByTagName("CategoryInfo");
            for (int i = 0; i < list.Count; i++)
            {
                XmlNodeList childerin = list[i].ChildNodes;
                if (textBox10.Text == childerin[2].InnerText)
                {
                    for (int j = 3; j < childerin.Count; j++)
                    {
                        richTextBox6.Text += childerin[j].InnerText + "\t";
                    }
                }

            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            richTextBox7.Text = "";
            XmlDocument doc = new XmlDocument();
            doc.Load("FileInfo.xml");
            XmlNodeList list = doc.GetElementsByTagName("CategoryInfo");
            for (int i = 0; i < list.Count; i++)
            {
                XmlNodeList childerin = list[i].ChildNodes;
                if (textBox11.Text == childerin[2].InnerText)
                {
                        richTextBox7.Text += childerin[0].InnerText + "\t\t";
                }
            }
            
        }
        Dictionary<string, List<string>> CategoryList = new Dictionary<string, List<string>>();
        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox6.Enabled = true;
            Dictionary<string, List<string>> CategList1 = new Dictionary<string, List<string>>();
            XmlDocument doc = new XmlDocument();
            doc.Load("FileInfo.xml");
            XmlNodeList list = doc.GetElementsByTagName("CategoryInfo");
            for (int i = 0; i < list.Count; i++)
            {
                List<string> ana1 = new List<string>();
                XmlNodeList children = list[i].ChildNodes;
                string fname = children[0].InnerText;
                string fpath = children[1].InnerText;
                string name1 = children[2].InnerText;
                ana1.Add(fname);
                ana1.Add(fpath);
                for (int j = 3; j < children.Count; j++)
                {
                    string c = children[j].InnerText;
                    ana1.Add(c);
                }
                CategList1.Add(name1, ana1);
            }
            for (int i = 0; i < CategList1.Count; i++)
            {
                if (CategList1.ContainsKey(textBox5.Text))
                {
                    textBox6.Text = textBox5.Text;
                    textBox7.Text = textBox14.Text;
                    richTextBox2.Text = "";
                    richTextBox3.Text = "";
                    richTextBox2.ForeColor = Color.Black;
                    richTextBox3.ForeColor = Color.Black;
                    textBox6.ForeColor = Color.Black;
                    textBox7.ForeColor = Color.Black;
                    for (int j = 2; j < CategList1.ElementAt(i).Value.Count; j++)
                    {
                        richTextBox2.Text += CategList1.ElementAt(i).Value.ElementAt(j) + "*";
                    }
                    FileStream f = new FileStream(textBox14.Text + ".txt", FileMode.Open);
                    StreamReader s = new StreamReader(f);
                    while (s.Peek() != -1)
                    {
                        richTextBox3.Text = s.ReadLine() + ".";
                    }
                    s.Close();
                    f.Close();


                }
            }
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            string filenam = @textBox14.Text;
            string filePath = AppDomain.CurrentDomain.BaseDirectory + filename;
            Dictionary<string, List<string>> CategList = new Dictionary<string, List<string>>();
            List<string> key = new List<string>();
            key.Add(textBox14.Text);
            key.Add(filePath);
            string keey = richTextBox2.Text;
           string [] arr = keey.Split('*');
            for(int i=0;i<CategList.Count;i++)
            {
                for(int j=0;j<CategList.ElementAt(i).Value.Count;j++)
                {
                    key.Add(arr[i]);
                }
            }

            CategList.Add(textBox5.Text,key);
           // FileInfo file = new FileInfo(filenam, filePath);
           // file.CategoryList.Add(textBox categ);
            
            XmlDocument doc = new XmlDocument();
            doc.Load("FileInfo.xml");
            XmlElement del = doc.DocumentElement;
            del.RemoveAll();
            doc.Save("FileInfo.xml");
            XmlElement fileinfo = doc.CreateElement("CategoryInfo");
            XmlElement fname = doc.CreateElement("FileName");
            fname.InnerText = textBox7.Text;
            fileinfo.AppendChild(fname);
            XmlElement fpath = doc.CreateElement("Filepath");
            fpath.InnerText = filePath;
            fileinfo.AppendChild(fpath);
            XmlElement cname = doc.CreateElement("CategoryName");
            cname.InnerText = textBox6.Text;
            fileinfo.AppendChild(cname);
            for (int i = 0; i < CategoryList.Count; i++)
            {
                for (int j = 0; j < CategoryList.ElementAt(i).Value.Count - 1; j++)
                {
                    XmlElement node = doc.CreateElement("Keyword");
                    node.InnerText = CategoryList.ElementAt(i).Value.ElementAt(j);
                    fileinfo.AppendChild(node);
                }

            }
            doc.Load("FileInfo.xml");
            XmlElement root = doc.DocumentElement;
            root.AppendChild(fileinfo);
            doc.Save("FileInfo.xml");
            key.Clear();
            CategList.Clear();
            MessageBox.Show("Done","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
        
        }

    }
}