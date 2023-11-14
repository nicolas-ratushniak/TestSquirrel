using System.Linq;
using System.Windows;
using Squirrel;

namespace TestSquirrel;

public partial class MainWindow : Window
{
    private UpdateManager? _manager;
    
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Check_OnClick(object sender, RoutedEventArgs e)
    {
        var updateInfo = await _manager!.CheckForUpdate();

        UpdateBtn.IsEnabled = updateInfo.ReleasesToApply.Any();
    }

    private async void Update_OnClick(object sender, RoutedEventArgs e)
    {
        await _manager.UpdateApp();

        MessageBox.Show("Updated!");
    }

    private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        _manager = await UpdateManager.GitHubUpdateManager("https://github.com/nicolas-ratushniak/TestSquirrel");
        VersionTb.Text = _manager.CurrentlyInstalledVersion().ToString();
    }
}