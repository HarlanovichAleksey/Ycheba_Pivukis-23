namespace Desktop_app
{
    partial class CalculatorForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxPaper = new System.Windows.Forms.ComboBox();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.buttonBusinessCards = new System.Windows.Forms.Button();
            this.buttonFlyers = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.comboBoxFlyerColor = new System.Windows.Forms.ComboBox();
            this.comboBoxFlyerSize = new System.Windows.Forms.ComboBox();
            this.radioButtonOneSideBlackWhite = new System.Windows.Forms.RadioButton();
            this.labelType = new System.Windows.Forms.Label();
            this.labelFlyerColor = new System.Windows.Forms.Label();
            this.labelFlyerSize = new System.Windows.Forms.Label();
            this.radioButtonTwoSidesBlackWhite = new System.Windows.Forms.RadioButton();
            this.radioButtonOneSideColor = new System.Windows.Forms.RadioButton();
            this.radioButtonTwoSidesColor = new System.Windows.Forms.RadioButton();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.pictureBoxFlyer = new System.Windows.Forms.PictureBox();
            this.pictureBoxFormat = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFlyer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFormat)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxPaper
            // 
            this.comboBoxPaper.FormattingEnabled = true;
            this.comboBoxPaper.Location = new System.Drawing.Point(40, 226);
            this.comboBoxPaper.Name = "comboBoxPaper";
            this.comboBoxPaper.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPaper.TabIndex = 0;
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(192, 89);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(75, 23);
            this.buttonCalculate.TabIndex = 1;
            this.buttonCalculate.Text = "Рассчитать";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            // 
            // buttonBusinessCards
            // 
            this.buttonBusinessCards.Location = new System.Drawing.Point(302, 89);
            this.buttonBusinessCards.Name = "buttonBusinessCards";
            this.buttonBusinessCards.Size = new System.Drawing.Size(75, 23);
            this.buttonBusinessCards.TabIndex = 2;
            this.buttonBusinessCards.Text = "Визитки";
            this.buttonBusinessCards.UseVisualStyleBackColor = true;
            // 
            // buttonFlyers
            // 
            this.buttonFlyers.Location = new System.Drawing.Point(417, 89);
            this.buttonFlyers.Name = "buttonFlyers";
            this.buttonFlyers.Size = new System.Drawing.Size(75, 23);
            this.buttonFlyers.TabIndex = 3;
            this.buttonFlyers.Text = "Флаеры";
            this.buttonFlyers.UseVisualStyleBackColor = true;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(564, 381);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(37, 13);
            this.labelResult.TabIndex = 4;
            this.labelResult.Text = "Итог: ";
            // 
            // comboBoxFlyerColor
            // 
            this.comboBoxFlyerColor.FormattingEnabled = true;
            this.comboBoxFlyerColor.Location = new System.Drawing.Point(40, 152);
            this.comboBoxFlyerColor.Name = "comboBoxFlyerColor";
            this.comboBoxFlyerColor.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFlyerColor.TabIndex = 5;
            // 
            // comboBoxFlyerSize
            // 
            this.comboBoxFlyerSize.FormattingEnabled = true;
            this.comboBoxFlyerSize.Location = new System.Drawing.Point(40, 189);
            this.comboBoxFlyerSize.Name = "comboBoxFlyerSize";
            this.comboBoxFlyerSize.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFlyerSize.TabIndex = 6;
            // 
            // radioButtonOneSideBlackWhite
            // 
            this.radioButtonOneSideBlackWhite.AutoSize = true;
            this.radioButtonOneSideBlackWhite.Location = new System.Drawing.Point(575, 124);
            this.radioButtonOneSideBlackWhite.Name = "radioButtonOneSideBlackWhite";
            this.radioButtonOneSideBlackWhite.Size = new System.Drawing.Size(125, 17);
            this.radioButtonOneSideBlackWhite.TabIndex = 8;
            this.radioButtonOneSideBlackWhite.TabStop = true;
            this.radioButtonOneSideBlackWhite.Text = "Односторонняя, ЧБ";
            this.radioButtonOneSideBlackWhite.UseVisualStyleBackColor = true;
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(572, 90);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(29, 13);
            this.labelType.TabIndex = 9;
            this.labelType.Text = "Тип:";
            // 
            // labelFlyerColor
            // 
            this.labelFlyerColor.AutoSize = true;
            this.labelFlyerColor.Location = new System.Drawing.Point(40, 136);
            this.labelFlyerColor.Name = "labelFlyerColor";
            this.labelFlyerColor.Size = new System.Drawing.Size(64, 13);
            this.labelFlyerColor.TabIndex = 10;
            this.labelFlyerColor.Text = "Цветность:";
            // 
            // labelFlyerSize
            // 
            this.labelFlyerSize.AutoSize = true;
            this.labelFlyerSize.Location = new System.Drawing.Point(40, 173);
            this.labelFlyerSize.Name = "labelFlyerSize";
            this.labelFlyerSize.Size = new System.Drawing.Size(49, 13);
            this.labelFlyerSize.TabIndex = 11;
            this.labelFlyerSize.Text = "Размер:";
            // 
            // radioButtonTwoSidesBlackWhite
            // 
            this.radioButtonTwoSidesBlackWhite.AutoSize = true;
            this.radioButtonTwoSidesBlackWhite.Location = new System.Drawing.Point(575, 156);
            this.radioButtonTwoSidesBlackWhite.Name = "radioButtonTwoSidesBlackWhite";
            this.radioButtonTwoSidesBlackWhite.Size = new System.Drawing.Size(119, 17);
            this.radioButtonTwoSidesBlackWhite.TabIndex = 12;
            this.radioButtonTwoSidesBlackWhite.TabStop = true;
            this.radioButtonTwoSidesBlackWhite.Text = "Двусторонняя, ЧБ";
            this.radioButtonTwoSidesBlackWhite.UseVisualStyleBackColor = true;
            // 
            // radioButtonOneSideColor
            // 
            this.radioButtonOneSideColor.AutoSize = true;
            this.radioButtonOneSideColor.Location = new System.Drawing.Point(575, 203);
            this.radioButtonOneSideColor.Name = "radioButtonOneSideColor";
            this.radioButtonOneSideColor.Size = new System.Drawing.Size(125, 17);
            this.radioButtonOneSideColor.TabIndex = 13;
            this.radioButtonOneSideColor.TabStop = true;
            this.radioButtonOneSideColor.Text = "Односторонняя, ЦВ";
            this.radioButtonOneSideColor.UseVisualStyleBackColor = true;
            // 
            // radioButtonTwoSidesColor
            // 
            this.radioButtonTwoSidesColor.AutoSize = true;
            this.radioButtonTwoSidesColor.Location = new System.Drawing.Point(575, 226);
            this.radioButtonTwoSidesColor.Name = "radioButtonTwoSidesColor";
            this.radioButtonTwoSidesColor.Size = new System.Drawing.Size(119, 17);
            this.radioButtonTwoSidesColor.TabIndex = 14;
            this.radioButtonTwoSidesColor.TabStop = true;
            this.radioButtonTwoSidesColor.Text = "Двусторонняя, ЦВ";
            this.radioButtonTwoSidesColor.UseVisualStyleBackColor = false;
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Location = new System.Drawing.Point(40, 50);
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownQuantity.TabIndex = 15;
            this.numericUpDownQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(40, 34);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(69, 13);
            this.labelQuantity.TabIndex = 16;
            this.labelQuantity.Text = "Количество:";
            // 
            // pictureBoxFlyer
            // 
            this.pictureBoxFlyer.Location = new System.Drawing.Point(227, 152);
            this.pictureBoxFlyer.Name = "pictureBoxFlyer";
            this.pictureBoxFlyer.Size = new System.Drawing.Size(306, 242);
            this.pictureBoxFlyer.TabIndex = 17;
            this.pictureBoxFlyer.TabStop = false;
            // 
            // pictureBoxFormat
            // 
            this.pictureBoxFormat.Location = new System.Drawing.Point(40, 298);
            this.pictureBoxFormat.Name = "pictureBoxFormat";
            this.pictureBoxFormat.Size = new System.Drawing.Size(150, 96);
            this.pictureBoxFormat.TabIndex = 18;
            this.pictureBoxFormat.TabStop = false;
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 409);
            this.Controls.Add(this.pictureBoxFormat);
            this.Controls.Add(this.pictureBoxFlyer);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.numericUpDownQuantity);
            this.Controls.Add(this.radioButtonTwoSidesColor);
            this.Controls.Add(this.radioButtonOneSideColor);
            this.Controls.Add(this.radioButtonTwoSidesBlackWhite);
            this.Controls.Add(this.labelFlyerSize);
            this.Controls.Add(this.labelFlyerColor);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.radioButtonOneSideBlackWhite);
            this.Controls.Add(this.comboBoxFlyerSize);
            this.Controls.Add(this.comboBoxFlyerColor);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.buttonFlyers);
            this.Controls.Add(this.buttonBusinessCards);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.comboBoxPaper);
            this.Name = "CalculatorForm";
            this.Text = "Калькулятор печати";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFlyer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFormat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPaper;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Button buttonBusinessCards;
        private System.Windows.Forms.Button buttonFlyers;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.ComboBox comboBoxFlyerColor;
        private System.Windows.Forms.ComboBox comboBoxFlyerSize;
        private System.Windows.Forms.RadioButton radioButtonOneSideBlackWhite;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelFlyerColor;
        private System.Windows.Forms.Label labelFlyerSize;
        private System.Windows.Forms.RadioButton radioButtonTwoSidesBlackWhite;
        private System.Windows.Forms.RadioButton radioButtonOneSideColor;
        private System.Windows.Forms.RadioButton radioButtonTwoSidesColor;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.PictureBox pictureBoxFlyer;
        private System.Windows.Forms.PictureBox pictureBoxFormat;
    }
}

