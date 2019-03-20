using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace HestiaApp
{

    public partial class Form1 : Form
    {
        public static int count = 0; //Fixes wierd line issue
        bool rksent;
        bool spamblocked = true;
        public static int spam;

        public Form1()
        {
            InitializeComponent();
        }
        public string Text
        {
            get { return ChatBox.Text; }
            set { ChatBox.Text += value; }

        }
        private void Form1_Load(object sender, EventArgs e) //On Load
        {
            Console.SetOut(new ControlWriter(ChatBox));
            Task task = Task.Run((Action)checkSpam);
            main();
            spam = 0;
            rksent = false;
        }
        private void checkSpam()
        {
            bool spamamount = false;
            int spamwait = 0;
            while (true)
            {
                if (spam > 2)
                {
                    if (!spamamount)
                    {
                        spam += 20;
                        spamamount = true;
                    }
                    spamblocked = true;

                    if (spamwait >= 2)
                    {
                        log("[!] Slow Down there! You have to wait " + (spam - 5) + " seconds before your next message");
                        spamwait = 0;
                    }
                    else
                    {
                        spamwait++;
                    }
                }
                else
                {
                    spamamount = false;
                    spamblocked = false;
                }
                spam--;
                System.Threading.Thread.Sleep(500);
            }
        }
        private void ClearChat_Click(object sender, EventArgs e) // ClearChat Button
        {
            Server.Sender senderr = new Server.Sender();
            senderr.Send("!clear");
            this.ChatBox.Text = "";
        }
        public void log(String message) // Log to chatbox cross thread enabled
        {
            if (Form1.count > 0) { message += "\n"; }
            ThreadHelperClass.SetText(this, ChatBox, message);
        }
        private void ChatBox_TextChanged(object sender, EventArgs e) // Scroll with cross-thread
        {
            ChatBox.SelectionStart = ChatBox.TextLength;
            ChatBox.ScrollToCaret();
        }
        private void SendButton_Click(object sender, EventArgs e)
        {
            if (!spamblocked)
            {
                if (rksent == false)
                {
                    try
                    {
                        start(SendBox.Text);
                        SendBox.Text = "";
                    }
                    catch
                    {
                        error("Error starting with room key");
                        throw;
                    }
                }
                else
                {
                    Server.Sender sendrer = new Server.Sender();
                    sendrer.Send(client.uid + ": " + SendBox.Text);
                    SendBox.Text = "";
                    spam++;
                }
            }
            else
            {
                SendBox.Text = "";
            }
        }
        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e) // Same as send button
        {

            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                if (!spamblocked)
                {
                    if (rksent == false)
                    {
                        try
                        {
                            start(SendBox.Text);
                            SendBox.Text = "";
                        }
                        catch
                        {
                            error("Error starting with room key");
                            throw;
                        }
                    }
                    else
                    {
                        Server.Sender senders = new Server.Sender();
                        senders.Send(client.uid + ": " + SendBox.Text);
                        SendBox.Text = "";
                        spam++;
                    }
                }
                else
                {
                    SendBox.Text = "";
                }
            }
        }
        public void error(String message)
        {
            log("[!] ERROR: " + message);
            return;
        }
        private void main() //Starting Function
        {
            log("[i] Please enter your room key to continue");
        }
       
        private void start(String rk) //Lets-a-go!
        {
            rksent = true;
            Random rnd = new Random();
            String guest = rnd.Next(101, 1000).ToString();
            client.uid = guest;
            Server.Crypto crypto = new Server.Crypto();
            Server.Crypto.EncryptionKey = crypto.CalculateMD5Hash(rk + Server.Crypto.EncryptionKey);
            String port = new string(Server.Crypto.EncryptionKey.Where(c => char.IsDigit(c)).ToArray()).Substring(0, 4);
            Server.port = Convert.ToInt32(port);
            log("[i] Joining Room: " + Server.Crypto.EncryptionKey);
            log("[i] Room Port: " + port);
            int msg = rnd.Next(1, 3);
            String[] msgs = new String[] { " Starting The Final Boss", " Starting The DoTS Destroyer", " Welcome to America" };
            String[] welcome = new String[] { " Has Zoomed In!", " Needs a heal!", " Is Welcomed!", " Is Here Hide Your Candy!", " Has Joined!" };

            log("[i]" + msgs[msg]);

            try
            {
                log("[i] Starting Receiver on port: " + Server.port + "...");
                Rec r = new Rec();
                r.startR();
                log("[i] Receiver Started");
            }
            catch
            {
                error("Error In Starting Receiver!");
            }
            log("[i] Starting Sender...");
            int wel = rnd.Next(1, 5);

            try
            {
                Server.Sender sender = new Server.Sender();
                sender.Send("\n" + "[i] " + client.uid + welcome[wel]+"\n");
            }
            catch
            {
                error("Error In Starting Sender!");
            }
            log("[i] Welcome " + client.uid + "! Type \"!quit\" to quit and \"!nick <nickname>\" to set your nickname");
        }

        
    

        public static class ThreadHelperClass
        {
            delegate void SetTextCallback(Form f, Control ctrl, string text);
            public static void SetText(Form form, Control ctrl, string text)
            {
                if (ctrl.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    form.Invoke(d, new object[] { form, ctrl, text });
                }
                else
                {
                    ctrl.Text += "\n" + text;
                }
            }
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            HestiaHelp h = new HestiaHelp();  
            h.Visible = true;
        }

        private void ChatBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
    public class ControlWriter : TextWriter
    {
        private Control textbox;
        public ControlWriter(Control textbox)
        {
            this.textbox = textbox;
        }

        public override void Write(char value)
        {
            textbox.Invoke(new Action(() => textbox.Text = ""));
        }

        public override void Write(string value)
        {
            textbox.Invoke(new Action(() => textbox.Text +=  value));
        }

        public override Encoding Encoding
        {
            get { return Encoding.ASCII; }
        }
    }
    class Rec
    {
        public void startR()
        {
            StartListening();
        }
        private readonly UdpClient udp = new UdpClient(Server.port);
        private void StartListening()
        {
            this.udp.BeginReceive(Receive, new object());
        }

        public void Receive(IAsyncResult ar)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, Server.port);
            byte[] bytes = udp.EndReceive(ar, ref ip);
            string message = Encoding.ASCII.GetString(bytes);
            Console.Write(Server.Crypto.Decrypt(message));
            commands(Server.Crypto.Decrypt(message));
            StartListening();
        }
        private void commands(String message) // Commands
        {
            if (message.Contains("!clear"))
            {
                Console.WriteLine("");
                Form1.count = 0;
                Console.Write("[i] Chat Cleared By User!");
            }
            if (message.Contains("!quit"))
            {
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}

class client
{
    public static String uid;
}
class Server
    {
    public class Receiver
    {

    }
    public class Sender
    {
        public void Send(String text)
        {
            UdpClient client = new UdpClient();
            IPEndPoint ip = new IPEndPoint(IPAddress.Broadcast, Server.port);
            command(text);
            byte[] bytes = Encoding.ASCII.GetBytes(Crypto.Encrypt(text));
            client.Send(bytes, bytes.Length, ip);
            client.Close();
        }
        void command(String text)
        {
            if (text.Contains("!nick"))
            {
                try
                {
                    String nick = text.Replace(client.uid + ": " + "!nick ", "");
                    client.uid = nick.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
                }
                catch
                {
                    Console.WriteLine("[!] Incorrect Syntax for !nick");
                }
            }
        }
    }
    public class StateObject
        {
            // Client  socket.  
            public Socket workSocket = null;
            // Size of receive buffer.  
            public const int BufferSize = 1024;
            // Receive buffer.  
            public byte[] buffer = new byte[BufferSize];
            // Received data string.  
            public StringBuilder sb = new StringBuilder();
        }
        public static Int32 port = 15000;

        public class Crypto
        {
            public String CalculateMD5Hash(string input)
            {
                MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hash = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }
            public static String EncryptionKey = "dIpEGtf8xb9SXreYOsYR8JRDLiZmgZXVClzMA4EKAg47fu3CJ3P0oxk7sR72";
            public static Random rand = new Random();
            public static string Encrypt(string clearText)
            {
                byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
                using (Aes encryptor = Aes.Create())
                {
                    byte[] IV = new byte[15];
                    rand.NextBytes(IV);
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, IV);
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        clearText = Convert.ToBase64String(IV) + Convert.ToBase64String(ms.ToArray());
                    }
                }
                return clearText;
            }
            public static string Decrypt(string cipherText)
            {
                byte[] IV = Convert.FromBase64String(cipherText.Substring(0, 20));
                cipherText = cipherText.Substring(20).Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, IV);
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                return cipherText;
            }
        }


        
    }

