using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Kanban_board_project.App_Data;

using System.Net;
using System.Net.Mail;

using System.Globalization;
using System.Text.RegularExpressions;

namespace Kanban_board_project
{
    public class management
    {
        public Boolean yaExiste(String uName, String password)
        {
            string conec = ConfigurationManager.ConnectionStrings["Kanban"].ConnectionString;
            SqlConnection cone = new SqlConnection(conec);

            cone.Open();
            string query = "select * from USUARIOS where USUARIO= '" + uName + "' AND PASSWORD='" + password + "'";
            SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, cone);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                cone.Close();
                return true;
            }

            cone.Close();
            return false;
        }

        public Boolean yaExisteUser(String uName)
        {
            string conec = ConfigurationManager.ConnectionStrings["Kanban"].ConnectionString;
            SqlConnection cone = new SqlConnection(conec);

            cone.Open();
            string query = "select * from USUARIOS where USUARIO= '" + uName + "'";
            SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, cone);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                cone.Close();
                return true;
            }

            cone.Close();
            return false;
        }

        public Boolean insertingRecord(string name, string profesion, string email, string user, string password)
        {
            string conec = ConfigurationManager.ConnectionStrings["Kanban"].ConnectionString;
            SqlConnection cone = new SqlConnection(conec);

            cone.Open();
            string query = "INSERT INTO USUARIOS(NOMBRE,PROFECION,USUARIO,PASSWORD,CORREO) VALUES(@name,@prof,@user,@pass,@email)";
            SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, cone);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@prof", profesion);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", password);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.ExecuteNonQuery();
            cone.Close();
            return true;
        }

        public Boolean sendActivationMessage(string ToEmail, string ToName, string FromEmail, string FromPassword)
        {
            var fromAddress = new MailAddress(FromEmail, "Kanban Boards Project");
            var toAddress = new MailAddress(ToEmail, ToName);
            const string subject = "Confirmacion de Registro de Cuenta";
            const string body = "Hey now!!";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, FromPassword),
                Timeout = 20000
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

            return true;
        }

        public void sendMessage()
        {
        }
        public int getid(string usuario)
        {
            string conec = ConfigurationManager.ConnectionStrings["Kanban"].ConnectionString;
            SqlConnection cone = new SqlConnection(conec);

            cone.Open();
            string query = "select IDUSUARIO from [Kanbanboard].[dbo].[USUARIOS] where USUARIO LIKE '" + usuario + "'"; 
            SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, cone);
            int id=(int)cmd.ExecuteScalar();
            cone.Close();
            return id;
        }
        public int emailIsValid(String emailToEvaluate)
        {
            CheckingEmailAddress.EmailVerify Verifier = new CheckingEmailAddress.EmailVerify();
            CheckingEmailAddress.ReturnValues ValuesNeeded = Verifier.VerifyEmail(emailToEvaluate, "0");

            if (!ValuesNeeded.CorrectSyntax)
                return 1;

            if (!ValuesNeeded.EmailDomainFound)
                return 2;

            if (!ValuesNeeded.GoodEmail)
                return 3;

            return 0;
        }

        private string DomainMapper(Match match)
        {
            return "";
        }

        public Boolean correoRegistrado(string email)
        {
            KanbanEntities ke = new KanbanEntities();
            return ke.USUARIOS.Count(co => co.CORREO.CompareTo(email)==0)==0 ?false:true;
        }

        public static Boolean crearCarta(string nombre, string descripcion, string color, DateTime ini, DateTime fin, int prioridad, int tipo)
        {
            if (ini!=null && fin!=null)
            {
                if (ini.CompareTo(fin) == 1)
                    return false;
            }
            return crearCarta(nombre, descripcion, color, ini!=null?ini.ToShortDateString():null, fin.ToShortDateString(), prioridad, tipo);
        }

        public static Boolean crearCarta(string nombre, string descripcion, string color, string ini, string fin, int prioridad, int tipo)
        {
            KanbanEntities ke = new KanbanEntities();
            if (prioridad <= 0)
            {
                return false;
            }
            CARD li = new CARD();
            li.FECHAFINAL = fin;
            if (ini != null) li.FECHAINICIO=ini;
            li.NOMBRE = nombre;
            li.DESCRIPCION = descripcion;
            li.COLOR = color;
            li.PRIORIDAD = prioridad;
            li.TIPO = tipo;
            ke.AddToCARDS(li);
            return true;
        }

        public static void inicializarCarta(int id){
            KanbanEntities ke = new KanbanEntities();
            var carta= ke.CARDS.Where(cart => cart.IDCARD == id).First();
            carta.FECHAINICIO = DateTime.Now.ToShortDateString();
          
        }

      

        public static Boolean editarCarta(int id, string nombre, string descripcion, string color, string fin, int prioridad)
        {
            KanbanEntities ke = new KanbanEntities();
            if (ke.CARDS.Count(co => co.IDCARD.CompareTo(id)==0) == 0)
            {
                return false;
            }
            var carta = ke.CARDS.Where(cart => cart.IDCARD == id).First();
            if (nombre != null)
            {
                carta.NOMBRE = nombre;
            }
            if (fin != null)
            {
                
                carta.FECHAFINAL = fin;
            }
            
            if (color != null)
            {
                carta.COLOR = color;
            }
            if (prioridad != null)
            {
                if (prioridad <= 0)
                    return false;
                carta.PRIORIDAD = prioridad;
            }
            return true;
        }
    }
}