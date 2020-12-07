namespace week08
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.createTimer = new System.Windows.Forms.Timer(this.components);
            this.conveyorTimer = new System.Windows.Forms.Timer(this.components);
            this.ballButton = new System.Windows.Forms.Button();
            this.carButton = new System.Windows.Forms.Button();
            this.comingNextLabel = new System.Windows.Forms.Label();
            this.colorButton = new System.Windows.Forms.Button();
            this.presentButton = new System.Windows.Forms.Button();
            this.ribColButton = new System.Windows.Forms.Button();
            this.boxColButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(0, 75);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1127, 573);
            this.mainPanel.TabIndex = 0;
            // 
            // createTimer
            // 
            this.createTimer.Enabled = true;
            this.createTimer.Interval = 3000;
            this.createTimer.Tick += new System.EventHandler(this.createTimer_Tick);
            // 
            // conveyorTimer
            // 
            this.conveyorTimer.Enabled = true;
            this.conveyorTimer.Interval = 10;
            this.conveyorTimer.Tick += new System.EventHandler(this.conveyorTimer_Tick);
            // 
            // ballButton
            // 
            this.ballButton.Location = new System.Drawing.Point(13, 13);
            this.ballButton.Name = "ballButton";
            this.ballButton.Size = new System.Drawing.Size(75, 23);
            this.ballButton.TabIndex = 1;
            this.ballButton.Text = "button1";
            this.ballButton.UseVisualStyleBackColor = true;
            // 
            // carButton
            // 
            this.carButton.Location = new System.Drawing.Point(94, 13);
            this.carButton.Name = "carButton";
            this.carButton.Size = new System.Drawing.Size(75, 23);
            this.carButton.TabIndex = 2;
            this.carButton.Text = "button2";
            this.carButton.UseVisualStyleBackColor = true;
            // 
            // comingNextLabel
            // 
            this.comingNextLabel.AutoSize = true;
            this.comingNextLabel.Location = new System.Drawing.Point(203, 18);
            this.comingNextLabel.Name = "comingNextLabel";
            this.comingNextLabel.Size = new System.Drawing.Size(35, 13);
            this.comingNextLabel.TabIndex = 3;
            this.comingNextLabel.Text = "label1";
            // 
            // colorButton
            // 
            this.colorButton.BackColor = System.Drawing.Color.Purple;
            this.colorButton.Location = new System.Drawing.Point(531, 12);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(75, 23);
            this.colorButton.TabIndex = 4;
            this.colorButton.UseVisualStyleBackColor = false;
            // 
            // presentButton
            // 
            this.presentButton.Location = new System.Drawing.Point(13, 43);
            this.presentButton.Name = "presentButton";
            this.presentButton.Size = new System.Drawing.Size(75, 23);
            this.presentButton.TabIndex = 5;
            this.presentButton.Text = "button1";
            this.presentButton.UseVisualStyleBackColor = true;
            // 
            // ribColButton
            // 
            this.ribColButton.BackColor = System.Drawing.Color.Lime;
            this.ribColButton.Location = new System.Drawing.Point(531, 43);
            this.ribColButton.Name = "ribColButton";
            this.ribColButton.Size = new System.Drawing.Size(75, 23);
            this.ribColButton.TabIndex = 6;
            this.ribColButton.UseVisualStyleBackColor = false;
            // 
            // boxColButton
            // 
            this.boxColButton.BackColor = System.Drawing.Color.Red;
            this.boxColButton.Location = new System.Drawing.Point(613, 43);
            this.boxColButton.Name = "boxColButton";
            this.boxColButton.Size = new System.Drawing.Size(75, 23);
            this.boxColButton.TabIndex = 7;
            this.boxColButton.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 692);
            this.Controls.Add(this.boxColButton);
            this.Controls.Add(this.ribColButton);
            this.Controls.Add(this.presentButton);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.comingNextLabel);
            this.Controls.Add(this.carButton);
            this.Controls.Add(this.ballButton);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Timer createTimer;
        private System.Windows.Forms.Timer conveyorTimer;
        private System.Windows.Forms.Button ballButton;
        private System.Windows.Forms.Button carButton;
        private System.Windows.Forms.Label comingNextLabel;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Button presentButton;
        private System.Windows.Forms.Button ribColButton;
        private System.Windows.Forms.Button boxColButton;
    }
}

