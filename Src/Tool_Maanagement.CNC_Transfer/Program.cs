using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CNC_Transfer;
using System.Threading;
using log4net;
using log4net.Config;
using System.Data.SqlClient;

namespace CNC_Transfer
{
    class Program
    {

        private static string IPs = ConfigurationManager.AppSettings["CNC_IPs"];//FTP服务器的用户名
        private static string FTPUSERNAME = ConfigurationManager.AppSettings["FTPUSERNAME"];//FTP服务器的用户名
        private static string FTPPASSWORD = ConfigurationManager.AppSettings["FTPPASSWORD"];//FTP服务器的密码
        private static string FTPPATH = ConfigurationManager.AppSettings["LocalFilePath"];
        private static string fileName = ConfigurationManager.AppSettings["FileName"];
        private static string Create_DT = DateTime.Now.ToString("yyyyMMddHHmmss");
        static void Main(string[] args)
        {            
            InitLog4Net();

            LogHelper.WriteLog("CNC Transfer  - Start");
            
            List<Thread> list = new List<Thread>();
            for (int i = 0; i < IPs.Split(';').Length; i++)
            {
                //ParameterizedThreadStart method = o => TThread(o.ToString());
                //Thread thread = new Thread(method);
                //thread.Start(IPs.Split(';')[i]);
                //list.Add(thread);
                TThread(IPs.Split(';')[i]);
                
            }
            

            //foreach (var t in list)
            //{
            //    t.Join();
            //}

            
             //TThread("10.120.90.39");
             

            /*
            CalcTime(Create_DT, "2", "10.120.90.48", "2019/2/23", "2019/2/24");
            CalcTime(Create_DT, "3", "10.120.90.48", "2019/2/23", "2019/2/24");
            CalcTime(Create_DT, "4", "10.120.90.48", "2019/2/23", "2019/2/24");
            CalcTime(Create_DT, "5", "10.120.90.48", "2019/2/23", "2019/2/24");
            */

            LogHelper.WriteLog("CNC Transfer  - End");
        }

        private static void TThread(string IP)
        {
            //Console.WriteLine($"執行緒:{ Thread.CurrentThread.ManagedThreadId}");
            string FTPCONSTR = "ftp://" + IP + "/";//FTP的服务器地址，格式为ftp://192.168.1.234:8021/。ip地址和端口换成自己的，这些建议写在配置文件中，方便修改
           
            if (Directory.Exists(FTPPATH + IP) == false)
            {
                Directory.CreateDirectory(FTPPATH + IP);
            }
            for (var i = 0; i < fileName.Split(';').Length; i++)
            {
                bool flag = false;
                for (int x = 0; x < 3; x++)
                {
                    if (flag != true)
                    {
                        flag = Download(FTPCONSTR, FTPPATH + IP + "\\", fileName.Split(';')[i]);
                       // Thread.Sleep(600);
                    }
                }
                if (flag == true)
                {
                    LogHelper.WriteLog($"FTP {IP} {fileName.Split(';')[i]} Download Success ~ ");
                    Readfile file = new Readfile();
                    flag = file.TransferDB(IP, fileName.Split(';')[i], Create_DT);
                    if(flag== true && fileName.Split(';')[i]=="PRD3.NC")
                       InsertStatusHistory(IP, Create_DT);
                }
                else
                    LogHelper.WriteLog($"[E] FTP {IP} {fileName.Split(';')[i]} Download Fail ~ ");
            }
            
        }

        #region 从ftp服务器下载文件

        /// <summary>;
        /// 从ftp服务器下载文件的功能
        /// </summary>
        /// <param name="ftpfilepath">ftp下载的地址</param>
        /// <param name="filePath">存放到本地的路径</param>
        /// <param name="fileName">保存的文件名称</param>
        /// <returns></returns>
        public static bool Download(string ftpfilepath, string filePath, string fileName)
        {

            try
            {
                //filePath = filePath.Replace("D:\\CNCData\\", "");
                String onlyFileName = Path.GetFileName(fileName);
                string newFileName = filePath + onlyFileName;
                if (File.Exists(newFileName))
                {
                    //errorinfo = string.Format("本地文件{0}已存在,无法下载", newFileName);                   
                    File.Delete(newFileName);
                    //return false;
                }
                ftpfilepath = ftpfilepath.Replace("\\", "/");
                string url = ftpfilepath + fileName;
                FtpWebRequest reqFtp = (FtpWebRequest)FtpWebRequest.Create(new Uri(url));
                reqFtp.UseBinary = true;
                reqFtp.Credentials = new NetworkCredential(FTPUSERNAME, FTPPASSWORD);
                FtpWebResponse response = (FtpWebResponse)reqFtp.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                FileStream outputStream = new FileStream(newFileName, FileMode.Create);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
                ftpStream.Close();
                outputStream.Close();
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                
                LogHelper.WriteLog($"[Download][{ftpfilepath}] Fail:" ,ex);
                return false;
            }
        }

        #endregion

        #region Log4Net
        private static void InitLog4Net()
        {
            var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
            XmlConfigurator.ConfigureAndWatch(logCfg);
        }

        #endregion

        public static string CalcTime(string Create_DT, string type, string ip, string startdate, string enddate)
        {
            try
            {
                int tTime = 0;
                int S_sno;
                int E_sno;
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["strCon"].ToString();
                    conn.Open(); // 打开数据库连接

                    string sql = "   SELECT sno as S_sno ,sno-1 as E_sno FROM[ToolManagement].[dbo].[CNC_PRD3_Log] where cnc_ip = @ip  and CNC_Status = @type AND CNC_StatusDT > @startdate AND CNC_StatusDT < @enddate  AND Create_DT=@Create_DT order by CNC_StatusDT";
                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.CommandText = sql;
                    sqlCmd.Connection = conn;
                    sqlCmd.Parameters.AddWithValue("@ip", ip);
                    sqlCmd.Parameters.AddWithValue("@type", type);
                    sqlCmd.Parameters.AddWithValue("@startdate", startdate);
                    sqlCmd.Parameters.AddWithValue("@enddate", enddate);
                    sqlCmd.Parameters.AddWithValue("@Create_DT", Create_DT);
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            S_sno = int.Parse(reader["S_sno"].ToString());
                            E_sno = int.Parse(reader["E_sno"].ToString());
                            using (SqlConnection conn2 = new SqlConnection())
                            {
                                conn2.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["strCon"].ToString();
                                conn2.Open(); // 打开数据库连接
                                string sqlstr = "SELECT datediff(second,(SELECT  CNC_StatusDT FROM [ToolManagement].[dbo].[CNC_PRD3_Log] WHERE SNO=@S_sno),(SELECT  CNC_StatusDT FROM [ToolManagement].[dbo].[CNC_PRD3_Log] WHERE SNO=@E_sno)) as time";
                                SqlCommand sqlCmd2 = new SqlCommand();
                                sqlCmd2.CommandText = sqlstr;
                                sqlCmd2.Connection = conn2;
                                sqlCmd2.Parameters.AddWithValue("@S_sno", S_sno);
                                sqlCmd2.Parameters.AddWithValue("@E_sno", E_sno);

                                if(!string.IsNullOrEmpty(sqlCmd2.ExecuteScalar().ToString()))
                                    tTime = tTime + int.Parse(sqlCmd2.ExecuteScalar().ToString());

                                sqlCmd2.Dispose();
                                conn2.Close();
                                conn2.Dispose();
                            }
                        }
                        reader.Close();
                        sqlCmd.Dispose();
                        conn.Close();
                        conn.Dispose();
                    }
                }

                int HH = tTime / 60 / 60;
                int mm = (tTime / 60) - (HH * 60);
                LogHelper.WriteLog($"[CalcTime][{type}][{startdate} ~ [{enddate}]] TIME:{ tTime/60}");
                return  ("00"+HH.ToString()).Substring(("00" + HH.ToString()).Length-2,2) + ":" + ("00" + mm.ToString()).Substring(("00" + mm.ToString()).Length - 2, 2);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog($"[CalcTime][{type}][{startdate} ~ [{enddate}]] Fail !", ex);
                return "00:00";
            }
        }

        public static void InsertStatusHistory(string IP,string Create_DT)
        {
            StatusHistory sh = new StatusHistory();
            DateTime Sdate = new DateTime();
            DateTime Edate = new DateTime();
            for (int x = 7; x >= 0; x--)
            {
                Sdate = DateTime.Now.AddDays(0 - x);
                Edate = DateTime.Now.AddDays((0 - x) + 1);
                sh.CNC_IP = IP;
                sh.Create_DT = Create_DT;
                sh.CNC_CalcDT = Sdate.ToString("yyyy/MM/dd");
                sh.CNC_CloseTime = CalcTime(Create_DT, "1", IP, Sdate.ToString("yyyy/MM/dd"), Edate.ToString("yyyy/MM/dd"));
                sh.CNC_StayTime = CalcTime(Create_DT, "2", IP, Sdate.ToString("yyyy/MM/dd"), Edate.ToString("yyyy/MM/dd"));
                sh.CNC_RunTime = CalcTime(Create_DT, "3", IP, Sdate.ToString("yyyy/MM/dd"), Edate.ToString("yyyy/MM/dd"));
                sh.CNC_StopTime = CalcTime(Create_DT, "4", IP, Sdate.ToString("yyyy/MM/dd"), Edate.ToString("yyyy/MM/dd"));
                sh.CNC_ErrTime = CalcTime(Create_DT, "5", IP, Sdate.ToString("yyyy/MM/dd"), Edate.ToString("yyyy/MM/dd"));

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["strCon"].ToString();
                    conn.Open(); // 打开数据库连接

                    string sql = "INSERT INTO [dbo].[CNC_StatusHistory] ([Create_DT],[CNC_IP],[CNC_CalcDT],[CNC_CloseTime],[CNC_StayTime],[CNC_RunTime],[CNC_StopTime],[CNC_ErrTime]) VALUES (@Create_DT,@CNC_IP,@CNC_CalcDT,@CNC_CloseTime,@CNC_StayTime,@CNC_RunTime,@CNC_StopTime,@CNC_ErrTime)";
                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.CommandText = sql;
                    sqlCmd.Connection = conn;

                    sqlCmd.Parameters.AddWithValue("@Create_DT", Create_DT);
                    sqlCmd.Parameters.AddWithValue("@CNC_IP", sh.CNC_IP);
                    sqlCmd.Parameters.AddWithValue("@CNC_CalcDT", sh.CNC_CalcDT);
                    sqlCmd.Parameters.AddWithValue("@CNC_CloseTime", sh.CNC_CloseTime);
                    sqlCmd.Parameters.AddWithValue("@CNC_StayTime", sh.CNC_StayTime);
                    sqlCmd.Parameters.AddWithValue("@CNC_RunTime", sh.CNC_RunTime);
                    sqlCmd.Parameters.AddWithValue("@CNC_StopTime", sh.CNC_StopTime);
                    sqlCmd.Parameters.AddWithValue("@CNC_ErrTime", sh.CNC_ErrTime);
                    sqlCmd.ExecuteNonQuery();

                    conn.Close();
                    conn.Dispose();
                }
            }
        }

    }
}
