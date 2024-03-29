using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tahrir
{
    class Address
    {
        public int? page { get; set; }
        public int? column { get; set; }
        public int? paragraph { get; set; }
        public int? line { get; set; }
        public int? word { get; set; }
        public int? subword { get; set; }
        public Address() { }
        public Address(int p,int c,int pr,int l,int w,int sw)
        {
            page = p;column = c;paragraph = pr;line = l;word = w;subword = sw;
        }
        public void fillAddress(string elementtype,UIElement element)
        {
            switch (elementtype)
            {
                case "page":
                    {
                        Page pg = (Page)element;
                        pageborder pgb = (pageborder)pg.Parent;
                        Frame frame =(Frame) pgb.Parent;
                        int counter = 0;
                        foreach(pageborder pb in frame.Children)
                        {
                            if (pb.Child == pg)
                            {
                                page = counter;
                                return;
                            }
                            counter++;
                        }
                        break;
                    }
                case "column":
                    {
                        Column col = (Column)element;
                        ColumnBorder colb = (ColumnBorder)col.Parent;
                        Page pg = (Page)colb.Parent;
                        pageborder pgb = (pageborder)pg.Parent;
                        Frame frame = (Frame)pgb.Parent;
                        int counter0 = 0;
                        int counter1 = 0;
                        foreach (pageborder pb in frame.Children)
                        {
                            if (pb.Child == pg)
                            {
                                foreach (ColumnBorder c in pg.Children)
                                {
                                    if (c.Child == col)
                                    {
                                        page = counter0;
                                        column = counter1;
                                        return;
                                    }
                                    counter1++;
                                }
                            }
                            counter0++;
                        }
                        break;
                    }
                case "paragraph":
                    {
                        Paragraph pr = (Paragraph)element;
                        Column col = (Column)pr.Parent;
                        ColumnBorder colb = (ColumnBorder)col.Parent;
                        Page pg = (Page)colb.Parent;
                        pageborder pgb = (pageborder)pg.Parent;
                        Frame frame = (Frame)pgb.Parent;
                        int counter0 = 0;
                        int counter1 = 0;
                        int counter2 = 0;
                        Column column1 = new Column();
                        foreach (pageborder pb in frame.Children)
                        {
                            if (pb.Child == pg)
                            {
                                foreach (ColumnBorder c in pg.Children)
                                {
                                    if (c.Child == col)
                                    {
                                        column1 = (Column)c.Child;
                                        foreach(Paragraph prg in column1.Children)
                                        {
                                            if (prg == pr)
                                            {
                                                page = counter0;
                                                column = counter1;
                                                paragraph = counter2;
                                                return;
                                            }
                                            counter2++;
                                        }
                                    }
                                    counter1++;
                                }
                            }
                            counter0++;
                        }
                        break;
                    }
                case "line":
                    {
                        line ln = (line)element;
                        Paragraph pr = (Paragraph)ln.Parent;
                        Column col = (Column)pr.Parent;
                        ColumnBorder colb = (ColumnBorder)col.Parent;
                        Page pg = (Page)colb.Parent;
                        pageborder pgb = (pageborder)pg.Parent;
                        Frame frame = (Frame)pgb.Parent;
                        int counter0 = 0;
                        int counter1 = 0;
                        int counter2 = 0;
                        int counter3 = 0;
                        Column column1 = new Column();
                        foreach (pageborder pb in frame.Children)
                        {
                            if (pb.Child == pg)
                            {
                                foreach (ColumnBorder c in pg.Children)
                                {
                                    if (c.Child== col)
                                    {
                                        column1 = (Column)c.Child;
                                        foreach (Paragraph prg in column1.Children)
                                        {
                                            if (prg == pr)
                                            {
                                               foreach(line l in prg.Children)
                                                {
                                                    if (l == ln)
                                                    {
                                                        page = counter0;
                                                        column = counter1;
                                                        paragraph = counter2;
                                                        line = counter3;
                                                        return;
                                                    }
                                                    counter3++;
                                                }

                                            }
                                            counter2++;
                                        }
                                    }
                                    counter1++;
                                }
                            }
                            counter0++;
                        }
                        break;
                    }
                case "word":
                    {
                        Word wrd = (Word)element;
                        line ln = (line)wrd.Parent;
                        Paragraph pr = (Paragraph)ln.Parent;
                        Column col = (Column)pr.Parent;
                        ColumnBorder colb =(ColumnBorder) col.Parent;
                        Page pg = (Page)colb.Parent;
                        pageborder pgb = (pageborder)pg.Parent;
                        Frame frame = (Frame)pgb.Parent;
                        int counter0 = 0;
                        int counter1 = 0;
                        int counter2 = 0;
                        int counter3 = 0;
                        int counter4 = 0;
                        Column column1 = new Column();
                        foreach (pageborder pb in frame.Children)
                        {
                            if (pb.Child == pg)
                            {
                                foreach (ColumnBorder c in pg.Children)
                                {
                                    if (c.Child == col)
                                    {
                                        column1 = (Column)c.Child;
                                        foreach (Paragraph prg in column1.Children)
                                        {
                                            if (prg == pr)
                                            {
                                                foreach (line l in prg.Children)
                                                {
                                                    if (l == ln)
                                                    {
                                                        foreach (Word w in Workspace.frame.pagesborder[counter0].page.columnborders[counter1].column.paragraphs[counter2].lines[counter3].words)
                                                        {
                                                            if (w == wrd)
                                                            {
                                                                page = counter0;
                                                                column = counter1;
                                                                paragraph = counter2;
                                                                line = counter3;
                                                                word = w.number;
                                                                return;
                                                            }
                                                            counter4++;
                                                        }
                                                    }
                                                    counter3++;
                                                }

                                            }
                                            counter2++;
                                        }
                                    }
                                    counter1++;
                                }
                            }
                            counter0++;
                        }
                        break;
                    }
                case "subword":
                    {
                        subword sb = (subword)element;
                        Word wrd = (Word)sb.Parent;
                        line ln = (line)wrd.Parent;
                        Paragraph pr = (Paragraph)ln.Parent;
                        Column col = (Column)pr.Parent;
                        ColumnBorder colb = (ColumnBorder)col.Parent;
                        Page pg = (Page)colb.Parent;
                        pageborder pgb = (pageborder)pg.Parent;
                        Frame frame = (Frame)pgb.Parent;
                        int counter0 = 0;
                        int counter1 = 0;
                        int counter2 = 0;
                        int counter3 = 0;
                        int counter4 = 0;
                        int counter5 = 0;
                        Column column1 = new Column();
                        foreach (pageborder pb in frame.Children)
                        {
                            if (pb.Child == pg)
                            {
                                foreach (ColumnBorder c in pg.Children)
                                {
                                    if (c.Child == col)
                                    {
                                        column1 =(Column) c.Child; 
                                        foreach (Paragraph prg in column1.Children)
                                        {
                                            if (prg == pr)
                                            {
                                                foreach (line l in prg.Children)
                                                {
                                                    if (l == ln)
                                                    {
                                                        foreach (Word w in Workspace.frame.pagesborder[counter0].page.columnborders[counter1].column.paragraphs[counter2].lines[counter3].words)
                                                        {
                                                            if (w == wrd)
                                                            {
                                                                foreach (subword s in w.Children)
                                                                {
                                                                    if (s == sb)
                                                                    {
                                                                        page = counter0;
                                                                        column = counter1;
                                                                        paragraph = counter2;
                                                                        line = counter3;
                                                                        word = w.number;
                                                                        subword = counter5;
                                                                        return;
                                                                    }
                                                                    counter5++;
                                                                }
                                                            }
                                                            counter4++;
                                                        }
                                                    }
                                                    counter3++;
                                                }

                                            }
                                            counter2++;
                                        }
                                    }
                                    counter1++;
                                }
                            }
                            counter0++;
                        }
                        break;
                    }
            }
        }
        public UIElement getElement(string elementtype)
        {
            switch (elementtype)
            {
                case "page":
                    {
                        if (page != null)
                            return Workspace.frame.pagesborder[(int)page].page;
                        break;
                    }
                case "column":
                    {
                        if (page != null && column != null)
                            return Workspace.frame.pagesborder[(int)page].page.columnborders[(int)column].column;
                        break;
                    }
                case "paragraph":
                    {
                        if (page != null && column != null && paragraph != null)
                            return Workspace.frame.pagesborder[(int)page].page.columnborders[(int)column].column.paragraphs[(int)paragraph];
                        break;
                    }
                case "line":
                    {
                        if (page != null && column != null && paragraph != null && line != null)
                            return Workspace.frame.pagesborder[(int)page].page.columnborders[(int)column].column.paragraphs[(int)paragraph].lines[(int)line];
                        break;
                    }
                case "word":
                    {
                        if (page != null && column != null && paragraph != null && line != null && word != null)
                            return Workspace.frame.pagesborder[(int)page].page.columnborders[(int)column].column.paragraphs[(int)paragraph].lines[(int)line].Children[(int)word]; ;
                        break;
                    }

                case "subword":
                    {
                        if (page != null && column != null && paragraph != null && line != null && word != null&&subword!=null)
                            return Workspace.frame.pagesborder[(int)page].page.columnborders[(int)column].column.paragraphs[(int)paragraph].lines[(int)line].words[(int)word].Children[(int)subword] ;
                        break;
                    }
                   
            }
            return null;
        }
    }
}
