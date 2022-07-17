using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaddingPageFlyout : ContentPage
    {
        public ListView ListView;

        public PaddingPageFlyout()
        {
            InitializeComponent();

            BindingContext = new PaddingPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class PaddingPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<PaddingPageFlyoutMenuItem> MenuItems { get; set; }

            public PaddingPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<PaddingPageFlyoutMenuItem>(new[]
                {
                    new PaddingPageFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new PaddingPageFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new PaddingPageFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new PaddingPageFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new PaddingPageFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}