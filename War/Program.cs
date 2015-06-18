using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
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
            //FileReader f = new FileReader();
            //ArrayList ins = f.getInstructions();
            //string casa = "cas";
            //casa += 'a';
            //Console.WriteLine(casa);
            Console.WriteLine(Environment.ProcessorCount);
        }
    }
}
