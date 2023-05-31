﻿using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Dept? Department { get; set; }
        public byte[] photo { get; set; }
        [NotMapped]
        public IFormFile FilePath { get; set; }
    }


}

