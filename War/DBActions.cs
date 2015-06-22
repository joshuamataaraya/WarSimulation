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
        private DBActions() { }
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
        /*
        public List<Game> getGames()
        {
            try
            {
                SqlCommand command = new SqlCommand("uspGetGames", _Connection);
                command.CommandType = CommandType.StoredProcedure
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }*/
    }
}
