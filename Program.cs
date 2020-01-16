using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            WebPageParser WPP = new WebPageParser();
            StreamReader srt = new StreamReader("C:/Users/Alex/OneDrive/421/true-url-articles.txt");
            StreamReader srf = new StreamReader("C:/Users/Alex/OneDrive/421/fake-url-articles.txt");

            StreamReader srcommonWords = new StreamReader("C:/Users/Alex/OneDrive/421/shortList.txt");
            StreamReader srmostcommonWords = new StreamReader("C:/Users/Alex/OneDrive/421/mostcommonwords.txt");

            StreamWriter wekaFile = new StreamWriter("C:/Users/Alex/OneDrive/421/shortwekadatas.arff");
            StreamWriter shortList = new StreamWriter("C:/Users/Alex/OneDrive/421/shortList.txt");

            List<string> trueUrls = new List<string>();
            List<string> fakeUrls = new List<string>();

            List<string> trueArts = new List<string>();
            List<string> fakeArts = new List<string>();

            List<string> commonWords = new List<string>();
            HashSet<string> mostCommonWords = new HashSet<string>();
            List<string> shortListWords = new List<string>();

            string line = string.Empty;
            while ((line = srt.ReadLine()) != null)
                trueUrls.Add(line);

            while ((line = srf.ReadLine()) != null)
                fakeUrls.Add(line);

            while ((line = srmostcommonWords.ReadLine()) != null)
                mostCommonWords.Add(line);


            wekaFile.WriteLine("@relation articleClass");

            //Console.WriteLine("https://www.cbc.ca/news/indigenous/fn-rights-framework-1.4905705");
            //var art = WPP.getArticleWithCommonWords("https://www.cbc.ca/news/indigenous/fn-rights-framework-1.4905705", commonWords, mostCommonWords);


            while ((line = srcommonWords.ReadLine()) != null)
            {
                commonWords.Add(line);
                string app = "@attribute " + line + " numeric";
            }

            wekaFile.WriteLine("@attribute s_class {true, false}");
            wekaFile.WriteLine();
            wekaFile.WriteLine();
            wekaFile.WriteLine();
            wekaFile.WriteLine();
            wekaFile.WriteLine("@data");

            foreach (string s in trueUrls)
            {
                Console.WriteLine(s);
                HashSet<String> art = WPP.getArticleWithCommonWords(s, commonWords, mostCommonWords);
                foreach (var word in commonWords)
                {
                    if (art.Contains(word))
                    {
                        //Console.WriteLine(word);
                        wekaFile.Write("1,");
                        if (!shortListWords.Contains(word))
                            shortListWords.Add(word);
                    }
                    else
                        wekaFile.Write("0,");

                    wekaFile.Flush();

                }
                wekaFile.WriteLine("true");
                wekaFile.Flush();
            }

            foreach (string s in fakeUrls)
            {
                Console.WriteLine(s);
                HashSet<String> art = WPP.getArticleWithCommonWords(s, commonWords, mostCommonWords);
                foreach (var word in commonWords)
                {
                    if (art.Contains(word))
                    {
                        wekaFile.Write("1,");
                        if (!shortListWords.Contains(word))
                            shortListWords.Add(word);
                    }
                    else
                        wekaFile.Write("0,");

                    wekaFile.Flush();

                }
                wekaFile.WriteLine("false");
                wekaFile.Flush();
            }

            //shortListWords.Sort();
            //foreach (string s in shortListWords)
            //{
            //    shortList.WriteLine(s);
            //    shortList.Flush();
            //}

        }
    }
    

    
}
