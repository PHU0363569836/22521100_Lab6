using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22521100_Lab6
{
    public partial class Bai02 : Form
    {
        public Bai02()
        {
            InitializeComponent();
        }
        private string Encrypt(string text, string key)
        {
            string result = "";
            int keyIndex = 0;
            foreach (char c in text)
            {
                //kiểm tra kí tự có phải chữ cái không
                if (char.IsLetter(c))
                {
                    //kiẻm tra hoa thường của chữ cái,nếu hoa thì trả về A thường thì trả về a
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    //kiểm tra key dịch bao nhiêu kí tự so với chữ cái tương ứng trong input text
                    int k = (char.IsUpper(key[keyIndex % key.Length]) ? key[keyIndex % key.Length] - 'A' : key[keyIndex % key.Length] - 'a');
                    //dịch chữ cái tương ứng của input text với số kí tự dịch vừa tim được ở trên
                    result += (char)((((c - offset) + k) % 26) + offset);
                    //tăng địa chỉ trong key
                    keyIndex++;
                }
                else
                {
                    //nếu c không phải chữ cái thì không cần dịch và thêm vào result
                    result += c;
                }
            }
            return result;
        }
        private string Decrypt(string text, string key)
        {
            string result = "";
            int keyIndex = 0;
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    int k = (char.IsUpper(key[keyIndex % key.Length]) ? key[keyIndex % key.Length] - 'A' : key[keyIndex % key.Length] - 'a');
                    // Sửa công thức giải mã:
                    int temp = (c - offset - k + 26) % 26;
                    result += (char)(temp + offset);
                    keyIndex++;
                }
                else
                {
                    result += c;
                }
            }
            return result;
        }
        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            string key = tb_key.Text;
            //kiểm tra key có null không
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Vui lòng nhập key.");
                return;
            }

            string input = tb_input.Text;
            if(input.Length > key.Length )
            {
                MessageBox.Show("key ngắn hơn input,key phải lớn hơn hoặc bằng input");
                return;
            }    
            tb_encrypt.Text = Encrypt(input, key);
        }

        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            string key = tb_key.Text;
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Vui lòng nhập key.");
                return;
            }
            string input = tb_encrypt.Text; // Giả sử tb_encrypt là TextBox hiển thị văn bản đã mã hóa
            tb_decrypt.Text = Decrypt(input, key);
        }
    }
}
