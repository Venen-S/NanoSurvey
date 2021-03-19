using System.ComponentModel.DataAnnotations;

namespace Models.BaseEntity
{
    /// <summary>
    /// Базовый обобщенный класс
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class Base<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}