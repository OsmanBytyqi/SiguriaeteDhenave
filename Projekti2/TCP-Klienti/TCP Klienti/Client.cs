using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.Security.Cryptography;
using System.Xml;
using MySql.Data.MySqlClient;
using MySql.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace TCP_Klienti
{
    public partial class Client : Form
    {
        //Lidhja me db
        string ConnectionString = "Server=localhost;Database=shpenzimet;Uid=root;Pwd=;SSL Mode=none";
        public static Socket server;
        static string receivedData;
        private string IP_Address = "";
        private int PortNo = 0;
        private bool Connected;
        public string tokeni;

        private static RSACryptoServiceProvider rsaClient = new RSACryptoServiceProvider();
        private static RSACryptoServiceProvider rsaServer = new RSACryptoServiceProvider();

        private static string publicKeyServer;
        public Client()
        {
            InitializeComponent();
            this.MinimizeBox = false;
        }
        private void SendDataToServer(string data)
        {
            server.Send(Encoding.ASCII.GetBytes(data));
        }

        private string ReceiveDataFromServer()
        {
            byte[] data = new byte[2048];
            int recv_data = server.Receive(data);
            string stringData = Encoding.ASCII.GetString(data, 0, recv_data);

            byte[] EncryptedData;
            byte[] IV;
            byte[] key;
            string[] stringDataList = stringData.Split('*');
            IV = Convert.FromBase64String(stringDataList[0]);
            key = Convert.FromBase64String(stringDataList[1]);
            EncryptedData = Convert.FromBase64String(stringDataList[2]);
            stringData = MyDES.DecryptTextFromMemory(EncryptedData, key, IV);


            receivedData = stringData;
            return stringData;
        }
        private void SendRequestToSrv(string teksti)
        {
            try
            {
                server.Send(Encoding.ASCII.GetBytes(teksti));
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message.ToString());
            }
        }
        //Lidhja me Server
        private void btnConnect_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[2048];

            if (txtIP.Text.Trim() != "" && txtPorti.Text.Trim() != "")
            {
                IP_Address = txtIP.Text.Trim();
                PortNo = Convert.ToInt32(txtPorti.Text.Trim());

                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(IP_Address), PortNo);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    server.Connect(ipep);

                    txtReceiveAnswer.AppendText("Jeni të lidhur me serverin:" + txtIP.Text + " dhe Portin: " + txtPorti.Text + "\n");
                    BWchatLog.RunWorkerAsync();

                    publicKeyServer = ReceiveDataFromServer();
                    txtReceiveAnswer.AppendText("\n\n");
                    rsaServer.FromXmlString(publicKeyServer);

                    Connected = true;
                }
                catch (SocketException ex)
                {
                    txtReceiveAnswer.AppendText("E pamundur që të lidheni me server. Ju lutem kontrolloni IP adresen dhe portin!");
                    txtReceiveAnswer.AppendText("\n" + ex.ToString());
                    Connected = false;
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please fill IP Address and/or Port first!");
            }
        }


        protected bool ValidateField(TextBox textbox, string Errormsg, ErrorProvider errorProvider1)
        {

            bool bStatus = true;

            if (textbox.Text == "")
            {
                errorProvider1.SetError(textbox, Errormsg);
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(textbox, "");
            }
            return bStatus;
        }
        //Validimi i imelles:
        protected bool ValidateEmail(TextBox iblEmail, ErrorProvider errorProvider1)
        {
            bool bStatus = true;

            string email = iblEmail.Text.TrimEnd();

            Regex regex = new Regex(@"^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
            {
                errorProvider1.SetError(iblEmail, "");
            }
            else
            {
                errorProvider1.SetError(iblEmail, "Invalid Email!");
                bStatus = false;
            }
            return bStatus;
        }
        protected void AllowOnlyNumeric(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Connected)
                MessageBox.Show("Duhet të lidheni me server!", "Vërejtje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            bool bValidFatura = ValidateField(iblFatura, "Fatura duhet të shënohet!", errorProvider1);
            bool bValidVlera = ValidateField(iblVlera,"Vlera duhet te shenohet!", errorProvider1);
            bool bValidEmail = ValidateEmail(iblEmail,errorProvider1);
            bool bValidViti = ValidateField(iblViti, "Viti duhet të shënohet!", errorProvider1);
            bool bValidMuaji = ValidateField(iblMuaji, "Muaji duhet të shënohet!", errorProvider1);
            bool bValidUserName = ValidateField(txtUserName, "UserName-i duhet të shënohet!", errorProvider1);
            bool bValidPassword = ValidateField(txtPassword, "Pasword-i duhet të shënohet!", errorProvider1);

            if (!bValidFatura || !bValidVlera || !bValidViti || !bValidMuaji || !bValidUserName || !bValidPassword||!bValidEmail)
                MessageBox.Show("Të dhënat janë jo valide!", "Vërejtje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                try
                {
                   Shfrytezuesi shfrytezuesi = new Shfrytezuesi();
                   shfrytezuesi.Fatura = iblFatura.Text.Trim();
                   shfrytezuesi.Email=iblEmail.Text.Trim();
                   shfrytezuesi.Vlera = Convert.ToDecimal(iblVlera.Text.Trim());
                   shfrytezuesi.Muaji = iblMuaji.Text.Trim();
                   shfrytezuesi.userId = txtUserName.Text.Trim();
                   shfrytezuesi.Viti = int.Parse(iblViti.Text.Trim());
                   shfrytezuesi.PasswordHash = txtPassword.Text.Trim();

                    //JavaScriptSerializer js = new JavaScriptSerializer();
                    //string json = js.Serialize(shfrytezuesi); 

                    string json = JsonConvert.SerializeObject(shfrytezuesi);
                    string SendCommand = "Regjistrimi " + json;

                    SendCommand = DESEncrypt(SendCommand);
                    SendRequestToSrv(SendCommand);

                    txtReceiveAnswer.AppendText("\n");
                    txtReceiveAnswer.Refresh();
                   
                    txtReceiveAnswer.AppendText("\n" + ReceiveDataFromServer());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Vërejtje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            try
            {
                connection.Open();
                string Salt = new Random().Next(100000, 1000000).ToString();
                string Password = txtPassword.Text;

                string SaltedPassword = Salt + Password;
                string SaltedHashPassword = CalculateHash(SaltedPassword);
                //Komandat ne Mysql
                string strCommand = "INSERT INTO info(username, password, fatura, muaji, viti, email, vlera, salt) VALUES ('" + txtUserName.Text + "','" + SaltedHashPassword + "','" + iblFatura.Text + "','" + iblMuaji.Text + "','" + iblViti.Text + "','" + iblEmail.Text + "','" + iblVlera.Text + "','" + Salt + "')";

                MySqlCommand sqlCommand = new MySqlCommand(strCommand, connection);
                int retValue = sqlCommand.ExecuteNonQuery();
                if (retValue > 0)
                    MessageBox.Show("Te dhenat u ruajten me Sukses!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Ruajtja deshtoi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lidhja deshtoi!\n" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            
            

        }
        private string CalculateHash(string SaltedPassword)
        {
            //Kthimi ne byte array
            byte[] byteSaltedPassword = Encoding.UTF8.GetBytes(SaltedPassword);
            SHA1CryptoServiceProvider objHash = new SHA1CryptoServiceProvider();

            byte[] byteSaltedHashPassword = objHash.ComputeHash(byteSaltedPassword);
            return Convert.ToBase64String(byteSaltedHashPassword);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
             if (!Connected)
                MessageBox.Show("Duhet të lidheni me server!", "Vërejtje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            bool bValidUserName = ValidateField(txtUserName1, "UserName-i duhet të shënohet!", errorProvider1);
            bool bValidPassword = ValidateField(txtPassword1, "Pasword-i duhet të shënohet!", errorProvider1);

            if (!bValidUserName || !bValidPassword)
                MessageBox.Show("Të dhënat janë jo valide!", "Vërejtje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                try
                {
                    Login login = new Login();
                    login.userId = txtUserName1.Text.Trim();
                    login.PasswordHash = txtPassword1.Text.Trim();
                    string json = JsonConvert.SerializeObject(login);
                    string SendCommand = "Authentifikimi " + json;

                    SendCommand = DESEncrypt(SendCommand);
                    SendRequestToSrv(SendCommand);

                    txtReceiveAnswer.AppendText("\n");
                    txtReceiveAnswer.Refresh();
                    string pergjigja = ReceiveDataFromServer();

                    if (pergjigja.Contains('@'))
                    {
                        string[] pergjigjaArray = pergjigja.Split('@');
                        tokeni = pergjigjaArray[1];
                        VerifyToken vtoken = new VerifyToken();

                        txtReceiveAnswer.AppendText("\n" + pergjigjaArray[0] + "\n" + vtoken.verifyToken(tokeni));
                    }
                    else
                    {
                        txtReceiveAnswer.AppendText("\n" + pergjigja + "\n" );
                    }
                           
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Vërejtje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
           
   

        }
        string DESEncrypt(string data)
        {
            DESCryptoServiceProvider DESalg = new DESCryptoServiceProvider();

            byte[] EncryptedData = MyDES.EncryptTextToMemory(data, DESalg.Key, DESalg.IV);

            byte[] RSAKey = RSA.RSAEncrypt(DESalg.Key, rsaServer.ExportParameters(false), false);

            return Convert.ToBase64String(DESalg.IV) + "*" + Convert.ToBase64String(RSAKey) + "*" + Convert.ToBase64String(EncryptedData);
        }
     private void iblVlera_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyNumeric(sender, e);
        }
    }
}
