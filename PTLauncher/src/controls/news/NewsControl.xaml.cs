using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Controls;

using PTLauncher.News;

namespace PTLauncher.src.controls.news
{
    /// <summary>
    /// Interaction logic for NewsControl.xaml
    /// </summary>
    public partial class NewsControl : UserControl
    {
        private IList<GameNews> gameNews = new List<GameNews>();
        public IList<GameNews> GameNews { get { return gameNews; } set { gameNews = value; } }

        public NewsControl()
        {
            InitializeComponent();
            DataContext = this;
            ObtainGameNews();
        }
        private void ObtainGameNews()
        {
            GameNews.Obtainer obtainer = new GameNews.Obtainer();
            GameNews = obtainer.GameNews;
        }

        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                string newsItemUrl = (e.AddedItems[0] as GameNews).Url;
                Process.Start(newsItemUrl);
            }
        }
    }
}
