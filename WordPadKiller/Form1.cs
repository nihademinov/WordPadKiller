using Microsoft.VisualBasic.ApplicationServices;
using System.Text.Json;
using System.Windows.Forms;

namespace WordPadKiller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string userFileName = textBoxSave.Text + ".txt";

            try
            {
                using FileStream fs = new FileStream(userFileName, FileMode.Open);
                File.WriteAllText(userFileName, richTextBox1.Text);

                fs.Close();
            }
            catch (Exception)
            {

                using FileStream fs = new FileStream(userFileName, FileMode.Create);
                fs.Close();

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;

                File.WriteAllText(userFileName, JsonSerializer.Serialize(richTextBox1.Text, options));
                MessageBox.Show("Your data successfully saved", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                richTextBox1.Text = "";

                fs.Close();

            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text File|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string textNameFile = openFileDialog1.FileName;

                string text = File.ReadAllText(textNameFile);
                richTextBox1.Text = text;   
            }
        }
    }
}