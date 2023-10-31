using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace PrintText
{
    class Program
    {
        static void Main(string[] args)
        {
            PrinterSettings printerSettings = null;

            var printDialog = new PrintDialog();
            var result = printDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                printerSettings = printDialog.PrinterSettings;
            }

            string s = "string to print";
            PrintDocument p = new PrintDocument();
            p.PrinterSettings = printerSettings;

            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                e1.Graphics.DrawString(
                    s, 
                    new Font("Times New Roman", 12), 
                    new SolidBrush(Color.Black), 
                    new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height)
                );
            };
            try
            {
                p.Print();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured While Printing", ex);
            }
        }
    }
}
