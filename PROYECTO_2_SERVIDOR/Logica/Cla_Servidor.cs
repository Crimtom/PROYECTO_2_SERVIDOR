using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace PROYECTO_2_SERVIDOR.Logica
{
    public class Cla_Servidor
    {
        private Cla_Padron Padron = new Cla_Padron();

        private TcpListener _servidor;
        private bool _activo;
        public int ClientesConectados { get; private set; }

        // Eventos para comunicar con el formulario (bitácora y contador)
        public event Action<string> OnLog;
        public event Action<int> OnCambioClientes;

        public void Iniciar(int puerto)
        {
            if (_activo) return;

            _servidor = new TcpListener(IPAddress.Any, puerto);
            _servidor.Start();
            _activo = true;

            Log("Servidor escuchando en el puerto " + puerto);

            Thread hilo = new Thread(EscucharClientes);
            hilo.IsBackground = true;
            hilo.Start();
        }

        public void Detener()
        {
            _activo = false;

            if (_servidor != null)
                _servidor.Stop();

            Log("Servidor detenido.");
        }

        private void EscucharClientes()
        {
            try
            {
                while (_activo)
                {
                    TcpClient cliente = _servidor.AcceptTcpClient();

                    ClientesConectados++;

                    if (OnCambioClientes != null)
                        OnCambioClientes(ClientesConectados);

                    Log("Cliente conectado.");

                    Thread hiloCliente = new Thread(AtenderCliente);
                    hiloCliente.IsBackground = true;
                    hiloCliente.Start(cliente);
                }
            }
            catch (SocketException)
            {
                // Ocurre cuando se detiene el servidor, se ignora
            }
        }

        private void AtenderCliente(object obj)
        {
            TcpClient cliente = (TcpClient)obj;

            try
            {
                NetworkStream stream = cliente.GetStream();

                byte[] buffer = new byte[1024];
                int leidos = stream.Read(buffer, 0, buffer.Length);

                string cedula = Encoding.ASCII.GetString(buffer, 0, leidos);
                Log("Consulta recibida: " + cedula);

                string respuesta;

                // Validacion de formato
                if (!cedula.All(char.IsDigit))
                {
                    // Codigo 4 = Formato inválido
                    respuesta = "4".PadRight(57, ' ');
                }
                else
                {
                    var persona = Padron.Buscar(cedula);

                    if (persona == null)
                    {
                        // Codigo 3 = Persona no registrada
                        respuesta = "3".PadRight(57, ' ');
                    }
                    else if (persona.Fallecido)
                    {
                        // Codigo 2 = Persona fallecida
                        respuesta = "2".PadRight(57, ' ');
                    }
                    else
                    {
                        // Codigo 1 = listo                       
                        respuesta =
                            "1" +
                            persona.Nombre.PadRight(30, ' ') +
                            persona.NumeroMesa.PadRight(6, ' ') +
                            persona.CentroVotacion.PadRight(20, ' ');
                    }
                }

                byte[] datos = Encoding.ASCII.GetBytes(respuesta);
                stream.Write(datos, 0, datos.Length);

                Log("Respuesta enviada: " + respuesta);
            }
            catch (Exception ex)
            {
                Log("Error con cliente: " + ex.Message);
            }
            finally
            {
                cliente.Close();

                ClientesConectados--;

                if (OnCambioClientes != null)
                    OnCambioClientes(ClientesConectados);
            }
        }

        private void Log(string mensaje)
        {
            if (OnLog != null)
                OnLog(DateTime.Now.ToString("HH:mm:ss") + " - " + mensaje);
        }
       


    }

}
