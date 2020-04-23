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
            ComboBoxLanguages.ItemsSource = GameLanguage.Languages;
            
            // Todo use LanguagePersistance (either registry or local file with option )
            ComboBoxLanguages.SelectedItem = GameLanguage.Languages.ElementAt(1);
        }
    }
}
