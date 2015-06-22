using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace War
{
    public partial class GameWindow : Form
    {
        //Constructor
        public GameWindow()
        {
            InitializeComponent();
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Game_FormClosed);           
        }
        
        
        //Event Handlers
        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        public void OnViewUpdated(object source, VesselsEventArgs e)
        {
            //Pintar dependiendo de la lista de barcos
            Console.WriteLine("update...");
            List<Vessel> _Vessels = e.Vessels;
            int vesselCounter = _Vessels.Count;
            Image image;
            Graphics graphics = _GamePanel.CreateGraphics();
            for (; vesselCounter > 0; vesselCounter-- )
            {
                if (_Vessels[vesselCounter-1].Life > 0)
                {
                    switch (_Vessels[vesselCounter-1].Life){
                        case 2:
                            image = new Bitmap(global::War.Properties.Resources.barco2);
                            break;
                        case 1:
                            image = new Bitmap(global::War.Properties.Resources.barco1);
                            break;
                        default:
                            image = new Bitmap(global::War.Properties.Resources.barco3);
                            break;
                    }
                    graphics.RotateTransform(_Vessels[vesselCounter - 1].getAngle());
                    graphics.DrawImage(image, _Vessels[vesselCounter - 1].PosX, _Vessels[vesselCounter - 1].PosY);
                }
            }
        }
    }
}
