using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinApp1606042132
{
    class DataBase_Cls
    {
        static string conStr = "Data Source=DESKTOP-RKACKTU;Initial Catalog = db_WinApp; Integrated Security = True";
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand SqlCom;
        DataSet sqlDS;
        public DataSet SqlDS
        {
            get { return sqlDS; }
            set { sqlDS = value; }
        }
        public bool IsConOpen()
        {
            con = new SqlConnection(conStr);
            try
            {
                con.Open();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public void SqlCon()    //数据库连接方法
        {
            try
            {
                //con.ConnectionString = conStr;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void DataSet()
        {
            SqlDataAdapter SqlDA = new SqlDataAdapter("select * from tb_Tea", con);
            sqlDS = new System.Data.DataSet();
            SqlDA.Fill(sqlDS);
        }
        public void sqlRead(string[] str)
        {
            SqlCom = new SqlCommand("select * from tb_Tea order by Name", con);
            SqlCon();
            SqlDataReader reader = SqlCom.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        str[i] = reader["Name"] + "*" + reader["Price"] + "*" + reader["Photo"];
                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                reader.Close();
                con.Close();
            }
        }
    }
}
