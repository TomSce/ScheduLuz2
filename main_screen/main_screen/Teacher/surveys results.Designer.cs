﻿namespace main_screen.Teacher
{
    partial class surveys_results
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Return = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.question = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.tableAdapterManager1 = new main_screen.ScheduLuzDataSet1TableAdapters.TableAdapterManager();
            this.survey = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.survey)).BeginInit();
            this.SuspendLayout();
            // 
            // Return
            // 
            this.Return.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Return.Location = new System.Drawing.Point(26, 497);
            this.Return.Name = "Return";
            this.Return.Size = new System.Drawing.Size(84, 28);
            this.Return.TabIndex = 78;
            this.Return.Text = "Return";
            this.Return.UseVisualStyleBackColor = true;
            this.Return.Click += new System.EventHandler(this.Return_Click);
            // 
            // listView
            // 
            this.listView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.date,
            this.question});
            this.listView.FullRowSelect = true;
            this.listView.Location = new System.Drawing.Point(12, 60);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(312, 428);
            this.listView.TabIndex = 79;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // date
            // 
            this.date.Text = "date";
            this.date.Width = 77;
            // 
            // question
            // 
            this.question.Text = "question";
            this.question.Width = 229;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 39);
            this.label1.TabIndex = 81;
            this.label1.Text = "surveys results";
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.connection_detailsTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = main_screen.ScheduLuzDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager1.usersTableAdapter = null;
            // 
            // survey
            // 
            chartArea2.Name = "ChartArea1";
            this.survey.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.survey.Legends.Add(legend2);
            this.survey.Location = new System.Drawing.Point(341, 60);
            this.survey.Name = "survey";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Salary";
            this.survey.Series.Add(series2);
            this.survey.Size = new System.Drawing.Size(451, 428);
            this.survey.TabIndex = 82;
            this.survey.Text = "chart1";
            this.survey.Click += new System.EventHandler(this.survey_Click);
            // 
            // surveys_results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 538);
            this.Controls.Add(this.survey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.Return);
            this.Name = "surveys_results";
            this.Text = "surveys_results";
            this.Load += new System.EventHandler(this.surveys_results_Load);
            ((System.ComponentModel.ISupportInitialize)(this.survey)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Return;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader date;
        private ScheduLuzDataSet1TableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.ColumnHeader question;
        private System.Windows.Forms.DataVisualization.Charting.Chart survey;
    }
}