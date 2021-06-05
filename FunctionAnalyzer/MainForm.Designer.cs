using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunctionAnalyzer
{
    partial class MainForm
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
            this.expressionBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.readExpressionButton = new System.Windows.Forms.Button();
            this.writeExpressionButton = new System.Windows.Forms.Button();
            this.analyzeExpressionButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.unfixedVariableBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fixedValueVariableBox = new System.Windows.Forms.TextBox();
            this.printGraphButton = new System.Windows.Forms.Button();
            this.accuracyBox = new System.Windows.Forms.TextBox();
            this.resultBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.findRootButton = new System.Windows.Forms.Button();
            this.printTreeButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.aBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // expressionBox
            // 
            this.expressionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expressionBox.Location = new System.Drawing.Point(120, 32);
            this.expressionBox.Name = "expressionBox";
            this.expressionBox.Size = new System.Drawing.Size(200, 26);
            this.expressionBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(154, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Анализируемая функция";
            // 
            // readExpressionButton
            // 
            this.readExpressionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.readExpressionButton.Location = new System.Drawing.Point(134, 64);
            this.readExpressionButton.Name = "readExpressionButton";
            this.readExpressionButton.Size = new System.Drawing.Size(75, 40);
            this.readExpressionButton.TabIndex = 2;
            this.readExpressionButton.Text = "Загрузить из файла";
            this.readExpressionButton.UseVisualStyleBackColor = true;
            this.readExpressionButton.Click += new System.EventHandler(this.readExpressionButton_Click);
            // 
            // writeExpressionButton
            // 
            this.writeExpressionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.writeExpressionButton.Location = new System.Drawing.Point(229, 64);
            this.writeExpressionButton.Name = "writeExpressionButton";
            this.writeExpressionButton.Size = new System.Drawing.Size(75, 40);
            this.writeExpressionButton.TabIndex = 3;
            this.writeExpressionButton.Text = "Записать в файл";
            this.writeExpressionButton.UseVisualStyleBackColor = true;
            this.writeExpressionButton.Click += new System.EventHandler(this.writeExpressionButton_Click);
            // 
            // analyzeExpressionButton
            // 
            this.analyzeExpressionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.analyzeExpressionButton.Location = new System.Drawing.Point(120, 110);
            this.analyzeExpressionButton.Name = "analyzeExpressionButton";
            this.analyzeExpressionButton.Size = new System.Drawing.Size(200, 40);
            this.analyzeExpressionButton.TabIndex = 4;
            this.analyzeExpressionButton.Text = "Проанализировать выражение";
            this.analyzeExpressionButton.UseVisualStyleBackColor = true;
            this.analyzeExpressionButton.Click += new System.EventHandler(this.analyzeExpressionButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(68, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(270, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Зафиксировать значения всех переменных, кроме:";
            // 
            // unfixedVariableBox
            // 
            this.unfixedVariableBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.unfixedVariableBox.Location = new System.Drawing.Point(344, 209);
            this.unfixedVariableBox.MaxLength = 1;
            this.unfixedVariableBox.Name = "unfixedVariableBox";
            this.unfixedVariableBox.Size = new System.Drawing.Size(27, 26);
            this.unfixedVariableBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(59, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Установить зафиксированным переменным значение:";
            // 
            // fixedValueVariableBox
            // 
            this.fixedValueVariableBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fixedValueVariableBox.Location = new System.Drawing.Point(353, 248);
            this.fixedValueVariableBox.Name = "fixedValueVariableBox";
            this.fixedValueVariableBox.Size = new System.Drawing.Size(50, 26);
            this.fixedValueVariableBox.TabIndex = 8;
            // 
            // printGraphButton
            // 
            this.printGraphButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.printGraphButton.Location = new System.Drawing.Point(120, 284);
            this.printGraphButton.Name = "printGraphButton";
            this.printGraphButton.Size = new System.Drawing.Size(200, 40);
            this.printGraphButton.TabIndex = 9;
            this.printGraphButton.Text = "Построить график функции";
            this.printGraphButton.UseVisualStyleBackColor = true;
            this.printGraphButton.Click += new System.EventHandler(this.printGraphButton_Click);
            // 
            // accuracyBox
            // 
            this.accuracyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.accuracyBox.Location = new System.Drawing.Point(332, 355);
            this.accuracyBox.Name = "accuracyBox";
            this.accuracyBox.Size = new System.Drawing.Size(72, 26);
            this.accuracyBox.TabIndex = 10;
            // 
            // resultBox
            // 
            this.resultBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultBox.Location = new System.Drawing.Point(237, 414);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(103, 26);
            this.resultBox.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(341, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Точность";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(261, 398);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Результат";
            // 
            // findRootButton
            // 
            this.findRootButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.findRootButton.Location = new System.Drawing.Point(106, 415);
            this.findRootButton.Name = "findRootButton";
            this.findRootButton.Size = new System.Drawing.Size(103, 26);
            this.findRootButton.TabIndex = 14;
            this.findRootButton.Text = "Найти корень";
            this.findRootButton.UseVisualStyleBackColor = true;
            this.findRootButton.Click += new System.EventHandler(this.findRootButton_Click);
            // 
            // printTreeButton
            // 
            this.printTreeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.printTreeButton.Location = new System.Drawing.Point(120, 156);
            this.printTreeButton.Name = "printTreeButton";
            this.printTreeButton.Size = new System.Drawing.Size(200, 40);
            this.printTreeButton.TabIndex = 15;
            this.printTreeButton.Text = "Отобразить бинарное дерево";
            this.printTreeButton.UseVisualStyleBackColor = true;
            this.printTreeButton.Click += new System.EventHandler(this.printTreeButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(23, 363);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Искать корень в интервале от";
            // 
            // aBox
            // 
            this.aBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aBox.Location = new System.Drawing.Point(186, 355);
            this.aBox.Name = "aBox";
            this.aBox.Size = new System.Drawing.Size(50, 26);
            this.aBox.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(239, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "до";
            // 
            // bBox
            // 
            this.bBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bBox.Location = new System.Drawing.Point(261, 355);
            this.bBox.Name = "bBox";
            this.bBox.Size = new System.Drawing.Size(50, 26);
            this.bBox.TabIndex = 19;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 461);
            this.Controls.Add(this.bBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.aBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.printTreeButton);
            this.Controls.Add(this.findRootButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.accuracyBox);
            this.Controls.Add(this.printGraphButton);
            this.Controls.Add(this.fixedValueVariableBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.unfixedVariableBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.analyzeExpressionButton);
            this.Controls.Add(this.writeExpressionButton);
            this.Controls.Add(this.readExpressionButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.expressionBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Function Analyzer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox expressionBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button readExpressionButton;
        private System.Windows.Forms.Button writeExpressionButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox unfixedVariableBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fixedValueVariableBox;
        private System.Windows.Forms.Button printGraphButton;
        private System.Windows.Forms.TextBox accuracyBox;
        private System.Windows.Forms.TextBox resultBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button findRootButton;
        private System.Windows.Forms.Button printTreeButton;
        private System.Windows.Forms.Button analyzeExpressionButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox aBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox bBox;
    }
}

