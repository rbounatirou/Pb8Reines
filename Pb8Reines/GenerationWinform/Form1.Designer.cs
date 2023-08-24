namespace GenerationWinform
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
            panelDessin = new Panel();
            buttonNouvelleGen = new Button();
            labelScore = new Label();
            labelProgres = new Label();
            labelTotalGen = new Label();
            buttonExport = new Button();
            SuspendLayout();
            // 
            // panelDessin
            // 
            panelDessin.Location = new Point(12, 12);
            panelDessin.Name = "panelDessin";
            panelDessin.Size = new Size(400, 400);
            panelDessin.TabIndex = 0;
            panelDessin.Paint += panelDessin_Paint;
            // 
            // buttonNouvelleGen
            // 
            buttonNouvelleGen.Location = new Point(418, 12);
            buttonNouvelleGen.Name = "buttonNouvelleGen";
            buttonNouvelleGen.Size = new Size(215, 57);
            buttonNouvelleGen.TabIndex = 1;
            buttonNouvelleGen.Text = "GENERATE !!!!";
            buttonNouvelleGen.UseVisualStyleBackColor = true;
            buttonNouvelleGen.Click += buttonNouvelleGen_Click;
            // 
            // labelScore
            // 
            labelScore.AutoSize = true;
            labelScore.Location = new Point(505, 149);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(22, 15);
            labelScore.TabIndex = 2;
            labelScore.Text = "???";
            // 
            // labelProgres
            // 
            labelProgres.AutoSize = true;
            labelProgres.Location = new Point(485, 207);
            labelProgres.Name = "labelProgres";
            labelProgres.Size = new Size(72, 15);
            labelProgres.TabIndex = 3;
            labelProgres.Text = "labelProgres";
            // 
            // labelTotalGen
            // 
            labelTotalGen.AutoSize = true;
            labelTotalGen.Location = new Point(505, 381);
            labelTotalGen.Name = "labelTotalGen";
            labelTotalGen.Size = new Size(13, 15);
            labelTotalGen.TabIndex = 4;
            labelTotalGen.Text = "0";
            // 
            // buttonExport
            // 
            buttonExport.Location = new Point(418, 75);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(215, 23);
            buttonExport.TabIndex = 5;
            buttonExport.Text = "Export to CSV";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 450);
            Controls.Add(buttonExport);
            Controls.Add(labelTotalGen);
            Controls.Add(labelProgres);
            Controls.Add(labelScore);
            Controls.Add(buttonNouvelleGen);
            Controls.Add(panelDessin);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelDessin;
        private Button buttonNouvelleGen;
        private Label labelScore;
        private Label labelProgres;
        private Label labelTotalGen;
        private Button buttonExport;
    }
}