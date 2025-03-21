using System;
using System.Windows.Forms;

namespace Desktop_app
{
    public partial class MDIMainForm : Form
    {
        public MDIMainForm()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр формы калькулятора
            CalculatorForm calculatorForm = new CalculatorForm();

            // Указываем, что это дочернее окно MDI
            calculatorForm.MdiParent = this;

            // Показываем форму
            calculatorForm.Show();
        }

        private void закрытьПоследнееОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Закрываем последнее открытое дочернее окно
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
                break;
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}