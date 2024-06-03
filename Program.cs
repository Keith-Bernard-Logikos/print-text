using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace PrintText
{
    class Program
    {
        private static int page = 0;

        private static void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            float leftMargin = 70.0f;
            float topMargin = 20.0f;
            float lineInc = 20.0f;

            var sb = new StringBuilder();
            sb.AppendLine(String.Format("page {0} - report line 1", page));
            sb.AppendLine(String.Format("page {0} - report line 2", page));
            sb.AppendLine(String.Format("page {0} - report line 3", page));
            sb.AppendLine(String.Format("page {0} - report line 4", page));
            sb.AppendLine(String.Format("page {0} - report line 5", page));
            sb.AppendLine(String.Format("page {0} - report line 6", page));
            sb.AppendLine(String.Format("page {0} - report line 7", page));
            sb.AppendLine(String.Format("page {0} - report line 8", page));
            sb.AppendLine(String.Format("page {0} - report line 9", page));
            sb.AppendLine(String.Format("page {0} - report line 10", page));

            Font printFontArial10 = new Font("Arial", 10, FontStyle.Regular);

            Graphics g = e.Graphics;
            e.Graphics.DrawString(sb.ToString(), printFontArial10, Brushes.Black, leftMargin, topMargin + lineInc);

            page++;
            e.HasMorePages = page < 2;
        }

        static void Main(string[] args)
        {
            page = 0;

            PrinterSettings printerSettings = null;

            var printDialog = new PrintDialog();
            var result = printDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                printerSettings = printDialog.PrinterSettings;
            }

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            pd.PrinterSettings = printerSettings;
            pd.Print();

            //PrinterSettings printerSettings = null;

            //var printDialog = new PrintDialog();
            //var result = printDialog.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    printerSettings = printDialog.PrinterSettings;
            //}

            //string s = "string to print";
            //PrintDocument p = new PrintDocument();
            //p.PrinterSettings = printerSettings;

            //p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            //{
            //    e1.Graphics.DrawString(
            //        s, 
            //        new Font("Times New Roman", 12), 
            //        new SolidBrush(Color.Black), 
            //        new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height)
            //    );
            //};
            //try
            //{
            //    p.Print();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Exception Occured While Printing", ex);
            //}
        }
    }
}
