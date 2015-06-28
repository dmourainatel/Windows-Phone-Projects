using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendoExcelFile
{
    public class  Constants
    {

            private string _id;
            private string _name;

            private string _insert;
            private string _delete;
            private string _update;

            public static string SELECT = "Select * from [Plan1$]";

            public string INSERT
            {
                get
                {
                    return _insert;
                }
            }

            public string DELETE
            {
                get
                {
                    return _delete;
                }
            }

            public string UPDATE
            {
                get
                {
                    return _update;
                }
            }

            public Constants(string id, string name)
            {          
                _insert = string.Format("INSERT INTO [Plan1$] (id,name) VALUES ('{0}','{1}')",id,name);
                _update = string.Format("UPDATE [Plan1$] SET name = {0} where id = {1}", name, id);
            }


            public Constants(string id)
            {
                //Não é possivel deletar dados do Excel utilizando OleDb. Sómente UPDATE e INSERT
                //_delete = string.Format("DELETE * FROM [Plan1$] WHERE id = '{0}'", id);
                _delete = string.Format("UPDATE [Plan1$] SET id = NULL,name = NULL WHERE id = {0}", id);
                _update = string.Format("UPDATE [Plan1$] SET name = '<PARAMETRO_INVALIDO>', id = -1 WHERE id = NULL");
            }


        //UPDATE = "UPDATE [Plan1$] SET Nome = 'IMPLEMENTANDO NOME' WHERE Id = 6;" };
    }
}
