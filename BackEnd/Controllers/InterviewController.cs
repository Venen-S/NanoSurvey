using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.ViewModels;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/")]
    public class InterviewController : ControllerBase
    {
        private readonly IAppContext _appContext;
        public InterviewController(IAppContext appContext)
        {
            _appContext = appContext;
        }

        /// <summary>
        /// Получение данных вопроса
        /// </summary>
        /// <param name="id">идентификатор вопроса</param>
        /// <returns></returns>
        [HttpGet]
        [Route("question/{questionId:long}")]
        public Question GetQuestionData(int questionId)
        {
            var request = _appContext.Questions
                .Include(q => q.Answers)
                .FirstOrDefaultAsync(q => q.Id == questionId)
                .Result;
            return request;
        }

        /// <summary>
        /// Сохранение результатов ответа
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("saveresult")]
        public async Task<long?> SaveResultAnswerAsync(ResultAnswerViewModel result)
        {
            var flag= await CheckingInterview(result);
            //Тут должна быть логика типо если флаг равен правда то занести в логги и бла бла бла еще 100500 операций
            //которые тут вообще не нужны, добавил флаг и возвращаемый тип у метода только потому что асинхронные методы
            //плохо уживаються с возвращаемым значением типа void

            //Добавляем в БД результаты
            await _appContext.Results.AddAsync(new Result
            {
                UserId = result.UserId,
                InterviewId = result.InterviewId,
                SurveysId = result.SurveysId,
                QuestionsId = result.QuestionId,
                AnswersId = result.AnswerId,
                QuestionNumb = result.QuestionNumb
            });
            await _appContext.SaveChangesAsync();

            var quest = GetNextQuestion(result);
            return quest;
        }

        //Если не встречаем в БД такое интервью, то создаем новое
        private async Task<bool> CheckingInterview(ResultAnswerViewModel result)
        {
            var count = _appContext.Interviews
                .Where(i => i.UserId == result.UserId && i.SurveyId == result.SurveysId);
            
            if (count.ToList().Count==0)
            {
                var id= await _appContext.Interviews.AddAsync(new Interview
                {
                    DateTimeInterview = DateTime.Now,
                    UserId = result.UserId,
                    SurveyId = result.SurveysId
                });
                await _appContext.SaveChangesAsync();
                result.InterviewId = id.Entity.Id;
                return true;
            }
            else
            {
                result.InterviewId = count.First().Id;
                return false;
            }
        }

        /// <summary>
        /// Получаем следующий вопрос
        /// </summary>
        /// <param name="result"></param>
        /// <returns>идентификатор вопроса, если следующего вопроса нет вернет null</returns>
        private long GetNextQuestion(ResultAnswerViewModel result)
        {
            var quest = _appContext.Questions
                .Where(q => q.SurveyId == result.SurveysId);
            if (quest.Max(q => q.NumberQuestion) == result.QuestionNumb)
            {
                return 0;
            }
            else
            {
                ++result.QuestionNumb;
                var res = _appContext.Questions
                    .Where(q=>q.SurveyId==result.SurveysId)
                    .FirstOrDefault(q => q.NumberQuestion == result.QuestionNumb);
                return res.Id;
            }
        }
    }
}
