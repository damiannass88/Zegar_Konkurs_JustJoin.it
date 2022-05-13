using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
public class Z : Window
{
    /// <summary>
    ///  Kliknij aby znaleść Twój Czas.. :)
    ///  
    /// Branch "Char_Randomly_displaying" jeśli bym miał kilka dodatkowych char do użycia.. :)
    /// </summary>
    Z()
    {
        Width = 490;

        Grid g = new();
        Content = g;
        WrapPanel w = new();
        w.HorizontalAlignment = HorizontalAlignment.Center;
        g.Children.Add(w);

        Random r = new();
        List<TextBlock> l = new();
        for (int i = 0; i < 12; i++)
        {
            for (int j = 10; j < 60; j += 2)
            {
                TextBlock b = new();
                b.Text = Convert.ToBase64String(Encoding.UTF8.GetBytes("  " + i + ":" + j));
                b.Width = 40;
                b.MouseLeftButtonUp += C;

                l.Insert(r.Next(0, l.Count + 1), b);
            }
        }
        foreach (TextBlock xInt in l)
            w.Children.Add(xInt);
    }

    void C(object sender, RoutedEventArgs e)
    {
        TextBlock T = (TextBlock)sender;
        T.Text = Encoding.UTF8.GetString(Convert.FromBase64String(T.Text));
        if (T.Text == "  10:24")
        // T.FontSize = 14;
        {
            T.FontSize = 16;
            T.Text = T.Text.Trim();
        }
        T.IsEnabled = false;
    }

    [STAThread]
    static void Main()
    {
        Application app = new();

        app.Run(new Z());
    }
}