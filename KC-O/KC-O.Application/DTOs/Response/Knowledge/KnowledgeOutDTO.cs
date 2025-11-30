namespace KC_O.Application.DTOs.Response.Knowledge
{
    public class KnowledgeOutDTO : BaseOutDto
    {
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public string? Tag { get; set; }
        public bool IsPopular { get; set; }
        public int KnowledgeCategoryId { get; set; }
        public KnowledgeCategoryOutDTO? KnowledgeCategory { get; set; }
    }
}
