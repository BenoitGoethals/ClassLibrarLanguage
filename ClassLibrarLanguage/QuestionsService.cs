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
        public QuestionsService()
        {
            
        }

        private IQuestFactory QuestFactory;

        private Session _session;

        public Session MakeSession(DateTime dateTime, Student student)
        {
            _session = new Session(dateTime, student);

            return _session;
        }
    }
}
