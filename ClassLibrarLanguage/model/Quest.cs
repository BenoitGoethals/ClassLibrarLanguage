using System;

namespace ClassLibrarLanguage.model
{
    public class Quest : IComparable<Quest>, IComparable
    {
        public ulong Id { get; set; }
        public Question Question { get; set; }
        public string Response { get; set; }


        public bool Ok()
        {
            return Response != null && Question.Awnser.Equals(Response);
        }

        public Quest(Question question, string response)
        {
            Question = question;
            Response = response;
        }


        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Question)}: {Question}, {nameof(Response)}: {Response}";
        }

        public int CompareTo(Quest other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Id.CompareTo(other.Id);
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            if (!(obj is Quest)) throw new ArgumentException($"Object must be of type {nameof(Quest)}");
            return CompareTo((Quest) obj);
        }

        protected bool Equals(Quest other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Quest) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}