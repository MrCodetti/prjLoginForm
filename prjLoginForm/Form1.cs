using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjLoginForm
{
    
    public partial class Form1 : Form
    {
        static int trie = 3;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (txtBenutzer.Text != "" && txtPasswort.Text != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(Datenzugriff.strSQL, Datenzugriff.cn);
                    cmd.Parameters.AddWithValue("@user", txtBenutzer.Text);
                    cmd.Parameters.AddWithValue("@pass", txtPasswort.Text);
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataTable dt = new DataTable();

                    Datenzugriff.cn.Open();
                    cmd.Connection = Datenzugriff.cn;
                    cmd.CommandText = Datenzugriff.strSQL;
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {
                        MessageBox.Show("Welcom aboard Captian", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        trie -= 1;
                        MessageBox.Show("Wrong Login or Password\n You have " + trie + " tries!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (trie == 0)
                    {
                        ;
                        if (MessageBox.Show("This is the End!", "END", MessageBoxButtons.OK, MessageBoxIcon.Warning) 
                            == System.Windows.Forms.DialogResult.OK)
                        {
                            Application.Exit();
                        }
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (Datenzugriff.cn.State != ConnectionState.Closed)
                    {
                        Datenzugriff.cn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter Login and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnEnde_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Close?", "END", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                            == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
