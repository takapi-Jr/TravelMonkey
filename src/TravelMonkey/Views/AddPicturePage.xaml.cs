using System;
using TravelMonkey.ViewModels;
using Xamarin.Forms;

namespace TravelMonkey.Views
{
    public partial class AddPicturePage : ContentPage
    {
        public AddPicturePage()
        {
            InitializeComponent();

            BindingContext = new AddPicturePageViewModel();

            MessagingCenter.Subscribe<AddPicturePageViewModel>(this, Constants.PictureAddedMessage, async (vm) => await Navigation.PopModalAsync(true));

            MessagingCenter.Subscribe<AddPicturePageViewModel>(this, Constants.PictureFailedMessage, async (vm) => await DisplayAlert("Uh-oh!", "Can you hand me my glasses? Something went wrong while analyzing this image", "OK"));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void TranslateDescription_Tapped(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PictureDescriptionLabel.Text))
            {
                await DisplayAlert("No description text", "You didn't take or choose a photo!", "OK");
                return;
            }

            await Navigation.PushModalAsync(new TranslationResultPage(PictureDescriptionLabel.Text));
        }
    }
}