using System.ComponentModel.DataAnnotations.Schema;
using Models.BaseEntity;

namespace Models.Entities
{
    public class Result:Base<long>
    {
        public int UserId { get; set; }
        public int InterviewId { get; set; }
        public int SurveysId { get; set; }
        public long QuestionsId { get; set; }
        public long AnswersId { get; set; }
        public int QuestionNumb { get; set; }
        public User User { get; set; }
        public Interview Interview { get; set; }
        public Survey Surveys { get; set; }
        public Question Questions { get; set; }
        public Answer Answers { get; set; }
    }
}