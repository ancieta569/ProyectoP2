using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoP2
{
    class Persona
    {
        private string id, nombres, apellido, genero, usuario, contra;
        private DateTime fNaci;

        public Persona()
        {

        }

        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Genero { get => genero; set => genero = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contra { get => contra; set => contra = value; }
        public DateTime FNaci { get => fNaci; set => fNaci = value; }
        public string Id { get => id; set => id = value; }
    }
}
