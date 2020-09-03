using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Bank.Models
{
    public class Transaction
    {
        [Key]
        [Display(Name = "Номер транзакции")]
        public int TransactionID { get; set; }
        public int CardId { get; set; }
        [ForeignKey("CardId")]
        public BankCard BankCard { get; set; }
        [Display(Name = "Номер карты")]
        public string CardNumber { get; set; }
        [Display(Name = "Вид транзакции")]
        public string TransactionType { get; set; }
        [Display(Name = "Номер счета получателя")]
        public string RecipientAccount { get; set; }
        [Display(Name = "ИНН получателя")]
        public string ITN { get; set; }
        //[DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:C0}")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        [Display(Name = "Сумма перевода")]
        public decimal Summ { get; set; }
        [Display(Name = "Валюта перевода")]
        public string Currency { get; set; }
        [Display(Name = "Комментарий")]
        public string Comment { get; set; }
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        [Display(Name = "Перевести на")]
        public string CardNumber2 { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }
    }

    public enum OperationType
    {
        [Description("Перевод между счетами")]
        Перевод_Между_Счетами,
        [Description("Перевод организации")]
        Перевод_Организации,
        [Description("Перевод частному лицу")]
        Перевод_Частному_Лицу,
        [Description("Пополнение баланса телефона")]
        Пополнение_Баланса_Телефона,
    }
}