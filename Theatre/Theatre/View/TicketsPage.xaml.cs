using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLStorage;
using Theatre.Model;
using Theatre.Services;
using Theatre.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Theatre.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketsPage : ContentPage
    {
        public TicketsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as TicketsListViewViewModel)?.Init(Navigation);
        }

        private async void TicketsLV_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((Xamarin.Forms.ListView)sender).SelectedItem = null;
            IFolder folder = FileSystem.Current.LocalStorage;
            var i = e.SelectedItem as Ticket;
            //open file if exists
            IFile file = await folder.GetFileAsync(i.id + i.file_name);
            //load stream to buffer
            using (System.IO.Stream stream = await file.OpenAsync(FileAccess.ReadAndWrite))
            {
                long length = stream.Length;
                byte[] streamBuffer = new byte[length];
                stream.Read(streamBuffer, 0, (int)length);
                DependencyService.Get<IFileWorker>().DownloadPDF(i.file_name, streamBuffer);
            }
        }
    }
}