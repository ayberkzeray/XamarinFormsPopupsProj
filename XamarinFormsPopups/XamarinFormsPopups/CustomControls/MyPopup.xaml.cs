using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsPopups.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPopup : PopupPage
    {
        ICommand _okeyCommand;
        ICommand _cancelCommand;
        public MyPopup(string title, string message, ICommand okeyCommand =null, ICommand cancelCommand = null, string okText="OKEY",string cancelText = "CANCEL")
        {
            InitializeComponent();

            boldLabel.Text = title;
            boldLabel.IsVisible = !string.IsNullOrEmpty(title);
            descriptionLabel.Text = message;
            okButton.Text = okText;
            cancelButton.Text = cancelText;
            _okeyCommand = okeyCommand;
            _cancelCommand = cancelCommand;
        }
        public void Ok_Clicked(object sender, System.EventArgs e)
        {
            if (PopupNavigation.Instance.PopupStack.Count > 0)
            {
                PopupNavigation.Instance.PopAsync();
            }
            _okeyCommand?.Execute(null);
        }

        public void Cancel_Clicked(object sender, System.EventArgs e)
        {
            _cancelCommand?.Execute(null);
            if (PopupNavigation.Instance.PopupStack.Count > 0)
            {
                PopupNavigation.Instance.PopAsync();
            }
        }
    }
}