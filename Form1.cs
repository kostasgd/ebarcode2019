using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.IO;
using ZXing.Common;
using ZXing;
using ZXing.QrCode;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Collections;
using System.Resources;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace EbarCode2019
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            Properties.Settings.Default.combobox1 = comboBox1.SelectedIndex;
            CaptureControl(textBoxResult);
        }

        private void comboBoxPrinters_SelectedIndexChanged(object sender, EventArgs e) { }

        private void FormMain_Load(object sender, EventArgs e)
        {
            foreach (string sPrinters in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                comboBoxPrinters.Items.Add(sPrinters);
            }
            foreach (string sPrinters in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                comboBoxPrinter2.Items.Add(sPrinters);
            }

            comboBoxPrinters.SelectedIndex = 3;
            comboBoxPrinter2.SelectedIndex = 3;
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 1;
            comboBox3.SelectedIndex = 2;
            comboBox4.SelectedIndex = 0;
            radioButton1.Checked = true;
            maskTextBoxChange();
        }
        public void maskTextBoxChange()
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBoxMask.Text = "######";
                textBoxFrom.MaxLength = 6;
                textBoxUntil.MaxLength = 6;
                textBoxUntil.Text = "";
                textBoxFrom.Text = "";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                textBoxMask.Text = "#######";
                textBoxFrom.MaxLength = 7;
                textBoxUntil.MaxLength = 7;
                textBoxUntil.Text = "";
                textBoxFrom.Text = "";
            }
            if (comboBox1.SelectedIndex == 2)
            {
                textBoxMask.Text = "########";
                textBoxFrom.MaxLength = 8;
                textBoxUntil.MaxLength = 8;
                textBoxUntil.Text = "";
                textBoxFrom.Text = "";
            }
            if (comboBox1.SelectedIndex == 3)
            {
                textBoxMask.Text = "#########";
                textBoxFrom.MaxLength = 9;
                textBoxUntil.MaxLength = 9;
                textBoxUntil.Text = "";
                textBoxFrom.Text = "";
            }
            if (comboBox1.SelectedIndex == 4)
            {
                textBoxMask.Text = "##########";
                textBoxFrom.MaxLength = 10;
                textBoxUntil.MaxLength = 10;
                textBoxUntil.Text = "";
                textBoxFrom.Text = "";
            }
        }
        private string line = "";
        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.txt";
            listBox1.Items.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string[] lines = File.ReadAllLines(openFileDialog1.FileName);
                foreach (string line in lines)
                {
                    string[] col = line.Split(new char[] { ' ' });
                    listBox1.Items.Add("*" + col[0] + "*\n");
                }
                textBoxTest.Text = File.ReadAllText(openFileDialog1.FileName);
                string[] txt = new string[textBoxTest.Lines.Length];
                for (int i = 0; i < textBoxTest.Lines.Length; i++)
                {
                    txt[i] = textBoxTest.Lines[i].ToString();
                }

                string stringWithRowNumbers = "";
                for (int i = 0; i < textBoxTest.Lines.Length; i++)
                {
                    stringWithRowNumbers += "*" + txt[i] + "*\r\n"; // The old/first line + your numbers + new line
                }
                textBoxTest.Text = stringWithRowNumbers;
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        if (listBox1.Items[i].ToString().Length > 9)
                        {
                            MessageBox.Show("Το αρχείο που φορτώσατε δεν ταιριάζει με την μάσκα εισαγωγής barcode", "Πρόβλημα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            listBox1.Items.Clear();
                        }
                    }
                    else if (comboBox1.SelectedIndex == 1)
                    {
                        if (listBox1.Items[i].ToString().Length > 10)
                        {
                            MessageBox.Show("Το αρχείο που φορτώσατε δεν ταιριάζει με την μάσκα εισαγωγής barcode", "Πρόβλημα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            listBox1.Items.Clear();
                        }
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        if (listBox1.Items[i].ToString().Length > 11)
                        {
                            MessageBox.Show("Το αρχείο που φορτώσατε δεν ταιριάζει με την μάσκα εισαγωγής barcode", "Πρόβλημα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            listBox1.Items.Clear();
                        }
                    }
                    else if (comboBox1.SelectedIndex == 3)
                    {
                        if (listBox1.Items[i].ToString().Length > 12)
                        {
                            MessageBox.Show("Το αρχείο που φορτώσατε δεν ταιριάζει με την μάσκα εισαγωγής barcode", "Πρόβλημα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            listBox1.Items.Clear();
                        }
                    }
                    else if (comboBox1.SelectedIndex == 4)
                    {
                        if (listBox1.Items[i].ToString().Length > 13)
                        {
                            MessageBox.Show("Το αρχείο που φορτώσατε δεν ταιριάζει με την μάσκα εισαγωγής barcode", "Πρόβλημα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            listBox1.Items.Clear();
                        }
                    }
                }
            }
        }
        private void listAllPrinters()
        {
            foreach (var item in PrinterSettings.InstalledPrinters)
            {
                this.comboBoxPrinters.Items.Add(item.ToString());
            }
            foreach (var item in PrinterSettings.InstalledPrinters)
            {
                this.comboBoxPrinter2.Items.Add(item.ToString());
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            maskTextBoxChange();
            if (comboBox1.SelectedIndex == 0)
            {
                label12.Text = "6";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                label12.Text = "7";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                label12.Text = "8";
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                label12.Text = "9";
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                label12.Text = "10";
            }
            if (textBoxX.Text == "5" & comboBox3.SelectedIndex != 1)
            {
                textBoxX.Text = "";
                MessageBox.Show("Δεν γίνεται να τοποθετηθούν 5 barcode με μασκα μεγαλύτερη του 6 ", "Πρόβλημα", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBoxFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxUntil_TextChanged(object sender, EventArgs e) { }

        private void textBoxY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxUntil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < textBoxResult.Lines.Length; i++)
            {
                //MessageBox.Show(textBoxResult.Lines[i].Length + "");
            }

            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(labelBarcode.Text, new Font("Arial", 16, FontStyle.Regular), Brushes.Black, 100, 111);
        }

        private void tabPage1_Click(object sender, EventArgs e) { }

        private void button2_Click(object sender, EventArgs e)
        {
            int val1;
            int val2;
            int i = 0, count = 0;
            int.TryParse(textBoxFrom.Text, out val1);
            int.TryParse(textBoxUntil.Text, out val2);
            int sum = textBoxResult.Text.Length;
            int z = val2 - val1;
            string p = "";
            char charToCount = '0';
            textBoxResult.ScrollBars = ScrollBars.Vertical;
            textBoxResult.Text = "";
            if (textBoxFrom.Text != "" && textBoxUntil.Text != "")
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    if (textBoxFrom.Text.Length > 0 & textBoxUntil.Text.Length > 0 & textBoxFrom.Text.Length <= 6 & textBoxUntil.Text.Length <= 7)
                    {
                        int l = 0;
                        foreach (char c in textBoxFrom.Text)
                        {
                            if (Char.IsDigit(c))
                                l++;
                            //MessageBox.Show(l + "");
                        }
                        for (i = 0; i < l; i++)
                        {
                            count++;
                        }
                        for (i = 0; i < 6 - count; i++)
                        {
                            p += "0";
                        }
                        try
                        {
                            for (i = 0; i < z + 1; i++)
                            {
                                textBoxResult.Text += "*" + p + val1 + "*\r\n";
                                val1 = val1 + 1;
                                if (val1 > 9 & val1 < 99)
                                {
                                    p = "0000";
                                }
                                else if (val1 > 99 & val1 < 999)
                                {
                                    p = "000";
                                }
                                else if (val1 > 999)
                                {
                                    p = "00";
                                }
                            }
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    if (textBoxFrom.Text.Length > 0 & textBoxUntil.Text.Length > 0 & textBoxFrom.Text.Length <= 7 & textBoxUntil.Text.Length <= 7)
                    {
                        int l = 0;
                        foreach (char c in textBoxFrom.Text)
                        {
                            if (Char.IsDigit(c))
                                l++;
                            //MessageBox.Show(l + "");
                        }
                        for (i = 0; i < 7 - l; i++)
                        {
                            p += "0";
                        }
                        for (i = 0; i < z + 1; i++)
                        {
                            textBoxResult.Text += "*" + p + val1 + "*\r\n";
                            val1 = val1 + 1;
                            if (val1 > 9 & val1 < 99)
                            {
                                p = "00000";
                            }
                            else if (val1 > 99 & val1 < 999)
                            {
                                p = "0000";
                            }
                            else if (val1 > 999 & val1 < 9999)
                            {
                                p = "000";
                            }
                        }
                    }
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    if (textBoxFrom.Text.Length > 0 & textBoxUntil.Text.Length > 0 & textBoxFrom.Text.Length <= 8 & textBoxUntil.Text.Length <= 8)
                    {
                        int l = 0;
                        foreach (char c in textBoxFrom.Text)
                        {
                            if (Char.IsDigit(c))
                                l++;
                        }
                        for (i = 0; i < 8 - l; i++)
                        {
                            p += "0";
                        }
                        for (i = 0; i < z + 1; i++)
                        {
                            textBoxResult.Text += "*" + p + val1 + "*\r\n";
                            val1 = val1 + 1;
                            if (val1 > 9 & val1 < 99)
                            {
                                p = "000000";
                            }
                            else if (val1 > 99 & val1 < 999)
                            {
                                p = "0000";
                            }
                            else if (val1 > 999 & val1 < 9999)
                            {
                                p = "0000";
                            }
                        }
                    }
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    if (textBoxFrom.Text.Length > 0 & textBoxUntil.Text.Length > 0 & textBoxFrom.Text.Length <= 9 & textBoxUntil.Text.Length <= 9)
                    {
                        int l = 0;
                        foreach (char c in textBoxFrom.Text)
                        {
                            if (Char.IsDigit(c))
                                l++;
                        }
                        for (i = 0; i < 9 - l; i++)
                        {
                            p += "0";
                        }

                        for (i = 0; i < z + 1; i++)
                        {
                            textBoxResult.Text += "*" + p + val1 + "*\r\n";
                            val1 = val1 + 1;
                            if (val1 > 9 & val1 < 99)
                            {
                                p = "0000000";
                            }
                            else if (val1 > 99 & val1 < 999)
                            {
                                p = "000000";
                            }
                            else if (val1 > 999 & val1 < 9999)
                            {
                                p = "00000";
                            }
                        }
                    }
                }
                else if (comboBox1.SelectedIndex == 4)
                {
                    if (textBoxFrom.Text.Length > 0 & textBoxUntil.Text.Length > 0 & textBoxFrom.Text.Length <= 10 & textBoxUntil.Text.Length <= 10)
                    {
                        int l = 0;
                        foreach (char c in textBoxFrom.Text)
                        {
                            if (Char.IsDigit(c))
                                l++;
                        }
                        for (i = 0; i < 10 - l; i++)
                        {
                            p += "0";
                        }

                        for (i = 0; i < z + 1; i++)
                        {
                            textBoxResult.Text += "*" + p + val1 + "*\r\n";
                            val1 = val1 + 1;
                            if (val1 > 9 & val1 < 99)
                            {
                                p = "00000000";
                            }
                            else if (val1 > 99 & val1 < 999)
                            {
                                p = "0000000";
                            }
                            else if (val1 > 999 & val1 < 9999)
                            {
                                p = "000000";
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BarcodeWriter writer = new BarcodeWriter() { Format = BarcodeFormat.CODE_39 };
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.DefaultPageSettings.Margins.Left = 100;
            doc.DefaultPageSettings.Margins.Right = 100;
            // Set the top and bottom margins to 1.5 inches.
            doc.DefaultPageSettings.Margins.Top = 150;
            doc.DefaultPageSettings.Margins.Bottom = 150;

            int i = 0;
            for (i = 0; i < textBoxResult.Lines.Length; i++)
            {
                picture.Image = writer.Write(listBox1.Items.ToString());
                doc.PrintPage += Doc_PrintPage;
                pd.Document = doc;
                //MessageBox.Show(textBoxResult.Lines[i].ToString());
            }
            if (pd.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }
        PictureBox picture = new PictureBox();
        PictureBox picture2 = new PictureBox();

        BarcodeWriter writer = new BarcodeWriter()
        {
            Format = BarcodeFormat.CODE_39,
        };

        private void button3_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            writer = new BarcodeWriter()
            {
                Format = BarcodeFormat.CODE_39,
            };

            picture = new PictureBox();
            //picture.Location = new System.Drawing.Point(360, 190);
            picture.Name = "picture1";
           // picture.Size = new Size(200, 160);
            // picture.BackColor = Color.Transparent;
            this.Controls.Add(picture);
            picture.BringToFront();
            picture.BackgroundImageLayout = ImageLayout.None;
            picture.Visible = false;
            picture.Image = writer.Write(textBoxResult.Lines[0].ToString());

            picture2 = new PictureBox();
            //picture2.Location = new System.Drawing.Point(279, 90);
            picture2.Name = "picture2";
            //picture2.Size = new Size(200, 160);
            // picture.BackColor = Color.Transparent;
            this.Controls.Add(picture2);
            picture2.BringToFront();
            picture2.BackgroundImageLayout = ImageLayout.None;
            picture2.Visible = false;
            picture2.Image = writer.Write(textBoxResult.Lines[1].ToString());
            PrintDialog pd = new PrintDialog();
            doc.PrintPage += Doc_PrintPage;
            pd.Document = doc;
            preview(doc);
        }
        private int placing1_h()
        {
            int place = 0;
            int size = Int32.Parse(comboBox3.SelectedItem.ToString());
            if (comboBox1.SelectedIndex == 0 & textBoxX.Text == "1")
            { if (comboBox3.SelectedIndex == 0) { place = 320; } else if (comboBox3.SelectedIndex == 1) { place = 300; } else if (comboBox3.SelectedIndex == 2) { place = 280; } else if (comboBox3.SelectedIndex == 3) { place = 260; } else if (comboBox3.SelectedIndex == 4) { place = 250; } }
            if (comboBox1.SelectedIndex == 1 & textBoxX.Text == "1")
            { if (comboBox3.SelectedIndex == 0) { place = 320; } else if (comboBox3.SelectedIndex == 1) { place = 300; } else if (comboBox3.SelectedIndex == 2) { place = 280; } else if (comboBox3.SelectedIndex == 3) { place = 260; } else if (comboBox3.SelectedIndex == 4) { place = 250; } }
            if (comboBox1.SelectedIndex == 2 & textBoxX.Text == "1")
            { if (comboBox3.SelectedIndex == 0) { place = 320; } else if (comboBox3.SelectedIndex == 1) { place = 300; } else if (comboBox3.SelectedIndex == 2) { place = 280; } else if (comboBox3.SelectedIndex == 3) { place = 260; } else if (comboBox3.SelectedIndex == 4) { place = 230; } }
            if (comboBox1.SelectedIndex == 3 & textBoxX.Text == "1")
            { if (comboBox3.SelectedIndex == 0) { place = 300; } else if (comboBox3.SelectedIndex == 1) { place = 300; } else if (comboBox3.SelectedIndex == 2) { place = 280; } else if (comboBox3.SelectedIndex == 3) { place = 260; } else if (comboBox3.SelectedIndex == 4) { place = 220; } }
            if (comboBox1.SelectedIndex == 4 & textBoxX.Text == "1")
            { if (comboBox3.SelectedIndex == 0) { place = 300; } else if (comboBox3.SelectedIndex == 1) { place = 280; } else if (comboBox3.SelectedIndex == 2) { place = 260; } else if (comboBox3.SelectedIndex == 3) { place = 230; } else if (comboBox3.SelectedIndex == 4) { place = 210; } }
            return place;
        }
        private int placing2_h()
        {
            int place = 0;
            int size = Int32.Parse(comboBox3.SelectedItem.ToString());
            if (comboBox1.SelectedIndex == 0 & textBoxX.Text == "2")
            { if (comboBox3.SelectedIndex == 0) { place = 390; } else if (comboBox3.SelectedIndex == 1) { place = 420; } else if (comboBox3.SelectedIndex == 2) { place = 410; } else if (comboBox3.SelectedIndex == 3) { place = 440; } else if (comboBox3.SelectedIndex == 4) { place = 430; } }
            if (comboBox1.SelectedIndex == 1 & textBoxX.Text == "2")
            { if (comboBox3.SelectedIndex == 0) { place = 370; } else if (comboBox3.SelectedIndex == 1) { place = 390; } else if (comboBox3.SelectedIndex == 2) { place = 380; } else if (comboBox3.SelectedIndex == 3) { place = 380; } else if (comboBox3.SelectedIndex == 4) { place = 400; } }
            if (comboBox1.SelectedIndex == 2 & textBoxX.Text == "2")
            { if (comboBox3.SelectedIndex == 0) { place = 370; } else if (comboBox3.SelectedIndex == 1) { place = 360; } else if (comboBox3.SelectedIndex == 2) { place = 340; } else if (comboBox3.SelectedIndex == 3) { place = 370; } else if (comboBox3.SelectedIndex == 4) { place = 390; } }
            if (comboBox1.SelectedIndex == 3 & textBoxX.Text == "2")
            { if (comboBox3.SelectedIndex == 0) { place = 350; } else if (comboBox3.SelectedIndex == 1) { place = 340; } else if (comboBox3.SelectedIndex == 2) { place = 330; } else if (comboBox3.SelectedIndex == 3) { place = 350; } else if (comboBox3.SelectedIndex == 4) { place = 360; } }
            if (comboBox1.SelectedIndex == 4 & textBoxX.Text == "2")
            { if (comboBox3.SelectedIndex == 0) { place = 320; } else if (comboBox3.SelectedIndex == 1) { place = 330; } else if (comboBox3.SelectedIndex == 2) { place = 330; } else if (comboBox3.SelectedIndex == 3) { place = 350; } else if (comboBox3.SelectedIndex == 4) { place = 370; } }
            return place;
        }
        private int placing3_h()
        {
            int place = 0;

            if (comboBox1.SelectedIndex == 0 & textBoxX.Text == "3")
            { if (comboBox3.SelectedIndex == 0) { place = 280; } else if (comboBox3.SelectedIndex == 1) { place = 270; } else if (comboBox3.SelectedIndex == 2) { place = 290; } else if (comboBox3.SelectedIndex == 3) { place = 230; } else if (comboBox3.SelectedIndex == 4) { place = 220; } }
            if (comboBox1.SelectedIndex == 1 & textBoxX.Text == "3")
            { if (comboBox3.SelectedIndex == 0) { place = 280; } else if (comboBox3.SelectedIndex == 1) { place = 255; } else if (comboBox3.SelectedIndex == 2) { place = 270; } else if (comboBox3.SelectedIndex == 3) { place = 230; } else if (comboBox3.SelectedIndex == 4) { place = 220; } }
            if (comboBox1.SelectedIndex == 2 & textBoxX.Text == "3")
            { if (comboBox3.SelectedIndex == 0) { place = 265; } else if (comboBox3.SelectedIndex == 1) { place = 250; } else if (comboBox3.SelectedIndex == 2) { place = 270; } }
            if (comboBox1.SelectedIndex == 3 & textBoxX.Text == "3")
            { if (comboBox3.SelectedIndex == 0) { place = 260; } else if (comboBox3.SelectedIndex == 1) { place = 240; } }
            if (comboBox1.SelectedIndex == 4 & textBoxX.Text == "3")
            { if (comboBox3.SelectedIndex == 0) { place = 250; } else if (comboBox3.SelectedIndex == 1) { place = 220; } }
            return place;
        }
        private int placing4_h()
        {
            int place = 0;
            int size = Int32.Parse(comboBox3.SelectedItem.ToString());
            if (comboBox1.SelectedIndex == 0 & textBoxX.Text == "4")
            { if (comboBox3.SelectedIndex == 0) { place = 190; } }
            if (comboBox1.SelectedIndex == 1 & textBoxX.Text == "4")
            { if (comboBox3.SelectedIndex == 0) { place =210; } }           
            return place;
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(picture.Width, picture.Height);
            Bitmap bm2 = new Bitmap(picture.Width, picture.Height);
            string m = comboBox3.SelectedItem.ToString();
            int N = 1, o = 0;
            try
            {
                N = Convert.ToInt32(m);
            }
            catch (System.FormatException ex) { }
            string combofont = comboBox2.SelectedItem.ToString();
            var font = new Font(combofont, N, FontStyle.Regular, GraphicsUnit.Point);
            
            picture2.DrawToBitmap(bm, new Rectangle(0, 0, 150, 150));
            picture.DrawToBitmap(bm, new Rectangle(0, 0, 150, 300));
            
            int h = 20, p = 32, first = 0, second = 0;
            int x = 0, y = 0;
            try
            {
                first = Int32.Parse(textBoxX.Text);
                second = Int32.Parse(textBoxY.Text);
                x = Int32.Parse(textBoxX.Text);
                y = Int32.Parse(textBoxY.Text);
            }
            catch (System.ArgumentException ex) { }
            catch (System.FormatException ep) { }
            int sum = x * y;
            if(comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h = 10; }
            try
            {
                for (int i = 0; i < 1; i++)
                {
                    int c = 0, k = 0, t = 0;
                    for (o = 0; o < first; o++)
                    {

                        if (textBoxX.Text == "1" & comboBox3.SelectedIndex != 4) { h += placing1_h(); }//1
                        else if (textBoxX.Text == "1" & comboBox3.SelectedIndex == 4) { h += placing1_h(); }//1

                        if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += 40; }
                        if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += 30; }
                        if (comboBox3.SelectedIndex == 2 & textBoxX.Text == "2") { h += 60; }
                        if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += 80; }
                        if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += 60; }
                        if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += 20; }

                        if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += 20; }
                        if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h -= 2; }

                        e.Graphics.DrawString(textBoxResult.Lines[o].ToString(), font, Brushes.Black, new Point(h, 30));

                        if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "3")) { h += placing3_h(); }//2
                        if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "4")) { h += placing4_h(); }//2
                        if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "2")) { h += placing2_h(); }//2

                        if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "3") { h += placing3_h(); }//3
                        if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += placing2_h(); }//γινεται υπερκαλυψη δεν μπορει να χωρεσει αλλο

                        if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += placing2_h(); }//0
                        if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += placing3_h(); }//0
                        if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "4") { h += placing4_h(); }//0
                        if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h += 170; }//0

                        if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += placing2_h(); }//4
                        if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "3") { h += placing3_h(); }//4

                        if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += placing2_h(); }
                        if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "4") { h += placing4_h(); }
                        if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += placing3_h(); }//1
                        c++;
                    }
                    if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h = 10; }
                    else
                    {
                        h = 20;
                    }
                    if (c < Int32.Parse(textBoxY.Text))
                    {
                        for (int j = 0; j < first; j++)
                        {
                            if (textBoxX.Text == "1" & comboBox3.SelectedIndex != 4) { h += placing1_h(); }//1
                            else if (textBoxX.Text == "1" & comboBox3.SelectedIndex == 4) { h += placing1_h(); }//1

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += 40; }
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += 30; }
                            if (comboBox3.SelectedIndex == 2 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += 80; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += 20; }

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += 20; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h -= 2; }

                            e.Graphics.DrawString(textBoxResult.Lines[c].ToString(), font, Brushes.Black, new Point(h, 130));//1,1...

                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "3")) { h += placing3_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "4")) { h += placing4_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "2")) { h += placing2_h(); }//2

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "3") { h += placing3_h(); }//3
                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += placing2_h(); }//γινεται υπερκαλυψη δεν μπορει να χωρεσει αλλο

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += placing2_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += placing3_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "4") { h += placing4_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h += 170; }//0

                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += placing2_h(); }//4
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "3") { h += placing3_h(); }//4

                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += placing2_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "4") { h += placing4_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += placing3_h(); }//1
                            c++;
                        }
                    }

                    if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h = 10; }
                    else
                    {
                        h = 20;
                    }
                    if (c < Int32.Parse(textBoxY.Text))
                    {
                       
                        for (int j = 0; j < first; j++)
                        {
                            if (textBoxX.Text == "1" & comboBox3.SelectedIndex != 4) { h += placing1_h(); }//1
                            else if (textBoxX.Text == "1" & comboBox3.SelectedIndex == 4) { h += placing1_h(); }//1


                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += 40; }
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += 30; }
                            if (comboBox3.SelectedIndex == 2 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += 80; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += 20; }

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += 20; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h -= 2; }

                            e.Graphics.DrawString(textBoxResult.Lines[c].ToString(), font, Brushes.Black, new Point(h, 230));//1,1...

                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "3")) { h += placing3_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "4")) { h += placing4_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "2")) { h += placing2_h(); }//2

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "3") { h += placing3_h(); }//3
                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += placing2_h(); }//γινεται υπερκαλυψη δεν μπορει να χωρεσει αλλο

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += placing2_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += placing3_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "4") { h += placing4_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h += 170; }//0

                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += placing2_h(); }//4
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "3") { h += placing3_h(); }//4

                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += placing2_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "4") { h += placing4_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += placing3_h(); }//1
                            c++;
                        }
                    }
                    if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h = 10; }
                    else
                    {
                        h = 20;
                    }
                    if (c < Int32.Parse(textBoxY.Text))
                    {
                        for (int j = 0; j < first; j++)
                        {
                            if (textBoxX.Text == "1" & comboBox3.SelectedIndex != 4) { h += placing1_h(); }//1
                            else if (textBoxX.Text == "1" & comboBox3.SelectedIndex == 4) { h += placing1_h(); }//1


                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += 40; }
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += 30; }
                            if (comboBox3.SelectedIndex == 2 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += 80; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += 20; }

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += 20; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h -= 2; }

                            e.Graphics.DrawString(textBoxResult.Lines[c].ToString(), font, Brushes.Black, new Point(h, 330));//1,1...

                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "3")) { h += placing3_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "4")) { h += placing4_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "2")) { h += placing2_h(); }//2

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "3") { h += placing3_h(); }//3
                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += placing2_h(); }//γινεται υπερκαλυψη δεν μπορει να χωρεσει αλλο

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += placing2_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += placing3_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "4") { h += placing4_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h += 170; }//0

                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += placing2_h(); }//4
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "3") { h += placing3_h(); }//4

                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += placing2_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "4") { h += placing4_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += placing3_h(); }//1
                            c++;
                        }
                    }

                    if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h = 10; }
                    else
                    {
                        h = 20;
                    }
                    if (c < Int32.Parse(textBoxY.Text))
                    {

                        for (int j = 0; j < first; j++)
                        {
                            if (textBoxX.Text == "1" & comboBox3.SelectedIndex != 4) { h += placing1_h(); }//1
                            else if (textBoxX.Text == "1" & comboBox3.SelectedIndex == 4) { h += placing1_h(); }//1


                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += 40; }
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += 30; }
                            if (comboBox3.SelectedIndex == 2 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += 80; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += 20; }

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += 20; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h -= 2; }

                            e.Graphics.DrawString(textBoxResult.Lines[c].ToString(), font, Brushes.Black, new Point(h, 430));//1,1...


                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "3")) { h += placing3_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "4")) { h += placing4_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "2")) { h += placing2_h(); }//2

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "3") { h += placing3_h(); }//3
                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += placing2_h(); }//γινεται υπερκαλυψη δεν μπορει να χωρεσει αλλο

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += placing2_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += placing3_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "4") { h += placing4_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h += 170; }//0

                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += placing2_h(); }//4
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "3") { h += placing3_h(); }//4

                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += placing2_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "4") { h += placing4_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += placing3_h(); }//1
                            c++;
                        }
                    }
                    if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h = 10; }
                    else
                    {
                        h = 20;
                    }
                    if (c < Int32.Parse(textBoxY.Text))
                    {

                        for (int j = 0; j < first; j++)
                        {
                            if (textBoxX.Text == "1" & comboBox3.SelectedIndex != 4) { h += placing1_h(); }//1
                            else if (textBoxX.Text == "1" & comboBox3.SelectedIndex == 4) { h += placing1_h(); }//1


                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += 40; }
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += 30; }
                            if (comboBox3.SelectedIndex == 2 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += 80; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += 20; }

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += 20; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h -= 2; }

                            e.Graphics.DrawString(textBoxResult.Lines[c].ToString(), font, Brushes.Black, new Point(h, 530));//1,1...


                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "3")) { h += placing3_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "4")) { h += placing4_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "2")) { h += placing2_h(); }//2

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "3") { h += placing3_h(); }//3
                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += placing2_h(); }//γινεται υπερκαλυψη δεν μπορει να χωρεσει αλλο

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += placing2_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += placing3_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "4") { h += placing4_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h += 170; }//0

                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += placing2_h(); }//4
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "3") { h += placing3_h(); }//4

                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += placing2_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "4") { h += placing4_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += placing3_h(); }//1
                            c++;
                        }
                    }
                    if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h = 10; }
                    else
                    {
                        h = 20;
                    }
                    if (c < Int32.Parse(textBoxY.Text))
                    {
                      
                        for (int j = 0; j < first; j++)
                        {
                            if (textBoxX.Text == "1" & comboBox3.SelectedIndex != 4) { h += placing1_h(); }//1
                            else if (textBoxX.Text == "1" & comboBox3.SelectedIndex == 4) { h += placing1_h(); }//1


                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += 40; }
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += 30; }
                            if (comboBox3.SelectedIndex == 2 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += 80; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += 20; }

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += 20; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h -= 2; }

                            e.Graphics.DrawString(textBoxResult.Lines[c].ToString(), font, Brushes.Black, new Point(h, 630));//1,1...

                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "3")) { h += placing3_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "4")) { h += placing4_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "2")) { h += placing2_h(); }//2

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "3") { h += placing3_h(); }//3
                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += placing2_h(); }//γινεται υπερκαλυψη δεν μπορει να χωρεσει αλλο

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += placing2_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += placing3_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "4") { h += placing4_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h += 170; }//0

                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += placing2_h(); }//4
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "3") { h += placing3_h(); }//4

                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += placing2_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "4") { h += placing4_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += placing3_h(); }//1
                            c++;
                        }
                    }
                    if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h = 10; }
                    else
                    {
                        h = 20;
                    }
                    if (c < Int32.Parse(textBoxY.Text))
                    {
                        
                        for (int j = 0; j < first; j++)
                        {
                            if (textBoxX.Text == "1" & comboBox3.SelectedIndex != 4) { h += placing1_h(); }//1
                            else if (textBoxX.Text == "1" & comboBox3.SelectedIndex == 4) { h += placing1_h(); }//1


                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += 40; }
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += 30; }
                            if (comboBox3.SelectedIndex == 2 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += 80; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += 20; }

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += 20; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h -= 2; }
                            e.Graphics.DrawString(textBoxResult.Lines[c].ToString(), font, Brushes.Black, new Point(h, 730));//1,1...

                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "3")) { h += placing3_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "4")) { h += placing4_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "2")) { h += placing2_h(); }//2

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "3") { h += placing3_h(); }//3
                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += placing2_h(); }//γινεται υπερκαλυψη δεν μπορει να χωρεσει αλλο

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += placing2_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += placing3_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "4") { h += placing4_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h += 170; }//0

                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += placing2_h(); }//4
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "3") { h += placing3_h(); }//4

                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += placing2_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "4") { h += placing4_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += placing3_h(); }//1
                            c++;
                        }
                    }
                    if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h = 10; }
                    else
                    {
                        h = 20;
                    }
                    if (c < Int32.Parse(textBoxY.Text))
                    {
                        for (int j = 0; j < first; j++)
                        {
                            if (textBoxX.Text == "1" & comboBox3.SelectedIndex != 4) { h += placing1_h(); }//1
                            else if (textBoxX.Text == "1" & comboBox3.SelectedIndex == 4) { h += placing1_h(); }//1


                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += 40; }
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += 30; }
                            if (comboBox3.SelectedIndex == 2 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += 80; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += 20; }

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += 20; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h -= 2; }

                            e.Graphics.DrawString(textBoxResult.Lines[c].ToString(), font, Brushes.Black, new Point(h, 830));//1,1...

                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "3")) { h += placing3_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "4")) { h += placing4_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "2")) { h += placing2_h(); }//2

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "3") { h += placing3_h(); }//3
                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += placing2_h(); }//γινεται υπερκαλυψη δεν μπορει να χωρεσει αλλο

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += placing2_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += placing3_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "4") { h += placing4_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h += 170; }//0

                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += placing2_h(); }//4
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "3") { h += placing3_h(); }//4

                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += placing2_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "4") { h += placing4_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += placing3_h(); }//1
                            c++;
                        }
                    }
                    if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h = 10; }
                    else
                    {
                        h = 20;
                    }
                    if (c < Int32.Parse(textBoxY.Text))
                    {
                        for (int j = 0; j < first; j++)
                        {
                            if (textBoxX.Text == "1" & comboBox3.SelectedIndex != 4) { h += placing1_h(); }//1
                            else if (textBoxX.Text == "1" & comboBox3.SelectedIndex == 4) { h += placing1_h(); }//1


                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += 40; }
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += 30; }
                            if (comboBox3.SelectedIndex == 2 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += 80; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += 20; }

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += 20; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h -= 2; }

                            e.Graphics.DrawString(textBoxResult.Lines[c].ToString(), font, Brushes.Black, new Point(h, 930));//1,1...

                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "3")) { h += placing3_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "4")) { h += placing4_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "2")) { h += placing2_h(); }//2

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "3") { h += placing3_h(); }//3
                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += placing2_h(); }//γινεται υπερκαλυψη δεν μπορει να χωρεσει αλλο

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += placing2_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += placing3_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "4") { h += placing4_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h += 170; }//0

                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += placing2_h(); }//4
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "3") { h += placing3_h(); }//4

                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += placing2_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "4") { h += placing4_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += placing3_h(); }//1
                            c++;
                        }
                    }
                    if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h = 10; }
                    else
                    {
                        h = 20;
                    }
                    if (c < Int32.Parse(textBoxY.Text))
                    {
                       
                        for (int j = 0; j < first; j++)
                        {
                            if (textBoxX.Text == "1" & comboBox3.SelectedIndex != 4) { h += placing1_h(); }//1
                            else if (textBoxX.Text == "1" & comboBox3.SelectedIndex == 4) { h += placing1_h(); }//1
                            

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += 40; }
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += 30; }
                            if (comboBox3.SelectedIndex == 2 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += 80; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += 20; }

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += 20; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h -=8; }

                            e.Graphics.DrawString(textBoxResult.Lines[c].ToString(), font, Brushes.Black, new Point(h, 1030));//1,1...

                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "3")) { h += placing3_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "4")) { h += placing4_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "2")) { h += placing2_h(); }//2

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "3") { h += placing3_h(); }//3
                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += placing2_h(); }//γινεται υπερκαλυψη δεν μπορει να χωρεσει αλλο

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += placing2_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += placing3_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "4") { h += placing4_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h += 170; }//0

                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += placing2_h(); }//4
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "3") { h += placing3_h(); }//4

                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += placing2_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "4") { h += placing4_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += placing3_h(); }//1
                            c++;
                        }
                    }
                   
                }
            }
            catch (System.IndexOutOfRangeException ex) { }
            bm.Dispose();
            bm2.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ArrayList q = new ArrayList();
            foreach (object o in listBox1.Items)
                q.Add(o);

            q.Sort();
            listBox1.Items.Clear();
            foreach (object o in q)
            {
                listBox1.Items.Add(o);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            ArrayList list = new ArrayList();

            foreach (object o in listBox1.Items)
            {
                list.Add(o);
            }
            list.Sort();
            list.Reverse();
            listBox1.Items.Clear();
            foreach (object o in list)
            {
                listBox1.Items.Add(o);
            }
        }

        private void textBoxProthema_TextChanged(object sender, EventArgs e)
        {
            string textPrefix = textBoxProthema.Text;
            string p = "";
            if (!textBoxFrom.Text.StartsWith(textPrefix))
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    for (int t = 0; t < textPrefix.Length - 1; t++) { p += "0"; }
                  //  MessageBox.Show("");
                }else if(comboBox1.SelectedIndex != 0) {

                for (int i = 0; i < textPrefix.Length; i++) { p += "0"; }}                
                    
                
                textBoxFrom.Text = textPrefix + p+"1";
                textBoxFrom.SelectionStart = textBoxFrom.Text.Length;
                textBoxUntil.Text = textPrefix;
                textBoxUntil.SelectionStart = textBoxUntil.Text.Length;
            }
        }
        private Bitmap CaptureControl(Control ctl)
        {
            Rectangle rect;
            if (ctl is Form)
                rect = new Rectangle(ctl.Location, ctl.Size);
            else
                rect = new Rectangle(ctl.PointToScreen(new Point(0, 0)), ctl.Size);

            Bitmap bitmap = new Bitmap(rect.Width, rect.Height, PixelFormat.Format64bppPArgb);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
            }
            return bitmap;
        }
        private void buttonTest_Click(object sender, EventArgs e)
        {
            string combofont = comboBox2.SelectedItem.ToString();
            try
            {
                if (textBoxResult.Text != null)
                {
                    PrintDialog pd = new PrintDialog();
                    PrintDocument doc = new PrintDocument();
                    int left=0, right=0, top=0, bottom=0;

                        left= Int32.Parse( textBoxLeft.Text);
                        right= Int32.Parse( textBoxRight.Text);
                        top= Int32.Parse( textBoxUp.Text);
                        bottom= Int32.Parse( textBoxBottom.Text);
                    

                    Margins margins = new Margins(0, 0, 0,0);

                        margins.Bottom = bottom;
                        margins.Top = top;
                        margins.Left = left;
                        margins.Right = right;

                    doc.DefaultPageSettings.Margins = margins;
                    doc.OriginAtMargins = true;
                    string barcode = textBoxResult.Lines[0].ToString();
                    Bitmap bitmap = new Bitmap(barcode.Length * 10, 20);

                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        Font oFont = new System.Drawing.Font(combofont, 12, FontStyle.Regular);
                        PointF point = new PointF(10f, 10f);
                        SolidBrush black = new SolidBrush(Color.Black);
                        SolidBrush white = new SolidBrush(Color.White);
                        graphics.FillRectangle(white, 0, 0, bitmap.Width, bitmap.Height);
                        graphics.DrawString(barcode, oFont, black, point);
                    }
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitmap.Save(ms, ImageFormat.Png);
                        picture.Image = bitmap;
                        picture.Height = bitmap.Height;
                        picture.Width = bitmap.Width;
                    }
                    doc.PrintPage += Doc_PrintPage;
                    pd.Document = doc;
                    preview(doc);
                }
            }
            catch (System.IndexOutOfRangeException ex) { }
        }

        private void textBoxKataliksi_TextChanged(object sender, EventArgs e)
        {
            string textPrefix = textBoxKataliksi.Text;
            if (!textBoxFrom.Text.EndsWith(textPrefix))
            {
                textBoxFrom.Text = textPrefix;
                textBoxFrom.SelectionStart = textBoxFrom.Text.Length;
                textBoxUntil.Text = textPrefix;
                textBoxUntil.SelectionStart = textBoxUntil.Text.Length;
            }
        }

        private void textBoxResult_TextChanged(object sender, EventArgs e) { }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) { }

        private void buttonPreview_Click(object sender, EventArgs e) { }

        private void preview(PrintDocument doc)
        {
            try
            {
                PrintPreviewDialog printDialog = new PrintPreviewDialog();
                printDialog.Document = doc;
                doc.EndPrint += doc_EndPrint; // Subscribe to EndPrint event of your document here.
                printDialog.ShowDialog();
            }
            catch (System.ArgumentException ex) { }
        }
        private static void doc_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (e.PrintAction == System.Drawing.Printing.PrintAction.PrintToPrinter)
            {
                
            }
            else if (e.PrintAction == System.Drawing.Printing.PrintAction.PrintToPreview)
            {
               
            }
        }
        public static class myPrinters
        {
            [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool SetDefaultPrinter(string Name);

        }
        private void comboBoxPrinters_SelectedValueChanged(object sender, EventArgs e)
        {
            string pname = this.comboBoxPrinters.SelectedItem.ToString();
            myPrinters.SetDefaultPrinter(pname);
        }

        private void comboBoxPrinter2_SelectedValueChanged(object sender, EventArgs e)
        {
            string pname = this.comboBoxPrinter2.SelectedItem.ToString();
            myPrinters.SetDefaultPrinter(pname);
        }
        private void Doc_PrintPage2(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(picture.Width, picture.Height);
            Bitmap bm2 = new Bitmap(picture.Width, picture.Height);
            string m = comboBox3.SelectedItem.ToString();
            int N = 1, o = 0;

            try
            {
                N = Convert.ToInt32(m);

            }
            catch (System.FormatException ex) { }
            string combofont = comboBox2.SelectedItem.ToString();
            var font = new Font(combofont, N, FontStyle.Regular, GraphicsUnit.Pixel);
            picture2.DrawToBitmap(bm, new Rectangle(0, 0, 530, 530));
            picture.DrawToBitmap(bm, new Rectangle(0, 0, 530, 530));
            int h = 20, p = 32, first = Int32.Parse(textBoxX.Text), second = Int32.Parse(textBoxY.Text);

            try
            {
                for (int i = 0; i < 1; i++)
                {
                  int c = 0, k = 0, t = 0;
                    for (o = 0; o < first; o++)
                    {

                        if (textBoxX.Text == "1" & comboBox3.SelectedIndex != 4) { h += placing1_h(); }//1
                        else if (textBoxX.Text == "1" & comboBox3.SelectedIndex == 4) { h += placing1_h(); }//1

                        if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += 40; }
                        if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += 30; }
                        if (comboBox3.SelectedIndex == 2 & textBoxX.Text == "2") { h += 60; }
                        if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += 80; }
                        if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += 60; }
                        if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += 20; }

                        if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += 20; }
                        if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h -= 3; }

                        e.Graphics.DrawString(listBox1.Items[o].ToString(), font, Brushes.Black, new Point(h, 30));

                        if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "3")) { h += placing3_h(); }//2
                        if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "4")) { h += placing4_h(); }//2
                        if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "2")) { h += placing2_h(); }//2

                        if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "3") { h += placing3_h(); }//3
                        if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += placing2_h(); }//γινεται υπερκαλυψη δεν μπορει να χωρεσει αλλο

                        if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += placing2_h(); }//0
                        if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += placing3_h(); }//0
                        if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "4") { h += placing4_h(); }//0
                        if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h += 174; }//0

                        if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += placing2_h(); }//4
                        if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "3") { h += placing3_h(); }//4

                        if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += placing2_h(); }
                        if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "4") { h += placing4_h(); }
                        if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += placing3_h(); }//1
                        c++;
                    }
                    if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h = 20; }
                    else
                    {
                        h = 20;
                    }

                    if (c < listBox1.Items.Count)
                    {

                        for (int j = 0; j < first; j++)
                        {
                            if (textBoxX.Text == "1" & comboBox3.SelectedIndex != 4) { h += placing1_h(); }//1
                            else if (textBoxX.Text == "1" & comboBox3.SelectedIndex == 4) { h += placing1_h(); }//1


                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += 40; }
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += 30; }
                            if (comboBox3.SelectedIndex == 2 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += 80; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += 20; }

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += 20; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h -= 3; }
                            e.Graphics.DrawString(listBox1.Items[c].ToString(), font, Brushes.Black, new Point(h, 130));//1,1...

                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "3")) { h += placing3_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "4")) { h += placing4_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "2")) { h += placing2_h(); }//2

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "3") { h += placing3_h(); }//3
                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += placing2_h(); }//γινεται υπερκαλυψη δεν μπορει να χωρεσει αλλο

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += placing2_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += placing3_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "4") { h += placing4_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h += 174; }//0

                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += placing2_h(); }//4
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "3") { h += placing3_h(); }//4

                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += placing2_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "4") { h += placing4_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += placing3_h(); }//1
                            c++;
                        }
                    }
                    if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h = 20; }
                    else
                    {
                        h = 20;
                    }
                    if (c < listBox1.Items.Count)
                    {
                        for (int j = 0; j < first; j++)
                        {
                            if (textBoxX.Text == "1" & comboBox3.SelectedIndex != 4) { h += placing1_h(); }//1
                            else if (textBoxX.Text == "1" & comboBox3.SelectedIndex == 4) { h += placing1_h(); }//1

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += 40; }
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += 30; }
                            if (comboBox3.SelectedIndex == 2 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += 80; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += 20; }

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += 20; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h -= 3; }
                            
                            e.Graphics.DrawString(listBox1.Items[c].ToString(), font, Brushes.Black, new Point(h, 230));//1,1...
                            
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "3")) { h += placing3_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "4")) { h += placing4_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "2")) { h += placing2_h(); }//2

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "3") { h += placing3_h(); }//3
                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += placing2_h(); }//γινεται υπερκαλυψη δεν μπορει να χωρεσει αλλο

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += placing2_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += placing3_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "4") { h += placing4_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h += 174; }//0

                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += placing2_h(); }//4
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "3") { h += placing3_h(); }//4

                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += placing2_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "4") { h += placing4_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += placing3_h(); }//1
                            c++;

                        }
                    }
                    if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h = 20; }
                    else
                    {
                        h = 20;
                    }
                    if (c < listBox1.Items.Count)
                    {
                        for (int j = 0; j < first; j++)
                        {
                            if (textBoxX.Text == "1" & comboBox3.SelectedIndex != 4) { h += placing1_h(); }//1
                            else if (textBoxX.Text == "1" & comboBox3.SelectedIndex == 4) { h += placing1_h(); }//1

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += 40; }
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += 30; }
                            if (comboBox3.SelectedIndex == 2 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += 80; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += 20; }

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += 20; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h -= 3; }
                            
                            e.Graphics.DrawString(listBox1.Items[c].ToString(), font, Brushes.Black, new Point(h, 330));//1,1...
                            
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "3")) { h += placing3_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "4")) { h += placing4_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "2")) { h += placing2_h(); }//2

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "3") { h += placing3_h(); }//3
                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += placing2_h(); }//γινεται υπερκαλυψη δεν μπορει να χωρεσει αλλο

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += placing2_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += placing3_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "4") { h += placing4_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h += 174; }//0

                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += placing2_h(); }//4
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "3") { h += placing3_h(); }//4

                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += placing2_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "4") { h += placing4_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += placing3_h(); }//1
                            c++;
                        }
                    }
                    if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h = 20; }
                    else
                    {
                        h = 20;
                    }
                    if (c < listBox1.Items.Count)
                    {
                        for (int j = 0; j < first; j++)
                        {
                            if (textBoxX.Text == "1" & comboBox3.SelectedIndex != 4) { h += placing1_h(); }//1
                            else if (textBoxX.Text == "1" & comboBox3.SelectedIndex == 4) { h += placing1_h(); }//1

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += 40; }
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += 30; }
                            if (comboBox3.SelectedIndex == 2 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += 80; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += 20; }

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += 20; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h -= 3; }

                            e.Graphics.DrawString(listBox1.Items[c].ToString(), font, Brushes.Black, new Point(h, 430));//1,1...
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "3")) { h += placing3_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "4")) { h += placing4_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "2")) { h += placing2_h(); }//2

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "3") { h += placing3_h(); }//3
                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += placing2_h(); }//γινεται υπερκαλυψη δεν μπορει να χωρεσει αλλο

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += placing2_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += placing3_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "4") { h += placing4_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h += 174; }//0

                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += placing2_h(); }//4
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "3") { h += placing3_h(); }//4

                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += placing2_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "4") { h += placing4_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += placing3_h(); }//1
                            c++;
                        }
                    }
                    if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h = 20; }
                    else
                    {
                        h = 20;
                    }
                    if (c < listBox1.Items.Count)
                    {
                        for (int j = 0; j < first; j++)
                        {
                            if (textBoxX.Text == "1" & comboBox3.SelectedIndex != 4) { h += placing1_h(); }//1
                            else if (textBoxX.Text == "1" & comboBox3.SelectedIndex == 4) { h += placing1_h(); }//1

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += 40; }
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += 30; }
                            if (comboBox3.SelectedIndex == 2 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += 80; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += 20; }

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += 20; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h -= 3; }

                            e.Graphics.DrawString(listBox1.Items[c].ToString(), font, Brushes.Black, new Point(h, 530));//1,1...

                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "3")) { h += placing3_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "4")) { h += placing4_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "2")) { h += placing2_h(); }//2

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "3") { h += placing3_h(); }//3
                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += placing2_h(); }//γινεται υπερκαλυψη δεν μπορει να χωρεσει αλλο

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += placing2_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += placing3_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "4") { h += placing4_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h += 174; }//0

                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += placing2_h(); }//4
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "3") { h += placing3_h(); }//4

                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += placing2_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "4") { h += placing4_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += placing3_h(); }//1
                            c++;
                        }
                    }
                    if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h = 20; }
                    else
                    {
                        h = 20;
                    }
                    if (c < listBox1.Items.Count)
                    {
                        for (int j = 0; j < first; j++)
                        {

                            if (textBoxX.Text == "1" & comboBox3.SelectedIndex != 4) { h += placing1_h(); }//1
                            else if (textBoxX.Text == "1" & comboBox3.SelectedIndex == 4) { h += placing1_h(); }//1

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += 40; }
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += 30; }
                            if (comboBox3.SelectedIndex == 2 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += 80; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += 20; }

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += 20; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h -= 3; }
                            e.Graphics.DrawString(listBox1.Items[c].ToString(), font, Brushes.Black, new Point(h, 630));//1,1...
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "3")) { h += placing3_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "4")) { h += placing4_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "2")) { h += placing2_h(); }//2

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "3") { h += placing3_h(); }//3
                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += placing2_h(); }//γινεται υπερκαλυψη δεν μπορει να χωρεσει αλλο

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += placing2_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += placing3_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "4") { h += placing4_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h += 174; }//0

                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += placing2_h(); }//4
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "3") { h += placing3_h(); }//4

                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += placing2_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "4") { h += placing4_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += placing3_h(); }//1
                            c++;
                        }
                    }
                    if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h = 20; }
                    else
                    {
                        h = 20;
                    }

                    if (c < listBox1.Items.Count)
                    {
                        for (int j = 0; j < first; j++)
                        {
                            if (textBoxX.Text == "1" & comboBox3.SelectedIndex != 4) { h += placing1_h(); }//1
                            else if (textBoxX.Text == "1" & comboBox3.SelectedIndex == 4) { h += placing1_h(); }//1

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += 40; }
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += 30; }
                            if (comboBox3.SelectedIndex == 2 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += 80; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += 20; }

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += 20; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h -= 3; }
                            e.Graphics.DrawString(listBox1.Items[c].ToString(), font, Brushes.Black, new Point(h, 730));//1,1...
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "3")) { h += placing3_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "4")) { h += placing4_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "2")) { h += placing2_h(); }//2

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "3") { h += placing3_h(); }//3
                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += placing2_h(); }//γινεται υπερκαλυψη δεν μπορει να χωρεσει αλλο

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += placing2_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += placing3_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "4") { h += placing4_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h += 174; }//0

                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += placing2_h(); }//4
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "3") { h += placing3_h(); }//4

                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += placing2_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "4") { h += placing4_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += placing3_h(); }//1
                            c++;
                        }
                    }
                    if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h = 20; }
                    else
                    {
                        h = 20;
                    }
                    if (c < listBox1.Items.Count)
                    {
                        for (int j = 0; j < first; j++)
                        {
                            if (textBoxX.Text == "1" & comboBox3.SelectedIndex != 4) { h += placing1_h(); }//1
                            else if (textBoxX.Text == "1" & comboBox3.SelectedIndex == 4) { h += placing1_h(); }//1

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += 40; }
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += 30; }
                            if (comboBox3.SelectedIndex == 2 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += 80; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += 20; }

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += 20; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h -= 3; }

                            e.Graphics.DrawString(listBox1.Items[c].ToString(), font, Brushes.Black, new Point(h, 830));//1,1...

                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "3")) { h += placing3_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "4")) { h += placing4_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "2")) { h += placing2_h(); }//2

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "3") { h += placing3_h(); }//3
                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += placing2_h(); }//γινεται υπερκαλυψη δεν μπορει να χωρεσει αλλο

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += placing2_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += placing3_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "4") { h += placing4_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h += 174; }//0

                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += placing2_h(); }//4
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "3") { h += placing3_h(); }//4

                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += placing2_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "4") { h += placing4_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += placing3_h(); }//1
                            c++;
                        }
                    }
                    if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h = 20; }
                    else
                    {
                        h = 20;
                    }
                    if (c < listBox1.Items.Count)
                    {
                        for (int j = 0; j < first; j++)
                        {
                            if (textBoxX.Text == "1" & comboBox3.SelectedIndex != 4) { h += placing1_h(); }//1
                            else if (textBoxX.Text == "1" & comboBox3.SelectedIndex == 4) { h += placing1_h(); }//1

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += 40; }
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += 30; }
                            if (comboBox3.SelectedIndex == 2 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += 80; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += 20; }

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += 20; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h -= 3; }
                            e.Graphics.DrawString(listBox1.Items[c].ToString(), font, Brushes.Black, new Point(h, 930));//1,1...
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "3")) { h += placing3_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "4")) { h += placing4_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "2")) { h += placing2_h(); }//2

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "3") { h += placing3_h(); }//3
                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += placing2_h(); }//γινεται υπερκαλυψη δεν μπορει να χωρεσει αλλο

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += placing2_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += placing3_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "4") { h += placing4_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h += 174; }//0

                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += placing2_h(); }//4
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "3") { h += placing3_h(); }//4

                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += placing2_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "4") { h += placing4_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += placing3_h(); }//1
                            c++;
                        }
                    }
                    if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h = 20; }
                    else
                    {
                        h = 20;
                    }
                    if (c < listBox1.Items.Count)
                    {
                        for (int j = 0; j < first; j++)
                        {
                            if (textBoxX.Text == "1" & comboBox3.SelectedIndex != 4) { h += placing1_h(); }//1
                            else if (textBoxX.Text == "1" & comboBox3.SelectedIndex == 4) { h += placing1_h(); }//1

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += 40; }
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += 30; }
                            if (comboBox3.SelectedIndex == 2 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += 80; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += 60; }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += 20; }

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += 20; }
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h -= 3; }
                            e.Graphics.DrawString(listBox1.Items[c].ToString(), font, Brushes.Black, new Point(h, 1030));//1,1...
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "3")) { h += placing3_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "4")) { h += placing4_h(); }//2
                            if ((comboBox3.SelectedIndex == 2 & textBoxX.Text == "2")) { h += placing2_h(); }//2

                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "3") { h += placing3_h(); }//3
                            if (comboBox3.SelectedIndex == 3 & textBoxX.Text == "2") { h += placing2_h(); }//γινεται υπερκαλυψη δεν μπορει να χωρεσει αλλο

                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "2") { h += placing2_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "3") { h += placing3_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "4") { h += placing4_h(); }//0
                            if (comboBox3.SelectedIndex == 0 & textBoxX.Text == "5") { h += 174; }//0

                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "2") { h += placing2_h(); }//4
                            if (comboBox3.SelectedIndex == 4 & textBoxX.Text == "3") { h += placing3_h(); }//4

                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "2") { h += placing2_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "4") { h += placing4_h(); }
                            if (comboBox3.SelectedIndex == 1 & textBoxX.Text == "3") { h += placing3_h(); }//1
                            c++;
                        }
                    }            
                }
            }
            catch (System.IndexOutOfRangeException ex) { }
            catch (System.ArgumentOutOfRangeException b) { }
            bm.Dispose();
            bm2.Dispose();
        }

        private void buttonPreview2_Click(object sender, EventArgs e)
        {
            string combofont = comboBox2.SelectedItem.ToString();
            try
            {
                if (listBox1.Items != null)
                {
                    PrintDialog pd = new PrintDialog();
                    PrintDocument doc = new PrintDocument();

                    string barcode = listBox1.Items.ToString();
                    Bitmap bitmap = new Bitmap(barcode.Length * 19, 90);

                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        Font oFont = new System.Drawing.Font(combofont, 12, FontStyle.Regular);
                        PointF point = new PointF(2f, 2f);
                        SolidBrush black = new SolidBrush(Color.Black);
                        SolidBrush white = new SolidBrush(Color.White);
                        graphics.FillRectangle(white, 0, 0, bitmap.Width, bitmap.Height);
                        graphics.DrawString(barcode, oFont, black, point);
                    }
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitmap.Save(ms, ImageFormat.Png);
                        picture.Image = bitmap;
                        picture.Height = bitmap.Height;
                        picture.Width = bitmap.Width;
                    }
                    doc.PrintPage += Doc_PrintPage2;
                    pd.Document = doc;
                    preview(doc);
                }
            }
            catch (System.IndexOutOfRangeException ex) { }
        }
        class BubbleSort : ISortAlgorithm<int>
        {
            private int[] myArray;
            public void Sort(int[] array)
            {
                myArray = array;
                int temp;
                for (int j = 1; j <= array.Length - 2; j++)
                {
                    for (int i = 0; i <= array.Length - 2; i++)
                    {
                        if (array[i] > array[i + 1])
                        {
                            temp = array[i + 1];
                            array[i + 1] = array[i];
                            array[i] = temp;
                        }
                    }
                }
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                foreach (int i in myArray)
                {
                    sb.Append(Convert.ToString(i));
                }
                return sb.ToString();
            }
        }

        private void textBoxX_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBoxX.Text == "0" || Int32.Parse(textBoxX.Text) > 5)
            {
                MessageBox.Show("Μη αποδεκτό όριο barcode ανα σειρά", "Πρόβλημα ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxX.Text = "";
            }
        }

        private void textBoxY_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBoxY.Text == "0" )
            {
                MessageBox.Show("Μη αποδεκτό όριο barcode ανα σειρά", "Πρόβλημα ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxY.Text = "";
            }
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((comboBox3.SelectedIndex !=0 ) && textBoxX.Text == "5")
            {
                textBoxX.Text = "";
                MessageBox.Show("Δεν γίνεται να τοποθετηθούν 5 barcode λογο του μεγέθους της μασκας ", "Πρόβλημα", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if ((comboBox3.SelectedIndex == 3 || comboBox3.SelectedIndex == 4 || comboBox3.SelectedIndex == 2) && textBoxX.Text == "4")
            {
                textBoxX.Text = "";
                MessageBox.Show("Δεν γίνεται να τοποθετηθούν τα barcode λογο του μεγέθους του font ", "Πρόβλημα", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if ((comboBox3.SelectedIndex == 3 || comboBox3.SelectedIndex == 4) && textBoxX.Text == "3")
            {
                textBoxX.Text = "";
                MessageBox.Show("Δεν γίνεται να τοποθετηθούν τα barcode λογο του μεγέθους του font ", "Πρόβλημα", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedIndex == 4 || comboBox1.SelectedIndex == 3 ) & textBoxX.Text == "3")
            {
                MessageBox.Show("Δεν γίνεται να τοποθετηθούν τα barcode λογο του μεγέθους της μάσκας ", "Πρόβλημα", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxX.Text = "";
            }
        }

        private void textBoxX_TextChanged(object sender, EventArgs e)
        {
            if (textBoxX.Text == "5" & comboBox3.SelectedIndex == 1|| comboBox3.SelectedIndex == 2 || comboBox3.SelectedIndex == 3 || comboBox3.SelectedIndex == 4)
            {
                textBoxX.Text = "";
                MessageBox.Show("Δεν γίνεται να τοποθετηθούν 5 barcode με μασκα μεγαλύτερη του 6 ", "Πρόβλημα", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if ((comboBox3.SelectedIndex == 1 || comboBox3.SelectedIndex == 2 || comboBox3.SelectedIndex == 3 || comboBox3.SelectedIndex == 4) && textBoxX.Text == "5")
            {
                textBoxX.Text = "";
                MessageBox.Show("Δεν γίνεται να τοποθετηθούν τα barcode λογο του μεγέθους του font ", "Πρόβλημα", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if ((comboBox3.SelectedIndex == 3 || comboBox3.SelectedIndex == 4 || comboBox3.SelectedIndex == 2 || comboBox3.SelectedIndex == 2) && textBoxX.Text == "4")
            {
                textBoxX.Text = "";
                MessageBox.Show("Δεν γίνεται να τοποθετηθούν τα barcode λογο του μεγέθους του font ", "Πρόβλημα", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if ((comboBox1.SelectedIndex == 3 || comboBox1.SelectedIndex == 4|| comboBox1.SelectedIndex == 2) & (comboBox3.SelectedIndex == 3 || comboBox3.SelectedIndex == 4 || comboBox3.SelectedIndex == 2) && textBoxX.Text == "3")
            {
                textBoxX.Text = "";
                MessageBox.Show("Δεν γίνεται να τοποθετηθούν τα barcode λογο του μεγέθους του font ", "Πρόβλημα", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if ((comboBox3.SelectedIndex == 3 || comboBox3.SelectedIndex == 4) && textBoxX.Text == "2")
            {
                textBoxX.Text = "";
                MessageBox.Show("Δεν γίνεται να τοποθετηθούν τα barcode λογο του μεγέθους του font ", "Πρόβλημα", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
