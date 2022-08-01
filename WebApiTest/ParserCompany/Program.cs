using HtmlAgilityPack;

var html = @"https://companies.devby.io";
HtmlWeb web = new HtmlWeb();
var htmlDoc = web.Load(html);
var nodes = htmlDoc.DocumentNode.SelectNodes("//a");
if (nodes is not null)
{
    foreach (HtmlNode item in nodes)
    {
        Console.WriteLine(item.InnerText);
    }
}
