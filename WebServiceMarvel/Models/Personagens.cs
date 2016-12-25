﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceMarvel.Models
{
    public class Url
    {
        public string type { get; set; }
        public string url { get; set; }
    }

    public class Thumbnail
    {
        public string path { get; set; }
        public string extension { get; set; }
    }

    
    public class Comics
    {
        public string available { get; set; }
        public string returned { get; set; }
        public string collectionURI { get; set; }
        public IList<Item> items { get; set; }
    }

    public class Item
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

    public class Stories
    {
        public string available { get; set; }
        public string returned { get; set; }
        public string collectionURI { get; set; }
        public IList<Item> items { get; set; }
    }


    public class Events
    {
        public string available { get; set; }
        public string returned { get; set; }
        public string collectionURI { get; set; }
        public IList<Item> items { get; set; }
    }

 
    public class Series
    {
        public string available { get; set; }
        public string returned { get; set; }
        public string collectionURI { get; set; }
        public IList<Item> items { get; set; }
    }

    public class Result
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string modified { get; set; }
        public string resourceURI { get; set; }
        public IList<Url> urls { get; set; }
        public Thumbnail thumbnail { get; set; }
        public Comics comics { get; set; }
        public Stories stories { get; set; }
        public Events events { get; set; }
        public Series series { get; set; }
    }

    public class Data
    {
        public string offset { get; set; }
        public string limit { get; set; }
        public string total { get; set; }
        public string count { get; set; }
        public IList<Result> results { get; set; }
    }

    public class Personagens
    {
        public string code { get; set; }
        public string status { get; set; }
        public string copyright { get; set; }
        public string attributionText { get; set; }
        public string attributionHTML { get; set; }
        public Data data { get; set; }
        public string etag { get; set; }
    }
}