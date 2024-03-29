using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tahrir
{
    static class SetCaretPos
    {
        static line l = new line();
        static Paragraph p = new Paragraph();
        static Column c = new Column();
        static Page page = new Page();
        public static void FromWord(Word word)
        {
            CaretPos.linepos = word.number; 
            l = (line)word.Parent;
            CaretPos.line = l.number;
            p = (Paragraph)l.Parent;
            CaretPos.paragraph = p.number;
            c = new Column();
            c = (Column)p.Parent;
            CaretPos.column = c.number;
            ColumnBorder b = (ColumnBorder)c.Parent;
            page = (Page)b.Parent;
            CaretPos.page = page.number;
        }
        public static void FromLine(line line)
        {
            CaretPos.line = line.number;
            p = (Paragraph)line.Parent;
            CaretPos.paragraph = p.number;
            c = new Column();
            c = (Column)p.Parent;
            CaretPos.column = c.number;
            ColumnBorder b = (ColumnBorder)c.Parent;
            page = (Page)b.Parent;
            CaretPos.page = page.number;
        }
        public static void FromParagraph(Paragraph p)
        {
            CaretPos.paragraph = p.number;
            c = new Column();
            c = (Column)p.Parent;
            CaretPos.column = c.number;
            ColumnBorder b = (ColumnBorder)c.Parent;
            Page page = (Page)b.Parent;
            CaretPos.page = page.number;
        }
        public static void FromColumn(Column c)
        {
            CaretPos.column = c.number;
            ColumnBorder b = (ColumnBorder)c.Parent;
            page = (Page)b.Parent;
            CaretPos.page = page.number;
        }
        public static void FromPage(Page p)
        {
            CaretPos.page = p.number;
        }
    }
}
