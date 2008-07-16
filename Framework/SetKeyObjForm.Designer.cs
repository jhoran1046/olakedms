namespace Framework.UI
{
    partial class SetKeyObjForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose ( );
            }
            base.Dispose ( disposing );
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent ( )
        {
            this.propertyGridKeyObj = new System.Windows.Forms.PropertyGrid ( );
            this.button1 = new System.Windows.Forms.Button ( );
            this.button2 = new System.Windows.Forms.Button ( );
            this.SuspendLayout ( );
            // 
            // propertyGridKeyObj
            // 
            this.propertyGridKeyObj.Dock = System.Windows.Forms.DockStyle.Top;
            this.propertyGridKeyObj.Location = new System.Drawing.Point ( 0 , 0 );
            this.propertyGridKeyObj.Name = "propertyGridKeyObj";
            this.propertyGridKeyObj.Size = new System.Drawing.Size ( 305 , 225 );
            this.propertyGridKeyObj.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point ( 64 , 231 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size ( 75 , 23 );
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point ( 155 , 231 );
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size ( 75 , 23 );
            this.button2.TabIndex = 2;
            this.button2.Text = "CANCEL";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // SetKeyObjForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F , 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size ( 305 , 266 );
            this.Controls.Add ( this.button2 );
            this.Controls.Add ( this.button1 );
            this.Controls.Add ( this.propertyGridKeyObj );
            this.Name = "SetKeyObjForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetKeyObjForm";
            this.Load += new System.EventHandler ( this.SetKeyObjForm_Load );
            this.ResumeLayout ( false );

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGridKeyObj;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}