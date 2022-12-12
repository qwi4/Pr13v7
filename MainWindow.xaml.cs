using System;
using System.Windows;

namespace Pr13v7
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

        private void mItEx_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вариант 7. " +
               "Дана матрица размера M * N. Найти номера строки и столбца для " +
               "элемента матрицы, наиболее близкого к среднему значению всех ее элементов.",
               "Задание",
               MessageBoxButton.OK,
               MessageBoxImage.Asterisk);
        }

        private void mItDeveloper_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("10",
               "Разработчик",
               MessageBoxButton.OK,
               MessageBoxImage.Asterisk);
        }

        private void mItExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        Matrix<int> matrix = new Matrix<int>(0, 0);

        private void btnFill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MatrixManipulations.Create(matrix, 
                Convert.ToInt32(txtboxRows.Text), 
                Convert.ToInt32(txtboxColumns.Text), 
                Convert.ToInt32(txtboxRangeMin.Text), 
                Convert.ToInt32(txtboxRangeMax.Text));

                dgMatrix1.ItemsSource = matrix.ToDataTable().DefaultView;

                txtboxTableSize.Text = $"{Convert.ToInt32(txtboxRows.Text)}:{Convert.ToInt32(txtboxColumns.Text)}";
            }
            catch (Exception)
            {
                MessageBox.Show("Введены неверные данные",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }           
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string path = @".\matrix" + matrix.Extension;
            matrix.Save(path);
            MessageBox.Show("Отлично!",
                "Сохранение",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            string path = @".\matrix" + matrix.Extension;
            matrix.Open(path);
            dgMatrix1.ItemsSource = matrix.ToDataTable().DefaultView;
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            txtboxResultRow.Text = MatrixManipulations.CalculateRow(matrix).ToString();
            txtboxResultColumn.Text = MatrixManipulations.CalculateColumn(matrix).ToString();
        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txtboxRows.Clear();
            txtboxColumns.Clear();
            txtboxRangeMin.Clear();
            txtboxRangeMax.Clear();
            txtboxResultRow.Clear();
            txtboxResultColumn.Clear();
            txtboxCellNumber.Clear();
            txtboxTableSize.Clear();
        }

        private void dgMatrix1_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {
            txtboxCellNumber.Text = $"{e.Row.GetIndex()}:{e.Column.DisplayIndex}";
            //Int32 selectedColumnCount = dgMatrix1.Columns;
        }

        private void txtboxRows_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            txtboxResultRow.Clear();
            txtboxResultColumn.Clear();
            txtboxTableSize.Clear();
            txtboxCellNumber.Clear();
        }

    }
}
