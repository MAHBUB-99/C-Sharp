namespace KC_O.Application.DTOs.Response.Knowledge
{
    public class KnowledgeCategoryOutDTO : BaseOutDto
    {
        public string? Name { get; set; }
        public List<KnowledgeOutDTO>? Knowledges { get; set; }
    }
}
