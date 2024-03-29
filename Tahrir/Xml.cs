using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace Tahrir
{
    class xml
    {
        XmlDocument doc = new XmlDocument();
        string Path = System.AppDomain.CurrentDomain.BaseDirectory + "/خط.xml";
        public xml()
        {
            CreateOrLoad();
        }
        void CreateOrLoad()
        {
            
            if (!File.Exists(Path))
            {
                XmlNode root = doc.CreateNode("element", "Pictures", "");
                doc.AppendChild(root);
                XmlNode nastaliq = doc.CreateNode("element", "نستعلیق", "");
                doc.FirstChild.AppendChild(nastaliq);
                XmlNode shekaste = doc.CreateNode("element", "شکسته_نستعلیق", "");
                doc.FirstChild.AppendChild(shekaste);
            }
            else
                doc.Load(Path);
        }
        public bool RegisteredPic(string picname,string font)
        {
           if (!doc.FirstChild.HasChildNodes)
                return false;
            XmlNode fontNode;
            if (font == "نستعلیق")
                fontNode = doc.FirstChild.FirstChild;
            else
                fontNode = doc.FirstChild.ChildNodes[1];
            foreach (XmlNode node in fontNode.ChildNodes)
            {
                if(node.Name==picname)
                {
                    return true;

                }
            }
            return false;
        }
        public void SaveImage(string  word,List<List<Point>> points,string font)
        {
            if (RegisteredPic(word,font))
                return;
            XmlNode root = doc.FirstChild;
            XmlNode fontNode;
            if (font == "نستعلیق")
                fontNode = doc.FirstChild.FirstChild;
            else
                fontNode = doc.FirstChild.ChildNodes[1];
            XmlNode pic = doc.CreateNode("element", word, "");
            fontNode.AppendChild(pic);
            foreach(List<Point> segment in points) {
                XmlNode seg = doc.CreateNode("element", "Segment", "");
                pic.AppendChild(seg);
                foreach (Point p in segment)
                {
                    XmlNode point = doc.CreateNode("element", "Point", "");
                    XmlNode x = doc.CreateNode("element", "X", "");
                    x.InnerXml = p.X.ToString();
                    XmlNode y = doc.CreateNode("element", "Y", "");
                    y.InnerXml = p.Y.ToString();
                    point.AppendChild(x);
                    point.AppendChild(y);
                    seg.AppendChild(point);
                }
               
            }
            doc.Save(Path);
        }
        
        public void RemoveImage(string word,string font)
        {
            doc.Load(Path);
            XmlNode root = doc.FirstChild;
            XmlNode fontNode;
            if (font == "نستعلیق")
                fontNode = doc.FirstChild.FirstChild;
            else
                fontNode = doc.FirstChild.ChildNodes[1];
            foreach (XmlNode node in fontNode.ChildNodes)
            {
                if (node.Name == word)
                {
                    fontNode.RemoveChild(node);
                    doc.Save(Path);
                    return;
                }
            }
        }
        public List<List<Point>> ReadImage(string word,string font)
        {
            List<Point> points = new List<Point>();
            List<List<Point>> picture = new List<List<Point>>();
            XmlNode root = doc.FirstChild;
            XmlNode fontNode;
            if (font == "نستعلیق")
                fontNode = doc.FirstChild.FirstChild;
            else
                fontNode = doc.FirstChild.ChildNodes[1];
            foreach (XmlNode pic in fontNode.ChildNodes)
            {
                if (pic.Name == word)
                {
                    foreach(XmlNode segment in pic.ChildNodes)
                    {
                        points = new List<Point>();
                        foreach(XmlNode point in segment.ChildNodes)
                        {
                            Point pixel = new Point() { X = Convert.ToInt32(point.ChildNodes[0].InnerText), Y = Convert.ToInt32(point.ChildNodes[1].InnerText) };
                            points.Add(pixel);
                        }
                        picture.Add(points);
                    }
                    return (picture);
                }
            }
            return null;
        }
        public List<string> wordlist(string font)
        {
            XmlNode root = doc.FirstChild;
            XmlNode fontNode;
            if (font == "نستعلیق")
                fontNode = doc.FirstChild.FirstChild;
            else
                fontNode = doc.FirstChild.ChildNodes[1];
            List<string> Words = new List<string>();
            foreach (XmlNode pic in fontNode.ChildNodes)
            {
                Words.Add(pic.Name);
            }
            return (Words);
        }
    }
}
