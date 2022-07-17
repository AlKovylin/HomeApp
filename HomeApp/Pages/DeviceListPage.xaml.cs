using System.Collections.Generic;
using Xamarin.Forms;
using HomeApp.Models;
using System.Linq;
using System;
using System.Collections.ObjectModel;

namespace HomeApp.Pages
{
    public partial class DeviceListPage : ContentPage
    {
        /// <summary>
        /// Ссылка на выбранный объект
        /// </summary>
        private HomeDevice SelectedDevice;

        /// <summary>
        /// Группируемая коллекция
        /// </summary>
        public ObservableCollection<Group<string, HomeDevice>> DeviceGroups { get; set; } = new ObservableCollection<Group<string, HomeDevice>>();

        public DeviceListPage()
        {
            InitializeComponent();

            // Первоначальные данные сохраним в обычном листе
            var initialList = new List<HomeDevice>();
            initialList.Add(new HomeDevice("Чайник", "Chainik.png", "LG, объем 2л.", "Кухня"));
            initialList.Add(new HomeDevice("Стиральная машина", "StiralnayaMashina.png", description: "BOSCH", "Ванная"));
            initialList.Add(new HomeDevice("Посудомоечная машина", "PosudomoechnayaMashina.png", "Gorenje", "Кухня"));
            initialList.Add(new HomeDevice("Мультиварка", "Multivarka.png", "Philips", "Кухня"));

            // Сгруппируем по комнатам
            var devicesByRooms = initialList.GroupBy(d => d.Room).Select(g => new Group<string, HomeDevice>(g.Key, g));

            // Сохраним
            DeviceGroups = new ObservableCollection<Group<string, HomeDevice>>(devicesByRooms);
            BindingContext = this;
        }

        /// <summary>
        /// Обработчик нажатия
        /// </summary>
        private void deviceList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // распаковка модели из объекта
            var tappedDevice = (HomeDevice)e.Item;
            // уведомление
            DisplayAlert("Нажатие", $"Вы нажали на элемент {tappedDevice.Name}", "OK"); ; ;
        }

        /// <summary>
        /// Обработчик выбора
        /// </summary>
        private void deviceList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // распаковка модели из объекта
            SelectedDevice = (HomeDevice)e.SelectedItem;
        }

        private async void LogoutButton_Clicked(object sender, EventArgs e)
        {
            // Возврат на первую страницу стека навигации (корневую страницу приложения) - экран логина
            await Navigation.PopAsync();
        }

        private async void NewDeviceButton_Clicked(object sender, EventArgs e)
        {
            // Переход на следующую страницу - страницу нового устройства (и помещение её в стек навигации)
            await Navigation.PushAsync(new DevicePage("Добавить устройство"));
            
        }

        private async void EditDeviceButton_Clicked(object sender, EventArgs e)
        {
            // проверяем, выбрал ли пользователь устройство из списка
            if (SelectedDevice == null)
            {
                await DisplayAlert(null, $"Пожалуйста, выберите устройство!", "OK");
                return;
            }

            // Переход на следующую страницу - страницу нового устройства (и помещение её в стек навигации)
            await Navigation.PushAsync(new DevicePage("Изменить устройство", SelectedDevice));
        }
    }
}