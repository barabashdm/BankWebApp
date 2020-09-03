using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
    public class EditModel
    {
        [Display(Name ="Фамилия")]
        public string Firstname { get; set; }
        [Display(Name = "Имя")]
        public string Secondname { get; set; }
        [Display(Name = "Отчество")]
        public string Thirdname { get; set; }
        [Display(Name = "Город")]
        public string City { get; set; }
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Серия паспорта")]
        public string PassportSeries { get; set; }
        [Display(Name = "Номер паспорта")]
        public string PassportNumber { get; set; }
    }
}