using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrarLanguage.model;
using Xunit;

namespace ClassLibrarLanguageTests.model
{
    public class StudentTests
    {
        [Fact()]
        public void StudentTest()
        {
            Student student = new Student() { ForName = "dfds", Id = 1, Name = "dsdf", Password = "fdsf", StudentNbr = "44", Username = "sdfds" };
            Student student2 = new Student() { ForName = "dfds", Id = 2, Name = "dsdf", Password = "fdsf", StudentNbr = "445", Username = "sdfds" };

            Assert.NotEqual(student,student2);
        }


        [Fact()]
        public void StudentCompareTest()
        {
            Random rnd=new Random();
            ISet<Student> studentsList = new SortedSet<Student>();
        
            for (int i = 0; i < 50; i++)
            {
                var student = new Student() { ForName = "dfds", Id = (ulong) i, Name = "dsdf"+i, Password = "fdsf", StudentNbr = "44"+i, Username = "sdfds"+i+ rnd.Next(520)};
                studentsList.Add(student);
            }

           Assert.True(studentsList.ToList().OrderByDescending(x => x.StudentNbr).SequenceEqual(studentsList.Reverse()));
           



        }
        }
    }
