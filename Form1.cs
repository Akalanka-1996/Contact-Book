using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace CS_2017_001
{
    public partial class Form1 : Form
    {
        DataTable dt1 = new DataTable();
        int click;
        string path = "phonebook.txt";

        public Form1()
        {
            InitializeComponent();
            dt1.Columns.Add("Contact Name");
            dt1.Columns.Add("Number 1");
            dt1.Columns.Add("Number 2");
            dt1.Columns.Add("Number 3");

            dataGridView1.DataSource = dt1;

           

        }
        


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void txtContactName_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dt1.Rows.Add(txtContactName.Text, txtCNumber1.Text,txtCNumber2.Text,txtCNumber3.Text);
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
            txtContactName.Clear();
            txtCNumber1.Clear();
            txtCNumber2.Clear();
            txtCNumber3.Clear();

            TextWriter note = new StreamWriter("phonebook.txt");

            for(int i=0; i<dataGridView1.Rows.Count-1; i++)
            {
                int j = 0;
                for(; j<dataGridView1.Columns.Count-1; j++)
                {
                    note.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                }
                note.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t");
                note.WriteLine("");
            }
            note.Close();
           


            
        }
        private void FillData()
        {


        }
         
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridView1.Rows[click];
            newDataRow.Cells[0].Value = txtContactDetailsName.Text;
            newDataRow.Cells[1].Value = txtContactDetailsNum1.Text;
            newDataRow.Cells[2].Value = txtContactDetailsNum2.Text;
            newDataRow.Cells[3].Value = txtContactDetailsNum3.Text;

            txtContactDetailsName.Clear();
            txtContactDetailsNum1.Clear();
            txtContactDetailsNum2.Clear();
            txtContactDetailsNum3.Clear();

            TextWriter note = new StreamWriter("phonebook.txt");

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                int j = 0;
                for (; j < dataGridView1.Columns.Count - 1; j++)
                {
                    note.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                }
                note.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t");
                note.WriteLine("");
            }
            note.Close();


        }

        

        private void txtSearchFor_TextChanged(object sender, EventArgs e)
        {
            BindingSource bd_source = new BindingSource();
            bd_source.DataSource = dataGridView1.DataSource;

            bd_source.Filter = "[Contact Name] like '%" + txtSearchFor.Text + "%'" +
                "OR [Number 1] like '%" + txtSearchFor.Text + "%'" +
                "OR [Number 2] like '%" + txtSearchFor.Text + "%'" +
                "OR [Number 3] like '%" + txtSearchFor.Text + "%'";



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader phonebook = new StreamReader("phonebook.txt");

            string newline;
            while((newline = phonebook.ReadLine()) != null)
            {
                DataRow rowData = dt1.NewRow();
                string[] values;
                values = newline.Split('|');
                for(int i=0; i<values.Length; i++)
                {
                    rowData[i] = values[i];
                }
                dt1.Rows.Add(rowData);
            }
            phonebook.Close();
            dataGridView1.DataSource = dt1;
            

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            click = e.RowIndex;
            if(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                txtContactDetailsName.Text = dataGridView1.Rows[e.RowIndex].Cells["Contact Name"].FormattedValue.ToString();
                txtContactDetailsNum1.Text = dataGridView1.Rows[e.RowIndex].Cells["Number 1"].FormattedValue.ToString();
                txtContactDetailsNum2.Text = dataGridView1.Rows[e.RowIndex].Cells["Number 2"].FormattedValue.ToString();
                txtContactDetailsNum3.Text = dataGridView1.Rows[e.RowIndex].Cells["Number 3"].FormattedValue.ToString();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(click);
            txtContactDetailsName.Clear();
            txtContactDetailsNum1.Clear();
            txtContactDetailsNum2.Clear();
            txtContactDetailsNum3.Clear();

            TextWriter note = new StreamWriter("phonebook.txt");

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                int j = 0;
                for (; j < dataGridView1.Columns.Count - 1; j++)
                {
                    note.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                }
                note.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t");
                note.WriteLine("");
            }
            note.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCNumber1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCNumber2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCNumber3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
