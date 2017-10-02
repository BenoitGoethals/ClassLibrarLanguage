using System.Runtime.Serialization;

namespace ClassLibrarLanguage.model
{
    [DataContract]
    public class Question
    {
        [DataMember]
        public ulong Id { get; set; }
        [DataMember]
        public string Problem { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public string Awnser { get; set; }


        public Question(string problem, string awnser)
        {
            Problem = problem;
            Awnser = awnser;
        }

        public Question(string problem, string awnser,string image)
        {
            Problem = problem;
            Awnser = awnser;
            Image = image;
        }

        public Question()
        {
        }

        protected bool Equals(Question other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Question) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }



        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Problem)}: {Problem}, {nameof(Awnser)}: {Awnser}";
        }
    }
}