using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        private SqlConnection conn;
        private SqlDataReader dr;
        private DataTable table;
        SqlDataAdapter ad=null;
        DataSet set=null;
        SqlCommandBuilder cmd = null;
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            //table.Columns.Add("id");
            //table.Columns.Add("name");
            //table.Columns.Add("LastName");
            //DataRow row=table.NewRow();
            //row[0] = 1;
            //row[1] = "Bob";
            //row[2] = "pupkin";
            //table.Rows.Add(row);
            //dataGridView1.DataSource = table;
            //SqlCommand comm=new SqlCommand();
            //comm.CommandText = "Select*from Authors";
            //comm.Connection = conn;
            //conn.Open();
            //dr = comm.ExecuteReader();
            //int line = 0;
            //do
            //{
            //    while (dr.Read())
            //    {
            //        if (line == 0)
            //        {
            //            for (int i = 0; i < dr.FieldCount; i++)
            //            {
            //                table.Columns.Add(dr.GetName(i));
            //            }
            //            line++;
            //        }
            //        DataRow row = table.NewRow();
            //        for (int i = 0; i < dr.FieldCount; i++)
            //        {
            //            row[i] = dr[i];
            //        }
            //        table.Rows.Add(row);
            //    }
            //}
            //while (dr.NextResult());
            //        dataGridView1.DataSource = table;
            //conn.Close();
            //dr.Close();
            //try
            //{
            //    SqlCommand comm = new SqlCommand();
            //    comm.CommandText = textBox1.Text;
            //    comm.Connection = conn;
            //    dataGridView1.DataSource = null;
            //    conn.Open();
            //    table = new DataTable();
            //    dr = comm.ExecuteReader();
            //    int line = 0;
            //    do
            //    {
            //        while (dr.Read())
            //        {
            //            if (line == 0)
            //            {
            //                for (int i = 0; i < dr.FieldCount; i++)
            //                {
            //                    table.Columns.Add(dr.GetName(i));
            //                }
            //                line++;
            //            }
            //            DataRow row = table.NewRow();
            //            for (int i = 0; i < dr.FieldCount; i++)
            //            {
            //                row[i] = dr[i];
            //            }
            //            table.Rows.Add(row);
            //        }
            //    }
            //    while (dr.NextResult());
            //    dataGridView1.DataSource = table;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Неверный синтаксис");
            //}
            //finally
            //{
            //    if (conn != null)
            //    {
            //        conn.Close();
            //    }
            //    if (dr != null)
            //    {
            //        dr.Close();
            //    }

            //}

            ////примеры подключения и запроса к таблицам и к базе пример работы dataSet
            //DataSet ds = new DataSet();
            //DataTable dt0 = ds.Tables[0];
            //DataTable dt1 = ds.Tables[1];
            //DataTable dt3 = ds.Tables["table"];
            //DataTable dt4 = ds.Tables["table1"];
            //string lastName = dt0.Rows[0][1].ToString();
            //string lastName1 = (string)ds.Tables[0].Rows[0]["Name"];

            //string seiektSql = "select * from Authors";
            //SqlDataAdapter da = new SqlDataAdapter(seiektSql,conn);
            //SqlCommandBuilder cmdBilder = new SqlCommandBuilder();
            //DataSet ds=new DataSet();
            //da.Fill(ds);



        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                set = new DataSet();
                string sql = textBox1.Text;
                ad = new SqlDataAdapter(sql, conn);
                dataGridView1.DataSource = null;
                cmd = new SqlCommandBuilder(ad);
                ad.Fill(set, "Books");
                dataGridView1.DataSource = set.Tables["Books"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Синтакси не верный");
            }
            finally { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ad.Update(set, "Books");

        }
    }
}
