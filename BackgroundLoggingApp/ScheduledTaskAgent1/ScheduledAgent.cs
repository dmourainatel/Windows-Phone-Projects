using System.Diagnostics;
using System.Windows;
using Microsoft.Phone.Scheduler;
using System.IO.IsolatedStorage;
using System.IO;
using System.Threading;
using System;
using Microsoft.Phone.Shell;

namespace ScheduledTaskAgent1
{
    public class ScheduledAgent : ScheduledTaskAgent
    {
        /// <remarks>
        /// ScheduledAgent constructor, initializes the UnhandledException handler
        /// </remarks>
        static ScheduledAgent()
        {
            // Subscribe to the managed exception handler
            Deployment.Current.Dispatcher.BeginInvoke(delegate
            {
                Application.Current.UnhandledException += UnhandledException;
            });
        }

        /// Code to execute on Unhandled Exceptions
        private static void UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                Debugger.Break();
            }
        }

        /// <summary>
        /// Agent that runs a scheduled task
        /// </summary>
        /// <param name="task">
        /// The invoked task
        /// </param>
        /// <remarks>
        /// This method is called when a periodic or resource intensive task is invoked
        /// </remarks>
        protected override void OnInvoke(ScheduledTask task)
        {
           
            if(task is PeriodicTask)
            {
                string log = LeLogDoIsStorage();
                log =string.Format("\nLog foi criado em : {0} as {1}",
                    DateTime.Now.ToLongDateString(),
                    DateTime.Now.ToLongTimeString());
                
                //Salva o Log
                SalvaLog(log);

                //Posso mostrar atravez de um ShellToast que o arquivo foi salvo
                //ShellToast toast = new ShellToast();
                //toast.Content = "Mais um log foi criado";
                //toast.Title = "Meu app";
                //toast.Show();
            }
            if(task is ResourceIntensiveTask)
            {

            }


            //TODO: Add code to perform your task in background

            NotifyComplete();
        }

        private async void SalvaLog(string log)
        {
            mut.WaitOne();
            IsolatedStorageFile isoFile = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream isoFileStream = new IsolatedStorageFileStream("\\Logs\\MeuLog.txt",FileMode.Create,isoFile);
            StreamWriter writer = new StreamWriter(isoFileStream);
            await writer.WriteAsync(log);
            //Libera os recursos
            writer.Close();
            isoFileStream.Close();
            mut.ReleaseMutex();
        }

        Mutex mut = new Mutex(false,"LogMutex");
        private string LeLogDoIsStorage()
        {
            mut.WaitOne();   
            IsolatedStorageFile isoFile = IsolatedStorageFile.GetUserStoreForApplication();
            // Se o meu arquivo de logo nao existe
            if(!isoFile.FileExists("\\Logs\\MeuLog.txt"))
            {     
                //Crio a pasta
                isoFile.CreateDirectory("Logs");
                mut.ReleaseMutex();
                return "";
            }
            isoFile.CreateFile("\\Logs\\MeuLog.txt");

            IsolatedStorageFileStream isoFileStream = new IsolatedStorageFileStream("\\Logs\\MeuLog.txt", System.IO.FileMode.Open, isoFile);
            StreamReader reader = new StreamReader(isoFileStream);
            string log = reader.ReadToEnd();

            //Libero os recursos
            isoFileStream.Close();
            reader.Close();

            mut.ReleaseMutex();
            return log;
        }
    }
}