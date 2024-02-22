using System;
using System.Threading;
using System.Windows;
using LagDaemon.AudioProcessing.UI;

namespace ConsoleApp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Bootstrapper.StartApplication();
        }
    }
}
