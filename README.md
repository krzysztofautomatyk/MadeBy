# MadeBy
# 🌟 Always-on-Top Window

[![License](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Platform](https://img.shields.io/badge/Platform-Windows-lightgrey.svg)](https://dotnet.microsoft.com/apps/desktop)
[![Framework](https://img.shields.io/badge/.NET-8.0-purple.svg)](https://dotnet.microsoft.com/)
[![Made By](https://img.shields.io/badge/Made%20by-Krzysztof%20Woźniczak-green.svg)](https://github.com/YourGitHubUsername)

## 📜 Project Overview

**Always-on-Top Window** is a lightweight WPF (Windows Presentation Foundation) application designed to demonstrate a custom "always-on-top" window with a sleek, minimalist design. It features:
- Always-on-top behavior to keep the window visible above other applications.
- Persistent window position across sessions by saving and restoring state.
- Drag-and-drop functionality for moving the window.
- Transparent and borderless UI for a modern look.

This project was created with the intention of having a personal watermark displayed during video recordings, ensuring a professional and unique touch.

---

## ✨ Features
- **Always on Top**: The window stays above all other windows.
- **Position Persistence**: Automatically saves and restores the window's position after relaunch.
- **Drag and Drop**: Easily reposition the window with mouse drag.
- **Modern UI**: Transparent and borderless design with no default system frame.

---

## 🔧 Technologies Used

- **WPF (Windows Presentation Foundation)**: For building the UI.
- **C# (.NET)**: Application logic and behavior.
- **XAML**: Markup for UI design.
- **Settings**: Persistent storage for saving application state.

---

## 📂 Project Structure

### Key Files
- `MainWindow.xaml`: Defines the visual layout of the application.
- `MainWindow.xaml.cs`: Contains the application logic for the main window.
- `Properties/Settings.settings`: Stores persistent user preferences such as window position.

---

## 🖼️ Screenshots

| Window with Custom Background               |
|---------------------------------------------|
| ![Custom Background](https://github.com/krzysztofautomatyk/MadeBy/blob/master/MadeBy/img/colorBackground.png) |


---

## 💻 How to Run the Project



1. Clone the repository to your local machine:   
   ```bash
   git clone https://github.com/krzysztofautomatyk/MadeBy.git
   ``` 
3. Open the solution in Visual Studio.
4. Ensure the `Settings.settings` file contains the following keys:
   - `WindowLeft` (type: `double`, default: `0`)
   - `WindowTop` (type: `double`, default: `0`)
5. Build and run the application.

---

## 🛠️ Code Highlights

### XAML (MainWindow.xaml)
```xml
<Window
    x:Class="MadeBy.MainWindow"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    Title="Always-on-Top Window"
    Width="300"
    Height="150"
    AllowsTransparency="True"
    Background="{x:Null}"
    ResizeMode="NoResize"
    ShowInTaskbar="True"
    Topmost="True"
    WindowStyle="None">
    <Grid x:Name="RootLayout">
        <TextBlock
            HorizontalAlignment="Center"
            VerticalAlignment="Center"
            FontFamily="Segoe UI Semibold"
            FontSize="20"
            Opacity="0.8"
            Text="made by: Krzysztof Woźniczak" Foreground="#FF888888" />
    </Grid>
</Window>
```

### C# Logic (MainWindow.xaml.cs)
```csharp
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
```

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## ✍️ Author

**Krzysztof Woźniczak**  
Feel free to reach out on:  
- [GitHub](https://github.com/krzysztofautomatyk)  
- [LinkedIn](https://www.linkedin.com/in/krzysztof-wozniczak/)  

