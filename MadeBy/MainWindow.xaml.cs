using System.Windows;

namespace MadeBy
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set the position saved in the settings
            this.SourceInitialized += OnSourceInitialized;

            // Handle application closing - save the window state
            this.Closing += MainWindow_Closing;

            // Enable window dragging
            RootLayout.MouseLeftButtonDown += (sender, e) => DragMove();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveWindowState();
        }

        private void SaveWindowState()
        {
            // Save the window's position
            Properties.Settings.Default.WindowLeft = this.Left;
            Properties.Settings.Default.WindowTop = this.Top;

            Properties.Settings.Default.Save();
        }

        private void OnSourceInitialized(object sender, EventArgs e)
        {
            // Restore the window's position
            if (Properties.Settings.Default.WindowLeft >= 0 && Properties.Settings.Default.WindowTop >= 0)
            {
                this.Left = Properties.Settings.Default.WindowLeft;
                this.Top = Properties.Settings.Default.WindowTop;
            }
        }
    }
}
