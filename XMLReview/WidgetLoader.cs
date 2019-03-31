using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace XMLReview
{
    class WidgetLoader
    {
        public class DocAndContainer
        {
            public XDocument xdoc { get; set; }
            public XElement container { get; set; }
        }
        public static List<Widget> ReadWidgets(string path)
        {

            DocAndContainer dnc = getContainer(path);
            var widget = from w in dnc.container.Descendants()
                         select new
                         {
                             Name = w.Attribute("Name").Value,
                             DOB = w.Attribute("DOB").Value,
                             NumberOfWidgets = w.Attribute("NumberOfWidgets").Value
                         };
            List<Widget> widgetList = new List<Widget>();
            foreach (var w in widget)
            {
                widgetList.Add(new Widget(w.Name, DateTime.Parse(w.DOB), int.Parse(w.NumberOfWidgets)));
            }

            return widgetList; 
        }

        private static DocAndContainer getContainer(string path)
        {
            XDocument xdoc = XDocument.Load(path);
            XElement root = xdoc.Root;
            DocAndContainer dnc = new DocAndContainer();
            dnc.xdoc = xdoc;
            dnc.container = root.Descendants().First();
            return dnc;
        }

        public static void WriteWidgets(List<Widget> wl, string path)
        {
            MessageBox.Show("Working on Saving Widgets To Disk");
            DocAndContainer dnc = getContainer(path);
            foreach (var w in wl)
            {
                try
                {
                var updatedWidget = (from widget in dnc.container.Descendants()
                                    where widget.Attribute("Name").Value == w.Name
                                    select widget).ToList().First();
                    updatedWidget.Attribute("NumberOfWidgets").SetValue(w.NumberOfWidgets);
                }
                catch (Exception e)
                {
                    dnc.container.Add(new XElement("ExampleObject", new XAttribute("Name", w.Name), new XAttribute("DOB", w.DOB), new XAttribute("NumberOfWidgets", w.NumberOfWidgets)));
                }
            }
            dnc.xdoc.Save(path);
            MessageBox.Show("Completed Saving to Disk. Please check to ensure everything is correct.");

        }

    }
}
