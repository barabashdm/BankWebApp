using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
        [Display(Name = "Фамилия")]
        public string Firstname { get; set; }
        [Display(Name = "Имя")]
        public string Secondname { get; set; }
        [Display(Name = "Отчество")]
        public string Thirdname { get; set; }
        public string City { get; set; }
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public List<Card> Cards { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Credit> credits { get; set; }
        public DbSet<BankCard> bankCards { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> transactions { get; set; }
        public DbSet<BankBox> bankboxes { get; set; }
        public IEnumerable ApplicationUsers { get; internal set; }
    }
}