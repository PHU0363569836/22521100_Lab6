using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _22521100_Lab6
{
    public partial class Bai03_Server : Form
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("0363569836225211000123456789ABCD");
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("0363569836225211");
        private List<Socket> listClient;
        private IPEndPoint ipepServer;
        private Socket listenerSocket;
        private Thread listenThread;

        public Bai03_Server()
        {
            InitializeComponent();
        }

        private byte[] Encrypt(string plainText)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;
                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                    return ms.ToArray();
                }
            }
        }

        private void btn_Listen_Click(object sender, EventArgs e)
        {
            if (listenThread == null || !listenThread.IsAlive)
            {
                //tạo một luồng listen từ server
                listenThread = new Thread(ListenThread);
                listenThread.Start();
                btn_Listen.Enabled = false;
                btn_Listen.Text = "Listening...";
            }
        }

        private void ListenThread()
        {
            try
            {
                //tạo một danh sách socket
                listClient = new List<Socket>();
                //tạo một socket ipv4 ,socket kiểu luồng,sử dụng giao thức tcp
                listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //tạo ip server có ip là 127.0.0.1 và port là 8080
                ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
                //socket listenerSocket sẽ lắng nghe địa chỉ 12.0.0.1 và port 8080
                listenerSocket.Bind(ipepServer);
                //tối đa có 10 socket kết nối 
                listenerSocket.Listen(10);

                Invoke(new Action(() =>
                {
                    lv_ListLog.Items.Add("Listening on : " + ipepServer.ToString());
                }));

                while (true)
                {
                    //tạo một kết nối dành riêng cho mỗi kết nối client,cho phép máy chủ sử dụng để giao tiếp với client
                    Socket clientSocket = listenerSocket.Accept();
                    //thêm client vào danh sách
                    listClient.Add(clientSocket);

                    string welcomeMsg = "Message From Server: Hi, Welcome to Room Chat!";
                    //mã hoá tin nhắn
                    byte[] encryptedWelcome = Encrypt(welcomeMsg);
                    //gửi tin nhắn đến client
                    clientSocket.Send(encryptedWelcome);
                    //thêm thông báo có client kết vào log
                    Invoke(new Action(() =>
                    {
                        lv_ListLog.Items.Add("New Client Connected: " + clientSocket.RemoteEndPoint.ToString());
                    }));
                    //tạo một luồng trỏ tới hàm ReceiveDataThread
                    Thread receiver = new Thread(() => ReceiveDataThread(clientSocket));
                    receiver.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ReceiveDataThread(Socket clientSocket)
        {
            try
            {
                byte[] recv = new byte[1024];
                while (true)
                {
                    //lấy kích thước receive và luu vào recv
                    int bytesReceived = clientSocket.Receive(recv);
                    if (bytesReceived == 0)
                    {
                        CloseClientConnection(clientSocket);
                        return;
                    }
                    //tạo một mãng byte để chứa dữ liệu receive
                    byte[] receivedData = new byte[bytesReceived];
                    //sao chép recv qua cho receiveData với kich thước là bytesReceived
                    Array.Copy(recv, receivedData, bytesReceived);
                    //tạo một log
                    string listViewString = clientSocket.RemoteEndPoint.ToString() + ": " + receivedData;
                    //thêm log vào listlog
                    Invoke(new Action(() =>
                    {
                        lv_ListLog.Items.Add(listViewString);
                    }));

                    Broadcast(receivedData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CloseClientConnection(Socket clientSocket)
        {
            clientSocket.Close();
            listClient.Remove(clientSocket);
            Invoke(new Action(() =>
            {
                lv_ListLog.Items.Add("Client Disconnected: " + clientSocket.RemoteEndPoint.ToString());
            }));
        }

        private void Broadcast(byte[] msg)
        {
            foreach (var item in listClient)
            {
                //gửi tin cho tất cả client kết nối với server
                item.Send(msg);
            }
        }

        private void Bai03_Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listenerSocket != null && listenerSocket.Connected)
            {
                listenerSocket.Close();
            }
            foreach (var client in listClient)
            {
                if (client != null && client.Connected)
                {
                    client.Close();
                }
            }
        }
    }
}
