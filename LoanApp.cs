using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using NuGet.Protocol.Plugins;

namespace SampleMVCApp.Models
{
    
    public enum LoanType
    {
        House,Personal , Vehicle
    }
    [Table("tblLoan")]
    public class LoanApp
    {
        [Key]
        public int Id { get; set; }
        public string Applicant { get; set; } = string.Empty;
        public int AmountOfLoan { get; set; } 
        public string Address { get; set;} = string.Empty;
        public string Type { get; set; }= LoanType.House.ToString();
        public bool Eligibility { get; set; } = true;
        public string FailureDescription { get; set; } = string.Empty;
    }
    public class LoanDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string Connection = @"Data Source=W-674PY03-1;Initial Catalog=karthik;Persist Security Info=True;User ID=sa;Password=Password@12345;TrustServerCertificate = True";
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(Connection);
        }
        public DbSet<LoanApp> Loans { get; set; }
    }
    public interface ILoanComponent
    {
        void AddNewLoanApplicant(LoanApp app);
        void UpdateLoanApplicant(LoanApp app);
        void DeleteApplication(int id);
        List<LoanApp> GetApplications();
        List<LoanApp> FindAllEligibleApplications();
        List<LoanApp> FindAllFailedApplications();
    }
    class LoanClass : ILoanComponent
    {
        private readonly LoanDbContext context;
        public LoanClass()
        {
            context = new LoanDbContext();
        }
        public void AddNewLoanApplicant(LoanApp app)
        {
            context.Loans.Add(app);
            context.SaveChanges();
        }

        public void DeleteApplication(int id)
        {
            var loan = context.Loans.FirstOrDefault((p)=>p.Id == id);
            if (loan != null)
            {
               context.Loans.Remove(loan);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("No Details Found to Delete");
            }
        }

        public List<LoanApp> FindAllEligibleApplications()
        {
            var loans = context.Loans.Where((l) => l.Eligibility == true);
            return loans.ToList();
        }

        public List<LoanApp> FindAllFailedApplications()
        {
            var loans = context.Loans.Where((l) => l.Eligibility == false);
            return loans.ToList();
        }

        public List<LoanApp> GetApplications()
        {
            List<LoanApp> data = context.Loans.ToList();
            return data;
        }

        public void UpdateLoanApplicant(LoanApp app)
        {
            var data = context.Loans.FirstOrDefault((p)=>p.Id==app.Id);
            if (data != null)
            {
                data.Address = app.Address;
                data.Applicant = app.Applicant;
                data.Eligibility = app.Eligibility;
                data.FailureDescription = app.FailureDescription;
                data.AmountOfLoan =app .AmountOfLoan;
                data.Type = app.Type;
            }
            context.Loans.Update(data);
            context.SaveChanges();
        }
    }
}
