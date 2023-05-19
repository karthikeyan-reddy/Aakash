using SampleMVCApp.Data;
namespace SampleMVCApp.Models
{
    public interface IDBFirstComponent
    {
        void AddNewEmployee(TblEmployee emp);
        List<TblEmployee> GetAllEmployees();
    }
    public class DBFirstComponent : IDBFirstComponent
    {
        public void AddNewEmployee(TblEmployee emp)
        {
            var context = new KarthikContext();
            context.TblEmployees.Add(emp);
            context.SaveChanges();
        }
        public List<TblEmployee> GetAllEmployees()
        {
            var context = new KarthikContext();
            var data = context.TblEmployees.ToList();
            return data;
        }
    }
}