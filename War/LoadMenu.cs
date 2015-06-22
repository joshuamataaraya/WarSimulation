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
            DBActions.Instance.loadGame((Game)_listGames.SelectedItem);
        }
        private void loadGames(){
            foreach(Game game in DBActions.Instance.getGames()){
                _listGames.Items.Add(game);
            }
        }
        private GameWindow _GameWindow = new GameWindow();
        private SetUp _SetUp = new SetUp();
    }
}
