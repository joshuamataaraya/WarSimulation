using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace War
{
    class DBActions
    {
        private static DBActions instance;
        private SqlConnection _Connection;
        private DBActions() { connect(); }
        public static DBActions Instance
        {
            get
            {
                if (instance==null){
                    instance=new DBActions();
                }
                return instance;
            }
        }

        public void connect()
        {
            string connetionString = null;
            connetionString = "Data Source=186.15.24.82; Initial Catalog=WarDB; User ID=warUser; Password=warUser123";
            _Connection = new SqlConnection(connetionString);
            try
            {
                _Connection.Open();
                Console.WriteLine("Connection Open ! ");
                _Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Can not open connection ! ");
            }
        }
        public void saveGame(String pName, int pPublicKey,List<Vessel> pVessels )
        {
            foreach (Vessel vess in pVessels)
            {
                foreach(Bullet bullet in vess.Bullets){

                }
            }
        }
        public SqlConnection Connection
        {
            get
            {
                return _Connection;
            }
        }
        public List<Game> getGames()
        {
            try
            {
                List<Game> games= new List<Game>();
                SqlCommand command = new SqlCommand("uspGetGames", _Connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}, {1}",
                        reader[0], reader[1]));
                    Game game = new Game((int)reader[0], (String)reader[1],reader[2].ToString());
                    games.Add(game);
                }
                reader.Close();
                return games;
            }
            catch (Exception ex)
            {
                if (_Connection.State ==ConnectionState.Open)
                {
                    _Connection.Close();
                }
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
