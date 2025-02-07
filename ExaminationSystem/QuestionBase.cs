namespace ExaminationSystem
{
    public abstract class QuestionBase : ICloneable, IComparable<QuestionBase>
    {
        public string QuestionHeader { get; set; }
        public string QuestionBody { get; set; }
        public int Mark { get; set; }
        public Answer[] AnswersList { get; set; }
        public int[] RightAnswerIds { get; set; }
        public int ChosenAnswer { get; set; }

        protected QuestionBase(string qustionHeader, string questionBody, int mark, Answer[] answersList, int[] rightAnswerIds)
        {
            QuestionHeader = qustionHeader;
            QuestionBody = questionBody;
            Mark = mark;
            AnswersList = answersList;
            RightAnswerIds = rightAnswerIds;
        }

        public abstract void ShowQuestion();

        public object Clone()
        {
            return MemberwiseClone();
        }

        public int CompareTo(QuestionBase otherQuestion)
        {
            if (otherQuestion == null) return 1;
            return Mark.CompareTo(otherQuestion.Mark);
        }

        public override string ToString()
        {
            return $"Header: {QuestionHeader}, Body: {QuestionBody}, Mark: {Mark}";
        }
    }
}
