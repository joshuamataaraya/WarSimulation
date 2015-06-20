namespace War
{
    partial class LoadMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this._iGameCode = new System.Windows.Forms.TextBox();
            this._bLoad = new System.Windows.Forms.Button();
            this._lGames = new System.Windows.Forms.Label();
            this._listGames = new System.Windows.Forms.ListBox();
            this._bCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search a game:";
            // 
            // _iGameCode
            // 
            this._iGameCode.Location = new System.Drawing.Point(206, 45);
            this._iGameCode.Name = "_iGameCode";
            this._iGameCode.Size = new System.Drawing.Size(116, 20);
            this._iGameCode.TabIndex = 1;
            // 
            // _bLoad
            // 
            this._bLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._bLoad.Location = new System.Drawing.Point(271, 365);
            this._bLoad.Name = "_bLoad";
            this._bLoad.Size = new System.Drawing.Size(118, 26);
            this._bLoad.TabIndex = 4;
            this._bLoad.Text = "Load Game";
            this._bLoad.UseVisualStyleBackColor = true;
            this._bLoad.Click += new System.EventHandler(this._bLoad_Click);
            // 
            // _lGames
            // 
            this._lGames.AutoSize = true;
            this._lGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lGames.Location = new System.Drawing.Point(151, 96);
            this._lGames.Name = "_lGames";
            this._lGames.Size = new System.Drawing.Size(85, 25);
            this._lGames.TabIndex = 3;
            this._lGames.Text = "Games";
            // 
            // _listGames
            // 
            this._listGames.FormattingEnabled = true;
            this._listGames.Location = new System.Drawing.Point(75, 124);
            this._listGames.Name = "_listGames";
            this._listGames.Size = new System.Drawing.Size(247, 212);
            this._listGames.TabIndex = 2;
            // 
            // _bCreate
            // 
            this._bCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._bCreate.Location = new System.Drawing.Point(75, 365);
            this._bCreate.Name = "_bCreate";
            this._bCreate.Size = new System.Drawing.Size(118, 26);
            this._bCreate.TabIndex = 5;
            this._bCreate.Text = "Create Game";
            this._bCreate.UseVisualStyleBackColor = true;
            this._bCreate.Click += new System.EventHandler(this._bCreate_Click);
            // 
            // LoadMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 430);
            this.Controls.Add(this._bCreate);
            this.Controls.Add(this._bLoad);
            this.Controls.Add(this._lGames);
            this.Controls.Add(this._listGames);
            this.Controls.Add(this._iGameCode);
            this.Controls.Add(this.label1);
            this.Name = "LoadMenu";
            this.Text = "LoadMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _iGameCode;
        private System.Windows.Forms.Button _bLoad;
        private System.Windows.Forms.Label _lGames;
        private System.Windows.Forms.ListBox _listGames;
        private System.Windows.Forms.Button _bCreate;
    }
}