using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNC_Transfer;
using System.Globalization;
using System.Data;

namespace CNC_Transfer
{
    class Readfile
    {

        public string path = System.Configuration.ConfigurationManager.AppSettings["LocalFilePath"];
        public bool TransferDB(string ip, string filename, string Create_DT)
        {
            try
            {
                switch (filename)
                {
                    case "VER.NC":
                        InsertVER(ip, filename, Create_DT);
                        break;
                    case "WKCNTR.NC":
                        InsertWKCNTR(ip, filename, Create_DT);
                        break;
                    case "PRD3.NC":
                        InsertPRD3_CurrentStatus(ip, filename, Create_DT);
                        InsertPRD3_Status(ip, filename, Create_DT);
                        break;
                    case "ATCTL.NC":
                        InsertATCTL(ip, filename, Create_DT);
                        break;
                    case "LOG.NC":
                        InsertLOG(ip, filename, Create_DT);
                        break;
                    default:
                        LogHelper.WriteLog($"無效的檔案");
                        break;
                }
            }catch(Exception e)
            {
                LogHelper.WriteLog("[TransferDB] have err:" ,e);
                return false;
            }
            return true;
        }


        #region InsertVER
        public bool InsertVER(string ip, string filename, string Create_DT)
        {

            VER CNC_VER = new VER();
            CNC_VER.CNC_IP = ip;
            string line;

            try
            {
                using (StreamReader read = new StreamReader(path + "\\" + ip + "\\" + filename, Encoding.Default))
                {
                    while ((line = read.ReadLine()) != null)
                    {
                        if (line.Split(',')[0] == "M01")
                        {
                            CNC_VER.CNC_Model = line.Split(',')[1].Replace("'", "");
                        }
                        if (line.Split(',')[0] == "V01")
                        {
                            CNC_VER.CNC_Ver = line.Split(',')[1].Replace("'", "");
                        }
                    }
                }
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["strCon"].ToString();
                    conn.Open(); // 打开数据库连接

                    string sql = "INSERT INTO [dbo].[CNC_Ver_Log] ([Create_DT],[CNC_IP],[CNC_Model],[CNC_Ver]) VALUES (@Create_DT,@CNC_IP,@CNC_Model,@CNC_Ver)";
                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.CommandText = sql;
                    sqlCmd.Connection = conn;
                    sqlCmd.Parameters.AddWithValue("@Create_DT", Create_DT);
                    sqlCmd.Parameters.AddWithValue("@CNC_IP", CNC_VER.CNC_IP);
                    sqlCmd.Parameters.AddWithValue("@CNC_Model", CNC_VER.CNC_Model);
                    sqlCmd.Parameters.AddWithValue("@CNC_Ver", CNC_VER.CNC_Ver);
                    sqlCmd.ExecuteNonQuery();

                    conn.Close();
                    conn.Dispose();
                }
                LogHelper.WriteLog($"[InsertVER]  {ip} Success ~ ");
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog($"[InsertVER]  {ip} Fail :",ex);                
            }
            return true;
        }

        #endregion

        #region InsertWKCNTR
        public bool InsertWKCNTR(string ip, string filename, string Create_DT)
        {

            WKCNTR WKCNTR = new WKCNTR();
            WKCNTR.CNC_IP = ip;
            string line;

            try
            {
                using (StreamReader read = new StreamReader(path + "\\" + ip + "\\" + filename, Encoding.Default))
                {
                    while ((line = read.ReadLine()) != null)
                    {
                        if (line.Split(',')[0] == "A01")
                        {
                            WKCNTR.CNC_Current_ProductionAmount = line.Split(',')[2].Replace("'", "");
                            WKCNTR.CNC_Alert_ProductionAmount = line.Split(',')[3].Replace("'", "");
                            WKCNTR.CNC_End_ProductionAmount = line.Split(',')[4].Replace("'", "");
                        }
                    }
                }
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["strCon"].ToString();
                    conn.Open(); // 打开数据库连接

                    string sql = "INSERT INTO [dbo].[CNC_WKCNTR_Log] ([Create_DT],[CNC_IP],[CNC_Current_ProductionAmount],[CNC_Alert_ProductionAmount],[CNC_End_ProductionAmount]) VALUES (@Create_DT,@CNC_IP,@CNC_Current_ProductionAmount,@CNC_Alert_ProductionAmount,@CNC_End_ProductionAmount)";
                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.CommandText = sql;
                    sqlCmd.Connection = conn;
                    sqlCmd.Parameters.AddWithValue("@Create_DT", Create_DT);
                    sqlCmd.Parameters.AddWithValue("@CNC_IP", WKCNTR.CNC_IP);
                    sqlCmd.Parameters.AddWithValue("@CNC_Current_ProductionAmount", WKCNTR.CNC_Current_ProductionAmount);
                    sqlCmd.Parameters.AddWithValue("@CNC_Alert_ProductionAmount", WKCNTR.CNC_Alert_ProductionAmount);
                    sqlCmd.Parameters.AddWithValue("@CNC_End_ProductionAmount", WKCNTR.CNC_End_ProductionAmount);
                    sqlCmd.ExecuteNonQuery();

                    conn.Close();
                    conn.Dispose();
                }
                LogHelper.WriteLog($"[InsertWKCNTR]  {ip} Success ~ ");
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog($"[InsertWKCNTR]  {ip} Fail :", ex);
            }
            return true;

        }

        #endregion

        #region InsertPRD3
        public bool InsertPRD3_CurrentStatus(string ip, string filename, string Create_DT)
        {

            PRD3 PRD3 = new PRD3();
            PRD3.CNC_IP = ip;
            string line;

            try
            {
                using (StreamReader read = new StreamReader(path + "\\" + ip + "\\" + filename, Encoding.Default))
                {
                    while ((line = read.ReadLine()) != null)
                    {
                        if (line.Split(',')[0] == "C01")
                        {
                            PRD3.CNC_Current_StatusDT = DateTime.ParseExact(line.Split(',')[1], "yyyyMMddHHmmss", new System.Globalization.CultureInfo("zh-CN", true), System.Globalization.DateTimeStyles.AllowInnerWhite).ToString("yyyy-MM-dd HH:mm:ss");
                            PRD3.CNC_Current_Status = line.Split(',')[2];
                            PRD3.CNC_ProgramNo = line.Split(',')[4];
                        }
                    }
                }
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["strCon"].ToString();
                    conn.Open(); // 打开数据库连接

                    string sql = "INSERT INTO [dbo].[CNC_PRD3_Log] ([Create_DT],[CNC_IP],[CNC_Current_Status],[CNC_Current_StatusDT],[CNC_ProgramNo]) VALUES (@Create_DT,@CNC_IP,@CNC_Current_Status,@CNC_Current_StatusDT,@CNC_ProgramNo)";
                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.CommandText = sql;
                    sqlCmd.Connection = conn;
                    sqlCmd.Parameters.AddWithValue("@Create_DT", Create_DT);
                    sqlCmd.Parameters.AddWithValue("@CNC_IP", PRD3.CNC_IP);
                    sqlCmd.Parameters.AddWithValue("@CNC_Current_Status", PRD3.CNC_Current_Status);
                    sqlCmd.Parameters.AddWithValue("@CNC_Current_StatusDT", PRD3.CNC_Current_StatusDT);
                    sqlCmd.Parameters.AddWithValue("@CNC_ProgramNo", PRD3.CNC_ProgramNo);
                    sqlCmd.ExecuteNonQuery();

                    conn.Close();
                    conn.Dispose();
                }
                LogHelper.WriteLog($"[InsertPRD3_CurrentStatus]  {ip} Success ~ ");
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog($"[InsertPRD3_CurrentStatus]  {ip} Fail :", ex);
            }
            return true;

        }

        public bool InsertPRD3_Status(string ip, string filename, string Create_DT)
        {

            PRD3 PRD3 = new PRD3();
            PRD3.CNC_IP = ip;
            string line;
            //int i = 0;
            try
            {
               
                DataTable dt = new DataTable();
                //dt.Columns.Add("Sno", typeof(int));
                dt.Columns.Add("Create_DT", System.Type.GetType("System.String"));
                dt.Columns.Add("CNC_IP", System.Type.GetType("System.String"));
                dt.Columns.Add("CNC_Current_Status", System.Type.GetType("System.String"));
                dt.Columns.Add("CNC_Current_StatusDT", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("CNC_Status", System.Type.GetType("System.String"));
                dt.Columns.Add("CNC_StatusDT", System.Type.GetType("System.DateTime"));
                dt.Columns.Add("CNC_ProgramNo", System.Type.GetType("System.String"));

                using (StreamReader read = new StreamReader(path + "\\" + ip + "\\" + filename, Encoding.Default))
                {
                    while ((line = read.ReadLine()) != null)
                    {
                        if (line.Split(',')[0].Contains('B'))
                        {
                            PRD3.CNC_StatusDT = DateTime.ParseExact(line.Split(',')[1], "yyyyMMddHHmmss", new System.Globalization.CultureInfo("zh-CN", true), System.Globalization.DateTimeStyles.AllowInnerWhite).ToString("yyyy-MM-dd HH:mm:ss");
                            PRD3.CNC_Status = line.Split(',')[2];
                            PRD3.CNC_ProgramNo = line.Split(',')[4];

                            /*
                            using (SqlConnection conn = new SqlConnection())
                            {
                                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["strCon"].ToString();
                                conn.Open(); // 打开数据库连接

                                string sql = "INSERT INTO [dbo].[CNC_PRD3_Log] ([Create_DT],[CNC_IP],[CNC_Status],[CNC_StatusDT],[CNC_ProgramNo]) VALUES (@Create_DT,@CNC_IP,@CNC_Status,@CNC_StatusDT,@CNC_ProgramNo)";
                                SqlCommand sqlCmd = new SqlCommand();
                                sqlCmd.CommandText = sql;
                                sqlCmd.Connection = conn;
                                sqlCmd.Parameters.AddWithValue("@Create_DT", Create_DT);
                                sqlCmd.Parameters.AddWithValue("@CNC_IP", PRD3.CNC_IP);
                                sqlCmd.Parameters.AddWithValue("@CNC_Status", PRD3.CNC_Status);
                                sqlCmd.Parameters.AddWithValue("@CNC_StatusDT", PRD3.CNC_StatusDT);
                                sqlCmd.Parameters.AddWithValue("@CNC_ProgramNo", PRD3.CNC_ProgramNo);
                                sqlCmd.ExecuteNonQuery();

                                conn.Close();
                                conn.Dispose();
                            }
                            */


                            DataRow dr = dt.NewRow();
                            dr["Create_DT"] = Create_DT;
                            dr["CNC_IP"] = ip;
                            //dr["CNC_Current_Status"] = string.IsNullOrEmpty(PRD3.CNC_Current_Status) ? "": PRD3.CNC_Current_Status;
                            //dr["CNC_Current_StatusDT"] = string.IsNullOrEmpty(PRD3.CNC_Current_StatusDT;
                            dr["CNC_Status"] = PRD3.CNC_Status;
                            dr["CNC_StatusDT"] = PRD3.CNC_StatusDT;
                            dr["CNC_ProgramNo"] = PRD3.CNC_ProgramNo;
                            dt.Rows.Add(dr);

                        }
                    }
                }


                SqlBulkCopyByDatatable(System.Configuration.ConfigurationManager.ConnectionStrings["strCon"].ToString(), "CNC_PRD3_Log", dt);

                LogHelper.WriteLog($"[InsertPRD3_Status]  {ip} Success ~ ");
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog($"[InsertPRD3_Status]  {ip} Fail :", ex);
            }
            return true;

        }

        #endregion

        #region InsertATCTL
        public bool InsertATCTL(string ip, string filename, string Create_DT)
        {
     
            ATCTL ATCTL = new ATCTL();
           ATCTL.CNC_IP = ip;
            string line;

            try
            {
                using (StreamReader read = new StreamReader(path + "\\" + ip + "\\" + filename, Encoding.Default))
                {
                    while ((line = read.ReadLine()) != null)
                    {
                        if (line.Split(',')[0].Contains('M') && int.Parse(line.Split(',')[1]) !=0 )
                        {
                            ATCTL.ATCTL_ID = line.Split(',')[1].Trim();
                            switch (line.Split(',')[4])
                            {
                                case "1":
                                    ATCTL.ATCTL_TYPE = "標準";
                                    break;
                                case "2":
                                    ATCTL.ATCTL_TYPE = "大直徑";
                                    break;
                                case "3":
                                    ATCTL.ATCTL_TYPE = "中等直徑";
                                    break;
                                default:
                                    ATCTL.ATCTL_TYPE = "無設定";
                                    break;
                            }

                            switch (line.Split(',')[5])
                            {
                                case "1":
                                    ATCTL.ATCTL_COLOR = "藍色";
                                    break;
                                case "2":
                                    ATCTL.ATCTL_COLOR = "紅色";
                                    break;
                                case "3":
                                    ATCTL.ATCTL_COLOR = "紫色";
                                    break;
                                case "4":
                                    ATCTL.ATCTL_COLOR = "綠色";
                                    break;
                                case "5":
                                    ATCTL.ATCTL_COLOR = "淡藍色";
                                    break;
                                case "6":
                                    ATCTL.ATCTL_COLOR = "黃色";
                                    break;
                                case "7":
                                    ATCTL.ATCTL_COLOR = "白色";
                                    break;
                                default:
                                    ATCTL.ATCTL_COLOR = "無顏色";
                                    break;
                            }
                        }
                        if (!string.IsNullOrEmpty(ATCTL.ATCTL_ID))
                        {
                            using (SqlConnection conn = new SqlConnection())
                            {
                                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["strCon"].ToString();
                                conn.Open(); // 打开数据库连接
                                
                                string sql = "INSERT INTO [dbo].[CNC_ATCTL_Log] ([Create_DT],[CNC_IP],[ATCTL_ID],[ATCTL_TYPE],[ATCTL_COLOR]) VALUES (@Create_DT,@CNC_IP,@ATCTL_ID,@ATCTL_TYPE,@ATCTL_COLOR)";
                                SqlCommand sqlCmd = new SqlCommand();
                                sqlCmd.CommandText = sql;
                                sqlCmd.Connection = conn;
                                
                                sqlCmd.Parameters.AddWithValue("@Create_DT", Create_DT);
                                sqlCmd.Parameters.AddWithValue("@CNC_IP", ATCTL.CNC_IP);
                                sqlCmd.Parameters.AddWithValue("@ATCTL_ID", ATCTL.ATCTL_ID);
                                sqlCmd.Parameters.AddWithValue("@ATCTL_TYPE", ATCTL.ATCTL_TYPE);
                                sqlCmd.Parameters.AddWithValue("@ATCTL_COLOR", ATCTL.ATCTL_COLOR);
                                sqlCmd.ExecuteNonQuery();

                                conn.Close();
                                conn.Dispose();
                            }
                            ATCTL.ATCTL_ID = "";
                        }
                }
 
                }
                LogHelper.WriteLog($"[InsertATCTL]  {ip} Success ~ ");
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog($"[InsertATCTL]  {ip} Fail :", ex);
            }
            return true;
        }

        #endregion

        #region InsertLOG
        public bool InsertLOG(string ip, string filename, string Create_DT)
        {

            LOG ALARM = new LOG();
            ALARM.CNC_IP = ip;
            string line;


            DataTable dt = new DataTable();
         
            dt.Columns.Add("Create_DT", System.Type.GetType("System.String"));
            dt.Columns.Add("CNC_IP", System.Type.GetType("System.String"));
            dt.Columns.Add("CNC_ALARM_CODE", System.Type.GetType("System.String"));
            dt.Columns.Add("CNC_ALARM_MSG", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("CNC_ALARM_DT", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("CNC_OperationNo", System.Type.GetType("System.String"));
            dt.Columns.Add("CNC__Coordinate_X", System.Type.GetType("System.String"));//C段
            dt.Columns.Add("CNC_ATCTL_ID", System.Type.GetType("System.String"));//D段
            dt.Columns.Add("CNC_RunProgramBank", System.Type.GetType("System.String"));//J段
       
            try
            {
                using (StreamReader read = new StreamReader(path + "\\" + ip + "\\" + filename, Encoding.Default))
                {
                    while ((line = read.ReadLine()) != null)
                    {
                        //B段
                        if (line.Split(',')[0].Contains('B'))
                        {

                            ALARM.CNC_LineNo = line.Split(',')[0].Substring(1);   
                            ALARM.CNC_ALARM_DT = DateTime.ParseExact(line.Split(',')[1], "yyyyMMddHHmmss", new System.Globalization.CultureInfo("zh-CN", true), System.Globalization.DateTimeStyles.AllowInnerWhite).ToString("yyyy-MM-dd HH:mm:ss");
                            switch (line.Split(',')[2].Substring(0,2))
                            {
                                case "01":
                                    ALARM.CNC_ALARM_CODE = "EX" + line.Split(',')[2].Substring(2, 4);
                                    break;
                                case "02":
                                    ALARM.CNC_ALARM_CODE = "EC" + line.Split(',')[2].Substring(2, 4);
                                    break;
                                case "03":
                                    ALARM.CNC_ALARM_CODE = "SV" + line.Split(',')[2].Substring(2, 4);
                                    break;
                                case "04":
                                    ALARM.CNC_ALARM_CODE = "NC" + line.Split(',')[2].Substring(2, 4);
                                    break;
                                case "05":
                                    ALARM.CNC_ALARM_CODE = "IO" + line.Split(',')[2].Substring(2, 4);
                                    break;
                                case "06":
                                    ALARM.CNC_ALARM_CODE = "SP" + line.Split(',')[2].Substring(2, 4);
                                    break;
                                case "07":
                                    ALARM.CNC_ALARM_CODE = "SM" + line.Split(',')[2].Substring(2, 4);
                                    break;
                                case "08":
                                    ALARM.CNC_ALARM_CODE = "SL" + line.Split(',')[2].Substring(2, 4);
                                    break;
                                case "09":
                                    ALARM.CNC_ALARM_CODE = "CM" + line.Split(',')[2].Substring(2, 4);
                                    break;
                                case "10":
                                    ALARM.CNC_ALARM_CODE = "ES" + line.Split(',')[2].Substring(2, 4);
                                    break;
                                case "11":
                                    ALARM.CNC_ALARM_CODE = "FC" + line.Split(',')[2].Substring(2, 4);
                                    break;
                                default:
                                    ALARM.CNC_ALARM_CODE = ""+ line.Split(',')[2].Substring(2, 4);
                                    ALARM.CNC_OperationNo = "("+ line.Split(',')[3].Substring(4, 4)+")";
                                    break;
                            }

                            DataRow dr = dt.NewRow();
                            dr["Create_DT"] = Create_DT;
                            dr["CNC_IP"] = ip;
                            dr["CNC_ALARM_CODE"] = ALARM.CNC_ALARM_CODE;
                            dr["CNC_ALARM_DT"] = ALARM.CNC_ALARM_DT;
                            dr["CNC_OperationNo"] = ALARM.CNC_OperationNo;
                            dt.Rows.Add(dr);

                        }
                        /* 
                        //C段
                        if(line.Split(',')[0].Contains('C') && line.Split(',')[0].Substring(1).EndsWith(ALARM.CNC_LineNo))
                        {
                            ALARM.CNC__Coordinate_X = line.Split(',')[1];
                        }
                        //D段
                        if (line.Split(',')[0].Contains('D') && line.Split(',')[0].Substring(1).EndsWith(ALARM.CNC_LineNo))
                        {
                            ALARM.CNC_ATCTL_ID = line.Split(',')[1];
                        }
                        //J段
                        if (line.Split(',')[0].Contains('J') && line.Split(',')[0].Substring(1).EndsWith(ALARM.CNC_LineNo))
                        {
                            ALARM.CNC_RunProgramBank = line.Split(',')[1].Replace("'","").Trim();

                            DataRow dr = dt.NewRow();
                            dr["Create_DT"] = Create_DT;
                            dr["CNC_IP"] = ip;
                            dr["CNC_ALARM_CODE"] = ALARM.CNC_ALARM_CODE;
                            dr["CNC_ALARM_DT"] = ALARM.CNC_ALARM_DT;
                            dr["CNC__Coordinate_X"] = ALARM.CNC__Coordinate_X;
                            dr["CNC_ATCTL_ID"] = ALARM.CNC_ATCTL_ID;
                            dr["CNC_RunProgramBank"] = ALARM.CNC_RunProgramBank;
                            dt.Rows.Add(dr);
                        }
                        */
                    }
                }
                SqlBulkCopyByDatatable(System.Configuration.ConfigurationManager.ConnectionStrings["strCon"].ToString(), "CNC_ALARM_Log", dt);
                LogHelper.WriteLog($"[InsertLOG]  {ip} Success ~ ");
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog($"[InsertLOG]  {ip} Fail :", ex);
            }
            return true;
        }
        #endregion 

        #region SqlBulkCopyByDatatable
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString">目标连接字符</param>
        /// <param name="TableName">目标表</param>
        /// <param name="dt">源数据</param>
        private void SqlBulkCopyByDatatable(string connectionString, string TableName, DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.KeepIdentity))
                {
                    try
                    {
                        sqlbulkcopy.DestinationTableName = TableName;
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            sqlbulkcopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
                        }
                        sqlbulkcopy.WriteToServer(dt);
                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        #endregion

        
    }
}
