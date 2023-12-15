using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Dictionary>" +
                "</Dictionary>");
            using (XmlTextWriter writer = new XmlTextWriter("c://Dictionary.xml", null))
            {
                writer.Formatting = Formatting.Indented;
                doc.Save(writer);
                MessageBox.Show("The Dictionary File is created");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var doc = XDocument.Load("C://Dictionary.xml");
            XElement newItem = new XElement("Item",
                                 new XElement("Word", textBox1.Text),
                                 new XElement("Meaning", textBox2.Text));
            doc.Element("Dictionary").Add(newItem);
            doc.Save("C//Dictionary.xml");
            MessageBox.Show("A New Item is Added");


        }

        private void button3_Click(object sender, EventArgs e)
        {
            XElement doc = XElement.Load("C//Dictionary.xml");
            foreach(var X in doc.Elements("Item"))
            {
                if(textBox3.Text == X.Element("Word").Value)
                    label4.Text+= X.Element("Meaning").Value;
                return;
            }
            label4.Text += "Not Found";
        }
        
    }
}
