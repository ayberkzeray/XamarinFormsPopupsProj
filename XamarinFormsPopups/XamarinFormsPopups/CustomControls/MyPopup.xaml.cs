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
        public MyPopup(string title, string message, string okText="OKEY")
        {
            InitializeComponent();

            boldLabel.Text = title;
            boldLabel.IsVisible = !string.IsNullOrEmpty(title);
            descriptionLabel.Text = message;
            okButton.Text = okText;
        }

        public void Ok_Clicked(object sender, System.EventArgs e)
        {
            if (PopupNavigation.Instance.PopupStack.Count > 0)
            {
                PopupNavigation.Instance.PopAsync();
            }
        }

    }
}