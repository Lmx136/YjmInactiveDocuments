using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace YjmInactiveDocuments
{
    public partial class SysFunc
    {
        ////声明读写INI文件的API函数
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);


        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        //读取INI文件所有的节名
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        public static extern int GetPrivateProfileSectionNames(string szBuffer, int size, string filePath);

        [DllImport("FCXFunc.dll")]
        public static extern bool ShowQueryForm(string Conn, string sql, int ADataBaseType, string Ini, ref string AResultSelect);

        [DllImport("FCXFunc.dll")]
        public static extern string GetOraConnDBStr();

        [DllImport("FCXFunc.dll")]
        public static extern bool ShowOraConnDBForm(int LanageType);

        [DllImport("FCXFunc.dll")]
        public static extern bool DataToExcel(string AConnString, string ASelectString);

        [DllImport("FCXFunc.dll")]
        public static extern string UnEncryptString(string Source, string Key);

        [DllImport("FCXFunc.dll")]
        public static extern bool ShowUserManageForm(string Conn, int SysIndex, int SysLang);

        [DllImport("FCXFunc.dll")]
        public static extern bool InitUserPopedom(string Conn, string MenuName, string Userid, int SysIndex);


        [DllImport("FCXFunc.dll")]
        public static extern bool ShowSysMenuForm(string Conn, int SysIndex, int SysLang);


        [DllImport("FCXFunc.dll")]
        public static extern bool ShowSysParaForm(string Conn, int SysIndex, int SysLang);



        [DllImport("ADOFCXGetCodeDll.dll")]
        ///<summary>  
        ///取码对话框


        ///</summary>  
        ///<param name="AHandle">应用程序句柄</param>  
        ///<param name="AConnString">连接字符串</param>  
        ///<param name="AOpenStr">select语句</param>  
        ///<param name="AInField">取码字段,多个字段用逗号分隔</param>  
        ///<param name="AInValue">取码值</param>  
        ///<param name="AInFieldLabel">标签</param>  
        ///<param name="AGetCodePos">取码方式.0-全匹配,1--左匹配,2--右匹配</param>  
        ///<param name="AShowX">取码框X坐标</param>  
        ///<param name="AShowY">取码框Y坐标</param>  
        ///<param name="AIfNullGetCode">是否可无值取码,如直接回车</param>  
        ///<param name="AIfShowDialogOneRecord">取出一条记录时是否显示取码框</param>  
        ///<param name="AIfShowDialogZeroRecord">取出零条记录时是否显示取码框</param>  
        ///<param name="AifAbetChineseChar">是否支持中文取码</param>  
        ///<param name="AOutValue">输出字符串</param>  
        ///<returns>返回是否执行了取码操作</returns>   
        public static extern bool ShowGetCodeForm(IntPtr AHandle, string AConnString, string AOpenStr,
                          string AInField, string AInValue, string AInFieldLabel, int AGetCodePos,
                          int AShowX, int AShowY, bool AIfNullGetCode,
                          bool AIfShowDialogOneRecord, bool AIfShowDialogZeroRecord,
                          bool AifAbetChineseChar, ref string AOutValue);


        public static string cfServerName;//要传入水晶报表




        public static string cfUserID;//要传入水晶报表




        public static string cfPassword;//要传入水晶报表



        public static string hrgdConnectString;
        public static string hrgdServerName;//要传入水晶报表




        public static string hrgdUserID;//要传入水晶报表




        public static string hrgdPassword;//要传入水晶报表




        public static string wmsConnectString = "Data Source =.; Initial Catalog =Test; User Id = sa; Password=123";
        public static string wmsServerName;//要传入水晶报表




        public static string wmsUserID;//要传入水晶报表




        public static string wmsPassword;//要传入水晶报表




        public static string LogName;//当前登录用户名称,由调用者使用


        public static string LogID;//当前登录用户名称,由调用者使用


        public static string PassWord;//当前登录用户名称,由调用者使用


        public static string Org; //登录的组织机构



        public static Boolean IfWmsOpen = false;

        public const int SysIndext = 1;

        public static string gConnHcwlStr = "Provider=MSDAORA.1:;Data Source=orcl;User ID=HRGD;PassWord=HRGD";
        public static string gConnHRGDStr = "Provider=MSDAORA.1:;Data Source=HRGDZS;User ID=ORAWMS;PassWord=ORAWMS";



        public static bool RedIni()
        {
            string AppFile = Application.ExecutablePath;//应用程序路径(包括名称)
            AppFile = AppFile.ToLower();
            AppFile = AppFile.Replace(".exe", "OraConnDB.ini");
            StringBuilder temp = new StringBuilder(255);
            SysFunc.GetPrivateProfileString("连接数据库", "数据库名称", "", temp, 255, AppFile);
            cfServerName = temp.ToString();
            cfServerName = SysFunc.UnEncryptString(cfServerName, "107DFC967CDCFAAF");

            SysFunc.GetPrivateProfileString("连接数据库", "用户名称", "", temp, 255, AppFile);
            cfUserID = temp.ToString();
            cfUserID = SysFunc.UnEncryptString(cfUserID, "107DFC967CDCFAAF");

            SysFunc.GetPrivateProfileString("连接数据库", "密码", "", temp, 255, AppFile);
            cfPassword = temp.ToString();
            cfPassword = SysFunc.UnEncryptString(cfPassword, "107DFC967CDCFAAF");
            return true;

        }


        public static bool WMSDBConn()
        {

            bool result;
            result = false;

            if (IfWmsOpen) return false;

            string newconnstr = "";
            newconnstr = GetOraConnDBStr();
            OleDbConnection odbconn = new OleDbConnection(newconnstr);
            try
            {
                odbconn.Open();
                result = true;
                RedIni();
                SysFunc.wmsConnectString = newconnstr;
            }
            catch
            {
                result = false;
            }
            if (result == false)
            {
                ShowOraConnDBForm(1);
                Application.Exit();
                return false;
            }

            return true;

        }

        public static bool HRGDBConn()
        {
            bool result;
            result = false;

            if (IfWmsOpen) return false;

            string newconnstr = "";
            newconnstr = GetOraConnDBStr();
            OleDbConnection odbconn = new OleDbConnection(newconnstr);
            try
            {
                odbconn.Open();
                result = true;
                RedIni();
                SysFunc.hrgdConnectString = newconnstr;
            }
            catch
            {
                result = false;
            }
            if (result == false)
            {
                ShowOraConnDBForm(1);
                Application.Exit();
                return false;
            }

            return true;

        }

    }
}
