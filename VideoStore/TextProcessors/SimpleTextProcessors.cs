namespace VideoStore
{
    public class SimpleTextProcessors : ITextProcessor
    {
        public string AddFooter(string text)
        {
            throw new System.NotImplementedException();
        }

        public string AddHeader(string text)
        {
            return AddLine(text);
        }

        public string AddLine(string text)
        {
            return $"{text}\n";
        }

        public string AddTitle(string text)
        {
            throw new System.NotImplementedException();
        }
    }
}
