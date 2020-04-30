using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Controls;
using PTLauncher.Language;
using PTLauncher.News;

namespace PTLauncher.src.controls.language
{
    /// <summary>
    /// Interaction logic for NewsControl.xaml
    /// </summary>
    public partial class LanguageControl : UserControl
    {
        public LanguageControl()
        {
            InitializeComponent();
            DataContext = this;
            ComboBoxLanguages.ItemsSource = LanguagePersistence.Languages;
            ComboBoxLanguages.SelectedItem = LanguagePersistence.LoadLanguage();
        }

        private void ComboBoxLanguages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((e.AddedItems) != null)
            {
                GameLanguage language = (e.AddedItems[0] as GameLanguage);
                LanguagePersistence.SaveLangauge(language);
            }
        }
    }
}
