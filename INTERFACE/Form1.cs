﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;


namespace INTERFACE
{
    public partial class Cliente : Form
    {
        private IPAddress ip = null;
        private int port = 0;
        private Thread th;
        private NetworkStream stream;
        static Dictionary<string, string> Onlineclients = new Dictionary<string, string>();

        public Cliente()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                TcpClient client = new TcpClient("192.168.18.27", 7000);
                stream = client.GetStream();

                ChatSection.ForeColor = Color.Green;
                ChatSection.Text = "Configurações: \nIP do Servidor: " + "192.168.18.27" + "\nPorta do Servidor: " + "7000";
                SendData($">{inputName.Text}");
                //SendData($"{inputName.Text} entrou no chat.");
            }

            catch (Exception)
            {
                ChatSection.ForeColor = Color.Red;
                ChatSection.Text = "ERRO NA CONEXÃO";
            }

            ChatSection.Text += $"Conectando ao servidor...{Environment.NewLine}";

            //acionado ao clicar no botao conectar
            th = new Thread(delegate () { RecvMessage(); });
            th.Start();


            //SendData(inputName.Text);


        }

        void RecvMessage()
        {
            while (true)
            {
                byte[] readingData = new byte[256];
                StringBuilder completeMessage = new StringBuilder();
                do
                {
                    int numberOfBytesRead = stream.Read(readingData, 0, readingData.Length);
                    completeMessage.AppendFormat("{0}", Encoding.Unicode.GetString(readingData, 0, numberOfBytesRead));
                }
                while (stream.DataAvailable);
                string receivedData = completeMessage.ToString();

                string[] substrings = receivedData.Split('-');
                List<string> nomes = new List<string>();
                string mensagem = "";


                for (int i = 0; i < substrings.Length; i++)
                {
                    if (substrings[i] != "")
                    {
                        if (i == substrings.Length - 1)
                        {
                            mensagem = substrings[i];
                        }
                        else
                        {
                            nomes.Add(substrings[i]);
                        }
                    }
                }

                if (nomes.Count > 0)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        foreach (string nome in nomes)
                        {
                            if (!checkedListBox1.Items.Contains(nome))
                            {
                                checkedListBox1.Items.Add(nome);
                            }
                            //Online.Text += $"{Name}{Environment.NewLine}";

                        }
                        if (!checkedListBox1.Items.Contains(Name))
                        {
                            ChatSection.Text += $"{mensagem}{Environment.NewLine}";
                        }
                    });
                }
                else
                {
                    string pattern = @"^\w+\s+\(privado\):\s+\w+";
                    Regex regex = new Regex(pattern);

                    if (regex.IsMatch(receivedData))
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            Inbox.Text += $"{receivedData}{Environment.NewLine}";
                        });
                    }
                    else if (receivedData.EndsWith("saiu do chat."))
                    {
                        string[] nomeSaiu = receivedData.Split(' ');
                        if (checkedListBox1.Items.Contains(nomeSaiu[0]))
                        {
                            this.Invoke((MethodInvoker)delegate ()
                            {
                                int index = checkedListBox1.Items.IndexOf(nomeSaiu[0]);
                                checkedListBox1.Items[index] = checkedListBox1.Items[index].ToString() + " (Offline)";
                                checkedListBox1.SetItemCheckState(index, CheckState.Indeterminate);
                                //checkedListBox1.Items.RemoveAt(index);
                            });

                            this.Invoke((MethodInvoker)delegate ()
                            {
                                ChatSection.Text += $"{receivedData}{Environment.NewLine}";
                            });
                        }
                    }
                    else
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            ChatSection.Text += $"{receivedData}{Environment.NewLine}";
                        });
                    }



                }
            }
        }


        void ReceiveMessages()
        {
            byte[] buffer = new byte[1024];

            while (true)
            {
                try
                {
                    Array.Clear(buffer, 0, buffer.Length);
                    int bytes = stream.Read(buffer, 0, buffer.Length);

                    string receivedData = Encoding.UTF8.GetString(buffer, 0, bytes);

                    if (receivedData == null)
                        break;

                    string[] substrings = receivedData.Split('-');
                    List<string> nomes = new List<string>();
                    string mensagem = "";


                    for (int i = 0; i < substrings.Length; i++)
                    {
                        if (substrings[i] != "")
                        {
                            if (i == substrings.Length - 1)
                            {
                                mensagem = substrings[i];
                            }
                            else
                            {
                                nomes.Add(substrings[i]);
                            }
                        }
                    }

                    if (nomes.Count > 0)
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            foreach (string nome in nomes)
                            {
                                if (!checkedListBox1.Items.Contains(nome))
                                {
                                    checkedListBox1.Items.Add(nome);
                                }
                                //Online.Text += $"{Name}{Environment.NewLine}";

                            }
                            if (!checkedListBox1.Items.Contains(Name))
                            {
                                ChatSection.Text += $"{mensagem}{Environment.NewLine}";
                            }
                        });
                    }
                    else
                    {
                        string pattern = @"^\w+\s+\(privado\):\s+\w+";
                        Regex regex = new Regex(pattern);

                        if (regex.IsMatch(receivedData))
                        {
                            this.Invoke((MethodInvoker)delegate ()
                            {
                                Inbox.Text += $"{receivedData}{Environment.NewLine}";
                            });
                        }
                        else if (receivedData.EndsWith("saiu do chat."))
                        {
                            string[] nomeSaiu = receivedData.Split(' ');
                            if (checkedListBox1.Items.Contains(nomeSaiu[0]))
                            {
                                this.Invoke((MethodInvoker)delegate ()
                                {
                                    int index = checkedListBox1.Items.IndexOf(nomeSaiu[0]);
                                    checkedListBox1.Items[index] = checkedListBox1.Items[index].ToString() + " (Offline)";
                                    checkedListBox1.SetItemCheckState(index, CheckState.Indeterminate);
                                    //checkedListBox1.Items.RemoveAt(index);
                                });

                                this.Invoke((MethodInvoker)delegate ()
                                {
                                    ChatSection.Text += $"{receivedData}{Environment.NewLine}";
                                });
                            }
                        }
                        else
                        {
                            this.Invoke((MethodInvoker)delegate ()
                            {
                                ChatSection.Text += $"{receivedData}{Environment.NewLine}";
                            });
                        }



                    }
                }
                catch
                {
                    Console.WriteLine("Erro +55");
                    break;
                }
            }
        }
        /*
        public void updateOwnList()
        {

            foreach (var par in Onlineclients)
            {
                string chave = par.Key;
                string valor = par.Value;

                this.Invoke((MethodInvoker)delegate ()
                {
                    if (!clientsList.Items.Contains(chave))
                    {
                        clientsList.Items.Add(chave);
                    }
                });
            }

        } */

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                foreach (int index in checkedListBox1.CheckedIndices)
                {
                    string nomeDoItem = checkedListBox1.Items[index].ToString();
                    // Se você preferir passar o índice
                    SendData($"/msg {nomeDoItem} {InputChat.Text}");

                    //InputChat.Text = "";
                    // string nomeDoItem = checkedListBox1.Items[index].ToString();
                    // FuncaoA(nomeDoItem);
                }
            }
            else
            {
                SendData(InputChat.Text);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void LogSection_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void SendData(string message)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }

        public void SendMessageToClient(string ipAddress, int port, string message)
        {
            try
            {
                // Cria um TcpClient conectado ao endereço IP e porta fornecidos
                using (TcpClient client = new TcpClient(ipAddress, port))
                {
                    // Obtém o NetworkStream associado ao TcpClient
                    using (NetworkStream stream = client.GetStream())
                    {
                        // Converte a mensagem em um array de bytes
                        byte[] messageBytes = Encoding.UTF8.GetBytes(message);

                        // Envia a mensagem para o cliente
                        stream.Write(messageBytes, 0, messageBytes.Length);
                        Console.WriteLine($"Mensagem enviada para {ipAddress}:{port}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Trata qualquer exceção que possa ocorrer durante a conexão ou envio
                Console.WriteLine($"Erro ao enviar mensagem para {ipAddress}:{port} - {ex.Message}");
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            SendData($"exit");
            this.Close();
        }

        private void ChatSection_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void InputChat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}