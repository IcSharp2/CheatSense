// Cheat Sense Is The Best Roblox Executor That Is Releasing Soon
// In This File Im Gonna Explain How Cheat Sense Works And Functions

using System;
using System.IO;
using System.Windows;
using System.Windows.Media.TextFormatting;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using System.Windows.Input;
using System.Diagnostics;
using Microsoft.Win32;

namespace Cheatsense // Namespace
{
    public partial class MainWindow : Window // WPF Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // This Is So We Can Load The Editor
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", "Monaco", "Monaco", "Monaco", "Monaco.html");
            Editor.Source = new Uri(path);
        }

        private void EN_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Drag Code So You Can Drag The Window Via The Software
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            // Opens The Script Folder
            string scriptsFolder = Path.Combine(Directory.GetCurrentDirectory(), "scripts");

            if (!Directory.Exists(scriptsFolder))
            {
                Directory.CreateDirectory(scriptsFolder);
            }
            // Uses Process.Start To Open Explorer.exe
            Process.Start("explorer.exe", scriptsFolder);
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            // Clears The Monaco / Editor
            Editor.ExecuteScriptAsync("editor.setValue('');");
        }

        private void Open(object sender, RoutedEventArgs e)
        {
            // Open File Code For Opening Scripts Via A Button
            
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                // Only Lua Files
                Filter = "Lua Files (*.lua)|*.lua|All Files (*.*)|*.*",
                // Title Of The Explorer.exe Window
                Title = "Cheatsense"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string luaCode = File.ReadAllText(openFileDialog.FileName);

                Editor.ExecuteScriptAsync($"monaco.editor.getModels()[0].setValue({System.Text.Json.JsonSerializer.Serialize(luaCode)});");
            }
        }

        private void Inject(object sender, RoutedEventArgs e)
        {
            // Not Leaking The Injection Code
        }
        private void Execute(object sender, RoutedEventArgs e)
        {
            // Not Leaking The Execute Code
        }
    }
}
