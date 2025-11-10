namespace LoginManagmentWEB.Models
{
    public class ActivityDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
    }
}
