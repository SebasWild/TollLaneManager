using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AutomatedRoadTollingSystem.Common
{
    class TabControlDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (item != null && item is AutomatedRoadTollingSystem.Entities.Lane)
                return element.FindResource("LaneDataTemplate") as DataTemplate;
            else if (item != null && item is AutomatedRoadTollingSystem.Entities.Report)
                return element.FindResource("ReportDataTemplate") as DataTemplate;
            return null;
        }
    }
}
