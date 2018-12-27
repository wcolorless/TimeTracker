using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeTracker
{
    public class DrawHistograms
    {
        public static void Draw(ILoger Loger, WrapPanel KeyPanel, WrapPanel MousePanel)
        {
            var Activity = Histograms.GetActivity(Loger);
            double Max1 = Activity.Item1.Count > 0 ? Activity.Item1.Max() : 0;
            if(Max1 > 140)
            {
                double coefficient = 150D / Max1;
                Activity.Item1 = Activity.Item1.Select((N) => N * coefficient).ToList();
            }
            KeyPanel.Children.Clear();
            foreach (double Value in Activity.Item1)
            {
                Grid grid = new Grid() { Height = Value, Width = 35, VerticalAlignment = VerticalAlignment.Bottom, Margin = new Thickness(1, 0, 1, 0)};
                grid.Children.Add(new Border() { BorderBrush = Brushes.Black, BorderThickness = new Thickness(1)});
                grid.Children.Add(new TextBlock() {FontSize = 10, Text = Value.ToString(), VerticalAlignment = VerticalAlignment.Bottom, Margin = new Thickness(10), HorizontalAlignment = HorizontalAlignment.Center });
                KeyPanel.Children.Add(grid);
            }
            KeyPanel.UpdateLayout();

            double Max2 = Activity.Item2.Count > 0 ? Activity.Item2.Max() : 0;
            if (Max2 > 140)
            {
                double coefficient = 150D / Max2;
                Activity.Item2 = Activity.Item2.Select((N) => N * coefficient).ToList();
            }
            MousePanel.Children.Clear();
            foreach (double Value in Activity.Item2)
            {
                Grid grid = new Grid() { Height = Value, Width = 35, VerticalAlignment = VerticalAlignment.Bottom, Margin = new Thickness(1, 0, 1, 0) };
                grid.Children.Add(new Border() { BorderBrush = Brushes.Black, BorderThickness = new Thickness(1) });
                grid.Children.Add(new TextBlock() { FontSize = 10, Text = Value.ToString(), VerticalAlignment = VerticalAlignment.Bottom, Margin = new Thickness(10), HorizontalAlignment = HorizontalAlignment.Center });
                MousePanel.Children.Add(grid);
            }
            MousePanel.UpdateLayout();
        }
    }
}
