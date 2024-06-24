using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22521100_Lab6
{
    public partial class Bai03 : Form
    {
        public Bai03()
        {
            InitializeComponent();
        }
        //tạo nhiều đối tượng client
        private List<Bai03_Client> clientForms = new List<Bai03_Client>();
        private void btn_client_Click(object sender, EventArgs e)
        {
            Bai03_Client client = new Bai03_Client();
            client.Show();
            //true để có thể nhấn nhiều lần
            btn_client.Enabled = true;
        }

        private void btn_server_Click(object sender, EventArgs e)
        {
            //bỏ qua các lỗi liên quan đến truy cập các điểu khiển từ các luồng khác nhau
            CheckForIllegalCrossThreadCalls = false;
            //tạo một luồng liên kết với serverthread
            //serverthread có phép thực hiện các tác vụ khác mà không làm treo chương trình chính
            Thread ServerThrd = new Thread(ServerThread);
            //khi gọi .start luồng sẽ bắt đầu thực thi phương thức serverthread
            ServerThrd.Start();
            //
            Thread isServerAli = new Thread(() => isServerAlive(ServerThrd));
            isServerAli.Start();
        }

        private void ServerThread()
        {
            Bai03_Server ChatServer = new Bai03_Server();
            ChatServer.ShowDialog();
        }

        private void isServerAlive(Thread ServerThread)
        {
            while (true)
            {
                if (ServerThread.IsAlive)
                {
                    //nếu luồng đang hoạt động thì không được mở server nữa
                    btn_server.Enabled = false;
                }
                else
                { 
                    //nếu luồng không hoạt động thì được phép mở thêm server
                    btn_server.Enabled = true;
                    break;
                }
            }
        }

       
    }
}
