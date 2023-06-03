using ServiceAbstract;

namespace BLL
{
    public class Source : IModel
    {
        public int StorageId { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public SourceType Type { get; set; }
        public Storage Storage { get; set; }
        public int Id { get; set; }
    }
    public enum SourceType
    {
        Book,
        Document,
        Video,
        Audio
    }
}