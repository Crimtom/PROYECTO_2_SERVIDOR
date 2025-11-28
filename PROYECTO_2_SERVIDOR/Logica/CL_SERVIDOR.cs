using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Threading.Tasks;

namespace PROYECTO_2_SERVIDOR.Logica
{
    internal class CL_SERVIDOR
    {
        // Se declaran los atributos

        private TcpListener tcpListener;
        private Thread listenThread;

        // Se declaran los métodos

        public void ServidorTcp()
        {
            this.tcpListener = new TcpListener(IPAddress.Any, 30000);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
        }
        private void ListenForClients()
        {
            this.tcpListener.Start();
            while (true)
            {
                //blocks until a client has connected to the server
                TcpClient client = this.tcpListener.AcceptTcpClient();
                //create a thread to handle communication
                //with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }
        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes("Connected");
            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
            byte[] message = new byte[4096];
            int bytesRead;
            while (true)
            {

                bytesRead = 0;
                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }
                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }
                //message has successfully been received
                encoder = new ASCIIEncoding();
                System.Diagnostics.Debug.WriteLine(encoder.GetString(message, 0, bytesRead));
            }
            tcpClient.Close();
        }
    }
}
