using System.Windows;

namespace РеализацияСимплекс_метода
{
    /// <summary>
    /// Класс окна вывода результата
    /// </summary>
    public partial class Output : Window
    {
        /// <summary>
        /// Инициализация окна
        /// </summary>
        public Output()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Закрытие окна
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //отмена закрытия
            e.Cancel = true;
            //место этого прячем
            Hide();
            //так сделано чтобы можно было повторно открыть это окно 
            //ведь мы не пересоздаём экземпляр этого окна
        }
    }
}
