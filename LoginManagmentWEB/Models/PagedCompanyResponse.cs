namespace LoginManagmentWEB.Models
{
    public class PagedCompanyResponse
    {
        public List<CompanyDto> Items { get; set; } = new();
        public int TotalCount { get; set; }
    }
}
