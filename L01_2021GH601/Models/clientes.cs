﻿using System.ComponentModel.DataAnnotations;

namespace L01_2021GH601.Models
{
    public class clientes
    {
        [Key]
        public int clienteId { get; set; }
        public string? nombreCliente { get; set; }
        public string? direccion { get; set; }
    }
}
