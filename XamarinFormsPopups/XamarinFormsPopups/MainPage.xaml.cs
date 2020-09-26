using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinFormsPopups.CustomControls;

namespace XamarinFormsPopups
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            MyPopup myPopup = new MyPopup(title:"This is title",message:"This is my message to the world: Lorem impsum",okeyCommand: okeyCommand, cancelCommand:cancelCommand);
            Device.BeginInvokeOnMainThread(async () =>
            {
                await PopupNavigation.Instance.PushAsync(myPopup, true);
            });
        }
        public ICommand okeyCommand => new Command(() =>
        { 
            okeyLabel.IsVisible = true;
            cancelLabel.IsVisible = false;
        });
        public ICommand cancelCommand => new Command(async() =>
        {
            okeyLabel.IsVisible = false;
            cancelLabel.IsVisible = true;
        });
    }
}
