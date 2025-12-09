using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_2_SERVIDOR.Logica
{
    public class Cla_Padron
    {
        private const string ArchivoPadron = @"C:\padron\padron.txt";

        public class PersonaPadron
        {
            public string Cedula { get; set; }
            public string Nombre { get; set; }
            public string NumeroMesa { get; set; }
            public string CentroVotacion { get; set; }
            public bool Fallecido { get; set; }
        }

        private Dictionary<string, PersonaPadron> padron =
            new Dictionary<string, PersonaPadron>();

        public Cla_Padron()
        {
            CargarDesdeArchivo();
        }
        public bool Grabar(string cedula, string nombre, string mesa, string centro, bool fallecido)
        {
            if (padron.ContainsKey(cedula))
            {
                var p = padron[cedula];
                p.Nombre = nombre;
                p.NumeroMesa = mesa;
                p.CentroVotacion = centro;
                p.Fallecido = fallecido;
            }
            else
            {
                padron.Add(cedula, new PersonaPadron
                {
                    Cedula = cedula,
                    Nombre = nombre,
                    NumeroMesa = mesa,
                    CentroVotacion = centro,
                    Fallecido = fallecido
                });
            }

            GuardarEnArchivo();
            return true;
        }


        public bool Eliminar(string cedula)
        {
            if (!padron.ContainsKey(cedula))
                return false;

            padron[cedula].Fallecido = true;

            GuardarEnArchivo();
            return true;
        }

  
        public PersonaPadron Buscar(string cedula)
        {
            if (padron.TryGetValue(cedula, out var persona))
                return persona;

            return null;
        }

        private void CargarDesdeArchivo()
        {
            if (!File.Exists(ArchivoPadron))
                return;

            var lineas = File.ReadAllLines(ArchivoPadron);

            foreach (var linea in lineas)
            {
                try
                {
                    var datos = linea.Split('|');

                    var persona = new PersonaPadron
                    {
                        Cedula = datos[0],
                        Nombre = datos[1],
                        NumeroMesa = datos[2],
                        CentroVotacion = datos[3],
                        Fallecido = bool.Parse(datos[4])
                    };

                    if (!padron.ContainsKey(persona.Cedula))
                        padron.Add(persona.Cedula, persona);
                }
                catch
                {
                    continue;
                }
            }
        }

  
        private void GuardarEnArchivo()
        {
            List<string> lineas = new List<string>();

            foreach (var p in padron.Values)
            {
                lineas.Add(
                    $"{p.Cedula}|{p.Nombre}|{p.NumeroMesa}|{p.CentroVotacion}|{p.Fallecido}"
                );
            }

            File.WriteAllLines(ArchivoPadron, lineas);
        }

      
    }
}
