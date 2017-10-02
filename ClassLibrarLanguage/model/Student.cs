using System;
using System.Runtime.Serialization;

namespace ClassLibrarLanguage.model
{
    [DataContract]
    public class Student : IComparable<Student>, IComparable
    {
        [DataMember]
        public ulong Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ForName { get; set; }
        [DataMember]
        public string StudentNbr { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }

        public Student()
        {
        }

        public Student(string name, string forName, string studentNbr, string username, string password)
        {
            Name = name;
            ForName = forName;
            StudentNbr = studentNbr;
            Username = username;
            Password = password;
        }

        protected bool Equals(Student other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Student) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }


        public int CompareTo(Student other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return string.Compare(StudentNbr, other.StudentNbr, StringComparison.Ordinal);
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            if (!(obj is Student)) throw new ArgumentException($"Object must be of type {nameof(Student)}");
            return CompareTo((Student) obj);
        }


        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(ForName)}: {ForName}, {nameof(StudentNbr)}: {StudentNbr}, {nameof(Username)}: {Username}, {nameof(Password)}: {Password}";
        }
    }
}