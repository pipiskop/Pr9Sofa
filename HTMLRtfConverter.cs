using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Spire.Doc;

using System.Windows;
using System.Windows.Documents;
using Document = Spire.Doc.Document;

namespace WpfAppPract9
{
    internal class HTMLRtfConverter
    {
        public static void ToHtml(TextRange rtf)
        {
            var fs = new FileStream("send.rtf", FileMode.Create);
            rtf.Save(fs, DataFormats.Rtf);
            fs.Close();
            var d = new Document("send.rtf", FileFormat.Rtf);
            d.SaveToFile("send.html", FileFormat.Html);
            d.Close();
            File.Delete("send.rtf");
        }
    }
}
