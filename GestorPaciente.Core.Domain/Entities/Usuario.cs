﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string TipoUsuario { get; set; }
    }
}
