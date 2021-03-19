using Models.BaseEntity;

namespace Models.Entities
{
    /// <summary>
    /// Вариант ответа на вопрос
    /// </summary>
    public class Answer:Base<long>
    {
        public string TextAnswer { get; set; }
    }
}