﻿using System.ComponentModel.DataAnnotations;

namespace L01_2021GH601.Models
{
    public class motorista
    {
        [Key]
        public int motoristaid { get; set; }
        public string nombreMotorista { get; set; }
    }
}
