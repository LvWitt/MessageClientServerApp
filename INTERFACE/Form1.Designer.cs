namespace INTERFACE
{
    partial class Cliente
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
            this.ChatSection = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.InputChat = new System.Windows.Forms.TextBox();
            this.SendMsgChatBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.inputName = new System.Windows.Forms.TextBox();
            this.Inbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // ClientConnectBtn
            // 
            this.ClientConnectBtn.Location = new System.Drawing.Point(291, 10);
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
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Chat Geral";
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
            this.ExitBtn.Location = new System.Drawing.Point(291, 40);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(99, 23);
            this.ExitBtn.TabIndex = 10;
            this.ExitBtn.Text = "Desconectar";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.Exit_Click);
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
            // Inbox
            // 
            this.Inbox.Location = new System.Drawing.Point(428, 154);
            this.Inbox.Multiline = true;
            this.Inbox.Name = "Inbox";
            this.Inbox.ReadOnly = true;
            this.Inbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Inbox.Size = new System.Drawing.Size(304, 270);
            this.Inbox.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(425, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Chat Privado";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Membros Online";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(428, 25);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(112, 94);
            this.checkedListBox1.TabIndex = 20;
            // 
            // Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Inbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.inputName);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.SendMsgChatBtn);
            this.Controls.Add(this.InputChat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChatSection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ClientConnectBtn);
            this.Name = "Cliente";
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClientConnectBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ChatSection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox InputChat;
        private System.Windows.Forms.Button SendMsgChatBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox inputName;
        private System.Windows.Forms.TextBox Inbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}

