namespace LoginManagmentWEB.Models
    {
        public class PagedUsersResponse
        {
            public List<UserDto> Items { get; set; } = new();
            public int TotalCount { get; set; }
        }
    }
