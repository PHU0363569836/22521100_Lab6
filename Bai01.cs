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
    public partial class Bai01 : Form
    {
        public Bai01()
        {
            InitializeComponent();
        }
        private string Encrypt(string text, int shift)
        {
            string result = "";
            foreach (char c in text)
            {
                //kiểm tra c có phải là chữ cái không đúng thì true sai thì false
                if (char.IsLetter(c))
                {
                    //kiểm tra chữ cái c là hoa hay thường,nếu hoa thì trả về A còn thường trả về a
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    //tìm kí tự sau khi dịch shift kí tự
                    result += (char)(((c + shift - offset) % 26) + offset);
                }
                else
                {
                    result += c;
                }
            }
            return result;
        }

        private string Decrypt(string text, int shift)
        {
            // Thực hiện giải mã với dịch chuyển ngược lại
            return Encrypt(text, 26 - shift);
        }
        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            int shift;
            //kiểm tra shift vừa nhập có phải số nguyên không
            if (int.TryParse(tb_shift.Text, out shift))
            {
                string input = tb_input.Text;
                tb_encrypt.Text = Encrypt(input, shift);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một số hợp lệ cho dịch chuyển (Shift).");
            }
        }

        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            int shift;
            if (int.TryParse(tb_shift.Text, out shift))
            {
                string input = tb_encrypt.Text;
                tb_decrypt.Text = Decrypt(input, shift); // Fix here: Changed textBox1.Text to outputTextBox.Text
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một số hợp lệ cho dịch chuyển (Shift).");
            }
        }
    }
}
