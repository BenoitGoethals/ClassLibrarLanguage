using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrarLanguage.model;
using Xunit;

namespace ClassLibrarLanguageTests.model
{
    public class SessionTests
    {
       

        [Fact()]
        public void AddTest()
        {
            Student student = new Student(){ForName = "dfds", Id = 1, Name = "dsdf", Password = "fdsf", StudentNbr = "44", Username = "sdfds"};
            Session session=new Session(DateTime.Now,student );
            
            Assert.Equal(student,session.Student);
        }

        [Fact()]
        public void QuestsTest()
        {
            Question question=new Question("test1","test");
            Quest quest = new Quest(question, "test");
            Student student = new Student() { ForName = "dfds", Id = 1, Name = "dsdf", Password = "fdsf", StudentNbr = "44", Username = "sdfds" };
            Session session = new Session(DateTime.Now, student);
            session.Add(quest);
            Assert.True(session.Quests().Contains(quest) );
            Assert.True(session.Quests().Single(x => x.Question.Equals(question)).Question.Equals(question));
           
        }

        [Fact()]
        public void SuccessfultQuestsTest()
        {
            Student student = new Student() { ForName = "dfds", Id = 1, Name = "dsdf", Password = "fdsf", StudentNbr = "44", Username = "sdfds" };
            Session session = new Session(DateTime.Now, student);
         
            for (int i = 0; i < 50; i++)
            {
                var quest = new Quest(new Question("test"+i,"test"+i),"test" +i){Id = (ulong) i};
                Assert.True(quest.Ok());
                session.Add(quest);
            }
            for (int i = 0; i < 20; i++)
            {
                var quest = new Quest(new Question("test" + i, "test" + i), "false" + i) { Id = (ulong)i };
                Assert.True(!quest.Ok());
                session.Add(quest);
            }


          
          
            Assert.True(session.Passed());
        }

        [Fact()]
        public void PassedTest()
        {
            Student student = new Student() { ForName = "dfds", Id = 1, Name = "dsdf", Password = "fdsf", StudentNbr = "44", Username = "sdfds" };
            Session session = new Session(DateTime.Now, student);

            Assert.True(session.Passed());
            for (int i = 0; i < 50; i++)
            {
                var quest = new Quest(new Question("test" + i, "test" + i), "test" + i) { Id = (ulong)i };
                Assert.True(quest.Ok());
                session.Add(quest);
            }
            for (int i = 0; i < 20; i++)
            {
                var quest = new Quest(new Question("test" + i, "test" + i), "false" + i) { Id = (ulong)i };
                Assert.True(!quest.Ok());
                session.Add(quest);
            }


           
        }


        [Fact()]
        public void NotPassedTest()
        {
            Student student = new Student() { ForName = "dfds", Id = 1, Name = "dsdf", Password = "fdsf", StudentNbr = "44", Username = "sdfds" };
            Session session = new Session(DateTime.Now, student);

            for (int i = 0; i < 10; i++)
            {
                var quest = new Quest(new Question("test" + i, "test" + i), "test" + i) { Id = (ulong)i };
                Assert.True(quest.Ok());
                session.Add(quest);
            }
            for (int i = 0; i < 50; i++)
            {
                var quest = new Quest(new Question("test" + i, "test" + i), "false" + i) { Id = (ulong)i };
                Assert.True(!quest.Ok());
                session.Add(quest);
            }


            
            Assert.False(session.Passed());
        }



        [Fact()]
        public void SuccessfulTest()
        {

            Student student = new Student() { ForName = "dfds", Id = 1, Name = "dsdf", Password = "fdsf", StudentNbr = "44", Username = "sdfds" };
            Session session = new Session(DateTime.Now, student);

            for (int i = 0; i < 10; i++)
            {
                var quest = new Quest(new Question("test" + i, "test" + i), "test" + i) { Id = (ulong)i };
                Assert.True(quest.Ok());
                session.Add(quest);
            }
            for (int i = 0; i < 50; i++)
            {
                var quest = new Quest(new Question("test" + i, "test" + i), "false" + i) { Id = (ulong)i };
                Assert.True(!quest.Ok());
                session.Add(quest);
            }


            Assert.True(session.Successful()==10);
            Assert.True(session.UnSuccessful() == 50);
        }

        

        [Fact()]
        public void EqualsTest()
        {
            Student student = new Student() { ForName = "dfds", Id = 1, Name = "dsdf", Password = "fdsf", StudentNbr = "44", Username = "sdfds" };
            Session session = new Session(DateTime.Now, student){Id = 1};
            Session session2 = new Session(DateTime.Now, student) { Id = 2 };

            Assert.NotEqual(session,session2);
        }

      
    }
}