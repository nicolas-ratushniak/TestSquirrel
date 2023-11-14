using System.Reflection;
using System.Windows;
using Squirrel;

namespace TestSquirrel;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var assembly = Assembly.GetExecutingAssembly();
        var fileInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
        VersionTb.Text = fileInfo.FileVersion;
    }

    private void Check_OnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void Update_OnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        // var manager = await UpdateManager.GitHubUpdateManager();
    }
}