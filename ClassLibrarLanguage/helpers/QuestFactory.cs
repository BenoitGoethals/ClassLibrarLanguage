using System;
using System.Collections.Generic;
using ClassLibrarLanguage.model;

namespace ClassLibrarLanguage.helpers
{
    public interface IQuestFactory
    {
        Quest MakeQuest();
    }

    public sealed class QuestFactory : IQuestFactory
    {
        private readonly Random _rnd=new Random();
        private readonly ILoader _loader;
        private IList<Tuple<string, string>> _tuple;

        public Quest MakeQuest()
        {
           var quesTuple= _tuple[_rnd.Next(_tuple.Count)];
           return new Quest(){Question = new Question(){Problem = quesTuple.Item1,Awnser = quesTuple.Item2}};
        }

        public QuestFactory()
        {
            _tuple = _loader.GetData(@"d:/data/cv.csv");
        }


        public override string ToString()
        {
            return $"{nameof(_tuple)}: {_tuple}";
        }
    }
}