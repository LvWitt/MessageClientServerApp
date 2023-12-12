using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

class Server
{
    static Dictionary<string, TcpClient> clients = new Dictionary<string, TcpClient>();

    static void Main()
    {
        TcpListener server = new TcpListener(IPAddress.Any, 55555);
        server.Start();

        Console.WriteLine("Servidor ouvindo na porta 55555");

        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            Thread clientThread = new Thread(() => HandleClient(client));
            clientThread.Start();
        }
    }

    static void HandleClient(TcpClient tcpClient)
    {
        NetworkStream stream = tcpClient.GetStream();
        byte[] data = new byte[1024];
        int bytesRead;



        // Solicita o nome de usuário ao cliente
        //SendData(stream, "Digite seu nome de usuário: ");
        string username = ReceiveData(stream);

        SendData(stream , $"Conectado com sucesso ao servidor de mensagens!");
        // Adiciona o cliente ao dicionário
        clients.Add(username, tcpClient);
        SendOnlineMembersList();

        // Notifica os outros clientes sobre a entrada do novo usuário
        Broadcast($"{username} entrou no chat.");


        Console.WriteLine($"{username} conectado");

        while (true)
        {
            try
            {
                bytesRead = stream.Read(data, 0, data.Length);
                if (bytesRead == 0)
                    break;

                string message = Encoding.UTF8.GetString(data, 0, bytesRead);

                // Lógica para direcionar mensagens privadas
                if (message.StartsWith("/"))
                {
                    string[] parts = message.Split(' ');
                    string recipient = parts[1];
                    string privateMessage = string.Join(' ', parts, 2, parts.Length - 2);

                    if (clients.ContainsKey(recipient))
                    {
                        SendData(clients[recipient].GetStream(), $"{username} (privado): {privateMessage}");
                        SendData(stream, $"Mensagem privada enviada para {recipient}.");
                    }
                    else
                    {
                        SendData(stream, $"Usuário {recipient} não encontrado.");
                    }
                }
                // Lógica para tratar comandos especiais
                else if (message.StartsWith("/lista"))
                {
                    string userList = "Usuários conectados: " + string.Join(", ", clients.Keys);
                    SendData(stream, userList);
                }
                else if (message.ToLower() == "exit")
                {
                    break;
                }
                else
                {
                    Broadcast($"{username}: {message}");
                }
            }
            catch
            {
                break;
            }
        }

        // Ao sair do loop, remova o cliente do dicionário
        clients.Remove(username);
        Broadcast($"{username} saiu do chat.");

        Console.WriteLine($"{username} desconectado");

        tcpClient.Close();
    }

    static void Broadcast(string message)
    {
        foreach (var client in clients.Values)
        {
            SendData(client.GetStream(), message);
        }
    }

    static void SendOnlineMembersList()
    {
        foreach (var client in clients)
        {
            string chave = client.Key;
            SendClientInfo(chave);
        }
    }

    static void SendData(NetworkStream stream, string message)
    {
        // Serializa o objeto de mensagem para JSON


        // Formata a mensagem serializada com o prefixo "MSG:"


        // Converte a mensagem formatada em bytes
        byte[] data = Encoding.UTF8.GetBytes(message);

        // Envia os dados para o cliente através da stream fornecida
        stream.Write(data, 0, data.Length);
    }

    static string ReceiveData(NetworkStream stream)
    {
        byte[] data = new byte[1024];
        int bytesRead = stream.Read(data, 0, data.Length);
        return Encoding.UTF8.GetString(data, 0, bytesRead);
    }

    static void SendClientInfo(String Name)
    {
        Name = Name + "-";
        Broadcast(Name);
    }
}