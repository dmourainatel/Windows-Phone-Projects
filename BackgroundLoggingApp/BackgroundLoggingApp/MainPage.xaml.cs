using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BackgroundLoggingApp.Resources;
using System.IO.IsolatedStorage;
using System.IO;
using System.Threading;
using Microsoft.Phone.Scheduler;

namespace BackgroundLoggingApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        PeriodicTask _periodicaTask;
        string _periodicTaskName = "Task logging";

        public MainPage()
        {
            InitializeComponent();
        }

        //Semaforo
        Mutex mut = new Mutex(false,"LogMutex");
        private void btnLeLog_Click(object sender, RoutedEventArgs e)
        {
            mut.WaitOne();//Espera até a thread poder trabalhar ( acessar nosso recurso .txt );

            IsolatedStorageFile isoFile = IsolatedStorageFile.GetUserStoreForApplication();

            if (!isoFile.DirectoryExists("/Logs/"))
            {
                mut.ReleaseMutex();// Liebro o meu mutex
                MessageBox.Show("Nenhum log foi encontrado");
                return;
            }
           
                IsolatedStorageFileStream isoLogFileStream = new IsolatedStorageFileStream(
                "\\Logs\\MeuLog.txt",
                System.IO.FileMode.Open,
                isoFile);

                StreamReader reader = new StreamReader(isoLogFileStream);
                string log = reader.ReadToEnd();

                //Liberar todos os recursos
                isoLogFileStream.Close();
                reader.Close();

                // Liebro o meu mutex
                mut.ReleaseMutex();

                MessageBox.Show(log);
            
        }

        private void btnIniciaLog_Click(object sender, RoutedEventArgs e)
        {
            _periodicaTask = (ScheduledActionService.Find(_periodicTaskName) as PeriodicTask);

            //Se ela exite e nao esta habilitada
            if(_periodicaTask != null && !_periodicaTask.IsEnabled)
            {
                MessageBox.Show("Este background agent esta desabilitado pelo usuario");
                return;
            }

            //conseguiu encontrar a task e ela esta habilitada
            if (_periodicaTask != null && _periodicaTask.IsEnabled)
            {
                ScheduledActionService.Remove(_periodicTaskName);
            }

            _periodicaTask = new PeriodicTask(_periodicTaskName);
            _periodicaTask.Description = "Esta eh a descricao da task";
            _periodicaTask.ExpirationTime = DateTime.Now.AddDays(14);// o maximo que aceita é 14 dias de prorrogação 2 semanas

            ScheduledActionService.Add(_periodicaTask);

            #if(DEBUG_AGENT)
                    ScheduledActionService.LaunchForTest(_periodicTaskName,TimeSpan.FromSeconds(2));                
            #endif
        }
    }
}