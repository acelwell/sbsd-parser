using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Article
    {
        private String URLBase;
        private String URLLong;
        private String headline;
        private List<string> author;
        private String text;
        private String publisher;

        //default constructor
        public Article()
        { }

        //overloaded constructor
        public Article(String newURLBase, String newURLLong, String newHeadline, List<string> newAuthor, String newText, String newPublisher)
        {
            URLBase = newURLBase;
            URLLong = newURLLong;
            headline = newHeadline;
            author = newAuthor;
            text = newText;
            publisher = newPublisher;
        }

        public void setURLBase(String newURLBase)
        {
            URLBase = newURLBase;
        }

        public String getURLBase()
        {
            return URLBase;
        }

        public void setURLLong(String newURLLong)
        {
            URLLong = newURLLong;
        }

        public String getURLLong()
        {
            return URLLong;
        }

        public void setHeadline(String newHeadline)
        {
            headline = newHeadline;
        }

        public String getHeadline()
        {
            return headline;
        }

        public void setAuthor(List<string> newAuthor)
        {
            author = newAuthor;
        }

        public List<string> getAuthor()
        {
            return author;
        }

        public void setText(String newText)
        {
            text = newText;
        }

        public String getText()
        {
            return text;
        }

        public void setPublisher(String newPublisher)
        {
            publisher = newPublisher;
        }

        public String getPublisher()
        {
            return publisher;
        }
    }
}
