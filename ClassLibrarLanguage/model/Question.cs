namespace ClassLibrarLanguage.model
{
    public class Question
    {
        public ulong Id { get; set; }
        public string Problem { get; set; }
        public string Image { get; set; }
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