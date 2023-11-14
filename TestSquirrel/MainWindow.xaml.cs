using System.Linq;
using System.Windows;
using Squirrel;

namespace TestSquirrel;

public partial class MainWindow : Window
{
    private const string RepoUrl = "https://github.com/nicolas-ratushniak/TestSquirrel";

    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Update_OnClick(object sender, RoutedEventArgs e)
    {
        using var manager = await UpdateManager
            .GitHubUpdateManager(RepoUrl);

        manager.UpdateApp();
    }

    private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        using var manager = await UpdateManager
            .GitHubUpdateManager(RepoUrl);
        
        VersionTb.Text = manager.CurrentlyInstalledVersion().ToString();
        
        var updateInfo = await manager.CheckForUpdate();
        UpdateBtn.IsEnabled = updateInfo.ReleasesToApply.Any();
    }
}