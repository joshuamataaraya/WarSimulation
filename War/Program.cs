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
           
            Console.WriteLine(Environment.ProcessorCount);
            GameWindow _GameWindow = new GameWindow();
            LoadMenu _Menu = new LoadMenu(_GameWindow);
            SetUp _Setup = new SetUp();

            _Setup.updateView += _GameWindow.OnViewUpdated;

            Application.Run(_Menu);
            

            int clave = RSAEncription.Instance.Encrypt("Primer Juego", 123);

        }
    }
}
