using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace WpWinNl.Behaviors
{
  public class KeepFromBottomBehavior : SafeBehavior<FrameworkElement>
  {

    private double originalBottomMargin;
    private AppBar bottomAppBar;
    protected override void OnSetup()
    {
      var page = AssociatedObject.GetVisualAncestors().OfType<Page>().First();
      bottomAppBar = page.BottomAppBar;
      bottomAppBar.Opened += BottomAppBarManipulated;
      bottomAppBar.Closed += BottomAppBarManipulated;
      originalBottomMargin = AssociatedObject.Margin.Bottom;
      UpdateBottomMargin();
      base.OnSetup();
    }

    void BottomAppBarManipulated(object sender, object e)
    {
      UpdateBottomMargin();
    }

    protected override void OnCleanup()
    {
      bottomAppBar.Opened -= BottomAppBarManipulated;
      bottomAppBar.Closed -= BottomAppBarManipulated;
      base.OnCleanup();
    }

    private async void UpdateBottomMargin()
    {
      await Task.Delay(1);
      var currentMargins = AssociatedObject.Margin;

      var newMargin = new Thickness(currentMargins.Left, currentMargins.Top, currentMargins.Right,
        originalBottomMargin + (bottomAppBar.IsOpen ?  bottomAppBar.ActualHeight : 0));
      AssociatedObject.Margin = newMargin;
    }

    public double WindowHeight { get; set; }
  }
}
