﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrarLanguage.model
{
    public class Session
    {
        public ulong Id { get; set; }
        public DateTime DateTime { get; set; }

        public Session(DateTime dateTime, Student student)
        {
            DateTime = dateTime;
            Student = student;
        }


        public Student Student { get; set; }
        private readonly IList<Quest> _quests=new List<Quest>();

        public void Add(Quest quest)
        {
            _quests.Add(quest);
        }

        public IList<Quest> Quests()
        {
            return _quests;
        }

        public IList<Quest> SuccessfultQuests()
        {
            return _quests.Where((w => w.Ok())).ToList();
        }

        public bool Passed()
        {
            return _quests.Count(w => w.Ok())>=_quests.Count/2; 
        }


        public IList<Quest> UnSuccessfulGetQuests()
        {
            return _quests.Where((w => !w.Ok())).ToList();
        }


        public int Successful()
        {
            return _quests.Count(w => w.Ok());
        }

        public int UnSuccessful()
        {
            return _quests.Count(w => !w.Ok());
        }

        public override string ToString()
        {
            return $"{nameof(_quests)}: {_quests}, {nameof(Id)}: {Id}, {nameof(DateTime)}: {DateTime}, {nameof(Student)}: {Student}";
        }

        protected bool Equals(Session other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Session) obj);
        }



        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }


    }
}