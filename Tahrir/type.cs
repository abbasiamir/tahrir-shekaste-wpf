using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Tahrir
{
    static class type
    {
        static public line ln { get; set; }
        static string word = "";
        static int wordtype =1;
        static bool lowspace = true;
        static public void typing(Key key)
        {
            if (key == Key.Space)
            {
                word = "";
                wordtype = 1;
                space space = new space();
                space.Width = 10;
               
                space.number = CaretPos.linepos;
                ln.Children.Insert(CaretPos.linepos++, space);
            }
            else if (key == Key.PageUp)
            {
                xml x = new xml();
                wordtype++;
                if (!x.RegisteredPic(word + "_" + wordtype, Font.font))
                    wordtype = 1;
                drawWord();
            }
            else if (key == Key.PageDown)
            {
                if (wordtype > 1)
                {
                    wordtype--;
                    drawWord();
                }
            }
            else {
                string character = input.getletter(key);
                if (character != "")
                {
                    word += character;
                }
                drawWord();
            }
        }
        static double Xoffset = 0;
        static bool drawWord()
        {
            List<Path> paths = new List<Path>();
            shap wordshap = new shap();
            
            xml x = new xml();
                paths = wordshap.MakePolygon(word + "_" + wordtype.ToString(), Font.font);
            if (paths != null)
            {
                if (ln.Children.Count > 1 && word.Length > 1)
                {
                    ln.Children.RemoveAt(--CaretPos.linepos);
                    ln.words.RemoveAt(CaretPos.linepos);
                   }

                Word wordStack = new Word();
                Xoffset = 0;
                foreach (Path path in paths)
                {
                    subword wordsub = new subword();
                    wordsub.Children.Add(path);
                   path.Measure(new System.Windows.Size(double.PositiveInfinity, double.PositiveInfinity));
                    if (path.DesiredSize.Width > Xoffset)
                        Xoffset = path.DesiredSize.Width;
                    wordStack.Width = Xoffset;
                    wordsub.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    wordStack.Children.Add(wordsub);
                    }
                ScaleTransform scale = new ScaleTransform() { ScaleX = .2, ScaleY = .2 };
                wordStack.LayoutTransform = scale;
                wordStack.FlowDirection = System.Windows.FlowDirection.LeftToRight;
                wordStack.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                ln.words.Add(wordStack);
                wordStack.number = ln.words.Count - 1;
                ln.Children.Insert(CaretPos.linepos++, wordStack);
                wordStack.address.fillAddress(UIETypes.Word, wordStack);
                foreach(subword subword in wordStack.Children)
                {
                    subword.address.fillAddress(UIETypes.SubWord, subword);
                }
               
                return true;
            }
            else
            {
                if (word != "" && word.Length > 1)
                {
                    wordtype = 1;
                    word = word.Last().ToString();
                    drawWord();
                }

            }
            
            return false;
        }
    }
}
