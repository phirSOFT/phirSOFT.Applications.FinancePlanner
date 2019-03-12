using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FastColoredTextBoxNS;
using NLog;
using System.Windows.Forms;

namespace phirSOFT.Applications.FinancePlanner.Controls
{

    /// <summary>
    /// Console emulator.
    /// </summary>
    public class ConsoleTextBox : FastColoredTextBox
    {
        private volatile bool isReadLineMode;
        private volatile bool isUpdating;
        private volatile bool isReadingLine;

        private Dictionary<Range, Action> links = new Dictionary<Range, Action>();

        TextStyle blueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Underline);

        bool CharIsHyperlink(Place place)
        {
            var mask = GetStyleIndexMask(new Style[] { blueStyle });
            if (place.iChar >= GetLineLength(place.iLine)) return false;
            return (this[place].style & mask) != 0;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            var p = PointToPlace(e.Location);
            Cursor = CharIsHyperlink(p) ? Cursors.Hand : Cursors.IBeam;
            base.OnMouseMove(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            var p = PointToPlace(e.Location);           
            if (CharIsHyperlink(p))
            {
                links.FirstOrDefault(r => r.Key.Contains(p)).Value?.Invoke();          
            }
        }


        private Place StartReadPlace { get; set; }

        public ConsoleTextBox()
        {
            TextChanged += ConsoleTextBox_TextChanged;
            IsReadLineMode = true;
        }

        private void ConsoleTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsReadLineMode || isReadingLine || isUpdating) return;
            OnLineRead(new LineReadEventArgs(new Range(this, StartReadPlace, Range.End).Text.TrimEnd('\r', '\n')));
            ClearUndo();
            GoEnd();
            StartReadPlace = Range.End;
            IsReadLineMode = true;
        }

        /// <summary>
        /// Control is waiting for line entering. 
        /// </summary>
        public bool IsReadLineMode
        {
            get { return isReadLineMode; }
            set { isReadLineMode = value; }
        }

        /// <summary>
        /// Append line to end of text.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="style"></param>
        public void WriteLine(string text, Style style = null)
        {
            IsReadLineMode = false;
            isUpdating = true;
            try
            {
                AppendText(text + "\n", style);
                GoEnd();
            }
            finally
            {
                isUpdating = false;
                ClearUndo();
            }
        }

        public void WriteLink(string link, Action executionAction)
        {
            isReadingLine = false;
            isUpdating = true;
            try
            {
                var fp = Range.End;
                AppendText(link, blueStyle);
                GoEnd();
                links.Add(new Range(this, fp, Range.End),executionAction);
            }
            finally
            {
                isUpdating = false;
                ClearUndo();
            }
            isReadingLine = true;
        }


        /// <summary>
        /// Wait for line entering.
        /// Set IsReadLineMode to false for break of waiting.
        /// </summary>
        /// <returns></returns>
        public string ReadLine()
        {

            GoEnd();
            StartReadPlace = Range.End;
            IsReadLineMode = true;
            isReadingLine = true;
            try
            {
                while (IsReadLineMode)
                {
                    Application.DoEvents();
                    Thread.Sleep(5);
                }
            }
            finally
            {
                IsReadLineMode = false;
                ClearUndo();
            }
            var value = new Range(this, StartReadPlace, Range.End).Text.TrimEnd('\r', '\n');
            isReadingLine = false;
            return value;
        }





        public event EventHandler<LineReadEventArgs> LineRead;




        public override void OnTextChanging(ref string text)
        {
            if (!IsReadLineMode && !isUpdating)
            {
                text = ""; //cancel changing
                return;
            }

            if (IsReadLineMode)
            {
                if (Selection.Start < StartReadPlace || Selection.End < StartReadPlace)
                    GoEnd();//move caret to entering position

                if (Selection.Start == StartReadPlace || Selection.End == StartReadPlace)
                    if (text == "\b") //backspace
                    {
                        text = ""; //cancel deleting of last char of readonly text
                        return;
                    }

                if (text != null && text.Contains('\n'))
                {
                    text = text.Substring(0, text.IndexOf('\n') + 1);
                    IsReadLineMode = false;
                }
            }

            base.OnTextChanging(ref text);
        }

        public override void Clear()
        {
            var oldIsReadMode = isReadLineMode;

            isReadLineMode = false;
            isUpdating = true;

            base.Clear();

            isUpdating = false;
            isReadLineMode = oldIsReadMode;

            StartReadPlace = Place.Empty;
        }

        protected virtual void OnLineRead(LineReadEventArgs e)
        {
            LineRead?.Invoke(this, e);
        }
    }

    public class LineReadEventArgs : EventArgs
    {
        public string Line { get; }

        public LineReadEventArgs(string line)
        {
            Line = line;
        }
    }
}

