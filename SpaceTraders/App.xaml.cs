using System.Windows;

namespace SpaceTraders
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var appExtensions = new AppExtensions();
            appExtensions.Main();
            
            base.OnStartup(e);
        }
    }
}