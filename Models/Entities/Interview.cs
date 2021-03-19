using System;
using System.ComponentModel.DataAnnotations.Schema;
using Models.BaseEntity;

namespace Models.Entities
{
    public class Interview:Base<int>
    {
        public DateTime DateTimeInterview { get; set; }
        public int UserId { get; set; }
        public int SurveyId { get; set; }
        public User User { get; set; }
        public Survey Survey { get; set; }
    }
}