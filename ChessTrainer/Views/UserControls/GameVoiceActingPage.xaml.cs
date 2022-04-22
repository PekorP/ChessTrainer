using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

namespace ChessTrainer.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для GameVoiceActingPage.xaml
    /// </summary>
    public partial class GameVoiceActingPage : UserControl
    {
        public GameVoiceActingPage()
        {
            InitializeComponent();
            ((INotifyCollectionChanged)ListBoxChessMoves.Items).CollectionChanged += Items_CollectionChanged;
        }

        private void Items_CollectionChanged(object sender, EventArgs e)
        {
            Border border = (Border)VisualTreeHelper.GetChild(ListBoxChessMoves, 0);
            ScrollViewer scrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
            scrollViewer.ScrollToBottom();
        }
    }
}
