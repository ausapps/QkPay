using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QkPay.Models
{
    public class User
    {
        public string Id { get; set; }

        public int Pin { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Birthday { get; set; }

        public string Gender { get; set; }

        public string Passport { get; set; }

        public string Avatar { get; set; }
    }
}

