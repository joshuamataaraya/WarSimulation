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
        public void saveGame(Game pGame,List<Vessel> vessels)
        {
            SqlCommand command = new SqlCommand("uspNewGame", _Connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@pId", pGame.id));
            command.Parameters.Add(new SqlParameter("@pName", pGame.Name));
            if (_Connection.State == ConnectionState.Closed)
            {
                command.Connection.Open();
            }
            command.ExecuteNonQuery();

            int vesselCounter=1;
            foreach (Vessel vessel in vessels)
            {
                SqlCommand command2 = new SqlCommand("uspInsertVessel", _Connection);
                command2.CommandType = CommandType.StoredProcedure;
                command2.Parameters.Add(new SqlParameter("@pId", pGame.id+vesselCounter*100));
                command2.Parameters.Add(new SqlParameter("@pIdGame", pGame.id));
                command2.Parameters.Add(new SqlParameter("@pPosX", vessel.PosX));
                command2.Parameters.Add(new SqlParameter("@pPosY", vessel.PosY));
                command2.Parameters.Add(new SqlParameter("@pInstructionCounter", vessel.CurrentInstruction));
                command2.Parameters.Add(new SqlParameter("@pGrade", vessel.Grade));
                command2.Parameters.Add(new SqlParameter("@pLife", vessel.Life));
                if (_Connection.State == ConnectionState.Closed)
                {
                    command2.Connection.Open();
                }
                command2.ExecuteNonQuery();
                foreach (Instruction instruction in vessel.Instructions)
                {
                    SqlCommand command3 = new SqlCommand("uspInsertInstruction", _Connection);
                    command3.CommandType = CommandType.StoredProcedure;
                    command3.Parameters.Add(new SqlParameter("@pIdShip", pGame.id + vesselCounter * 100));
                    command3.Parameters.Add(new SqlParameter("@pGrade", instruction.Grade));
                    if (instruction.Action == "avanzar")
                    {
                        command3.Parameters.Add(new SqlParameter("@pAction", 0));
                    }
                    else
                    {
                        command3.Parameters.Add(new SqlParameter("@pAction", 1));
                    }
                    command3.Parameters.Add(new SqlParameter("@pValue", instruction.Value));
                    command3.Parameters.Add(new SqlParameter("@pInstructionId", instruction.Id));
                    if (_Connection.State == ConnectionState.Closed)
                    {
                        command3.Connection.Open();
                    }
                    command3.ExecuteNonQuery();
                }
                foreach (Bullet bullet in vessel.Bullets)
                {
                    SqlCommand command4 = new SqlCommand("uspInsertBullet", _Connection);
                    command4.CommandType = CommandType.StoredProcedure;
                    command4.Parameters.Add(new SqlParameter("@pIdShip", pGame.id + vesselCounter * 100));
                    command4.Parameters.Add(new SqlParameter("@pPosX", bullet.PosX));
                    command4.Parameters.Add(new SqlParameter("@pPosY", bullet.PosY));
                    command4.Parameters.Add(new SqlParameter("@pGrade", bullet.Grade));
                    command4.Parameters.Add(new SqlParameter("@pValue", bullet.Value));
                    if (_Connection.State == ConnectionState.Closed)
                    {
                        command4.Connection.Open();
                    }
                    command4.ExecuteNonQuery();
                }
            }
        }
        public SetUp loadGame(Game pGame)
        {
            try{
                List<Vessel> vessels = new List<Vessel>();
                SqlCommand command = new SqlCommand("uspGetShips", _Connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@pIdGame",pGame.id));
                if (_Connection.State == ConnectionState.Closed)
                {
                    command.Connection.Open();
                }
                
                SqlDataReader reader = command.ExecuteReader();                
                while (reader.Read())
                {
                    Vessel vessel = new Vessel();
                    Console.WriteLine(reader[2]);
                    vessel.PosX = Convert.ToSingle((double)reader[2]);
                    vessel.PosY =Convert.ToSingle((double)reader[3]);
                    vessel.Life = (int)reader["Life"];
                    vessel.Grade = Convert.ToSingle((double)reader["Grade"]); 
                    vessel.CurrentInstruction = (int)reader["instructionCounter"];
                    vessel.dbId = (int)reader["Id"];
                    vessels.Add(vessel);              
                }
                reader.Close();

                foreach (Vessel vessel in vessels){
                    SqlCommand command2 = new SqlCommand("uspGetInstructions", _Connection);
                    command2.CommandType = CommandType.StoredProcedure;
                    command2.Parameters.Add(new SqlParameter("@pIdShip", vessel.dbId));
                    SqlDataReader reader2 = command2.ExecuteReader();
                    List<Instruction> instructions = new List<Instruction>();
                    while (reader2.Read())
                    {
                        Instruction instruction = new Instruction();
                        Boolean action = (Boolean)reader2["Action"];
                        if (action == false)
                        {
                            instruction.Action = "avanzar";
                        }else{
                            instruction.Action = "disparar";
                        }
                        instruction.Value = Convert.ToSingle(reader2["Value"]);
                        instruction.Id = (int)reader2["InstructionId"];
                        instructions.Add(instruction);
                        vessel.addInstruction(instruction);
                    }
                    reader2.Close();

                    SqlCommand command3 = new SqlCommand("uspGetBullets", _Connection);
                    command3.CommandType = CommandType.StoredProcedure;
                    command3.Parameters.Add(new SqlParameter("@pIdShip", vessel.dbId));
                    SqlDataReader reader3 = command3.ExecuteReader();
                    List<Bullet> bullets = new List<Bullet>();
                    while (reader3.Read())
                    {
                        Bullet bullet = new Bullet(Convert.ToSingle((double)reader3["Value"]),
                            Convert.ToSingle(reader3["Grade"]), Convert.ToSingle(reader3["posX"]),
                            Convert.ToSingle(reader3["posY"]));
                        bullets.Add(bullet);
                    }
                    vessel.Bullets = bullets;
                    reader3.Close();
                }

                SetUp setUp = new SetUp(vessels);
                
                return setUp;
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
