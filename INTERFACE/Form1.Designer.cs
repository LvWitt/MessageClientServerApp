namespace INTERFACE
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ClientConnectBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LogSection = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ChatSection = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.InputChat = new System.Windows.Forms.TextBox();
            this.SendMsgChatBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.clientsList = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.inputName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ClientConnectBtn
            // 
            this.ClientConnectBtn.Location = new System.Drawing.Point(291, 38);
            this.ClientConnectBtn.Name = "ClientConnectBtn";
            this.ClientConnectBtn.Size = new System.Drawing.Size(99, 23);
            this.ClientConnectBtn.TabIndex = 1;
            this.ClientConnectBtn.Text = "Conectar";
            this.ClientConnectBtn.UseVisualStyleBackColor = true;
            this.ClientConnectBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(81, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(201, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP Servidor";
            // 
            // LogSection
            // 
            this.LogSection.Location = new System.Drawing.Point(408, 34);
            this.LogSection.Multiline = true;
            this.LogSection.Name = "LogSection";
            this.LogSection.ReadOnly = true;
            this.LogSection.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogSection.Size = new System.Drawing.Size(379, 146);
            this.LogSection.TabIndex = 4;
            this.LogSection.TextChanged += new System.EventHandler(this.LogSection_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "LOG";
            // 
            // ChatSection
            // 
            this.ChatSection.Location = new System.Drawing.Point(18, 94);
            this.ChatSection.Multiline = true;
            this.ChatSection.Name = "ChatSection";
            this.ChatSection.ReadOnly = true;
            this.ChatSection.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ChatSection.Size = new System.Drawing.Size(379, 267);
            this.ChatSection.TabIndex = 6;
            this.ChatSection.TextChanged += new System.EventHandler(this.ChatSection_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Chat";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // InputChat
            // 
            this.InputChat.Location = new System.Drawing.Point(19, 376);
            this.InputChat.Multiline = true;
            this.InputChat.Name = "InputChat";
            this.InputChat.Size = new System.Drawing.Size(316, 48);
            this.InputChat.TabIndex = 8;
            // 
            // SendMsgChatBtn
            // 
            this.SendMsgChatBtn.Location = new System.Drawing.Point(341, 376);
            this.SendMsgChatBtn.Name = "SendMsgChatBtn";
            this.SendMsgChatBtn.Size = new System.Drawing.Size(57, 48);
            this.SendMsgChatBtn.TabIndex = 9;
            this.SendMsgChatBtn.Text = "Enviar";
            this.SendMsgChatBtn.UseVisualStyleBackColor = true;
            this.SendMsgChatBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(291, 65);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(99, 23);
            this.ExitBtn.TabIndex = 10;
            this.ExitBtn.Text = "Desconectar";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.Exit_Click);
            // 
            // clientsList
            // 
            this.clientsList.FormattingEnabled = true;
            this.clientsList.Location = new System.Drawing.Point(409, 205);
            this.clientsList.Name = "clientsList";
            this.clientsList.Size = new System.Drawing.Size(144, 154);
            this.clientsList.TabIndex = 11;
            this.clientsList.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(406, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Members";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Nome";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // inputName
            // 
            this.inputName.Location = new System.Drawing.Point(81, 11);
            this.inputName.Name = "inputName";
            this.inputName.Size = new System.Drawing.Size(201, 20);
            this.inputName.TabIndex = 13;
            this.inputName.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.inputName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.clientsList);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.SendMsgChatBtn);
            this.Controls.Add(this.InputChat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChatSection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LogSection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ClientConnectBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClientConnectBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LogSection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ChatSection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox InputChat;
        private System.Windows.Forms.Button SendMsgChatBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox inputName;
        private System.Windows.Forms.CheckedListBox clientsList;
    }
}

