

using ServiceAbstract;

namespace BLL
{
    public class Storage : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}