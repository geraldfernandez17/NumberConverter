
namespace NumberConvertion
{
    partial class number_converter
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_convert = new System.Windows.Forms.Button();
            this.lbl_ouput = new System.Windows.Forms.Label();
            this.lbl_warning = new System.Windows.Forms.Label();
            this.btn_reset = new System.Windows.Forms.Button();
            this.tb_input = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Input";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(368, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ouput";
            // 
            // btn_convert
            // 
            this.btn_convert.Location = new System.Drawing.Point(28, 132);
            this.btn_convert.Name = "btn_convert";
            this.btn_convert.Size = new System.Drawing.Size(112, 34);
            this.btn_convert.TabIndex = 3;
            this.btn_convert.Text = "Convert";
            this.btn_convert.UseVisualStyleBackColor = true;
            this.btn_convert.Click += new System.EventHandler(this.btn_convert_Click);
            // 
            // lbl_ouput
            // 
            this.lbl_ouput.Location = new System.Drawing.Point(107, 300);
            this.lbl_ouput.Name = "lbl_ouput";
            this.lbl_ouput.Size = new System.Drawing.Size(588, 106);
            this.lbl_ouput.TabIndex = 5;
            this.lbl_ouput.Text = ". . . .";
            this.lbl_ouput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_warning
            // 
            this.lbl_warning.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lbl_warning.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbl_warning.Location = new System.Drawing.Point(28, 189);
            this.lbl_warning.Name = "lbl_warning";
            this.lbl_warning.Size = new System.Drawing.Size(458, 58);
            this.lbl_warning.TabIndex = 6;
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(159, 132);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(112, 34);
            this.btn_reset.TabIndex = 7;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // tb_input
            // 
            this.tb_input.Location = new System.Drawing.Point(28, 70);
            this.tb_input.Name = "tb_input";
            this.tb_input.Size = new System.Drawing.Size(403, 31);
            this.tb_input.TabIndex = 8;
            this.tb_input.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_input_KeyPress);
            // 
            // number_converter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tb_input);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.lbl_warning);
            this.Controls.Add(this.lbl_ouput);
            this.Controls.Add(this.btn_convert);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "number_converter";
            this.Text = "Number Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_convert;
        private System.Windows.Forms.Label lbl_ouput;
        private System.Windows.Forms.Label lbl_warning;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.TextBox tb_input;
    }
}

