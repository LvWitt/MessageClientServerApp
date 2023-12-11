using System;
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

namespace INTERFACE
{
    public partial class Form1 : Form
    {
        static TcpClient tcpClient;
        private NetworkStream stream;
        static Dictionary<string, string> Onlineclients = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tcpClient = new TcpClient("127.0.0.1", 55555);
            stream = tcpClient.GetStream();
            LogSection.Text += $"Conectando ao servidor...{Environment.NewLine}";


            SendData(inputName.Text);

            // Inicia uma thread para receber mensagens
            Thread receiveThread = new Thread(delegate () { ReceiveMessages(); });
            receiveThread.Start();

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

                    // Verifica o prefixo da mensagem recebida
                    if (receivedData.StartsWith("DICT-"))
                    {
                        string[] partes = receivedData.Split(new string[] { "DICT-", ":", "/", "-MSG:" }, StringSplitOptions.None);

                        // Armazena cada parte em sua respectiva variável
                        string ip = partes[1];
                        string porta = partes[2];
                        string nome = partes[3];
                        receivedData = partes[4];

                    }

                    if (receivedData.StartsWith("-MSG"))
                    {
                        string[] parte = receivedData.Split(new string[] {"-MSG:"}, StringSplitOptions.None);
                        receivedData = parte[0];
                    }

                    Console.WriteLine(receivedData);

                    this.Invoke((MethodInvoker)delegate ()
                    {
                        ChatSection.Text += $"{receivedData}{Environment.NewLine}";
                    });


                }
                catch
                {
                    Console.WriteLine("Erro +55");
                    break;
                }
            }
        }

        public void UpdateOwnDictionary(Dictionary<string, string> dicionarioRecebido)
        {
            foreach (var par in dicionarioRecebido)
            {
                // Se a chave já existe, atualiza o valor; caso contrário, adiciona a nova entrada
                Onlineclients[par.Key] = par.Value;
            }
        }

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
            SendData(InputChat.Text);
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

            if (!string.IsNullOrEmpty(message))
            {
                if (clientsList.CheckedItems.Count > 0)
                {
                    foreach (var item in clientsList.CheckedItems)
                    {
                        // Aqui, estou assumindo que cada 'item' é uma string contendo o endereço IP e a porta no formato "IP:Porta"
                        string[] parts = item.ToString().Split(':');
                        if (parts.Length == 2)
                        {
                            string ip = parts[0];
                            int port = int.Parse(parts[1]);

                            // Chama a função para enviar a mensagem para o cliente especificado
                            SendMessageToClient(ip, port, message);
                        }
                    }
                }
                else
                {
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    stream.Write(data, 0, data.Length);
                }
            }
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

        public void EnviarMensagemParaCliente(string endereco, string mensagem)
        {
            // Separa o IP e a porta com base no caractere ':'
            string[] partes = endereco.Split(':');
            string clientIP = partes[0];
            int clientPort = int.Parse(partes[1]);

            // Converte a mensagem em bytes
            byte[] data = Encoding.UTF8.GetBytes(mensagem);

            // Cria um TcpClient e conecta ao cliente
            TcpClient client = new TcpClient(clientIP, clientPort);

            // Obtém o NetworkStream
            NetworkStream stream = client.GetStream();

            // Envia os dados para o cliente
            stream.Write(data, 0, data.Length);

            // Fecha o stream e o cliente
            stream.Close();
            client.Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            tcpClient.Close();
        }

        private void ChatSection_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
