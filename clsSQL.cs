using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;


namespace CuttingMake
{
    public class clsSQL
    {

        public static string strConn
        {
            set
            {
                //Provider = Microsoft.ACE.OLEDB.12.0; Data Source =
                //strConn = clsLoad.ReadIniStr("DataBase", "SQLServer", "", Application.StartupPath + "\\land.ini");
            }
            get
            {
                return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "" + clsLoad.ReadIniStr("DataBase", "SQLServerA", "", Application.StartupPath + "\\land.ini");
            }
        }

        //检查数据连接是否正常
        public static string  strConnect()
        {
            try
            {
                //OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source =D:\\fisVIN.mdb");
                //strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =C:\\JOHNPrintDB.accdb";
                //SqlConnection thisConnection = new SqlConnection(strConn);
                //thisConnection.Open();
                //thisConnection.Close();

                OleDbConnection dbconn = new OleDbConnection(strConn);               
                dbconn.Open();
                dbconn.Close();
                return "";
            }
            catch 
            {
                clsLoad.strErr = "数据连接异常，请检查配置文件数据库连接字符：" + strConn;  
                //clsLoad.WriteLog("bolConnect函数"+ex.ToString());
                return clsLoad.strErr ;
            } 
        }

        //执行更新，删除，插入指令，返回 影响  的记录数 ExecuteNonQuery();　　它的返回值类型为int型。多用于执行增加，删除，修改数据。返回受影响的行数。
        public static int intExecuteQuery(string strSql)
        {
            int insertRows = 0;
            try
            {
                //SqlConnection thisConnection = new SqlConnection(strConn);
                //thisConnection.Open();
                //SqlCommand thisCommand = thisConnection.CreateCommand();
                //thisCommand.CommandText = strSql;
                //insertRows = thisCommand.ExecuteNonQuery();
                //thisConnection.Close();
                

                OleDbConnection dbconn = new OleDbConnection(strConn);                
                OleDbCommand thisCommand = new OleDbCommand(strSql);
                thisCommand.Connection = dbconn; 
                dbconn.Open();
                insertRows = thisCommand.ExecuteNonQuery();
                dbconn.Close();
                return insertRows;

            }
            catch (Exception ex)
            {                
                clsLoad.WriteLog("intExecuteQuery函数" + ex.ToString());
                return insertRows;
            } 
        }

        //获取数据记录数　.ExecuteScaler();它的返回值类型多位int类型。它返回的多为执行select查询。得到的返回结果为一个值的情况，比如使用count函数求表中记录个数或者使用sum函数求和等
        public static string strGetfield(string strSql)
        {
            string str = "";
            try
            {
                //SqlConnection thisConnection = new SqlConnection(strConn);
                //thisConnection.Open();
                //SqlCommand thisCommand = thisConnection.CreateCommand();
                //thisCommand.CommandText = strSql;
                //str=Convert.ToString(thisCommand.ExecuteScalar()); 
                //thisConnection.Close();


                OleDbConnection dbconn = new OleDbConnection(strConn);
                OleDbCommand thisCommand = new OleDbCommand(strSql);
                thisCommand.Connection = dbconn; 
                dbconn.Open();
                str = Convert.ToString(thisCommand.ExecuteScalar()); 
                dbconn.Close();
                return str;
            }
            catch (Exception ex)
            {
                clsLoad.WriteLog("strGetfield函数" + ex.ToString());
                return str;
            } 
            
        }
        public static string strGetfields(string strSql) //返回数据库的单字段的子录集 
        {
            string str = "";           
            try
            {
                //using (SqlConnection conn = new SqlConnection(strConn))
                //{
                //    conn.Open();
                //    SqlCommand cmd = new SqlCommand(strSQL, conn);
                //    SqlDataReader reader = cmd.ExecuteReader();
                //    while (reader.Read())
                //    {
                //        str += (reader[0] + "@");
                //    }
                //    cmd.Dispose();
                //    conn.Close();
                //}


                OleDbConnection dbconn = new OleDbConnection(strConn);
                OleDbCommand thisCommand = new OleDbCommand(strSql);
                thisCommand.Connection = dbconn;
                dbconn.Open();
                OleDbDataReader reader = thisCommand.ExecuteReader();

                while (reader.Read())
                {
                    str += (reader[0] + "@");
                }
                dbconn.Dispose();
                dbconn.Close();
                return str;
            }
            catch (Exception ex)
            {
                clsLoad.WriteLog("strGetfields函数" + ex.ToString());               
                return "";
            } 
        } 
        //返回查询语句单行记录集
        public static OleDbDataReader GetDataReader(string strSql)
        {
            try
            {
                //SqlConnection thisConnection = new SqlConnection(strConn);
                //thisConnection.Open();
                //SqlCommand thisCommand = thisConnection.CreateCommand();
                //thisCommand.CommandText = strSql;
                // thisReader = thisCommand.ExecuteReader();


                 OleDbConnection dbconn = new OleDbConnection(strConn);
                 OleDbCommand thisCommand = new OleDbCommand(strSql);
                 thisCommand.Connection = dbconn; 
                 dbconn.Open();
                 OleDbDataReader reader = thisCommand.ExecuteReader();
                 return reader;
               
            }
            catch (Exception ex)
            {

                clsLoad.WriteLog("GetDataReader函数" + ex.ToString());
                return null;
           
            }


        }

                  /// <summary>
          /// 执行SQL语句
          /// </summary>
          /// <param name="strSql">sql语句</param>
          /// <param name="cmdType">CommandType.Text代表执行的SQL语句、CommandType.StoreProcedure代表执行的是存储过程</param>
          /// <param name="pms">可变参数数组</param>
          /// <returns></returns>
         // public static int ExecuteNonQuery(string strSql, CommandType cmdType, params SqlParameter[] pms)
         // {
         //   OleDbConnection dbconn = new OleDbConnection(strConn);
         //   OleDbCommand thisCommand = new OleDbCommand(strSql);
         //   thisCommand.Connection = dbconn;
         //   thisCommand.CommandType = cmdType;

         //   if (pms != null)
         //    {
         //       thisCommand.Parameters.AddRange(pms);
         //    }
         //   dbconn.Open();
         //   SqlTransaction trans = dbconn.BeginTransaction();
         //    try
         //    {
         //       thisCommand.Transaction = trans;
         //        int count = thisCommand.ExecuteNonQuery();
         //        if (count > 0)
         //        {
         //            trans.Commit(); //提交事务
         //            return 1;
         //        }
         //        else
         //            {
         //                trans.Rollback(); //回滚事务
         //                return -1;
         //            }
         //    }
         //    catch (Exception EX)
         //    {
         //       trans.Rollback(); //回滚事务
         //        MessageBox.Show(EX.Message.ToString());
         //        return -1;
         //    }
         //    finally
         //    {
         //       dbconn.Close();
         //       dbconn.Dispose();
         //       thisCommand.Dispose();
         //       dbconn.Close();
         //   }
         //}



        //public static DataTable GetDataTable(string sql)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        OleDbDataAdapter da = new OleDbDataAdapter();
        //        DataSet dataSet1 = new DataSet();

        //        sql = clsLoad.ReadIniStr("DataBase", "SQLServer", "", Application.StartupPath + "\\land.ini");
        //        OleDbConnection Conn = new OleDbConnection(strConn);
        //        //sql = "select * from PartType";
        //        da = new OleDbDataAdapter(sql, Conn);
        //        OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
        //        da.Fill(dataSet1);
        //        dt = dataSet1.Tables[0];
        //        return dt;


        //        OleDbDataAdapter mark_da = new OleDbDataAdapter();
        //        DataSet ds = new DataSet();
        //        OleDbCommand thisCommand = new OleDbCommand(sql);
        //        thisCommand.Connection = Conn;
        //        mark_da.SelectCommand = thisCommand;
        //        mark_da.Fill(ds, "tb_mark");
        //        dataGridView1.DataSource = mark_ds.Tables[0];
        //    }
        //    catch (Exception ex)
        //    {

        //        clsLoad.WriteLog("GetDataTable函数" + ex.ToString());
        //        return dt;
        //        //return null;
        //    }

        //}

        //返回查询语句所以记录集

        //public DataSet GetDataSet(string sql, string strTable)
        //{
        //    DataSet ds = new DataSet();
        //    SqlConnection conn = new SqlConnection(source);
        //    conn.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        //    //从指定的索引开始取PageSize条记录   
        //    //da.Fill(ds, startIndex, dgCustomPage.PageSize, "CurDataTable");   
        //    da.Fill(ds, strTable);
        //    return ds;
        //}


    
        //private void PickDatafromNormalTable()
        //{
        //    //Scan DB
        //    string strConn = "Server=(local);Database=PassatPrint;uid=sa;pwd=sa;";
        //    SqlConnection thisConnection = new SqlConnection(strConn);

        //    string strCmd = "Select InputCode,PrintCode from History_Table where Status='0'";
        //    SqlDataAdapter thisAdapter = new SqlDataAdapter(strCmd, thisConnection);

        //    DataSet thisDataSet = new DataSet();

        //    thisAdapter.Fill(thisDataSet, "Kenn");

        //    foreach (DataRow theRow in thisDataSet.Tables["Kenn"].Rows)
        //    {
        //        //存入队列
        //        string Data1 = Convert.ToString(theRow["InputCode"]);
        //        string Data2 = Convert.ToString(theRow["PrintCode"]);
        //        Data1 += ',';
        //        Data1 += Data2;
        //        lock (messageQueue)
        //        {
        //            if (messageQueue.Count == MAX_MESSAGE_COUNT)
        //            {
        //                MessageBox.Show("the Queue is full");
        //                //return 5;
        //                //write log file
        //            }
        //            else
        //            {
        //                messageQueue.Enqueue(Data1);
        //                Monitor.Pulse(messageQueue);

        //            }
        //        }

        //    }

        //    thisConnection.Close();
        //}
    


     


    }

}
