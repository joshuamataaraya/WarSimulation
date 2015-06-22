using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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
            SqlConnection cnn ;
            connetionString = "Data Source=186.15.24.82; Initial Catalog=WarDB; User ID=WarUser; Password=WarUser123";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                Console.WriteLine("Connection Open ! ");
                cnn.Close();
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
    }
}
