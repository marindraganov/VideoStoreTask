namespace VideoStore
{
    public class SimpleTextProcessors : ITextProcessor
    {
        public string AddFooter(string text)
        {
            return text;
        }

        public string AddHeader(string text)
        {
            return AddLine(text);
        }

        public string AddLine(string text)
        {
            return $"{text}\n";
        }

        public string Add(string text)
        {
            return text;
        }

        public string AddTitle(string text)
        {
            return $"\t{text}\t";
        }
    }
}
