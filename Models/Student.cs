﻿using System;
using System.Collections.Generic;

namespace Domaine.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        public string Prenom { get; set; } = null!;
    }
}
