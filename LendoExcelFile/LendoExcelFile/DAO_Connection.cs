using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendoExcelFile
{
    public class DAO_Connection
    {
        private string _fileName;
        private OleDbConnection _connection;

        public OleDbConnection SingletonConnection
        {
            get
            {
                return new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=" + _fileName + ";" +
                "Extended Properties=Excel 8.0;");
            }
        }

        public DAO_Connection(string FileName)
        {
            this._fileName = FileName;
        }
    }
}
