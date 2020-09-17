using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioPrueba.Infrastructure.Service
{
    class DtoKraken<T>
    {
        /// <summary>
        /// Sistema
        /// </summary>
        public string target { get; set; }

        /// <summary>
        /// Operacion
        /// </summary>
        public string operation { get; set; }

        /// <summary>
        /// Datos a enviar
        /// </summary>
        public List<T> data { get; set; }
    }
}
