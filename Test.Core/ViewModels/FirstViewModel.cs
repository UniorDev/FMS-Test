using MvvmCross.Core.ViewModels;

namespace Test.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        private string _hello = "Hello MvvmCross";
        public string Hello
        {
            get { return _hello; }
            set { SetProperty(ref _hello, value); }
        }

        private byte _clickedTimes = 0;

        public byte ClickedTimes
        {
            get { return _clickedTimes; }
            set { _clickedTimes = value; RaisePropertyChanged(() => ClickedTimes); }
        }

        public IMvxCommand ButtonClickedCommand { get { return buttonClickedCommand; } }

        private IMvxCommand buttonClickedCommand;

        public IMvxCommand NavigateCommand { get { return navigateCommand; } }

        private IMvxCommand navigateCommand;

        public FirstViewModel()
        {
            buttonClickedCommand = new MvxCommand(OnButtonClicked);
            navigateCommand = new MvxCommand(OnNavigate);
        }

        private void OnButtonClicked()
        {
            ClickedTimes++;
        }

        private void OnNavigate()
        {
            ShowViewModel<SecondViewModel>();
        }
    }
}
