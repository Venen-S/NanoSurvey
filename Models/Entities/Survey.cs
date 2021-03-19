using System.Collections.Generic;
using Models.BaseEntity;

namespace Models.Entities
{
    /// <summary>
    /// Анкета опроса
    /// </summary>
    public class Survey:Base<int>
    {
        public string Name { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}