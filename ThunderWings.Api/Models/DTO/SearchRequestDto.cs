namespace ThunderWings.Api.Models.DTO
{
    public class SearchRequestDto
    {
        public string? Name { get; set; }
        public string? Role { get; set; }
        public string? Manufacturer { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
