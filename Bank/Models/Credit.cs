using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
    public class Credit
    {
        [Key]
        public int CreditID { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        [Display(Name = "Карта")]
        public int CardID { get; set; }
        public BankCard BankCard { get; set; }
        [Display(Name = "Процентная ставка")]
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public decimal Percent { get; set; }
        [Display(Name = "Сумма кредита")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal Summ { get; set; }
        [Display(Name = "Цель кредита")]
        public string Purp { get; set; }
        [Display(Name = "Дата выдачи")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime IssueDate { get; set; }
        [Display(Name = "Выдан до")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DeadLine { get; set; }
        [Display(Name = "Осталось выплатить")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal LeftToPay { get; set; }
    }
}