using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using static Org.BouncyCastle.Math.EC.ECCurve;
namespace DiscordGuardian
{

    public static class Banco
    {
        public static string bot_token = "";
        public static bool bot_status = true;

        //Dados de conexão
        public static string db_server = "";
        public static string db_data = "";
        public static string db_user = "";
        public static string db_pass = "";
        public static int db_timeout = 100; //não mexer
        public static string db_dados = ($"server={db_server};database={db_data};Uid={db_user};pwd={db_pass};Connection Timeout={db_timeout}");
        public static MySqlConnection con_db = new MySqlConnection(db_dados);

        public static void iniciar_conexao()
        {
            try
            {
                con_db.Open();
                Console.WriteLine("Conectado!");
            }
            catch (Exception dberror)
            {
                Console.WriteLine("Erro!\n" + dberror);
            }
        }

        public static bool user_auth_mc(string user)
        {
            bool exists = false;
            string com_check_user_exists = "select * from allowedUsers where username='" + user + "';";
            MySqlCommand comm = new MySqlCommand();
            var com = Banco.con_db.CreateCommand();
            com.CommandText = com_check_user_exists;
            var reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                exists = true;
            }
            reader.Close();
            if(exists != false)
            {
                string c = "update allowedUsers set auth=true where username='" + user + "';";
                MySqlCommand comm2 = new MySqlCommand();
                var com2 = Banco.con_db.CreateCommand();
                com2.CommandText = c;
                var ew = com2.ExecuteNonQuery();
                return true;
            }
            else
            {
                string c = "insert into allowedUsers values(default, null,'" + user + "', true);";
                MySqlCommand comm2 = new MySqlCommand();
                var com2 = Banco.con_db.CreateCommand();
                com2.CommandText = c;
                var ew = com2.ExecuteNonQuery();
                return true;

            }

        }


    }
}
