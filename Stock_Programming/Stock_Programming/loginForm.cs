using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Programming
{
    public partial class loginForm : Form
    {
        string message = "ID 또는 Code번호가 틀립니다. 다시 확인하고 입력해주세요";
        string caption = "Login Error";
        
        public loginForm()
        {
            InitializeComponent();
        }

        private void loginForm_Load(object sender, EventArgs e) //라벨, 그룹박스의 배경색 삭제
        {
            label1.BackColor = Color.Transparent;
            label1.Parent = pictureBox1;

            groupBox1.BackColor = Color.Transparent;
            groupBox1.Parent = pictureBox1;

            label2.BackColor = Color.Transparent;
            label2.Parent = pictureBox1;
        }
        private void loginButton_Click(object sender, EventArgs e) //DB에 아이디, Code 체크
        { 
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\giyeo\OneDrive\문서\logindata.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from USERINFO where Id='"+idBox.Text+"'and Passward='"+psBox.Text+"'",con);
            DataTable newtable = new DataTable();

            sda.Fill(newtable);

            if(newtable.Rows[0][0].ToString() =="1")
            {
                Form1 form1 = new Form1();
                this.Hide();
                form1.userId = idBox.Text;
                form1.Show();
                
            }
            else
                MessageBox.Show(message, caption, MessageBoxButtons.OK);
        }
        private void Join_Click(object sender, EventArgs e) //회원가입 폼으로 이동
        {
            SignUpForm sign = new SignUpForm();
            sign.Show();
        }
    }
}
