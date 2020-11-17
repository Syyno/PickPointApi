using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PickPointAPI.Util;

namespace PickPointAPI.Models.DTO.Order_DTO_s
{
    public class OrderCreate
    {
        [Required]
        public int Number { get; set; } //номер заказа
        [Range(1,6)]
        [Required]
        public int Status { get; set; }
        [Required]
        [MaxLength(10)]
        public string[] Content { get; set; } //состав заказа (массив товаров)
        [Required]
        public decimal Cost { get; set; } //стоимость заказа
        [Required]
        [PostamatNumberValidation]
        public int PostamatNumber { get; set; } //номер постамата доставки
        [Required]
        [RegularExpression(@"^\+7[0-9]{3}-[0-9]{3}-[0-9]{2}-[0-9]{2}$")] // +7XXX-XXX-XX-XX
        public string CustomerTelephoneNumber { get; set; } //номер телефона получателя
        [Required]
        public string CustomerFullName { get; set; } // ФИО получателя
    }
}
