using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Verenchuk
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            Window1 passwordWindow = new Window1();
            if (passwordWindow.ShowDialog() == false)
                return;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы(*.txt)| *.txt";
            if (saveFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            string currentText = this.Text.Text;
            try
            {
                FileVigenere.WriteOnFile(saveFileDialog.FileName, currentText, passwordWindow.GetPassword());
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show("Ошибка при записи файла: " + ex.Message);
                return;
            }

        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            Window1 passwordWindow = new Window1();
            if (passwordWindow.ShowDialog() == false)
                return;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы(*.txt)| *.txt";
            if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            string resultDecryption;
            try
            {
                resultDecryption = FileVigenere.ReadFromFile(openFileDialog.FileName, passwordWindow.GetPassword());
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Ошибка при чтении файла: " + ex.Message);
                return;
            }

            this.Text.Text = resultDecryption;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void SaveFileWithoutCrypt(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы(*.txt)| *.txt";

            if (saveFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            string currentText = this.Text.Text;
            try
            {
                FileVigenere.WriteOnFile(saveFileDialog.FileName, currentText, null);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Ошибка при записи файла: " + ex.Message);
                return;
            }
        }
    }
}
