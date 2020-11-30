using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoP2
{
    class Config
    {
        private string RutaArchivo()
        {
            string pathName = @"usuarios.txt";
            return System.IO.Path.GetFullPath(pathName);
        }

        public string Md5(string txt)
        {
            string res = string.Empty;
            byte[] md5 = System.Text.Encoding.Unicode.GetBytes(txt);
            res = Convert.ToBase64String(md5);
            return res;
        }

        public void VeriTxt()
        {
            try
            {
                string ruta = RutaArchivo();
                if (!File.Exists(ruta))
                {
                    File.Create(ruta).Dispose();
                    Persona p = new Persona();
                    p.Id = GenerarId();
                    p.Nombres = "Admin";
                    p.Apellido = "Admin";
                    p.Genero = "Admin";
                    p.FNaci = DateTime.Parse("1999-03-06");
                    p.Usuario = "admin";
                    p.Contra = Md5("12");
                    InsertaDato(p);
                }

            }
            catch (Exception ex)
            {

            }
        }

        public string GenerarId()
        {
            string id = Guid.NewGuid().ToString();
            return id;
        }

        public void InsertaDato(Persona p)
        {
            string ruta = RutaArchivo();
            string dato = p.Id + ',' + p.Nombres + ',' + p.Apellido + ',' + p.Genero + ',' + p.FNaci + ',' + p.Usuario + ',' + p.Contra;
            StreamWriter sw = File.AppendText(ruta);
            sw.WriteLine(dato);
            sw.Close();
        }

        public bool ValidarUsuario(string usuario, string contra)
        {
            string ruta = RutaArchivo();
            bool resultado = false;
            string[] datosUsuario;
            StreamReader sr = File.OpenText(ruta);
            string linea = sr.ReadLine();
            while (linea != null)
            {
                datosUsuario = linea.Split(',');
                if (usuario == datosUsuario[5] && contra == datosUsuario[6])
                {
                    resultado = true;
                    break;
                }
                linea = sr.ReadLine();
            }
            sr.Close();
            return resultado;
        }
    }
}
