using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Pages
{
    public partial class LoginPage : ContentPage
    {
        // Константа для текста кнопки
        public const string BUTTON_TEXT = "Войти";
        // Переменная счетчика
        public static int loginCouner = 0;

        // Создаем объект, возвращающий свойства устройства
        IDeviceDetector detector = DependencyService.Get<IDeviceDetector>();


        public LoginPage()
        {
            InitializeComponent();

            // Изменяем внешний вид кнопки для Windows-версии
            //if (Device.RuntimePlatform == Device.UWP)
            //    loginButton.CornerRadius = 0;

            // Изменяем внешний вид кнопки для Desktop-версии
            if (Device.Idiom == TargetIdiom.Desktop)
                loginButton.CornerRadius = 0;

            // Передаем информацию о платформе на экран
            runningDevice.Text = detector.GetDevice();
        }
        /*private void Login_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Text = "⌛ Выполняется вход...";          
        }*/

        /// <summary>
        /// По клику обрабатываем счётчик и выводим разные сообщения
        /// </summary>
        private async void Login_Click(object sender, EventArgs e)
        {
            loginButton.Text = $"Выполняется вход..";
            // Имитация задержки (приложение загружает данные с сервера)
            await Task.Delay(150);

            // Переход на следующую страницу - страницу списка устройств
            await Navigation.PushAsync(new DeviceListPage());
            // Восстановим первоначальный текст на кнопке (на случай, если пользователь вернется на этот экран чтобы выполнить вход снова)
            loginButton.Text = BUTTON_TEXT;

            //if (loginCouner == 0)
            //{
            //    // Если первая попытка - просто меняем сообщения
            //    loginButton.Text = $"⌛Выполняется вход..";
            //}
            //else if (loginCouner > 5) // Слишком много попыток - показываем ошибку
            //{
            //    // Деактивируем кнопку
            //    loginButton.IsEnabled = false;

            //    // Получаем последний дочерний элемент, используя свойство Children, затем выполняем распаковку
            //    var infoMessage = (Label)stackLayout.Children.Last();
            //    // Задаем текст элемента
            //    infoMessage.Text = "Слишком много попыток! Попробуйте позже";
            //}
            //else
            //{
            //    // Изменяем текст кнопки и показываем количество попыток входа
            //    loginButton.Text = $"⌛Выполняется вход...   Попыток входа: {loginCouner}";
            //}

            //// Увеличиваем счетчик
            //loginCouner += 1;
        }
    }
}