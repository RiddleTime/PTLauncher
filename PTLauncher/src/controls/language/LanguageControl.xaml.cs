using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Controls;

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
        }
    }
}
