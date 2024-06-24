using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _22521100_Lab6
{
    public partial class Bai03_Client : Form
    {
        //khởi tạo key và IV
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("0363569836225211000123456789ABCD");
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("0363569836225211");
        private TcpClient tcpClient;
        private NetworkStream ns;
        private string clientName;

        public Bai03_Client()
        {
            InitializeComponent();
        }

        private byte[] Encrypt(string plainText)
        {
            //tạo đối tượng AES
            using (var aes = Aes.Create())
            {
                //thiết lập key
                aes.Key = Key;
                //thiết lập iv
                aes.IV = IV;
                //tạo đối tượng mã hoá bằng AES với key và iv được thiết lập sẵn
                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                //memorystream cho phép chúng ta đọc,ghi và tìm kiếm dữ liệu trong bộ nhớ của hệ thống
                using (var ms = new MemoryStream())
                {
                    //dữ liệu mã hoá sẽ được đưa vào ms ,crytostreammode.write là chỉ định muốn ghi vào
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    //hàm dùng để truyền plaintext vào để mã hoá và lưu vào ms
                    using (var sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                    //trả về vùng nhớ của bản mã
                    return ms.ToArray();
                }
            }
        }

        private string Decrypt(byte[] cipherText)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;
                //tạo đối tượng giải mã AES
                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                //tạo một vùng nhớ để lưu dữ liệu đã mã hoá
                using (var ms = new MemoryStream(cipherText))
                //cho phép giải mã bản mã lưu trong ms và gán cho cs
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                //hàm này để đọc dữ liệu có trogn cs
                using (var sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            try
            {   
                //tạo một đối tượng client trỏ tới địa chỉ ip là 127.0.0.1 và port là 8080
                tcpClient = new TcpClient();
                tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 8080);
                //getstream hỗ trợ đọc và ghi dữ liệu với socket TCP,giúp việc truyền thông tin giữa client và server trở nên ổn định hơn
                ns = tcpClient.GetStream();
                //tạo một luồng trỏ tới hàm receiveFromserver
                Thread receiver = new Thread(ReceiveFromServer);
                receiver.Start();
                //tắt nút connect
                btn_Connect.Enabled = false;
                clientName = tb_name.Text.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void ReceiveFromServer()
        {
            try
            {
                //chiều dài tối da của recv
                byte[] recv = new byte[1024];
                while (true)
                {
                    //đọc dữ liệu của ns và lưu vào recv
                    int bytesReceived = ns.Read(recv, 0, recv.Length);
                    //kiểm tra kích thước của recv ,kích thước của recv không được bằng không
                    if (bytesReceived == 0)
                    {
                        MessageBox.Show("Server disconnected");
                        CloseClient();
                        return;
                    }
                    //tạo một mảng byte để lưu dữ liệu với kích thước là byteReceived
                    byte[] receivedData = new byte[bytesReceived];
                    //sao chép dữ liệu từ recv sang receiveData
                    Array.Copy(recv, receivedData, bytesReceived);
                    //giải mã dữ liệu từ receicvedData 
                    string decryptedText = Decrypt(receivedData);

                    UpdateUIThread(decryptedText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                CloseClient();
            }
        }

        private void UpdateUIThread(string text)
        {
            //kiểm tra lv_message có ở trong luồng giao diện người dùng hay không
            if (lv_message.InvokeRequired)
            {
                //nếu ở luồng khác thì gọi lại hàm updateUIThread
                lv_message.Invoke(new Action<string>(UpdateUIThread), text);
            }
            else
            {
                //nếu đang ở trong luồng rồi thì thêm text vào lv_message
                lv_message.Items.Add(text);
            }
        }
        private void btn_send_Click(object sender, EventArgs e)
        {
            SendMess(tb_Message.Text);
        }
        private void SendMess(string text)
        {
            //thêm tên người dùng vào message
            string fullMessage = clientName + ": " + text;
            //mã hoá dữ liệu về dạng byte
            byte[] data = Encrypt(fullMessage);
            //gửi lên server
            ns.Write(data, 0, data.Length);
            //xoá tb_message
            tb_Message.Text = "";
        }
        private void CloseClient()
        {
            if (tcpClient != null)
            {
                tcpClient.Close();
            }
        }

        private void Bai03_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseClient();
        }
    }
}
