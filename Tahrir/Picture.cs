using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Tahrir
{
    class Picture
    {
        BitmapImage image;
        Point begin = new Point();
        Point end = new Point();
        List<Point> sides;
        List<Point> visiteds = new List<Point>();
        List<List<Point>> Segmentes;
        bool endSegment = false;
        byte[] context;
        int strid = 0;
        public Picture()
        {
            
        }
        public void Save(string path,string font)
        {
            xml x = new xml();
            string word = path.Remove(0, path.LastIndexOf("\\") + 1);
            word = word.Remove(word.IndexOf("."));
            if (x.RegisteredPic(word,font))
                return;
            sides = new List<Point>();
            Segmentes = new List<List<Point>>();
            image = new BitmapImage(new Uri(path));
            strid = image.PixelWidth * 4;
            int size = strid * image.PixelHeight;
            context = new byte[size];
            image.CopyPixels(context, strid, 0);
            setClip();
            surfBundries();
            x.SaveImage(word, Segmentes,font);
        }
        void surfBundries()
        {
            visiteds = new List<Point>();
            for (int j =(int) begin.Y; j < image.PixelHeight; j++)
            {
                for (int i = (int)begin.X; i < image.PixelWidth; i++)
                {
                    if(IsinBoundry(i,j)&&!IsinSides(i, j))
                    {
                        FindPixels(i, j);
                        if(sides.Count>0)
                            Segmentes.Add(sides);
                        sides = new List<Point>();
                    }
                }
            }
        }
        void setClip()
        {
            setBeginX();
            setBeginY();
            setEndX();
            setEndY();
        }

        int getIndex(int x,int y)
        {
            return (y * strid + 4 * x);
        }
        void setBeginY()
        {
            for (int i = 0; i < image.PixelHeight; i++)
            {
                for (int j = 0; j < image.PixelWidth; j++)
                {
                    int index = getIndex(j, i);
                    if (context[index] <100 && context[index + 1] <100 && context[index + 2] <100)
                    {
                        begin.Y = i;
                        return;
                    }
                }
            }
        }
        void setBeginX()
        {
            for (int i = 0; i < image.PixelWidth; i++)
            {
                for (int j = 0; j < image.PixelHeight; j++)
                {
                    int index = getIndex(i,j);
                    if (context[index] <100 && context[index + 1] <100 && context[index + 2] <100)
                    {
                        begin.X = i;
                        return;
                    }
                }
            }
        }
        void setEndX()
        {
            for (int i = image.PixelWidth-1; i >=0; i--)
            {
                for (int j = image.PixelHeight-1; j >=0; j--)
                {
                    int index = getIndex(i,j);
                    if (context[index] <100 && context[index + 1] <100 && context[index + 2] <100)
                    {
                        end.X = i;
                        return;
                    }
                }
            }
        }
        void setEndY()
        {
            for (int i = image.PixelHeight-1; i >=0; i--)
            {
                for (int j = image.PixelWidth-1; j >=0; j--)
                {
                    int index = getIndex(j,i);
                    if (context[index] <100 && context[index + 1] <100 && context[index + 2] <100)
                    {
                        end.Y = i;
                        return;
                    }
                }
            }
        }
        bool IsinBoundry(int x,int y)
        {
            bool white = false;
            bool black = false;
            //if(x>end.X||x<begin.X||y>end.Y||y<begin.Y)
               
            int index0 = getIndex(x, y);
            if (!(context[index0] < 100 && context[index0 + 1] < 100 && context[index0 + 2] < 100))
                return false;
            if (x + 1 < image.PixelWidth)
            {
                int index = getIndex(x + 1, y);
                if (context[index] < 100 && context[index + 1] < 100 && context[index + 2] < 100)
                    black = true;
                else if (context[index] > 100 && context[index + 1] > 100 && context[index + 2] > 100)
                    white = true;
            }
            if (x - 1 >= 0)
            {
                int index = getIndex(x - 1, y);
                if (context[index] < 100 && context[index + 1] < 100 && context[index + 2] < 100)
                    black = true;
                else if (context[index] > 100 && context[index + 1] > 100 && context[index + 2] > 100)
                    white = true;
            }
            if (y + 1 <image.PixelHeight)
            {
                int index = getIndex(x, y + 1);
                if (context[index] < 100 && context[index + 1] < 100 && context[index + 2] < 100)
                    black = true;
                else if (context[index] > 100 && context[index + 1] > 100 && context[index + 2] > 100)
                    white = true;
            }
            if (y - 1 >=0)
            {
                int index = getIndex(x, y - 1);
                if (context[index] < 100 && context[index + 1] < 100 && context[index + 2] < 100)
                    black = true;
                else if (context[index] > 100 && context[index + 1] > 100 && context[index + 2] > 100)
                    white = true;
            }
            if (x + 1 <image.PixelWidth&& y + 1 <image.PixelHeight)
            {
                int index = getIndex(x + 1, y + 1);
                if (context[index] < 100 && context[index + 1] < 100 && context[index + 2] < 100)
                    black = true;
                else if (context[index] > 100 && context[index + 1] > 100 && context[index + 2] > 100)
                    white = true;
            }
            if (x - 1 >= 0 && y - 1 >= 0)
            {
                int index = getIndex(x - 1, y - 1);
                if (context[index] < 100 && context[index + 1] < 100 && context[index + 2] < 100)
                    black = true;
                else if (context[index] > 100 && context[index + 1] > 100 && context[index + 2] > 100)
                    white = true;
            }
            if (x + 1 <image.PixelWidth && y - 1 >= 0)
            {
                int index = getIndex(x + 1, y - 1);
                if (context[index] < 100 && context[index + 1] < 100 && context[index + 2] < 100)
                    black = true;
                else if (context[index] > 100 && context[index + 1] > 100 && context[index + 2] > 100)
                    white = true;
            }
            if (x - 1 >= 0 && y + 1 <image.PixelHeight)
            {
                int index = getIndex(x - 1, y + 1);
                if (context[index] < 100 && context[index + 1] < 100 && context[index + 2] < 100)
                    black = true;
                else if (context[index] > 100 && context[index + 1] > 100 && context[index + 2] > 100)
                    white = true;
            }
            if (white == true && black == true)
                return true;
            else
                return false;
        }
        bool IsVisited(int x,int y)
        {
            foreach(Point p in visiteds)
            {
                if (p.X == x && p.Y == y)
                    return true;
            }
            return false;
        }
       
        bool search(int x,int y,int length)
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (FindPixels(x + i, y + j))
                        return true;
                }
            }
            for (int i = 0; i < length; i++)
            {
                for (int j=0;j< length;j++)
                {
                    if (FindPixels(x + i, y - j))
                        return true;
                }
            }
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (FindPixels(x - i, y + j))
                        return true;
                }
            }
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (FindPixels(x - i, y - j))
                        return true;
                }
            }
            return false;
        }
        void Return(int x , int y)
        {
            int radius = 3;
            while (!search(x, y, radius))
            {
                radius++;
                if (radius > 10)
                {
                    endSegment = true;
                    return;
                }
            }
               
           
            
        }
        bool FindPixels(int x,int y)
        {
           
             if (!IsVisited(x, y))
                 visiteds.Add(new Point(x, y));
            else
                return false;
            if (x > end.X || y > end.Y)
                return false;
            if (IsinBoundry(x, y))
            {
                 if (x >= begin.X && y >= begin.Y )
                {
                    
                    sides.Add(new Point(x - begin.X, y - begin.Y));
                    if (!FindPixels(x + 1, y))
                        if (!FindPixels(x, y + 1))
                            if (!FindPixels(x + 1, y + 1))
                                if (!FindPixels(x - 1, y))
                                    if (!FindPixels(x, y - 1))
                                        if (!FindPixels(x - 1, y - 1))
                                            if (!FindPixels(x - 1, y + 1))
                                                if (!FindPixels(x + 1, y - 1))
                                                    Return(x, y);

                    return true;   
                }
            }
            return false;
        }
        bool IsinSides(int x,int y)
        {
            foreach(Point item in sides)
            {
                if (item.X == x && item.Y == y)
                    return true;
            }
            return false;
        }
    }
}
