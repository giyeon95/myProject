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
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private Boolean idCheckd = false;
        private Boolean pwCheckd = false;
        private Boolean moneyCheckd = false; 
        loginForm login = new loginForm();
        Form1 form1 = new Form1();
         DataTable newtable = new DataTable();
      
        private void pwCheck()//비밀번호 일치 확인
        {
            if (codeBox.Text.Equals(codeCheckBox.Text))
                pwCheckd = true;
            else
                pwCheckd = false;
        }
        private void startMoney_Leave(object sender, EventArgs e) //입력금액판별식
        {
            int money=0;
            for (int i = 0; i < startMoney.Text.Length; i++)
            {
              int ascii = startMoney.Text[i];
                if (ascii < 48 || ascii > 57) // 아스키코드 이용 , 숫자만입력받았는지 확인
                {
                    MessageBox.Show("숫자만 입력하세요", "Error", MessageBoxButtons.OK);
                    startMoney.Text = "";
                    i = startMoney.Text.Length; 
                }
                else
                {
                    moneyCheckd = true;
                    money = int.Parse(startMoney.Text);
                }
            }
            if (moneyCheckd)
            {
                if (money < 100000 || money > 10000000) 
                {
                    MessageBox.Show("10만원이상, 1000이하의 금액을 입력해주세요", "Error", MessageBoxButtons.OK);
                    startMoney.Text = "";
                }
            }
        }

        private void SignUpForm_Load(object sender, EventArgs e) 
        {
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Parent = pictureBox1; // 배경화면 삭제

         }
        private void checkBox_Click(object sender, EventArgs e)//DB연결, ID값 비교 및 중복 ID 확인
        {
            idCheckd = false;

            if (idBox.Text == "")
            {
                MessageBox.Show("ID를 입력하세요", "Error", MessageBoxButtons.OK);
            }
            else
            {
                var con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\giyeo\OneDrive\문서\logindata.mdf; Integrated Security = True; Connect Timeout = 30");
                con.Open();

                if (!idCheckd)   // 중복체크
                {
                    string sql = "select Id from USERINFO where Id= '" + idBox.Text + "'";
                    var Comm = new SqlCommand(sql, con);
                    var myRead = Comm.ExecuteReader();
                    
                    if (myRead.HasRows)
                    {
                        idCheckd = false;
                        labelId.ForeColor = Color.Red;
                        labelId.Text = "ID가 존재합니다.";
                    }
                    else
                    {
                        idCheckd = true;
                        labelId.ForeColor = Color.Blue;
                        labelId.Text = "사용가능한 ID입니다.";
                    }
                    con.Close();
                }
            }
        }

        private void CanButton_Click(object sender, EventArgs e) //취소버튼 클릭
        {
            this.Close();
            login.Show();
        }
        private void SignButton_Click(object sender, EventArgs e)
        {
            if(idCheckd)
            {
                pwCheck();
                if(pwCheckd)
                {
                    string sql = "INSERT USERINFO(Id, Passward,StartMoney,EndMoney) VALUES(@Id,@Passward,@StartMoney,@EndMoney)"; //DB에 값 저장
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\giyeo\OneDrive\문서\logindata.mdf;Integrated Security=True;Connect Timeout=30");
                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                    DataTable newtable = new DataTable();
                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@Id", idBox.Text);
                    cmd.Parameters.AddWithValue("@Passward", codeBox.Text);
                    cmd.Parameters.AddWithValue("@StartMoney", int.Parse(startMoney.Text));
                    cmd.Parameters.AddWithValue("@EndMoney", int.Parse(startMoney.Text));


                
                    
                        con.Open();
                       int  i = cmd.ExecuteNonQuery();
                        con.Close();
               

                    if (i == 1) // 데이터 저장 확인
                    {
                        this.Close();
                        login.Show();
                        MessageBox.Show("가입이 완료되었습니다", "확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    { MessageBox.Show("데이터 저장 오류", "확인", MessageBoxButtons.OK, MessageBoxIcon.Error);}
                }
                else
                { MessageBox.Show("패스워드가 일치하지 않습니다.", "확인", MessageBoxButtons.OK, MessageBoxIcon.Error);}
            }
            else
            { MessageBox.Show("ID 중복체크를 해주시기 바랍니다", "확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);}
        } //가입버튼 확인
        private void codeBox_Leave(object sender, EventArgs e) //숫자에 입력했는지 확인
        {
            for (int i = 0; i < codeBox.Text.Length; i++)
            {
                int ascii = codeBox.Text[i];
                if (ascii < 48 || ascii > 57) // 아스키코드 이용 , 숫자만입력받았는지 확인
                {
                    MessageBox.Show("숫자만 입력하세요", "Error", MessageBoxButtons.OK);
                    codeBox.Text = "";
                    i = codeBox.Text.Length;
                } else { }
            }
        }
        private void codeCheckBox_Leave(object sender, EventArgs e) //Code번호 일치불일치 확인
        {
            if (codeBox.Text.Equals(codeCheckBox.Text)) //Code번호가 일치
            {
                codeSameCheck.ForeColor = Color.Blue;
                codeSameCheck.Text = "Code가 일치합니다.";
            }
            else //Code번호 불일치
            {
                codeSameCheck.ForeColor = Color.Red;
                codeSameCheck.Text = "Code가 일치하지 않습니다. 다시입력해주세요";
                codeCheckBox.Text = "";
            }
        }
    } 
}
