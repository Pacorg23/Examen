using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaHAcimiento { get; set; }
        public char Sexo { get; set; }

    }
}