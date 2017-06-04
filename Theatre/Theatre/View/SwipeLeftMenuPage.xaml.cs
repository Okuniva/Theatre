using System;
using System.Collections.Generic;
using Theatre.Model;
using Theatre.View.PerformancePage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Theatre.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwipeLeftMenuPage : MasterDetailPage
    {
        public List<DataMenuItem> menuList { get; set; }

        public SwipeLeftMenuPage()
        {
            InitializeComponent();

            menuList = new List<DataMenuItem>();
            var page1 = new DataMenuItem() { Title = "Главная", Icon = "itemIcon1.png", TargetType = typeof(HomePage) };
            //var page8 = new DataMenuItem() { Title = "Театры", Icon = "itemIcon4.png", TargetType = typeof(LoadingPage) };
            ////var page3 = new DataMenuItem() { Title = "Репертуар", Icon = "itemIcon4.png", TargetType = typeof(TheatresPage) };
            var page4 = new DataMenuItem() { Title = "Поиск", Icon = "itemIcon7.png", TargetType = typeof(SearchPage) };
            //var page5 = new DataMenuItem() { Title = "Мой Аккаунт", Icon = "itemIcon3.png", TargetType = typeof(AccountPage) };
            //// var page6 = new DataMenuItem() { Title = "Обратная связь", Icon = "itemIcon9.png", TargetType = typeof(FeedbackPage) };
            //var page7 = new DataMenuItem() { Title = "Билеты", Icon = "itemIcon8.png", TargetType = typeof(TicketsPage) };
            //var page2 = new DataMenuItem() { Title = "Новости", Icon = "itemIcon2.png", TargetType = typeof(ArticlePage) }; //IOS & UWP add
            //var page9 = new DataMenuItem() { Title = "Справка", Icon = "itemIcon6.png", TargetType = typeof(AboutPage) };
            ////var page10 = new DataMenuItem() { Title = "Избранное", Icon = "itemIcon5.png", TargetType = typeof(AboutPage) };

            menuList.Add(page1);
            //menuList.Add(page2);
            ////menuList.Add(page3);
            menuList.Add(page4);
            //menuList.Add(page5);
            ////menuList.Add(page6);
            //menuList.Add(page7);
            //menuList.Add(page8);
            //menuList.Add(page9);
            //menuList.Add(page10);

            navigationDrawerList.ItemsSource = menuList;
            navigationDrawerList.SelectedItem = page1;
            navigationDrawerList.SeparatorVisibility = SeparatorVisibility.None;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HomePage)));
            //{
            //    BarBackgroundColor = Color.FromHex("#99613B"),
            //    BarTextColor = Color.FromHex("#FFF2D8"),
            //};
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (DataMenuItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}