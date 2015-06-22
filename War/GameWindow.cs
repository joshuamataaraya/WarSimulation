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
        
        //Functions

        //Resource from stackoverflow to rotate an image
        //http://stackoverflow.com/questions/2163829/how-do-i-rotate-a-picture-in-c-sharp
        public static Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);
            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
            //now rotate the image
            gfx.RotateTransform(rotationAngle);
            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));
            //dispose of our Graphics object
            gfx.Dispose();
            //return the image
            return bmp;
        }


        //Event Handlers
        public void OnViewUpdated(object source, VesselsEventArgs e)
        {
            /*M1
            //Pintar dependiendo de la lista de barcos
            Console.WriteLine("update...");
            _Vessels = e.Vessels;
            vesselCounter = _Vessels.Count;
            _GamePanel.Invalidate();
            Graphics graphics = _GamePanel.CreateGraphics();
            Image image;
            for (; vesselCounter > 0; vesselCounter--)
            {
                
                if (_Vessels[vesselCounter - 1].Life > 0)
                {
                    switch (_Vessels[vesselCounter - 1].Life)
                    {
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
                    Console.WriteLine("barco: " + vesselCounter + " Angle: "+_Vessels[vesselCounter - 1].getAngle());
                    graphics.RotateTransform(_Vessels[vesselCounter - 1].getAngle());
                    graphics.DrawImage(image, _Vessels[vesselCounter - 1].PosX, _Vessels[vesselCounter - 1].PosY);
                }
            }
            */

//            /*M2
            //this._GamePanel.Controls.Clear();
            _Vessels = e.Vessels;
            vesselCounter = _Vessels.Count;
            _GamePanel.Controls.Clear();
            this.Paint += new System.Windows.Forms.PaintEventHandler(this._GamePanel_Paint);
//                */
        }
        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void _GamePanel_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("pintar!");
            graphics = _GamePanel.CreateGraphics();
            Image image;
            for (; vesselCounter > 0; vesselCounter--)
            {
                Console.Write(_Vessels[vesselCounter - 1].Life);
                if (_Vessels[vesselCounter - 1].Life > 0)
                {
                    switch (_Vessels[vesselCounter - 1].Life)
                    {
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
        List<Vessel> _Vessels;
        int vesselCounter;
        Graphics graphics;
    }
}
