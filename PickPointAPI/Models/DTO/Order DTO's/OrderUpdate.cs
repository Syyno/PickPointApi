using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PickPointAPI.Models
{
    public class OrderUpdate
    {
        [Required]
        public int Number { get; set; } //номер заказа
        [Required]
        [MaxLength(10)]
        public string[] Content { get; set; } //состав заказа (массив товаров)
        [Required]
        public decimal Cost { get; set; } //стоимость заказа
        [Required]
        public int PostamatNumber { get; set; } //номер постамата доставки
        [Required]
        [RegularExpression(@"^\+7[0-9]{3}-[0-9]{3}-[0-9]{2}-[0-9]{2}$")] // +7XXX-XXX-XX-XX
        public string CustomerTelephoneNumber { get; set; } //номер телефона получателя
        [Required]
        public string CustomerFullName { get; set; } // ФИО получателя
    }
}
