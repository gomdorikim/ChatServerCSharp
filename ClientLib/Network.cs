using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib
{
    public class Network
    {
        public Socket socket;
        public delegate void ReceivedDataHandler(byte[] data);
        public event ReceivedDataHandler ReceivedData;

        public void Connect(string ip, int port)
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(ip), port);
            Connect(iep, socket);
        }
        private void Connect(EndPoint remoteEP, Socket client)
        {
            client.BeginConnect(remoteEP,
                new AsyncCallback(ConnectCallback), client);
        }
        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private void Send(byte[] data)
        {
            // Begin sending the data to the remote device.
            socket.BeginSend(data, 0, data.Length, SocketFlags.None,
                new AsyncCallback(SendCallback), socket);
        }
        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private void Receive()
        {
            try
            {
                // Create the state object.
                DataObject state = new DataObject();
                state.workSocket = socket;

                // Begin receiving the data from the remote device.
                socket.BeginReceive(state.buffer, 0, DataObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket 
                // from the asynchronous state object.
                DataObject state = (DataObject)ar.AsyncState;
                Socket client = state.workSocket;
                // Read data from the remote device.
                int bytesRead = client.EndReceive(ar);
                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.
                    new StringBuilder().Append(state.buffer);
                    //  Get the rest of the data.
                    client.BeginReceive(state.buffer, 0, DataObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    byte[] data;
                    // All the data has arrived; put it in response.
                    if (state.save.Length > 1)
                    {
                        data = state.save;
                    }
                    // Signal that all bytes have been received.

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
