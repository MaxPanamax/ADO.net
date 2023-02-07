using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ConsoleApp3
{
    internal class Program
    {
        SqlConnection con=null;
        string st = " ";
        public Program()
        {
            con = new SqlConnection();

            con.ConnectionString = ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            //con.ConnectionString = @"Data Source=218-04\SQLEXPRESS; initial Catalog= Library; User id= sa; Password=Telman33";
            //con = new SqlConnection(@"Data Source=218-04\SQLEXPRESS; initial Catolog= Library; User id= sa; Password=Telman33");
            //string insertString= @"Data Source=218-04\SQLEXPRESS; initial Catolog= Library; User id= sa; Password=Telman33"
            //SqlCommand cmd = new SqlCommand(insertString, con);

        }
        public void InsertQuert()
        {
            try
            {
                con.Open();
              
                //string userName=//textBox"user5';drop table  Authors;'"
                //string sql = @"selec*from Authors where FerstName='" + userName + "'";
                //SqlParameter param1=new SqlParameter();
                //param1.ParameterName = "@p1";
                //param1.SqlDbType = System.Data.SqlDbType.NVarChar;
                //param1.Value = userName;
                //SqlClientMetaDataCollectionNames.Parameters.Add('@p1', SqlDbType.NVarChar).Valeu =//textBox;
                string insertString = @"insert into(FirstName,LastName) values ('Roger','Zelezny')";
                SqlCommand cmd = new SqlCommand(insertString, con);
                cmd.ExecuteNonQuery();
                //cmd.Parameters.Add(param1);
            }
            finally 
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public void ReadData()
        {
            SqlDataReader rdr = null;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select*from Authors", con);
                rdr = cmd.ExecuteReader();
                int Line = 0;
                do
                {
                    while (rdr.Read())
                    {
                        if(Line==0)
                        {
                            for(int i=0;i<rdr.FieldCount;i++)
                            {
                                Console.Write(rdr.GetName(i).ToString()+"\t");
                            }
                            Console.WriteLine();
                        }
                        Line++;
                        Console.WriteLine(rdr[0] + "\t" + rdr[1] + "\t\t" + rdr[2]);
                    }
                    Console.WriteLine("Обработано записей: " + Line.ToString());
                }
                while (rdr.NextResult());
            }
            finally
            {
                if (rdr != null)
                { con.Close(); }
                if (con != null) { con.Close(); }
            }
            con.Open();
        }
        static void Main(string[] args)
        {
            Program pr = new Program();
            //pr.InsertQuert();
            pr.ReadData();
        }
    }
}
