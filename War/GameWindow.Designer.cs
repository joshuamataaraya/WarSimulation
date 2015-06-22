namespace War
{
    partial class GameWindow
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
            this._GamePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // _GamePanel
            // 
            this._GamePanel.BackColor = System.Drawing.Color.Transparent;
            this._GamePanel.Location = new System.Drawing.Point(0, 0);
            this._GamePanel.Name = "_GamePanel";
            this._GamePanel.Size = new System.Drawing.Size(734, 711);
            this._GamePanel.TabIndex = 0;
            this._GamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this._GamePanel_Paint);
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::War.Properties.Resources.water;
            this.ClientSize = new System.Drawing.Size(734, 711);
            this.Controls.Add(this._GamePanel);
            this.MaximumSize = new System.Drawing.Size(750, 750);
            this.MinimumSize = new System.Drawing.Size(750, 750);
            this.Name = "GameWindow";
            this.Text = "GameWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _GamePanel;



    }
}