using ProjectV2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectV2
{
    public partial class Form2 : Form
    {

        public static int institutionId;
        public Form2()
        {
            InitializeComponent();
            FillInstitutionsTypeComboBox();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FillInstitutionsTypeComboBox()
        {
            Institution institution = new Institution { };
            List<Institution> institutions = new List<Institution>();

            institutions = institution.getInstitutionsList();

            foreach (Institution singleInstitution in institutions)
            {
                comboBox1.Items.Add(singleInstitution.InstitutionId);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedIndex == -1))
            {
                MessageBox.Show("Please Enter All Data!!");
            }
            else
            {
                institutionId = Convert.ToInt32(comboBox1.Text);
                Form1 form1 = new Form1();
                form1.Show();
            }

         
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
