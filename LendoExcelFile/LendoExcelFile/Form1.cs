using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LendoExcelFile
{
    public partial class Form1 : Form
    {
        private DataSet ds;
        private List<string> list;
        private OpenFileDialog openFile;

        DAO_Connection SingleConnection;
        OleDbConnection connection;

        //private bool verifyXls = false;

        public Form1()
        {
            InitializeComponent();

            ds = new DataSet();
            SingleConnection = new DAO_Connection("C:\\Users\\diegou\\Desktop\\teste.xls");
            connection = SingleConnection.SingletonConnection;
            connection.Open();
            RefreshValuesTable();
            connection.Close();
        }



        //private void btnSelecionar_Click(object sender, EventArgs e)
        //{
        //    openFile = new OpenFileDialog();
        //    openFile.Filter = "All Files (*.*)|*.*"; // Estudar mais profundamente o atributo Filter da classe OpenFileDialog
        //    openFile.Title = @"C:\Users\diegou\Desktop";
        //    openFile.FileName = "selecione um arquivo";
        //    openFile.FileOk += openFile_FileOk;

        //    if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        ds = new DataSet();
        //        verifyXls = true;

        //        SingleConnection = new DAO_Connection(openFile.FileName);
        //        connection = SingleConnection.SingletonConnection;        
        //        connection.Open();
        //        RefreshValuesTable();
        //        connection.Close();
        //    }

        //}

        void openFile_FileOk(object sender, CancelEventArgs e)
        {
            if (e.Cancel == true)
                MessageBox.Show("Tem certeza disso?");
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            if (txbName.Text != null)
            {
                try
                {
                    connection.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = connection;
                    Constants constants = new Constants(ReturnNextIdToInsert().ToString(), txbName.Text);
                    cmd.CommandText = constants.INSERT;
                    cmd.ExecuteNonQuery();
                    RefreshValuesTable();
                    connection.Close();

                    MessageBox.Show("Valor inserido com sucesso!");
                    txbName.Text = "";
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }

            }
            else
                MessageBox.Show("É necessário entrar com um Nome!");
        }

        private void RefreshValuesTable()
        {
            dataGrid.ClearSelection();
            ds.Clear();

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(Constants.SELECT, connection);
            dataAdapter.Fill(ds);
            dataGrid.DataSource = ds.Tables[0];

            Constants constante;
            OleDbCommand cmd;
            for (int i = 0; i < dataGrid.Rows.Count-1; i++)
            {
                try
                {
                    if (string.IsNullOrEmpty(dataGrid.Rows[i].Cells[0].Value.ToString()))
                    {             
                        constante = new Constants("");
                        cmd = new OleDbCommand();
                        cmd.CommandText = constante.UPDATE;
                        cmd.Connection = connection;
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                
            }
            //ds.Tables[0].WriteXml("newFileTeste",false);
        }

        private int ReturnNextIdToInsert()
        {
            DataGridViewRow row;
            int maior = 0;
            for (int i = 0; i < dataGrid.Rows.Count - 1; i++)
            {
                row = dataGrid.Rows[i];
                string value = row.Cells[0].Value.ToString();
                if (Convert.ToInt32(value) > maior)
                {
                    maior = Convert.ToInt32(value);
                }
            }
            return maior + 1;
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            string id = "-1";

            for (int i = 0; i < dataGrid.Rows.Count-1; i++)
            {
                if (dataGrid.Rows[i].Cells[0].Selected)
                {
                    id = dataGrid.Rows[i].Cells[0].Value.ToString();
                }
            }

            if (id.Equals("-1"))
            { 
                MessageBox.Show("Selecione um Id na tabela para remover as informações.");
                return;
            }

            connection.Open(); 
            Constants constante = new Constants(id);
            OleDbCommand cmd = new OleDbCommand(constante.DELETE,connection);
            cmd.ExecuteNonQuery();
            RefreshValuesTable();
            connection.Close();
        }
    }
}
