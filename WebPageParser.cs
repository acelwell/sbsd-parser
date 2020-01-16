using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace ConsoleApp1
{
    class WebPageParser
    {
        Article art = new Article();

        public Article PageParser(string url)
        {



            art.setHeadline(getTitle(url));
            art.setURLBase(getURLBase(url));
            art.setURLLong(url);
            //art.setText(getArticle(url));

            Console.WriteLine(art.getHeadline());
            //Console.WriteLine(art.getText());
            Console.WriteLine(art.getURLBase());
            Console.WriteLine(art.getURLLong());

            return art;
        }

        List<string> getAuthor(string url)
        {
            List<string> authors = new List<string>();
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            string html = String.Empty;

            StreamReader sr = new StreamReader(data);

            html = sr.ReadToEnd();
            html = Regex.Replace(html, "><", "> <");
            html = Regex.Replace(html, ">", "> ");
            html = Regex.Replace(html, "<", " <");
            var arti = html.Split(' ');



            return authors;
        }

        String getURLBase(string url)
        {
            string baseLink = string.Empty;

            var words = url.Split('/');

            baseLink = words[2];

            return baseLink;
        }

        String getTitle(string url)
        {
            //HtmlWeb hw = new HtmlWeb();
            //var doc = hw.Load(url);

            //string title = doc.DocumentNode.SelectSingleNode("//head/title").InnerHtml;

            return "";

        }

        public HashSet<string> getArticleWithCommonWords(string url, List<string> commonwords, HashSet<string> mostcommonwords)
        {

            WebRequest request;
            WebResponse response;
            Stream data;
            HashSet<string> artWords = new HashSet<string>();

            if (url == null || url == "")
                return artWords;

            try
            {
                request = WebRequest.Create(url);
                response = request.GetResponse();
                data = response.GetResponseStream();
            }
            catch (WebException ex)
            {
                Console.WriteLine("couldn't retrive article :(");
                return artWords;
            }

            Console.WriteLine(url);

            string html = String.Empty;

            string article = string.Empty;

            StreamReader sr = new StreamReader(data);


            html = sr.ReadToEnd();
            html = Regex.Replace(html, "><", "> <");
            html = Regex.Replace(html, ">", "> ");
            html = Regex.Replace(html, "<", " <");
            html = html.ToLower();
            var arti = html.Split(' ');

            foreach (string word in arti)
            {
                //Console.Write(word);
                if (commonwords.Contains(word) && !mostcommonwords.Contains(word))
                {
                    Console.WriteLine(word);
                    artWords.Add(word);
                }
            }



            return artWords;
        }

        //public String getArticle(string url)
        //{

        //    WebRequest request = WebRequest.Create(url);
        //    WebResponse response = request.GetResponse();
        //    Stream data = response.GetResponseStream();
        //    string html = String.Empty;

        //    string article = string.Empty;

        //    StreamReader sr = new StreamReader(data);

        //    int i = 0;
        //    bool print = false;
        //    char scan = 'a';
        //    char prev = 'a';

        //    html = sr.ReadToEnd();
        //    html = Regex.Replace(html, "><", "> <");
        //    html = Regex.Replace(html, ">", "> ");
        //    html = Regex.Replace(html, "<", " <");
        //    var arti = html.Split(' ');



        //    //Console.WriteLine(link);

        //    for (int a = 0; a < arti.Length; a++)
        //    {
        //        // check for </div class=\... and for <p>
        //        if (arti[a].Contains("<div") && arti[a + 1].Contains("class=\"zn-body__paragraph") ||
        //            arti[a].Contains("<p") && arti[a + 1].Contains("class=\"zn-body__paragraph") ||
        //            arti[a].Contains("<p") && arti[a + 1].Contains("class=\"speakable")||
        //            arti[a].Contains("<p"))
        //        {

        //            a += 2;
        //            print = true;
        //        }
        //        // check for <p> tag
        //        if (arti[a].Contains("<p>"))
        //        {

        //            a += 1;
        //            print = true;
        //        }
        //        // check for closing tag to the paragraph
        //        if ((arti[a].Contains("</div>")) || (arti[a].Contains("</p>")))
        //        {
        //            print = false;
        //        }
        //        // check for imbedded a href and skip it
        //        if (arti[a].Contains("<a"))
        //        {
        //            for (int b = a; !arti[b].Contains("</a>") && b < arti.Length; b++)
        //                a = b;
        //            a += 2;
        //        }
        //        // check for <cite and skip it
        //        if (arti[a].Contains("<cite"))
        //        {
        //            for (int b = a; !arti[b].Contains("</cite>") && b < arti.Length; b++)
        //                a = b;
        //            a += 2;
        //        }
        //        // check for <span
        //        if (arti[a].Contains("<span"))
        //        {
        //            for (int b = a; !arti[b].Contains("</span>") && b < arti.Length; b++)
        //                a = b;
        //            a += 2;
        //        }
        //        // check for <figure
        //        if (arti[a].Contains("<figure"))
        //        {
        //            for (int b = a; !arti[b].Contains("</figure>") && b < arti.Length; b++)
        //                a = b;
        //            a += 2;
        //        }
        //        // check for <script
        //        if (arti[a].Contains("<script"))
        //        {
        //            for (int b = a; !arti[b].Contains("</script>") && b < arti.Length; b++)
        //                a = b;
        //            a += 2;
        //        }
        //        // check for <iframe
        //        if (arti[a].Contains("<iframe"))
        //        {
        //            for (int b = a; !arti[b].Contains("</iframe>") && b < arti.Length; b++)
        //                a = b;
        //            a += 2;
        //        }
        //        // add the current work to the index
        //        if (print)
        //        {
        //            if (arti[a].Contains("speakable"))
        //            {

        //            }
        //            else
        //                article += ' ' + arti[a];
        //        }
        //    }

        //    return article;
        //}
    }
}
