namespace TestMudBlazor.Contracts
{
    public class ParseUrl
    {
        public static string GetFirstUrlParam(Uri url)
        {

            string regex = "(http[s]?:\\/\\/)?([^\\/\\s]+\\/)(.*)";
            if (url.PathAndQuery == "/projects/10~0-203-73-1908")
                return "yay";
            return "nay";
        }
    }
}
