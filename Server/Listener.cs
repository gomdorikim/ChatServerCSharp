using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public class Listener
    {
        Socket s;

        public bool Listening
        { get; private set; }
        public int Port 
        { get; private set; }

        public Listener(int port)
        { 
            Port = port; s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
        }
        public void Start()
        {
            Client.all = new List<Client>();
            if (Listening) { UConsole.Log("Tried to begin listening but already was. Ignoring"); return; }
            s.Bind(new IPEndPoint(0, Port));
            s.Listen(0);
            s.BeginAccept(callback, null);
            Listening = true;
        }
        public void Stop()
        {
            Client.all.Clear();
            if (!Listening) { UConsole.Log("Tried to stop listening but already was. Ignoring"); return; }
            s.Close();
            s.Dispose();
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        void callback(IAsyncResult ar)
        {
            try
            {
                Socket s = this.s.EndAccept(ar);
                if (SocketAccepted != null)
                {
                    SocketAccepted(s);
                }
                this.s.BeginAccept(callback, null);
            }
            catch (System.Exception ex)
            {
                UConsole.Log("Listener.cs:52 " + ex.Message);
                Console.Write(ex.ToString());
            }
        }
        public delegate void SocketAcceptedHandler(Socket e);
        public event SocketAcceptedHandler SocketAccepted;
    }
}
