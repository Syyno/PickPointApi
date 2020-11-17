using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace PickPointAPI.Models
{
    public class PostamatStore
    {
        private readonly string _number;
        [Required]
        public string Number => _number; //номер постамата
        [Required]
        public string Address { get; set; }// адрес постамата
        [Required]
        public bool Status { get; set; } // статус постамата (рабочий = true)

        public PostamatStore(string number)
        {
            _number = number;
        }
    }
}
