namespace EmployeeManagementSystem.Models
{
    public class NonWorkingDay
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }  // e.g., "Holiday", "Weekend"
    }
}
