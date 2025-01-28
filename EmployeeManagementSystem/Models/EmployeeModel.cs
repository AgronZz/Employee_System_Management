using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeModel
    {
        [Key]

        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Salary { get; set; }

        public DateTime ContractSigned { get; set; }

        public DateTime ContractExpired { get; set; }

        public bool isActive { get; set; }
    }
}
