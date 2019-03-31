using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace XMLReview
{
    class Widget
    {
        public WidgetIncrementCommand Increment { get; private set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public int NumberOfWidgets { get; set; }

        public Widget(string _name, DateTime _dob)
        {
            this.Name = _name;
            this.DOB = _dob;
            this.NumberOfWidgets = 0;
            Increment = new WidgetIncrementCommand(IncrementWidgets);
        }

        public Widget(string _name, DateTime _dob, int _now)
        {
            this.Name = _name;
            this.DOB = _dob;
            this.NumberOfWidgets = _now;
        }
        public Widget() { }

        public void IncrementWidgets()
        {
            //MessageBox.Show(NumberOfWidgets.ToString());
            NumberOfWidgets++;
            //return this.NumberOfWidgets;
        }
    }
}
