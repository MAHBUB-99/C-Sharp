namespace KC_O.Application.DTOs.Response
{
    public abstract class BaseOutDto
    {
        public int Id { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
