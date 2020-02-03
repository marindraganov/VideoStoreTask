namespace VideoStore
{
    public class HTMLTextProcessor : ITextProcessor
    {
        public string Add(string text)
        {
            return text;
        }

        public string AddFooter(string text)
        {
            return $"<footer>{text}</footer>";
        }

        public string AddHeader(string text)
        {
            return $"<h1>{text}</h1>\n";
        }

        public string AddLine(string text)
        {
            return $"<p>{text}</p>\n";
        }

        public string AddTitle(string text)
        {
            return $"<b>{text}</b>";
        }
    }
}
