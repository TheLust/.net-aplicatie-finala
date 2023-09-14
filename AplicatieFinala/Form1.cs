using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicatieFinala
{
    public partial class Form1 : Form
    {
        int nrmodificari = 0; SqlConnection co;
        public Form1()
        {
            InitializeComponent();
            co = new SqlConnection(@"Data Source=LAB106_PC03\SQLEXPRESS;Initial Catalog=nush;Integrated Security=True");
            co.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertsql;
            insertsql = "insert into salar_angajat (id,nume,prenume,vechime,salar) values " +
                "(" + textBox1.Text + ", '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "')";
            SqlCommand cmd = new SqlCommand(insertsql, co);
            nrmodificari = nrmodificari + cmd.ExecuteNonQuery();
            textBox6.Text = Convert.ToString(nrmodificari);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selectSQL = "SELECT * FROM salar_angajat";
            SqlCommand cmd = new SqlCommand(selectSQL, co);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "salar_angajat");
            label7.Text = "NUME"; label8.Text = "PRENUME"; label9.Text = "VECHIME"; label10.Text = "SALAR";
            foreach (DataRow r in ds.Tables["salar_angajat"].Rows)
            {
                label7.Text = label7.Text + "\n" + r["nume"] + "\n";
                label8.Text = label8.Text + "\n" + r["prenume"] + "\n";
                label9.Text = label9.Text + "\n" + r["vechime"] + "\n";
                label10.Text = label10.Text + "\n" + r["salar"] + "\n";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string deletesql;
            deletesql = "delete from salar_angajat where nume='"; deletesql += textBox7.Text + "'";
            SqlCommand cmd = new SqlCommand(deletesql, co);
            nrmodificari = nrmodificari + cmd.ExecuteNonQuery();
            textBox6.Text = Convert.ToString(nrmodificari);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int suma;
            SqlCommand cmd = new SqlCommand("select SUM(SALAR) FROM SALAR_ANGAJAT", co);
            suma = (int)cmd.ExecuteScalar();
            textBox8.Text = Convert.ToString(suma);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int min;
            SqlCommand cmd = new SqlCommand("select min(vechime) FROM SALAR_ANGAJAT", co);
            min = (int)cmd.ExecuteScalar();
            textBox9.Text = Convert.ToString(min);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            int max;
            SqlCommand cmd = new SqlCommand("select max(SALAR) FROM SALAR_ANGAJAT", co);
            max = (int)cmd.ExecuteScalar();
            textBox10.Text = Convert.ToString(max);
        }

        private void button1_Clic_1(object sender, EventArgs e)
        {
            string selectSQL = "select * FROM SALAR_ANGAJAT ORDER BY NUME ASC";
            SqlCommand cmmd = new SqlCommand(selectSQL, co);
            SqlDataAdapter adapter = new SqlDataAdapter(cmmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "salar_angajat");
            label7.Text = ""; label8.Text = ""; label9.Text = ""; label10.Text = "";
            foreach (DataRow r in ds.Tables["salar_angajat"].Rows)
            {
                label7.Text = label7.Text + "\n" + r["nume"] + "\n";
                label8.Text = label8.Text + "\n" + r["prenume"] + "\n";
                label9.Text = label9.Text + "\n" + r["vechime"] + "\n";
                label10.Text = label10.Text + "\n" + r["salar"] + "\n";
            }
        }
    }
}
