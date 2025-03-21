using System;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using System.IO;

namespace Desktop_app
{
    public partial class CalculatorForm : Form
    {
        // Перечисление для определения текущего типа расчета (Визитки или Флаеры)
        private enum CalculationType { BusinessCards, Flyers };
        private CalculationType currentCalculationType = CalculationType.Flyers; // По умолчанию - флаеры

        public CalculatorForm()
        {
            InitializeComponent();

            // Заполняем ComboBox для бумаги, цветности и размера флаеров
            comboBoxPaper.Items.AddRange(new object[] { "Мелованная", "Повышенной белизны (SPLENDORGEL)", "Журнальная" });
            comboBoxFlyerColor.Items.AddRange(new object[] { "1/0", "1/1", "4/0", "4/1", "4/4" });
            comboBoxFlyerSize.Items.AddRange(new object[] { "A4", "A5", "A6", "A7" });

            // Подписываемся на события ComboBox, чтобы картинки сразу обновлялись
            comboBoxFlyerColor.SelectedIndexChanged += ComboBoxFlyerColor_SelectedIndexChanged;
            comboBoxFlyerSize.SelectedIndexChanged += ComboBoxFlyerSize_SelectedIndexChanged;

            // Настройка видимости при загрузке
            currentCalculationType = CalculationType.Flyers;  //Начинаем с флаеров
            labelFlyerColor.Visible = true;
            comboBoxFlyerColor.Visible = true;
            labelFlyerSize.Visible = true;
            comboBoxFlyerSize.Visible = true;
            comboBoxPaper.Visible = true;
            //Инициализация, если сразу флаеры, то не надо видеть типы печати
            radioButtonOneSideBlackWhite.Visible = false;
            radioButtonTwoSidesBlackWhite.Visible = false;
            radioButtonOneSideColor.Visible = false;
            radioButtonTwoSidesColor.Visible = false;
            labelType.Visible = false;

            // Подписываемся на событие Click кнопки "Рассчитать"
            buttonCalculate.Click += buttonCalculate_Click;

            //Добавляем обработчики для кнопок переключения
            buttonBusinessCards.Click += buttonBusinessCards_Click;
            buttonFlyers.Click += buttonFlyers_Click;

            // Стилизация формы
            this.BackColor = Color.LightGray;
            this.Font = new Font("Arial", 10);
            this.Text = "Калькулятор печати";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false; // Запретить разворачивание на весь экран

            // Стилизация кнопок
            buttonCalculate.BackColor = Color.White;
            buttonBusinessCards.BackColor = Color.White;
            buttonFlyers.BackColor = Color.White;
            buttonCalculate.ForeColor = Color.DarkBlue;
            buttonBusinessCards.ForeColor = Color.DarkBlue;
            buttonFlyers.ForeColor = Color.DarkBlue;

            // Показываем картинку для стартового размера
            ShowFlyerFormatImage("listovka-a4"); // По умолчанию показываем A4
            ShowFlyerImage(comboBoxFlyerColor.Text);
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                int quantity = (int)numericUpDownQuantity.Value;
                double totalPrice = 0;

                // Получаем значения из ComboBox
                string color = comboBoxFlyerColor.SelectedItem?.ToString();
                string paper = comboBoxPaper.SelectedItem?.ToString();
                string size = comboBoxFlyerSize.SelectedItem?.ToString();

                // Проверка на null
                if (string.IsNullOrEmpty(color) || string.IsNullOrEmpty(paper) || string.IsNullOrEmpty(size))
                {
                    MessageBox.Show("Пожалуйста, выберите все параметры.");
                    return;
                }

                // 1. Цена изготовления шаблона (Цветность/цена)
                double templatePrice = 0;
                switch (color)
                {
                    case "1/0": templatePrice = 230; break;
                    case "1/1": templatePrice = 320; break;
                    case "4/0": templatePrice = 230; break;
                    case "4/1": templatePrice = 300; break;
                    case "4/4": templatePrice = 320; break;
                }

                // 2. Стоимость бумаги (Тип бумаги/цена за лист)
                double paperPricePerSheet = 0;
                switch (paper)
                {
                    case "Мелованная": paperPricePerSheet = 12; break;
                    case "Повышенной белизны (SPLENDORGEL)": paperPricePerSheet = 41.5; break;
                    case "Журнальная": paperPricePerSheet = 9; break;
                }

                // 3. Стоимость печати (Цветность/цена за лист)
                double printPricePerSheet = 0;
                switch (color)
                {
                    case "1/0": printPricePerSheet = 18; break;
                    case "1/1": printPricePerSheet = 36; break;
                    case "4/0": printPricePerSheet = 38; break;
                    case "4/1": printPricePerSheet = 53; break;
                    case "4/4": printPricePerSheet = 76; break;
                }

                // Расчет тиража (в зависимости от размера)
                double tirazhDivisor = 0;
                string imageListovka = "";
                switch (size)
                {
                    case "A4": tirazhDivisor = 4; imageListovka = "listovka-a4"; break;
                    case "A5": tirazhDivisor = 8; imageListovka = "listovka-a5"; break;
                    case "A6": tirazhDivisor = 16; imageListovka = "listovka-a6"; break;
                    case "A7": tirazhDivisor = 32; imageListovka = "listovka-a7"; break;
                }

                double tirazh = quantity / tirazhDivisor;

                // Стоимость = Цена изготовления шаблона + Стоимость бумаги*тираж + Стоимость печати*тираж
                totalPrice = templatePrice + paperPricePerSheet * tirazh + printPricePerSheet * tirazh;

                // Вывод итоговой цены
                labelResult.Text = "ИТОГ: " + totalPrice.ToString("N2") + " руб.";
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректное количество.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        // Отображение картинки флаера (в зависимости от цветности)
        private void ShowFlyerImage(string color)
        {
            string imageName = "";
            switch (color)
            {
                case "1/0": imageName = "1_0"; break;
                case "1/1": imageName = "1_1"; break;
                case "4/0": imageName = "4_0"; break;
                case "4/1": imageName = "4_1"; break;
                case "4/4": imageName = "4_4"; break;
            }

            if (!string.IsNullOrEmpty(imageName))
            {
                ShowImage(imageName, pictureBoxFlyer);
            }
            else
            {
                pictureBoxFlyer.Image = null;
                pictureBoxFlyer.Visible = false;
            }
        }

        // Отображение картинки формата листовки
        private void ShowFlyerFormatImage(string imageName)
        {
            ShowImage(imageName, pictureBoxFormat);
        }

        // Отображение картинки (общий метод)
        private void ShowImage(string imageName, PictureBox pictureBox)
        {
            try
            {
                Bitmap image = (Bitmap)Properties.Resources.ResourceManager.GetObject(imageName);

                if (image != null)
                {
                    pictureBox.Image = image;
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Visible = true;
                }
                else
                {
                    pictureBox.Image = null;
                    pictureBox.Visible = false;
                    MessageBox.Show("Изображение '" + imageName + "' не найдено в ресурсах.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображения: " + ex.Message);
            }
        }

        private void ComboBoxFlyerColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowFlyerImage(comboBoxFlyerColor.Text);
        }

        private void ComboBoxFlyerSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            string size = comboBoxFlyerSize.Text;
            string imageName = "";
            switch (size)
            {
                case "A4": imageName = "listovka-a4"; break;
                case "A5": imageName = "listovka-a5"; break;
                case "A6": imageName = "listovka-a6"; break;
                case "A7": imageName = "listovka-a7"; break;
            }
            ShowFlyerFormatImage(imageName);
        }

        // Обработчики для переключения между визитками и флаерами
        private void buttonBusinessCards_Click(object sender, EventArgs e)
        {
            //  isCardShowed = true;
            // isFlyerShowed = false;

            labelFlyerColor.Visible = false;
            comboBoxFlyerColor.Visible = false;
            labelFlyerSize.Visible = false;
            comboBoxFlyerSize.Visible = false;
            comboBoxPaper.Visible = false;

            radioButtonOneSideBlackWhite.Visible = true;
            radioButtonTwoSidesBlackWhite.Visible = true;
            radioButtonOneSideColor.Visible = true;
            radioButtonTwoSidesColor.Visible = true;

            labelType.Visible = true;

            currentCalculationType = CalculationType.BusinessCards;

        }

        private void buttonFlyers_Click(object sender, EventArgs e)
        {
            // isCardShowed = false;
            // isFlyerShowed = true;

            labelFlyerColor.Visible = true;
            comboBoxFlyerColor.Visible = true;
            labelFlyerSize.Visible = true;
            comboBoxFlyerSize.Visible = true;
            comboBoxPaper.Visible = true;

            radioButtonOneSideBlackWhite.Visible = false;
            radioButtonTwoSidesBlackWhite.Visible = false;
            radioButtonOneSideColor.Visible = false;
            radioButtonTwoSidesColor.Visible = false;

            labelType.Visible = false;

            currentCalculationType = CalculationType.Flyers;
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}