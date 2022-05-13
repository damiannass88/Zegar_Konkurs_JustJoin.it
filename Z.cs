using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
class Z : Window
{
    /// <summary>
    ///  Kliknij aby znaleść Twój Czas.. :)
    ///  
    /// (Naturalnie liczę że komentarz summary, nie jest liczony jako chars algorytmu :D )
    /// </summary>
    Z()
    {
        Width = 490;
        Height = 440;

        Grid g = new();
        Content = g;
        WrapPanel w = new();
        w.HorizontalAlignment = HorizontalAlignment.Center;
        g.Children.Add(w);

        for (int i = 0; i < 12; i++)
        {
            for (int j = 10; j < 53; j += 2)
            {
                TextBlock b = new();
                b.Text = Convert.ToBase64String(Encoding.UTF8.GetBytes("  " + i + ":" + j));
                b.Width = 40;
                b.MouseLeftButtonUp += C;

                w.Children.Add(b);
            }
        }
    }

    void C(object sender, RoutedEventArgs e)
    {
        TextBlock T = (TextBlock)sender;
        T.Text = Encoding.UTF8.GetString(Convert.FromBase64String(T.Text));
        if (T.Text == "  10:24")
         T.FontSize = 14;
        T.IsEnabled = false;
    }

    [STAThread]
    static void Main()
    {
        Application app = new();

        app.Run(new Z());
    }
}