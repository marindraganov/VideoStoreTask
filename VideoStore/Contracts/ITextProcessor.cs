namespace VideoStore
{
    public interface ITextProcessor
    {
        string AddHeader(string text);

        string AddTitle(string text);

        string AddFooter(string text);

        string AddLine(string text);

        string Add(string text);
    }
}
