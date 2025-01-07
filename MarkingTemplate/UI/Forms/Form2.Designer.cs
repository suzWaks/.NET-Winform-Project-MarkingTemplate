namespace MarkingTemplate
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ResultName = new System.Windows.Forms.Label();
            this.ResultDevLevel = new System.Windows.Forms.Label();
            this.ratingValue = new System.Windows.Forms.Label();
            this.FinalPercentage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(348, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Hi BOY!";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel1.Controls.Add(this.ResultName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ResultDevLevel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ratingValue, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.FinalPercentage, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.13542F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.44792F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.97917F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.94792F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.51852F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(782, 509);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // ResultName
            // 
            this.ResultName.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.ResultName, 4);
            this.ResultName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultName.ForeColor = System.Drawing.Color.AliceBlue;
            this.ResultName.Location = new System.Drawing.Point(46, 85);
            this.ResultName.Name = "ResultName";
            this.ResultName.Size = new System.Drawing.Size(686, 67);
            this.ResultName.TabIndex = 0;
            this.ResultName.Text = "Name";
            this.ResultName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ResultDevLevel
            // 
            this.ResultDevLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultDevLevel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.ResultDevLevel, 4);
            this.ResultDevLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultDevLevel.ForeColor = System.Drawing.Color.LightBlue;
            this.ResultDevLevel.Location = new System.Drawing.Point(46, 152);
            this.ResultDevLevel.Name = "ResultDevLevel";
            this.ResultDevLevel.Size = new System.Drawing.Size(686, 25);
            this.ResultDevLevel.TabIndex = 1;
            this.ResultDevLevel.Text = "Developer Level";
            this.ResultDevLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ratingValue
            // 
            this.ratingValue.AutoSize = true;
            this.ratingValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ratingValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ratingValue.ForeColor = System.Drawing.Color.Orange;
            this.ratingValue.Location = new System.Drawing.Point(219, 244);
            this.ratingValue.Name = "ratingValue";
            this.ratingValue.Size = new System.Drawing.Size(167, 69);
            this.ratingValue.TabIndex = 2;
            this.ratingValue.Text = "0.00";
            this.ratingValue.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // FinalPercentage
            // 
            this.FinalPercentage.AutoSize = true;
            this.FinalPercentage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FinalPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinalPercentage.ForeColor = System.Drawing.Color.Orange;
            this.FinalPercentage.Location = new System.Drawing.Point(392, 255);
            this.FinalPercentage.Name = "FinalPercentage";
            this.FinalPercentage.Size = new System.Drawing.Size(167, 58);
            this.FinalPercentage.TabIndex = 3;
            this.FinalPercentage.Text = "000%";
            this.FinalPercentage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.BurlyWood;
            this.label3.Location = new System.Drawing.Point(219, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 71);
            this.label3.TabIndex = 4;
            this.label3.Text = "Your rating";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.BurlyWood;
            this.label4.Location = new System.Drawing.Point(392, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 71);
            this.label4.TabIndex = 5;
            this.label4.Text = "Percentage";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(782, 509);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Result";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label ResultName;
        private System.Windows.Forms.Label ResultDevLevel;
        private System.Windows.Forms.Label ratingValue;
        private System.Windows.Forms.Label FinalPercentage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}