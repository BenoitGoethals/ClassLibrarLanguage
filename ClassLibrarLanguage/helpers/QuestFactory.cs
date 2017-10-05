using System;
using System.Collections.Generic;
using ClassLibrarLanguage.model;

namespace ClassLibrarLanguage.helpers
{
    public interface IQuestFactory
    {
        Quest MakeQuest();
    }

    public  class QuestFactory : IQuestFactory
    {
        private readonly Random _rnd=new Random();
        private  ILoader _loader;
        private IList<Tuple<string, string>> _tuple=new List<Tuple<string, string>>();

      
        public Quest MakeQuest()
        {
           var quesTuple= _tuple[_rnd.Next(_tuple.Count)];
           return new Quest(){Question = new Question(){Problem = quesTuple.Item1,Awnser = quesTuple.Item2}};
        }

        public QuestFactory(ILoader loader)
        {
            _loader = loader;
            _tuple = _loader.GetData(@"d:/data/cv.csv");
        }

        public QuestFactory()
        {
        }


        public override string ToString()
        {
            return $"{nameof(_tuple)}: {_tuple}";
        }
    }
}