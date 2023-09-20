﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBAuth.DAO.Models
{
    public class Permission{

        public int IdRole { get; set; }
        public Role? Role { get; set; }
        public int IdFonction { get; set; }
        public Fonction? Fonction { get; set; }
        public string? Nom { get; set; }
        public bool[] Status { get; set; } = Enumerable.Repeat(true, 6).ToArray();

    }
}