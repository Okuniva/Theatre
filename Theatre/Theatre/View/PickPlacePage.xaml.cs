using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;
using Theatre.Model;
using Theatre.Services;
using Theatre.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Theatre.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickPlacePage : ContentPage
    {
        private Dictionary<string, string> _seats;

        public PickPlacePage(PickPlaceViewModel viewmodel)
        {
            InitializeComponent();
            BindingContext = viewmodel;
            viewmodel.Navigation = Navigation;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            _seats = await new LoadServices().GetSeats(24); // id
            SetHall('c', null);
        }

        //c - sectors
        //r - rows
        //s - seats
        private void SetHall(char place, string selected)
        {
            string keySubStr = "";
            string tempCheckKey = "";
            string firstKey = _seats.Keys.First();
            int left = firstKey.IndexOf('-');
            int right = firstKey.LastIndexOf('-');

            switch (place)
            {
                case 'c':
                    foreach (var key in _seats.Keys)
                    {
                        keySubStr = key.Substring(0, left);
                        if (keySubStr != tempCheckKey)
                        {
                            PickerSector.Items.Add(keySubStr);
                            tempCheckKey = keySubStr;
                        }
                    }
                    break;
                case 'r':
                    foreach (var key in _seats.Keys)
                    {
                        if (key.Substring(0, left).Contains(selected))
                        {
                            keySubStr = key.Substring(left + 1, right - left - 1);
                            if (keySubStr != tempCheckKey)
                            {
                                PickerRow.Items.Add(keySubStr);
                                tempCheckKey = keySubStr;
                            }
                        }
                    }
                    break;
                case 's':
                    foreach (var key in _seats.Keys)
                    {
                        if (key.Substring(left + 1, right - left).Contains(selected))
                        {
                            keySubStr = key.Substring(right + 1, key.Length - right - 1);
                            if (keySubStr != tempCheckKey)
                            {
                                PickerSeat.Items.Add(keySubStr);
                                tempCheckKey = keySubStr;
                            }
                        }
                    }
                    break;
            }
        }

        private void PickerSector_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            PickerRow.Items.Clear();
            PickerSeat.Items.Clear();
            SetHall('r', PickerSector.Items[PickerSector.SelectedIndex]);
        }

        private void PickerRow_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            PickerSeat.Items.Clear();
            SetHall('s', PickerRow.Items[PickerRow.SelectedIndex]);
        }

        private void PickerSeat_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (PickerSector.SelectedIndex != -1 && PickerRow.SelectedIndex != -1 && PickerSeat.SelectedIndex != -1)
                LabelPrice.Text =
                    _seats[
                        PickerSector.Items[PickerSector.SelectedIndex] + "-" +
                        PickerRow.Items[PickerRow.SelectedIndex] +
                        "-" + PickerSeat.Items[PickerSeat.SelectedIndex]];
            else
                LabelPrice.Text = "";
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            if (PickerSector.SelectedIndex != -1 && PickerRow.SelectedIndex != -1 && PickerSeat.SelectedIndex != -1)
            {
                string place =PickerSector.SelectedItem + "-" + PickerRow.SelectedItem + "-" + PickerSeat.SelectedItem;
                (BindingContext as PickPlaceViewModel).GoToDetail(place);

            }
            else
            {
                await DisplayAlert("Ошибка", "Заполните все поля", "OK");
            }
        }
    }
}