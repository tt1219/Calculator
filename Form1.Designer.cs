﻿namespace Calculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label_Input = new Label();
            Label_Process = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            button14 = new Button();
            button15 = new Button();
            button16 = new Button();
            button17 = new Button();
            button18 = new Button();
            button19 = new Button();
            button20 = new Button();
            SuspendLayout();
            // 
            // Label_Input
            // 
            Label_Input.Font = new Font("Yu Gothic UI", 20F);
            Label_Input.Location = new Point(36, 34);
            Label_Input.Name = "Label_Input";
            Label_Input.Size = new Size(250, 38);
            Label_Input.TabIndex = 0;
            Label_Input.Text = "0";
            Label_Input.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Label_Process
            // 
            Label_Process.Location = new Point(86, 9);
            Label_Process.Name = "Label_Process";
            Label_Process.Size = new Size(200, 15);
            Label_Process.TabIndex = 0;
            Label_Process.TextAlign = ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            button1.Location = new Point(12, 95);
            button1.Name = "button1";
            button1.Size = new Size(64, 43);
            button1.TabIndex = 1;
            button1.Text = "%";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(82, 95);
            button2.Name = "button2";
            button2.Size = new Size(64, 43);
            button2.TabIndex = 1;
            button2.Text = "CE";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ClearEntry_Click;
            // 
            // button3
            // 
            button3.Location = new Point(152, 95);
            button3.Name = "button3";
            button3.Size = new Size(64, 43);
            button3.TabIndex = 1;
            button3.Text = "C";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Clear_Click;
            // 
            // button4
            // 
            button4.Location = new Point(222, 95);
            button4.Name = "button4";
            button4.Size = new Size(64, 43);
            button4.TabIndex = 1;
            button4.Text = "÷";
            button4.UseVisualStyleBackColor = true;
            button4.Click += OperationButton_Click;
            // 
            // button5
            // 
            button5.Location = new Point(12, 144);
            button5.Name = "button5";
            button5.Size = new Size(64, 43);
            button5.TabIndex = 1;
            button5.Text = "7";
            button5.UseVisualStyleBackColor = true;
            button5.Click += NumberButton_Click;
            // 
            // button6
            // 
            button6.Location = new Point(82, 144);
            button6.Name = "button6";
            button6.Size = new Size(64, 43);
            button6.TabIndex = 1;
            button6.Text = "8";
            button6.UseVisualStyleBackColor = true;
            button6.Click += NumberButton_Click;
            // 
            // button7
            // 
            button7.Location = new Point(152, 144);
            button7.Name = "button7";
            button7.Size = new Size(64, 43);
            button7.TabIndex = 1;
            button7.Text = "9";
            button7.UseVisualStyleBackColor = true;
            button7.Click += NumberButton_Click;
            // 
            // button8
            // 
            button8.Location = new Point(222, 144);
            button8.Name = "button8";
            button8.Size = new Size(64, 43);
            button8.TabIndex = 1;
            button8.Text = "×";
            button8.UseVisualStyleBackColor = true;
            button8.Click += OperationButton_Click;
            // 
            // button9
            // 
            button9.Location = new Point(12, 193);
            button9.Name = "button9";
            button9.Size = new Size(64, 43);
            button9.TabIndex = 1;
            button9.Text = "4";
            button9.UseVisualStyleBackColor = true;
            button9.Click += NumberButton_Click;
            // 
            // button10
            // 
            button10.Location = new Point(82, 193);
            button10.Name = "button10";
            button10.Size = new Size(64, 43);
            button10.TabIndex = 1;
            button10.Text = "5";
            button10.UseVisualStyleBackColor = true;
            button10.Click += NumberButton_Click;
            // 
            // button11
            // 
            button11.Location = new Point(152, 193);
            button11.Name = "button11";
            button11.Size = new Size(64, 43);
            button11.TabIndex = 1;
            button11.Text = "6";
            button11.UseVisualStyleBackColor = true;
            button11.Click += NumberButton_Click;
            // 
            // button12
            // 
            button12.Location = new Point(222, 193);
            button12.Name = "button12";
            button12.Size = new Size(64, 43);
            button12.TabIndex = 1;
            button12.Text = "-";
            button12.UseVisualStyleBackColor = true;
            button12.Click += OperationButton_Click;
            // 
            // button13
            // 
            button13.Location = new Point(12, 242);
            button13.Name = "button13";
            button13.Size = new Size(64, 43);
            button13.TabIndex = 1;
            button13.Text = "1";
            button13.UseVisualStyleBackColor = true;
            button13.Click += NumberButton_Click;
            // 
            // button14
            // 
            button14.Location = new Point(82, 242);
            button14.Name = "button14";
            button14.Size = new Size(64, 43);
            button14.TabIndex = 1;
            button14.Text = "2";
            button14.UseVisualStyleBackColor = true;
            button14.Click += NumberButton_Click;
            // 
            // button15
            // 
            button15.Location = new Point(152, 242);
            button15.Name = "button15";
            button15.Size = new Size(64, 43);
            button15.TabIndex = 1;
            button15.Text = "3";
            button15.UseVisualStyleBackColor = true;
            button15.Click += NumberButton_Click;
            // 
            // button16
            // 
            button16.Location = new Point(222, 242);
            button16.Name = "button16";
            button16.Size = new Size(64, 43);
            button16.TabIndex = 1;
            button16.Text = "+";
            button16.UseVisualStyleBackColor = true;
            button16.Click += OperationButton_Click;
            // 
            // button17
            // 
            button17.Location = new Point(12, 291);
            button17.Name = "button17";
            button17.Size = new Size(64, 43);
            button17.TabIndex = 1;
            button17.Text = "±";
            button17.UseVisualStyleBackColor = true;
            button17.Click += PlusMinus_Click;
            // 
            // button18
            // 
            button18.Location = new Point(82, 291);
            button18.Name = "button18";
            button18.Size = new Size(64, 43);
            button18.TabIndex = 1;
            button18.Text = "0";
            button18.UseVisualStyleBackColor = true;
            button18.Click += NumberButton_Click;
            // 
            // button19
            // 
            button19.Location = new Point(152, 291);
            button19.Name = "button19";
            button19.Size = new Size(64, 43);
            button19.TabIndex = 1;
            button19.Text = ".";
            button19.UseVisualStyleBackColor = true;
            button19.Click += DotButton_Click;
            // 
            // button20
            // 
            button20.Location = new Point(222, 291);
            button20.Name = "button20";
            button20.Size = new Size(64, 43);
            button20.TabIndex = 1;
            button20.Text = "=";
            button20.UseVisualStyleBackColor = true;
            button20.Click += OperationButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(302, 349);
            Controls.Add(button20);
            Controls.Add(button19);
            Controls.Add(button16);
            Controls.Add(button15);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(button18);
            Controls.Add(button8);
            Controls.Add(button14);
            Controls.Add(button7);
            Controls.Add(button10);
            Controls.Add(button17);
            Controls.Add(button4);
            Controls.Add(button13);
            Controls.Add(button6);
            Controls.Add(button9);
            Controls.Add(button3);
            Controls.Add(button5);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(Label_Process);
            Controls.Add(Label_Input);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Label Label_Input;
        private Label Label_Process;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button14;
        private Button button15;
        private Button button16;
        private Button button17;
        private Button button18;
        private Button button19;
        private Button button20;
    }
}
