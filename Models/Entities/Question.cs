using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Models.BaseEntity;

namespace Models.Entities
{
    /// <summary>
    /// Вопрос анкеты
    /// </summary>
    public class Question:Base<long>
    {
        public string TextQuestion { get; set; }
        public int SurveyId { get;set;}
        public int NumberQuestion { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}