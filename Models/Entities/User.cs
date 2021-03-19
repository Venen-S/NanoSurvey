using Models.BaseEntity;

namespace Models.Entities
{
    public class User:Base<int>
    {
        public string Name { get; set; }
    }
}