using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace _0H03040麥愷澄_個人製作
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        string connectionString;

        public Form1()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["_0H03040麥愷澄_個人製作.Properties.Settings.Database1ConnectionString"].ConnectionString;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AllSite();
            AllForamt();
        }

        private void AllSite()
        {
            
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM site", connection))
            {

                DataTable SiteList = new DataTable();
                adapter.Fill(SiteList);

                listBox1.DisplayMember = "Site";
                listBox1.ValueMember = "Id";
                listBox1.DataSource = SiteList;
            }
        }

        private void AllForamt()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM format", connection))
            {

                DataTable FormatList = new DataTable();
                adapter.Fill(FormatList);

                listBox4.DisplayMember = "FormatName";
                listBox4.ValueMember = "FormatId";
                listBox4.DataSource = FormatList;

                listBox5.DisplayMember = "FormatName";
                listBox5.ValueMember = "FormatId";
                listBox5.DataSource = FormatList;
            }
        }

        private void GetAccountName()
        {
            string query = "SELECT AccountName FROM site WHERE Id = @SiteId";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@SiteId", listBox1.SelectedValue);

                DataTable AccountName = new DataTable();
                adapter.Fill(AccountName);

                listBox2.DisplayMember = "AccountName";
                listBox2.ValueMember = "Id";
                listBox2.DataSource = AccountName;
            }
        }

        private void GetPasswordFrame()
        {
            string query = "SELECT FormatName FROM format " +
                "INNER JOIN pwd ON format.FormatId = pwd.Password WHERE pwd.SiteId = @SiteId";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@SiteId", listBox1.SelectedValue);

                DataTable PasswordList = new DataTable();
                adapter.Fill(PasswordList);

                listBox3.DisplayMember = "FormatName";
                listBox3.ValueMember = "Id";
                listBox3.DataSource = PasswordList;
            }
        }

        private void GetMemo()
        {
            string query = "SELECT Memo FROM format WHERE FormatId = @FormatId";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@FormatId", listBox5.SelectedValue);

                DataTable MemoList = new DataTable();
                adapter.Fill(MemoList);

                listBox6.DisplayMember = "Memo";
                listBox6.ValueMember = "FormatId";
                listBox6.DataSource = MemoList;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAccountName();
            GetPasswordFrame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new System.Random();
            int r, i;
            string random = "", chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int.TryParse(comboBox1.Text, out int cnt);
            if (radioButton1.Checked)
            {
                for (i = 0; i < cnt; i++)
                {
                    r = rnd.Next(10);
                    random += chars[r];
                }
                textBox1.Text = random;

            } else if (radioButton2.Checked)
            {
                for (i = 0; i < cnt; i++)
                {
                    r = rnd.Next(10, chars.Length);
                    random += chars[r];
                }
                textBox1.Text = random;

            } else if (radioButton3.Checked)
            {
                for (i = 0; i < cnt; i++)
                {
                    r = rnd.Next(0, chars.Length);
                    random += chars[r];
                }
                textBox1.Text = random;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Setting;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Generator;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = List;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = List;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Generator;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Setting;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = List;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Generator;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Setting;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = List;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Generator;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Setting;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Main;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Main;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Main;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = List;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Generator;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO site VALUES(@SiteName, NULL)";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@SiteName", textBox4.Text);
                command.ExecuteScalar();
            }

            AllSite();
            textBox4.Text = "";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string query = "UPDATE site SET Site = @SiteName WHERE Id = @SiteId";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@SiteName", textBox4.Text);
                command.Parameters.AddWithValue("@SiteId", listBox1.SelectedValue);
                command.ExecuteScalar();
            }

            AllSite();
            textBox4.Text = "";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM site WHERE Id = @SiteId";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@SiteId", listBox1.SelectedValue);
                command.ExecuteScalar();
            }

            AllSite();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string query = "UPDATE site SET AccountName = @AccountName WHERE Id = @SiteId";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@AccountName", textBox4.Text);
                command.Parameters.AddWithValue("@SiteId", listBox1.SelectedValue);
                command.ExecuteScalar();
            }

            AllSite();
            textBox4.Text = "";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string query = "UPDATE site SET AccountName = @AccountName WHERE Id = @SiteId";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@AccountName", textBox4.Text);
                command.Parameters.AddWithValue("@SiteId", listBox1.SelectedValue);
                command.ExecuteScalar();
            }

            AllSite();
            textBox4.Text = "";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO pwd VALUES(@SiteId, @FormatId)";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@SiteId", listBox1.SelectedValue);
                command.Parameters.AddWithValue("@FormatId", listBox4.SelectedValue);
                command.ExecuteScalar();
            }

            GetPasswordFrame();
        }
        
        private void button20_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM pwd WHERE SiteId = @SiteId AND Password = @FormatId";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@SiteId", listBox1.SelectedValue);
                command.Parameters.AddWithValue("@FormatId", listBox4.SelectedValue);
                command.ExecuteScalar();
            }

            GetPasswordFrame();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMemo();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO format VALUES(@FormatName, NULL)";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@FormatName", textBox2.Text);
                command.ExecuteScalar();
            }

            AllForamt();
            textBox2.Text = "";
        }

        private void button28_Click(object sender, EventArgs e)
        {
            string query = "UPDATE format SET FormatName = @FormatName WHERE FormatId = @FormatId";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@FormatId", listBox5.SelectedValue);
                command.Parameters.AddWithValue("@FormatName", textBox2.Text);
                command.ExecuteScalar();
            }

            AllForamt();
            textBox2.Text = "";
        }

        private void button29_Click(object sender, EventArgs e)
        {
            string query = "UPDATE format SET Memo = @Memo WHERE FormatId = @FormatId";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@FormatId", listBox5.SelectedValue);
                command.Parameters.AddWithValue("@Memo", textBox2.Text);
                command.ExecuteScalar();
            }

            AllForamt();
            textBox2.Text = "";
        }

        private void button30_Click(object sender, EventArgs e)
        {
            string query = "UPDATE format SET Memo = NULL WHERE FormatId = @FormatId";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@FormatId", listBox5.SelectedValue);
                command.ExecuteScalar();
            }

            AllForamt();
            textBox2.Text = "";
        }
    }
}
