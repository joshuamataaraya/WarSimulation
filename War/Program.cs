using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
namespace War
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            FileReader f = new FileReader();
            List<Instruction> ins = f.getInstructions();

            VesselSetter setUp = new VesselSetter(ins);
            //List<Vessel> vessels = setUp.vessels;
            //Process[] notepads = Process.GetProcessesByName("notepad");
            //if (notepads.Length == 0)
            //    Process.Start("notepad");

            //Process CurrentProcess = Process.GetCurrentProcess();
            //Console.WriteLine("ProcessName: {0}", CurrentProcess.ProcessName);

            //string casa = "cas";
            //casa += 'a';
            //Console.WriteLine(casa);
            Console.WriteLine(Environment.ProcessorCount);
        }
    }
}
