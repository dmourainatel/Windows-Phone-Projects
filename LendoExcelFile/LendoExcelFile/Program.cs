using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LendoExcelFile
{
    static class Programs
    {


        [STAThread]
        static void Main()
        {

            DAO_Connection SingleConnection = new DAO_Connection("C:\\Users\\diegou\\Desktop\\teste.xls;");
            OleDbConnection connection = SingleConnection.SingletonConnection;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        

        //private static void ReaderExcel()
        //{
        //    string uri = @"C:\Users\diegou\Desktop\Devices Maps\Done";

        //     DirectoryInfo di = new DirectoryInfo(uri);
        //     //para procurar todos os xls
        //     FileInfo[] rgFiles = di.GetFiles("*.xls");
        //        //Aqui comece um foreach para trabalhar com todos os arquivos encontrados
        //        foreach(FileInfo fi in rgFiles)
        //        {
        //            Debug.WriteLine(fi.FullName);    
        //        } 
        //}
    }
}
 