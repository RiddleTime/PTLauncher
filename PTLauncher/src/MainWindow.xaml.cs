using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using PTLauncher.News;

namespace PTLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = new MainVM();
        }

        private void WindowMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void Button_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Play(object sender, RoutedEventArgs e)
        {
            Process ProjectTorque = new Process();

            ProjectTorque.StartInfo.FileName = "ProjectTorque.exe"; // Needs to be full path
            ProjectTorque.StartInfo.Arguments = MainVM.selectedPlace.ToString(); // If you have any arguments

            bool result = ProjectTorque.Start();
            Debug.WriteLine(ProjectTorque.StartInfo.FileName);
            Debug.WriteLine(ProjectTorque.StartInfo.Arguments);

            Debug.WriteLine("Exit Launcher, Project Torque started.");
            Environment.Exit(0);
        }

        private void Button_Discord(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://discordapp.com/invite/hVNTPe2");
        }
        private void Button_Forum(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://community.projecttorque.racing/");
        }
        private void Button_GP(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://steambilling.projecttorque.racing/");
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

