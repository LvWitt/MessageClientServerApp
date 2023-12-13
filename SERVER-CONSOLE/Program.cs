using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Linq;


class Server
{
    static Dictionary<string, NetworkStream> clients = new Dictionary<string, NetworkStream>();
    static int ClientConnections = 0;
    static NetworkStream[] streams = new NetworkStream[ClientConnections];

    static void Main()
    {
        TcpListener listeningSocket = new TcpListener(IPAddress.Any, 7000);
        listeningSocket.Start();
        Console.WriteLine("Server started");

        for (; ; Thread.Sleep(75))
        {
            TcpClient mySocket = listeningSocket.AcceptTcpClient();
            Console.WriteLine("Client connected");
            NetworkStream stream = mySocket.GetStream();
            //string ConnectMessage = "Connect...\n";

            // byte[] BytesWrite = Encoding.Unicode.GetBytes(ConnectMessage);
            //stream.Write(BytesWrite, 0, BytesWrite.Length);
            ClientConnections++;



            Array.Resize<NetworkStream>(ref streams, ClientConnections);
            streams[ClientConnections - 1] = stream;

            //byte[] data = new byte[1024];
            ////data = Encoding.Unicode.GetBytes("");
            //stream.Write(data, 0, data.Length);

            Thread th = new Thread(delegate () { SendMessageToClient(ClientConnections - 1); });
            th.Start();
        }
    }
    static void SendMessageToClient(int ID)
    {
        byte[] data = new byte[1024];
        int bytes;

        for (; ; Thread.Sleep(75))
        {
            if (streams[ID].DataAvailable)
            {
                int flagInputNome = 0;
                int flagMsgPrivada = 0;
                StringBuilder builder = new StringBuilder();
                do
                {
                    bytes = streams[ID].Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (streams[ID].DataAvailable);
                string message = builder.ToString();
                Console.WriteLine(message);


                if (!clients.ContainsKey(message) && message.StartsWith(">"))
                {
                    flagInputNome = 1;
                    message = message.Replace(">", "");

                    clients.Add(message, streams[ID]);
                    SendOnlineMembersList();
                    Console.WriteLine("REGRISTRANDO NOME \n");
                    message = $"{message} entrou no chat.";
                }

                // Lógica para direcionar mensagens privadas
                if (message.StartsWith("/"))
                {
                    flagMsgPrivada = 1;
                    flagInputNome = 1;

                    string[] comandos = message.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string comando in comandos)
                        {
                            string[] parts = comando.Split(' ');
                            string recipient = parts[1];
                            string privateMessage = string.Join(' ', parts, 2, parts.Length - 2);

                            if (clients.ContainsKey(recipient))
                            {
                                string username = null;
                                foreach (var par in clients)
                                {

                                    if (Object.ReferenceEquals(par.Value, streams[ID]))
                                    {
                                        username = par.Key;
                                        break; // Interrompe o loop assim que a chave for encontrada
                                    }
                                }
                                SendData(clients[recipient], $"{username} (privado): {privateMessage}");
                                SendData(streams[ID], $"Mensagem privada enviada para {recipient}.");
                            }
                            else
                            {
                                SendData(streams[ID], $"Usuário {recipient} não encontrado.");
                            }
                        }




                    
                }
                else if (message.ToLower() == "exit")
                {
                    break;
                }


                /*
                int posicaoDoisPontos = message.IndexOf(':'); // Encontra a posição do ':'
                string resultado = "";
                if (posicaoDoisPontos != -1)
                {
                    // Extrai a substring que vem antes do ':'
                     resultado = message.Substring(0, posicaoDoisPontos);
                    Console.WriteLine(resultado); // Saída: nasdaw
                }

                clients.Add(resultado, streams[ID]);*/
                if (flagInputNome == 0)
                {
                    string chaveEncontrada = null;
                    foreach (var par in clients)
                    {

                        if (Object.ReferenceEquals(par.Value, streams[ID]))
                        {
                            chaveEncontrada = par.Key;
                            break; // Interrompe o loop assim que a chave for encontrada
                        }
                    }
                    data = Encoding.Unicode.GetBytes($"{chaveEncontrada}: {message}");
                    for (int i = 0; i < ClientConnections; i++)
                    {
                        streams[i].Write(data, 0, data.Length);
                    }
                }
                else if (flagMsgPrivada == 0)
                {
                    data = Encoding.Unicode.GetBytes(message);
                    for (int i = 0; i < ClientConnections; i++)
                    {
                        streams[i].Write(data, 0, data.Length);
                    }
                }

            }
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

        //SendData(stream, $"Conectado com sucesso ao servidor de mensagens!");
        // Adiciona o cliente ao dicionário

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
                        //SendData(clients[recipient].GetStream(), $"{username} (privado): {privateMessage}");
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
            //SendData(client.GetStream(), message);
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
        byte[] data = Encoding.Unicode.GetBytes(message);

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
        byte[] dataName = new byte[1024];
        //Broadcast(Name);
        dataName = Encoding.Unicode.GetBytes(Name);
        for (int i = 0; i < ClientConnections; i++)
        {
            streams[i].Write(dataName, 0, dataName.Length);
        }
    }
}