using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ClassLibrarLanguage.helpers;
using ClassLibrarLanguage.model;

namespace ClassLibrarLanguage
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class QuestionsService : IQuestionsService
    {

        private IQuestFactory _questFactory;

        public QuestionsService(IQuestFactory questFactory)
        {
            _questFactory = questFactory;
        }

        private Session _session;

        public IQuestFactory QuestFactory { get => _questFactory; set => _questFactory = value; }

        public Session MakeSession(DateTime dateTime, Student student)
        {
            _session = new Session(dateTime, student);

            return _session;
        }
    }
}
