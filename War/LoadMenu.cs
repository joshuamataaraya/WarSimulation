using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace War
{
    public partial class LoadMenu : Form
    {
        public LoadMenu()
        {
            InitializeComponent();
            _GameWindow = new GameWindow();
            _SetUp = new SetUp();
            loadGames();
            _SetUp.updateView += _GameWindow.OnViewUpdated;
        }

        private void _bCreate_Click(object sender, EventArgs e)
        {
            this.Hide();
            _GameWindow.Show();
            _SetUp.runGame();
        }

        private void _bLoad_Click(object sender, EventArgs e)
        {
            ///Verificar si la clave que esta en _iGameCode es el private key del juego seleccionade en _listGames
            ///Si no esta la clave correcta lanzar un alerta
            ///

            Game juegoPrueba = new Game("Forth game");
            juegoPrueba.id = 75;

            Instruction i = new Instruction();
            i.Id = 851;
            i.Action = "Avanzar";
            i.Value = Convert.ToSingle(2.3);
            i.Grade = Convert.ToSingle(0.5);

            Bullet b = new Bullet(Convert.ToSingle(2.3),Convert.ToSingle(0.5),Convert.ToSingle(100),Convert.ToSingle(200));

            Vessel v = new Vessel();
            v.addInstruction(i);
            List<Bullet> vs = new List<Bullet>();
            vs.Add(b);
            v.Bullets = vs;

            List<Vessel> vess = new List<Vessel>();
            vess.Add(v);

            DBActions.Instance.saveGame(juegoPrueba,vess);
            DBActions.Instance.loadGame((Game)_listGames.SelectedItem);
        }
        private void loadGames(){
            foreach(Game game in DBActions.Instance.getGames()){
                _listGames.Items.Add(game);
            }
        }
        private GameWindow _GameWindow;
        private SetUp _SetUp;
    }
}
