using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace Test.IOS.Views
{
    public partial class FirstView : MvxViewController
    {
        public FirstView() : base("FirstView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var view = new UIStackView();
            view.Frame = new CoreGraphics.CGRect(0, 200, 350, 100);

            var button = UIButton.FromType(UIButtonType.Custom);
            button.Frame = new CoreGraphics.CGRect(0, 0, 320, 20);
            button.SetTitle("Click me please", UIControlState.Normal);
            button.BackgroundColor = UIColor.Cyan;
            view.AddSubview(button);

            var navigateButton = UIButton.FromType(UIButtonType.Custom);
            navigateButton.Frame = new CoreGraphics.CGRect(0, 40, 320, 20);
            navigateButton.SetTitle("Navigate", UIControlState.Normal);
            navigateButton.BackgroundColor = UIColor.Cyan;
            view.AddSubview(navigateButton);

            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            set.Bind(Label).To(vm => vm.ClickedTimes);
            set.Bind(TextField).To(vm => vm.Hello);
            set.Bind(button).To(vm => vm.ButtonClickedCommand);
            set.Bind(navigateButton).To(vm => vm.NavigateCommand);
            set.Apply();

            View.AddSubview(view);
        }
    }
}
