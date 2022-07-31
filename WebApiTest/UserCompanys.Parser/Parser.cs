using HtmlAgilityPack;

namespace WebApiTest;

public class Parser
{
    public List<string> GetInfo()
    {
        HtmlWeb web = new HtmlWeb();
        HtmlDocument document = web.Load("https://avtohomenew.ru/marki-avtomobiley-ix-proizvoditeli.html");

        string table = document.DocumentNode.SelectNodes("//*[@id=\"post-18\"]/div[1]/table/tbody").First().InnerText;
        var array = table.Split("\n\n\n\n\n");
        var list = array.ToList();
        list.RemoveAt(0);

        return list;
    }
}
