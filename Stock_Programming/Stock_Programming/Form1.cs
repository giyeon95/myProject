using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Stock_Programming
{
    public partial class Form1 : Form
    {
        Stock Tron;
        Stock Ripple;
        Stock Eos;
        Stock Ada;
        Stock QTum;
        Series[] series = new Series[10];

        Player player;
        Main main;
        DealSystem dealsystem;
        public Boolean boolBuySell = false;

        
        public string userId;
        bool sell_100_check = true;
        bool buy_100_check = true;
        bool time = false;
        bool buyReservation = false;
        bool reservation = true;
        int timer = 0;
        int rePrice;
        int reBuyPrice;
        int reQuantity;
        int reBuyQuantity;
        int reSellint;
        int reBuyint;
        string errorMessage = "코인개수가 부족합니다 잠시후에 다시 시도해주세요";

        public delegate void TextDelegate(string textbox);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) //폼이 실행될때
        {

            timer1.Enabled = true;
            timer2.Enabled = true;
            
            main = new Main(this);
            dealsystem = new DealSystem(this);
            TextDelegate textDelegate = new TextDelegate(SetTextBox);

            Ripple = new Stock("Ripple", "RAB", 1000, 100000);
            Tron = new Stock("Tron", "TAB", 700, 100000);
            Eos = new Stock("Eos", "EAB", 500, 100000);
            Ada = new Stock("Ada", "AAB", 300, 100000);
            QTum = new Stock("QTum", "QAB", 800, 100000); 
            
            SellStock.Items.Add(Ripple.StockName);
            SellStock.Items.Add(Tron.StockName);
            SellStock.Items.Add(Eos.StockName);
            SellStock.Items.Add(Ada.StockName);
            SellStock.Items.Add(QTum.StockName);
            //SellStock 리스트 추가
            BuyStock.Items.Add(Ripple.StockName);
            BuyStock.Items.Add(Tron.StockName);
            BuyStock.Items.Add(Eos.StockName);
            BuyStock.Items.Add(Ada.StockName);
            BuyStock.Items.Add(QTum.StockName);
            //BuyStock 리스트 추가

            series[0] = new Series(Ripple.StockName, 1000 + Ripple.StockCurrentPrice);
            series[1] = new Series(Tron.StockName, 500 + Tron.StockCurrentPrice);
            series[2] = new Series(Eos.StockName, 800 + Eos.StockCurrentPrice);
            series[3] = new Series(Ada.StockName, 1000 + Eos.StockCurrentPrice);
            series[4] = new Series(QTum.StockName, 1000 + Eos.StockCurrentPrice);

            for (int i = 0; i < 5; i++) { StockChart.Series.Add(series[i]); } // 그래프에 그림 추가


            StockChart.Series[Ripple.StockName].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            StockChart.Series[Tron.StockName].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            StockChart.Series[Eos.StockName].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            StockChart.Series[Ada.StockName].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            StockChart.Series[QTum.StockName].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            //차트 타입 지정

            StockChart.Series[Ripple.StockName].Points.Add(Ripple.StockCurrentPrice);
            StockChart.Series[Tron.StockName].Points.Add(Tron.StockCurrentPrice);
            StockChart.Series[Eos.StockName].Points.Add(Eos.StockCurrentPrice);
            StockChart.Series[Ada.StockName].Points.Add(Ada.StockCurrentPrice);
            StockChart.Series[QTum.StockName].Points.Add(QTum.StockCurrentPrice);
            //차트 에 점찍기
           
            main.VirtualRun(textDelegate, Ripple,Tron, Eos,Ada,QTum); // 가상객체 생성매서드

            GridView.RowCount = 10;

            GridView.Rows[0].HeaderCell.Value = Ripple.StockName;
            GridView.Rows[1].HeaderCell.Value = Tron.StockName;
            GridView.Rows[2].HeaderCell.Value = Eos.StockName;
            GridView.Rows[3].HeaderCell.Value = Ada.StockName;
            GridView.Rows[4].HeaderCell.Value = QTum.StockName;
            //스톡차트 표에 주식이름 설정

            this.GridView[0, 0].Value = "2T5JT0"+Ripple.StockCode+"0";
            this.GridView[0, 1].Value = "7M2Z92"+Tron.StockCode+"2";
            this.GridView[0, 2].Value = "0OE1P4"+Eos.StockCode+"3";
            this.GridView[0, 3].Value = "43BV9K"+Ada.StockCode+"4";
            this.GridView[0, 4].Value = "7FA2P0"+QTum.StockCode+"5";
            //스톡차트 표에 주식 코드값 설정

            this.GridView[1, 0].Value = Ripple.StockCurrentPrice + " KRW";
            this.GridView[1, 1].Value = Tron.StockCurrentPrice + " KRW";
            this.GridView[1, 2].Value = Eos.StockCurrentPrice + " KRW";
            this.GridView[1, 3].Value = Ada.StockCurrentPrice + " KRW";
            this.GridView[1, 4].Value = QTum.StockCurrentPrice + " KRW";
            //스톡차트 표에 가격 설정

            this.GridView[2, 0].Value = Ripple.Variance+"%";
            this.GridView[2, 1].Value = Tron.Variance + "%";
            this.GridView[2, 2].Value = Eos.Variance + "%";
            this.GridView[2, 3].Value = Ada.Variance + "%";
            this.GridView[2, 4].Value = QTum.Variance + "%";
            //스톡차트 표에 상승폭 설정

            this.GridView[3, 0].Value = Ripple.StockVolume + " 건";
            this.GridView[3, 1].Value = Tron.StockVolume + " 건";
            this.GridView[3, 2].Value = Eos.StockVolume + " 건";
            this.GridView[3, 3].Value = Ada.StockVolume + " 건";
            this.GridView[3, 4].Value = QTum.StockVolume + " 건";
            //스톡차트 표에 거래량 설정


            





            //-----------------------------Player 정보를 DB에서 넘겨받는 구문----------------------------------------------

            string sql = "Select * from USERINFO where Id = '"+userId+"'"; //로그인한 아이디의 정보를 받아오는 문자열
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\giyeo\OneDrive\문서\logindata.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);  
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) //DB에서 현재코인의 개수, 이름등을 받아옴
            {
                string id = dr["Id"].ToString();
                int InitialCapital = 1000000;
                int CurrentCapital = 1000000;
                float Variance =1;
                //    int InitialCapital = (int)dr["StartMoney"];
                //    int CurrentCapital = (int)dr["EndMoney"];                
                // float Variance = Convert.ToSingle(dr["Benefit"]);
                int RipCount = (int)dr["Rip"];
                int TronCount = (int)dr["Tron"];
                int EosCount = (int)dr["Eos"];
                int AdaCount = (int)dr["Ada"];
                int QtumCount = (int)dr["QTum"];

                pIdLabel.Text = dr["Id"].ToString();
                pStartLabel.Text = dr["StartMoney"].ToString()+"KRW";
                pNowLabel.Text = dr["EndMoney"].ToString()+"KRW";
                pVarLabel.Text = dr["Benefit"].ToString()+"%";
                ripCountLabel.Text = dr["Rip"].ToString() + "개";
                tronCountLabel.Text = dr["Tron"].ToString() + "개";
                eosCountLabel.Text = dr["Eos"].ToString() + "개";
                adaCountLabel.Text = dr["Ada"].ToString() + "개";
                qtumCountLabel.Text = dr["QTum"].ToString() + "개";

                player = new Player(id, InitialCapital, CurrentCapital, Variance, RipCount, TronCount, EosCount, AdaCount, QtumCount); // 플레이어 객체에 저장
            }
            con.Close();
        }

        private void timer1_Tick(object sender, EventArgs e) //객체가 생성완료되면 시장타이머 가동
        { 
            buyOrSellTimer.Enabled = boolBuySell; // 타이머 실행
            if (boolBuySell) timer1.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e) // 차트업데이트 타이머
        {
            
            main.ChartUpdate(StockChart,Ripple);
            main.ChartUpdate(StockChart, Tron);
            main.ChartUpdate(StockChart, Eos);
            main.ChartUpdate(StockChart, Ada);
            main.ChartUpdate(StockChart, QTum);

            this.GridView[1, 0].Value = Ripple.StockCurrentPrice + " KRW";
            this.GridView[1, 1].Value = Tron.StockCurrentPrice + " KRW";
            this.GridView[1, 2].Value = Eos.StockCurrentPrice + " KRW";
            this.GridView[1, 3].Value = Ada.StockCurrentPrice + " KRW";
            this.GridView[1, 4].Value = QTum.StockCurrentPrice + " KRW";
            //스톡차트 표에 가격 Update

            if (Ripple.Variance > 0)
                this.GridView[2, 0].Style.ForeColor = Color.Red;
            else if(Ripple.Variance<0)
                this.GridView[2, 0].Style.ForeColor = Color.Blue;
            else if(Ripple.Variance.Equals(0))
                this.GridView[2, 0].Style.ForeColor = Color.Black;

            if (Tron.Variance > 0)
                this.GridView[2, 1].Style.ForeColor = Color.Red;
            else if (Tron.Variance < 0)
                this.GridView[2, 1].Style.ForeColor = Color.Blue;
            else if (Tron.Variance.Equals(0))
                this.GridView[2, 1].Style.ForeColor = Color.Black;

            if (Eos.Variance > 0)
                this.GridView[2, 2].Style.ForeColor = Color.Red;
            else if (Eos.Variance < 0)
                this.GridView[2, 2].Style.ForeColor = Color.Blue;
            else if (Eos.Variance.Equals(0))
                this.GridView[2, 2].Style.ForeColor = Color.Black;

            if (Ada.Variance > 0)
                this.GridView[2, 3].Style.ForeColor = Color.Red;
            else if (Ada.Variance < 0)
                this.GridView[2, 3].Style.ForeColor = Color.Blue;
            else if (Ada.Variance.Equals(0))
                this.GridView[2, 3].Style.ForeColor = Color.Black;

            if (QTum.Variance > 0)
                this.GridView[2, 4].Style.ForeColor = Color.Red;
            else if (QTum.Variance < 0)
                this.GridView[2, 4].Style.ForeColor = Color.Blue;
            else if (QTum.Variance.Equals(0))
                this.GridView[2, 4].Style.ForeColor = Color.Black;


            this.GridView[2, 0].Value = Ripple.Variance + "%";
            this.GridView[2, 1].Value = Tron.Variance + "%";
            this.GridView[2, 2].Value = Eos.Variance + "%";
            this.GridView[2, 3].Value = Ada.Variance + "%";
            this.GridView[2, 4].Value = QTum.Variance + "%";
            //스톡차트 표에 상승폭 Update

            this.GridView[3, 0].Value = Ripple.StockVolume+" 건";
            this.GridView[3, 1].Value = Tron.StockVolume + " 건";
            this.GridView[3, 2].Value = Eos.StockVolume + " 건";
            this.GridView[3, 3].Value = Ada.StockVolume + " 건";
            this.GridView[3, 4].Value = QTum.StockVolume + " 건";
            //스톡차트 표에 거래량 Update
            Ripple.UpdateVariance();
            Tron.UpdateVariance();
            Eos.UpdateVariance();
            Ada.UpdateVariance();
            QTum.UpdateVariance();
            //상승률 증가

            
                StockChart.ChartAreas[0].AxisX.Maximum = 20+timer;
            if (timer % 20 == 0) time = true;
            if (time)
            {
                StockChart.ChartAreas[0].AxisX.Minimum = timer;
                time = false;
            }
           
            



            pStartLabel.Text = player.InitialCapital.ToString()+"KRW";
            pNowLabel.Text = player.CurrentCapital.ToString()+"KRW";
            pVarLabel.Text = player.Variance+ "%";
            ripCountLabel.Text = player.RipCount+ "개";
            tronCountLabel.Text = player.TronCount+ "개";
            eosCountLabel.Text = player.EosCount + "개";
            adaCountLabel.Text = player.AdaCount + "개";
            qtumCountLabel.Text = player.QtumCount + "개";
            //사용자 개인정보 업데이트 

            timer++;
        }

        private void UpdateBenefit_Tick(object sender, EventArgs e)
        {
            main.UpdateVirtualBenefit(Ripple, Tron, Eos, Ada, QTum);
            charactorSell.Enabled = true;
            charactorBuy.Enabled = true;
        } //시장의 움직임, 판매로직, 구매로직 true

        private void charactorSell_Tick(object sender, EventArgs e)
        {
            main.benefitSell(Ripple, Tron, Eos, Ada, QTum);
        } //성격과 이익률에따른 판매로직 실행

        private void charactorBuy_Tick(object sender, EventArgs e)
        {
            main.benefitBuy(Ripple, Tron, Eos, Ada, QTum);
            Ripple.UpdateQuantity();
            Tron.UpdateQuantity();
            Eos.UpdateQuantity();
            Ada.UpdateQuantity();
            QTum.UpdateQuantity();
        } //성격과 이익률에따른 구매로직 실행

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Run = false;
            loginForm loginform = new loginForm();
            loginform.Close();
        }

        public void SetTextBox(string richTextBox)
        {
            LogBox.Text += richTextBox;    
        } //Delegate 연산을 위한 매서드

        private void buyOrSellTimer_Tick(object sender, EventArgs e) // 주식시장 생성
        {
            main.StockStore(Ripple, Tron, Eos, Ada, QTum,dealsystem);
            UpdateBenefit.Enabled = true;
        }

        private void SellQuantityBox_Leave(object sender, EventArgs e)
        {
            int selectedIndex = SellStock.SelectedIndex;

            for (int i = 0; i < SellQuantityBox.Text.Length; i++)
            {
                int ascii = SellQuantityBox.Text[i];
                if (ascii < 48 || ascii > 57) // 아스키코드 이용 , 숫자만입력받았는지 확인
                {
                    MessageBox.Show("숫자만 입력하세요", "Error", MessageBoxButtons.OK);
                    SellQuantityBox.Text = "";
                    i = SellQuantityBox.Text.Length;
                }
                else
                {
                    switch (selectedIndex)
                    {
                        case 0:
                            { //리플
                                if (int.Parse(SellQuantityBox.Text) > player.RipCount)
                                {
                                    MessageBox.Show("가지고 있는 수량보다 많습니다. 다시 설정해주세요", "Error", MessageBoxButtons.OK);
                                    SellQuantityBox.Text = "";
                                }
                                break;
                            }
                        case 1:
                            { //트론           
                                if (int.Parse(SellQuantityBox.Text) > player.TronCount)
                                {
                                    MessageBox.Show("가지고 있는 수량보다 많습니다. 다시 설정해주세요", "Error", MessageBoxButtons.OK);
                                    SellQuantityBox.Text = "";
                                }
                                break;
                            }
                        case 2:
                            { //이오스
                                if (int.Parse(SellQuantityBox.Text) > player.EosCount)
                                {
                                    MessageBox.Show("가지고 있는 수량보다 많습니다. 다시 설정해주세요", "Error", MessageBoxButtons.OK);
                                    SellQuantityBox.Text = "";
                                }
                                break;
                            }
                        case 3:
                            { //에이다
                                if (int.Parse(SellQuantityBox.Text) > player.AdaCount)
                                {
                                    MessageBox.Show("가지고 있는 수량보다 많습니다. 다시 설정해주세요", "Error", MessageBoxButtons.OK);
                                    SellQuantityBox.Text = "";
                                }
                                break;
                            }
                        case 4:
                            { //퀀텀
                                if (int.Parse(SellQuantityBox.Text) > player.QtumCount)
                                {
                                    MessageBox.Show("가지고 있는 수량보다 많습니다. 다시 설정해주세요", "Error", MessageBoxButtons.OK);
                                    SellQuantityBox.Text = "";
                                }
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        } // 판매 개수에 숫자만 들어가게 제작

        private void BuyQuantityBox_Leave(object sender, EventArgs e)
        {
            int selectedIndex = BuyStock.SelectedIndex;

            for (int i = 0; i < BuyQuantityBox.Text.Length; i++)
            {
                int ascii = BuyQuantityBox.Text[i];
                if (ascii < 48 || ascii > 57) // 아스키코드 이용 , 숫자만입력받았는지 확인
                {
                    MessageBox.Show("숫자만 입력하세요", "Error", MessageBoxButtons.OK);
                    BuyQuantityBox.Text = "";
                    i = BuyQuantityBox.Text.Length;
                }
                else
                {
                    switch (selectedIndex)
                    {
                        case 0:
                            { //리플
                                if (player.CurrentCapital < Ripple.StockCurrentPrice * int.Parse(BuyQuantityBox.Text))
                                {
                                    MessageBox.Show("구매할수있는 수량을 초과하였습니다. 다시입력해주세요", "Error", MessageBoxButtons.OK);
                                    BuyQuantityBox.Text = "";
                                }
                                break;
                            }
                        case 1:
                            { //트론
                                if (player.CurrentCapital < Tron.StockCurrentPrice * int.Parse(BuyQuantityBox.Text))
                                {
                                    MessageBox.Show("구매할수있는 수량을 초과하였습니다. 다시입력해주세요", "Error", MessageBoxButtons.OK);
                                    BuyQuantityBox.Text = "";
                                }
                                break;
                            }
                        case 2:
                            { //이오스
                                if (player.CurrentCapital < Eos.StockCurrentPrice * int.Parse(BuyQuantityBox.Text))
                                {
                                    MessageBox.Show("구매할수있는 수량을 초과하였습니다. 다시입력해주세요", "Error", MessageBoxButtons.OK);
                                    BuyQuantityBox.Text = "";
                                }
                                break;
                            }
                        case 3:
                            { //에이다
                                if (player.CurrentCapital < Ada.StockCurrentPrice * int.Parse(BuyQuantityBox.Text))
                                {
                                    MessageBox.Show("구매할수있는 수량을 초과하였습니다. 다시입력해주세요", "Error", MessageBoxButtons.OK);
                                    BuyQuantityBox.Text = "";
                                }
                                break;
                            }
                        case 4:
                            { //퀀텀
                                if (player.CurrentCapital < QTum.StockCurrentPrice * int.Parse(BuyQuantityBox.Text))
                                {
                                    MessageBox.Show("구매할수있는 수량을 초과하였습니다. 다시입력해주세요", "Error", MessageBoxButtons.OK);
                                    BuyQuantityBox.Text = "";
                                }
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        } //구매 개수에 숫자만 들어가게 제작

        private void SellPriceBox_Leave(object sender, EventArgs e)
        {
            for (int i = 0; i < SellPriceBox.Text.Length; i++)
            {
                int ascii = SellPriceBox.Text[i];
                if (ascii < 48 || ascii > 57) // 아스키코드 이용 , 숫자만입력받았는지 확인
                {
                    MessageBox.Show("숫자만 입력하세요", "Error", MessageBoxButtons.OK);
                    SellPriceBox.Text = "";
                    i = SellPriceBox.Text.Length;
                }
                else
                {
                    int gop;

                    int selectedIndex = SellStock.SelectedIndex;
                    int sell_price = int.Parse(SellPriceBox.Text);
                    
                    if (!(SellQuantityBox.Text == "" || SellPriceBox.Text == ""))
                    {
                            gop = int.Parse(SellQuantityBox.Text) * sell_price;
                            sumLabelSell.Text = "(" + SellQuantityBox.Text + "주* " + sell_price + "KRW =" + gop + "KRW)";
                    }
                }
            }
        } //판매가격에 숫자만 들어가게 제작

        private void BuyPriceBox_Leave(object sender, EventArgs e)
        {
            for (int i = 0; i < BuyPriceBox.Text.Length; i++)
            {
                int ascii = BuyPriceBox.Text[i];
                if (ascii < 48 || ascii > 57) // 아스키코드 이용 , 숫자만입력받았는지 확인
                {
                    MessageBox.Show("숫자만 입력하세요", "Error", MessageBoxButtons.OK);
                    BuyPriceBox.Text = "";
                    i = BuyPriceBox.Text.Length;
                }
                else
                {
                    int gop;
                    int buy_price = int.Parse(BuyPriceBox.Text);
                    if (!(BuyQuantityBox.Text == "" || BuyPriceBox.Text == ""))
                    {
                        gop = int.Parse(BuyQuantityBox.Text) * buy_price;
                        sumLabelBuy.Text = "(" + BuyQuantityBox.Text + "주* " + buy_price + "KRW =" + gop + "KRW)";
                    }

                }
            }
        } //구매가격에 숫자만 들어가게 제작

        private void radioNowPrice1_CheckedChanged(object sender, EventArgs e)
        {
            int gop;
           
                int selectedIndex = SellStock.SelectedIndex;
                switch (selectedIndex)
                {
                    case 0:
                        { //리플
                            SellPriceBox.Text = Ripple.StockCurrentPrice.ToString();

                            if (!(SellQuantityBox.Text == "" || SellPriceBox.Text == ""))
                            {
                                gop = int.Parse(SellQuantityBox.Text) * Ripple.StockCurrentPrice;
                                sumLabelSell.Text = "(" + SellQuantityBox.Text + "주* " + Ripple.StockCurrentPrice + "KRW =" + gop + "KRW)";
                            }
                            else { }
                            break;
                        }
                    case 1:
                        { //트론
                            SellPriceBox.Text = Tron.StockCurrentPrice.ToString();

                            if (!(SellQuantityBox.Text == "" || SellPriceBox.Text == ""))
                            {
                                gop = int.Parse(SellQuantityBox.Text) * Tron.StockCurrentPrice;
                                sumLabelSell.Text = "(" + SellQuantityBox.Text + "주* " + Tron.StockCurrentPrice + "KRW =" + gop + "KRW)";
                            }
                            else { }
                            break;
                        }
                    case 2:
                        { //이오스
                            SellPriceBox.Text = Eos.StockCurrentPrice.ToString();

                            if (!(SellQuantityBox.Text == "" || SellPriceBox.Text == ""))
                            {
                                gop = int.Parse(SellQuantityBox.Text) * Eos.StockCurrentPrice;
                                sumLabelSell.Text = "(" + SellQuantityBox.Text + "주* " + Eos.StockCurrentPrice + "KRW =" + gop + "KRW)";
                            }
                            else { }
                            break;
                        }
                    case 3:
                        { //에이다
                            SellPriceBox.Text = Ada.StockCurrentPrice.ToString();

                            if (!(SellQuantityBox.Text == "" || SellPriceBox.Text == ""))
                            {
                                gop = int.Parse(SellQuantityBox.Text) * Ada.StockCurrentPrice;
                                sumLabelSell.Text = "(" + SellQuantityBox.Text + "주* " + Ada.StockCurrentPrice + "KRW =" + gop + "KRW)";
                            }
                            else { }
                            break;
                        }
                    case 4:
                        { //퀀텀
                            SellPriceBox.Text = QTum.StockCurrentPrice.ToString();

                            if (!(SellPriceBox.Text == "" || SellQuantityBox.Text == ""))
                            {
                                gop = int.Parse(SellQuantityBox.Text) * QTum.StockCurrentPrice;
                                sumLabelSell.Text = "(" + SellQuantityBox.Text + "주* " + QTum.StockCurrentPrice + "KRW =" + gop + "KRW)";
                            }
                            else { }
                            break;
                        }
                    default:
                        break;
                }
                radioNowPrice1.Checked = false;
        } // 현재가격으로 구매하는 라디오 버튼 클릭시

        private void radioNowPrice2_CheckedChanged(object sender, EventArgs e)
        {
            int gop;

            int selectedIndex = BuyStock.SelectedIndex;
            switch (selectedIndex)
            {
                case 0:
                    { //리플
                        BuyPriceBox.Text = Ripple.StockCurrentPrice.ToString();

                        if (!(BuyQuantityBox.Text == "" || BuyPriceBox.Text == ""))
                        {
                            gop = int.Parse(BuyQuantityBox.Text) * Ripple.StockCurrentPrice;
                            sumLabelBuy.Text = "(" + BuyQuantityBox.Text + "주* " + Ripple.StockCurrentPrice + "KRW =" + gop + "KRW)";
                        }
                        else { }
                        break;
                    }
                case 1:
                    { //트론
                        BuyPriceBox.Text = Tron.StockCurrentPrice.ToString();

                        if (!(BuyQuantityBox.Text == "" || BuyPriceBox.Text == ""))
                        {
                            gop = int.Parse(BuyQuantityBox.Text) * Tron.StockCurrentPrice;
                            sumLabelBuy.Text = "(" + BuyQuantityBox.Text + "주* " + Tron.StockCurrentPrice + "KRW =" + gop + "KRW)";
                        }
                        else { }
                        break;
                    }
                case 2:
                    { //이오스
                        BuyPriceBox.Text = Eos.StockCurrentPrice.ToString();

                        if (!(BuyQuantityBox.Text == "" || BuyPriceBox.Text == ""))
                        {
                            gop = int.Parse(BuyQuantityBox.Text) * Eos.StockCurrentPrice;
                            sumLabelBuy.Text = "(" + BuyQuantityBox.Text + "주* " + Eos.StockCurrentPrice + "KRW =" + gop + "KRW)";
                        }
                        else { }
                        break;
                    }
                case 3:
                    { //에이다
                        BuyPriceBox.Text = Ada.StockCurrentPrice.ToString();

                        if (!(BuyQuantityBox.Text == "" || BuyPriceBox.Text == ""))
                        {
                            gop = int.Parse(BuyQuantityBox.Text) * Ada.StockCurrentPrice;
                            sumLabelBuy.Text = "(" + BuyQuantityBox.Text + "주* " + Ada.StockCurrentPrice + "KRW =" + gop + "KRW)";
                        }
                        else { }
                        break;
                    }
                case 4:
                    { //퀀텀
                        BuyPriceBox.Text = QTum.StockCurrentPrice.ToString();

                        if (!(BuyPriceBox.Text == "" || BuyQuantityBox.Text == ""))
                        {
                            gop = int.Parse(BuyQuantityBox.Text) * QTum.StockCurrentPrice;
                            sumLabelBuy.Text = "(" + BuyQuantityBox.Text + "주* " + QTum.StockCurrentPrice + "KRW =" + gop + "KRW)";
                        }
                        else { }
                        break;
                    }
                default:
                    break;
            }
            radioNowPrice2.Checked = false;
        } //현재가격으로 판매하는 라디오버튼 클릭시

        private void SellAllCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (sell_100_check && SellAllCheck.Checked)
            {
                int selectedIndex = SellStock.SelectedIndex;
                int gop;
                switch (selectedIndex)
                {
                    case 0:
                        { //리플
                            SellQuantityBox.Text = player.RipCount.ToString();
                            if (!(SellQuantityBox.Text == "" || SellPriceBox.Text == ""))
                            {
                                gop = int.Parse(SellQuantityBox.Text) * Ripple.StockCurrentPrice;
                                sumLabelSell.Text = "(" + SellQuantityBox.Text + "주* " + Ripple.StockCurrentPrice + "KRW =" + gop + "KRW)";
                            }
                            break;
                        }
                    case 1:
                        { //트론
                            SellQuantityBox.Text = player.TronCount.ToString();
                            if (!(SellQuantityBox.Text == "" || SellPriceBox.Text == ""))
                            {
                                gop = int.Parse(SellQuantityBox.Text) * Tron.StockCurrentPrice;
                                sumLabelSell.Text = "(" + SellQuantityBox.Text + "주* " + Tron.StockCurrentPrice + "KRW =" + gop + "KRW)";
                            }
                            break;
                        }
                    case 2:
                        { //이오스
                            SellQuantityBox.Text = player.EosCount.ToString();
                            if (!(SellQuantityBox.Text == "" || SellPriceBox.Text == ""))
                            {
                                gop = int.Parse(SellQuantityBox.Text) * Eos.StockCurrentPrice;
                                sumLabelSell.Text = "(" + SellQuantityBox.Text + "주* " + Eos.StockCurrentPrice + "KRW =" + gop + "KRW)";
                            }
                            break;
                        }
                    case 3:
                        { //에이다
                            SellQuantityBox.Text = player.AdaCount.ToString();
                            if (!(SellQuantityBox.Text == "" || SellPriceBox.Text == ""))
                            {
                                gop = int.Parse(SellQuantityBox.Text) * Ada.StockCurrentPrice;
                                sumLabelSell.Text = "(" + SellQuantityBox.Text + "주* " + Ada.StockCurrentPrice + "KRW =" + gop + "KRW)";
                            }
                            break;
                        }
                    case 4:
                        { //퀀텀
                            SellQuantityBox.Text = player.QtumCount.ToString();
                            if (!(SellQuantityBox.Text == "" || SellPriceBox.Text == ""))
                            {
                                gop = int.Parse(SellQuantityBox.Text) * QTum.StockCurrentPrice;
                                sumLabelSell.Text = "(" + SellQuantityBox.Text + "주* " + QTum.StockCurrentPrice + "KRW =" + gop + "KRW)";
                            }
                            break;
                        }
                    default:
                        break;
                }
                sell_100_check = false;
            } else
            {
                sell_100_check = true;
                SellQuantityBox.Text = "";
            }
        } //판매 100% 버튼 클릭시

        private void BuyAllCheck_CheckedChanged(object sender, EventArgs e)
        {
            if(buy_100_check&&BuyAllCheck.Checked) {
                int gop;
            int selectedIndex = BuyStock.SelectedIndex;
                switch (selectedIndex)
                {
                    case 0:
                        { //리플
                            BuyQuantityBox.Text = (player.CurrentCapital / Ripple.StockCurrentPrice).ToString();
                            if (!(BuyPriceBox.Text == "" || BuyQuantityBox.Text == ""))
                            {
                                gop = int.Parse(BuyQuantityBox.Text) * Ripple.StockCurrentPrice;
                                sumLabelBuy.Text = "(" + BuyQuantityBox.Text + "주* " + Ripple.StockCurrentPrice + "KRW =" + gop + "KRW)";
                            }
                            break;
                        }
                    case 1:
                        { //트론
                            BuyQuantityBox.Text = (player.CurrentCapital / Tron.StockCurrentPrice).ToString();
                            if (!(BuyPriceBox.Text == "" || BuyQuantityBox.Text == ""))
                            {
                                gop = int.Parse(BuyQuantityBox.Text) * Tron.StockCurrentPrice;
                                sumLabelBuy.Text = "(" + BuyQuantityBox.Text + "주* " + Tron.StockCurrentPrice + "KRW =" + gop + "KRW)";
                            }
                            break;
                        }
                    case 2:
                        { //이오스
                            BuyQuantityBox.Text = (player.CurrentCapital / Eos.StockCurrentPrice).ToString();
                            if (!(BuyPriceBox.Text == "" || BuyQuantityBox.Text == ""))
                            {
                                gop = int.Parse(BuyQuantityBox.Text) * Eos.StockCurrentPrice;
                                sumLabelBuy.Text = "(" + BuyQuantityBox.Text + "주* " + Eos.StockCurrentPrice + "KRW =" + gop + "KRW)";
                            }
                            break;
                        }
                    case 3:
                        { //에이다
                            BuyQuantityBox.Text = (player.CurrentCapital / Ada.StockCurrentPrice).ToString();
                            if (!(BuyPriceBox.Text == "" || BuyQuantityBox.Text == ""))
                            {
                                gop = int.Parse(BuyQuantityBox.Text) * Ada.StockCurrentPrice;
                                sumLabelBuy.Text = "(" + BuyQuantityBox.Text + "주* " + Ada.StockCurrentPrice + "KRW =" + gop + "KRW)";
                            }
                            break;
                        }
                    case 4:
                        { //퀀텀
                            BuyQuantityBox.Text = (player.CurrentCapital / QTum.StockCurrentPrice).ToString();
                            if (!(BuyPriceBox.Text == "" || BuyQuantityBox.Text == ""))
                            {
                                gop = int.Parse(BuyQuantityBox.Text) * QTum.StockCurrentPrice;
                                sumLabelBuy.Text = "(" + BuyQuantityBox.Text + "주* " + QTum.StockCurrentPrice + "KRW =" + gop + "KRW)";
                            }
                            break;
                        }
                    default:
                        break;
                }
                buy_100_check = false;
            }else
            {
                buy_100_check = true ;
                BuyQuantityBox.Text = "";
            }
        } //구매 100% 버튼 클릭시

        private void SellStock_TextChanged(object sender, EventArgs e)
        {
            radioNowPrice1.Checked = false;
            SellAllCheck.Checked = false;
            SellQuantityBox.Text = "";
            SellPriceBox.Text = "";
            sumLabelSell.Text = "";
        } //판매 GroupBox 변경시

        private void BuyStock_TextChanged(object sender, EventArgs e)
        {
            radioNowPrice2.Checked = false;
            BuyAllCheck.Checked = false;
            BuyQuantityBox.Text = "";
            BuyPriceBox.Text = "";
            sumLabelBuy.Text = "";
        } //구매GroupBox 변경시

        private void SellButton_Click(object sender, EventArgs e) //주식 판매 버튼 클릭
        {
            if (SellQuantityBox.Text == "" || SellPriceBox.Text == "")
            {
                MessageBox.Show("가격과 수량을 먼저 입력하세요", "Error", MessageBoxButtons.OK);
                SellQuantityBox.Text = "";
                SellPriceBox.Text = "";
                SellAllCheck.Checked = false;
                radioNowPrice1.Checked = false;
            }
            else
            {
                if (SellQuantityBox.Text.Equals("0"))
                {
                    MessageBox.Show("수량이 0 개입니다. 다시 시도해주세요", "Error", MessageBoxButtons.OK);
                    SellQuantityBox.Text = "";
                    SellAllCheck.Checked = false;
                    radioNowPrice1.Checked = false;
                    SellPriceBox.Text = "";
                }
                else
                {
                    MessageBoxButtons button = MessageBoxButtons.YesNo;
                    string checkmessage = SellStock.SelectedItem + "을 " + SellQuantityBox.Text + "개 판매하시겠습니까?";
                    string caption = "알림";


                    DialogResult result = MessageBox.Show(checkmessage, "판매확인", button);

                    if (result.Equals(DialogResult.Yes)) //판매 확인버튼을 누를시
                    {
                        int selectedIndex = SellStock.SelectedIndex;
                        int SellQuantityCoin = int.Parse(SellQuantityBox.Text);
                        int SellPrice = int.Parse(SellPriceBox.Text);

                        reQuantity = SellQuantityCoin;
                        rePrice = SellPrice;
                        reSellint = selectedIndex;
                        string resultmessage = player.PlayerId + "님의 지갑에" + SellQuantityCoin * SellPrice + "만큼 돈이 들어왔습니다.";
                        
                        switch (selectedIndex)
                        {
                            case 0:
                                {
                                    if (SellPrice > Ripple.StockCurrentPrice)
                                    {
                                        if (ReservationTimer.Enabled)
                                        {
                                            MessageBox.Show("이미 예약이 걸려있습니다. 다시입력해주세요.", "Reservation Error", MessageBoxButtons.OK);
                                            reservation = true;
                                        }
                                        else
                                        {
                                            player.RipCount -= SellQuantityCoin; //사용자 리플갯수 감소
                                            reSellLabel.Text = Ripple.StockName + "코인을 " + rePrice + "KRW에 " + reQuantity + "개 매도 진행중";
                                            reservation = true;
                                        }
                                    }
                                    else
                                    {
                                        player.RipCount -= SellQuantityCoin; //사용자 리플갯수 감소
                                        player.CurrentCapital += SellQuantityCoin * SellPrice; //지갑에 돈 추가
                                        Ripple.Quantity += SellQuantityCoin;
                                        Ripple.SellStock(SellQuantityCoin);
                                        reservation = false;
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    if (SellPrice > Tron.StockCurrentPrice)
                                    {
                                        if (ReservationTimer.Enabled)
                                        {
                                            MessageBox.Show("이미 예약이 걸려있습니다. 다시입력해주세요.", "Reservation Error", MessageBoxButtons.OK);
                                            reservation = true;
                                        }
                                        else
                                        {
                                            player.TronCount -= SellQuantityCoin; //사용자 트론갯수 감소
                                            reSellLabel.Text = Tron.StockName + "코인을 " + rePrice + "KRW에 " + reQuantity + "개 매도 진행중";
                                            reservation = true;
                                        }
                                    }
                                    else
                                    {
                                        player.TronCount -= SellQuantityCoin; //사용자 트론갯수 감소
                                        player.CurrentCapital += SellQuantityCoin * SellPrice; //지갑에 돈 추가
                                        Tron.Quantity += SellQuantityCoin;
                                        Tron.SellStock(SellQuantityCoin);
                                        reservation = false;
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    if (SellPrice > Eos.StockCurrentPrice)
                                    {
                                        if (ReservationTimer.Enabled)
                                        {
                                            MessageBox.Show("이미 예약이 걸려있습니다. 다시입력해주세요.", "Reservation Error", MessageBoxButtons.OK);
                                            reservation = true;
                                        }
                                        else
                                        {
                                            player.EosCount -= SellQuantityCoin;
                                            reSellLabel.Text = Eos.StockName + "코인을 " + rePrice + "KRW에 " + reQuantity + "개 매도 진행중";
                                            reservation = true;
                                        }
                                    }
                                    else
                                    {
                                        player.EosCount -= SellQuantityCoin; //사용자 이오스갯수 감소
                                        player.CurrentCapital += SellQuantityCoin * SellPrice; //지갑에 돈 추가
                                        Eos.Quantity += SellQuantityCoin;
                                        Eos.SellStock(SellQuantityCoin);
                                        reservation = false;
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    if (SellPrice > Ada.StockCurrentPrice)
                                    {
                                        if (ReservationTimer.Enabled)
                                        {
                                            MessageBox.Show("이미 예약이 걸려있습니다. 다시입력해주세요.", "Reservation Error", MessageBoxButtons.OK);
                                            reservation = true;
                                        }
                                        else
                                        {
                                            player.AdaCount -= SellQuantityCoin;
                                            reSellLabel.Text = Ada.StockName + "코인을 " + rePrice + "KRW에 " + reQuantity + "개 매도 진행중";
                                            reservation = true;
                                        }
                                    }
                                    else
                                    {
                                        player.AdaCount -= SellQuantityCoin; //사용자 에이다갯수 감소
                                        player.CurrentCapital += SellQuantityCoin * SellPrice; //지갑에 돈 추가
                                        Ada.Quantity += SellQuantityCoin;
                                        Ada.SellStock(SellQuantityCoin);
                                        reservation = false;
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    if (SellPrice > QTum.StockCurrentPrice)
                                    {
                                        if (ReservationTimer.Enabled)
                                        {
                                            MessageBox.Show("이미 예약이 걸려있습니다. 다시입력해주세요.", "Reservation Error", MessageBoxButtons.OK);
                                            reservation = true;
                                        }
                                        else
                                        {
                                            player.QtumCount -= SellQuantityCoin;
                                            reSellLabel.Text = QTum.StockName + "코인을 " + rePrice + "KRW에 " + reQuantity + "개 매도 진행중";
                                            reservation = true;
                                        }
                                    }
                                    else
                                    {
                                        player.QtumCount -= SellQuantityCoin; //사용자 퀀텀갯수 감소
                                        player.CurrentCapital += SellQuantityCoin * SellPrice; //지갑에 돈 추가
                                        QTum.Quantity += SellQuantityCoin;
                                        QTum.SellStock(SellQuantityCoin);
                                        reservation = false;
                                    }
                                    break;
                                }
                            default: { break; }
                        }
                        if (!reservation)
                        {
                            MessageBox.Show(resultmessage, caption, MessageBoxButtons.OK);
                        }
                        else if(reservation && ReservationTimer.Enabled.Equals(false))
                        {
                            ReservationTimer.Enabled = true;
                            MessageBox.Show(SellPrice + "KRW에 판매예약 되었습니다. ", "예약", MessageBoxButtons.OK);
                        }
                        SellQuantityBox.Text = "";
                        SellAllCheck.Checked = false;
                        radioNowPrice1.Checked = false;
                        SellPriceBox.Text = "";
                    }
                    else if (result.Equals(DialogResult.No))
                    {
                        MessageBox.Show("취소되었습니다.", caption, MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void BuyButton_Click(object sender, EventArgs e) // 주식 구매버튼
        {
            if (BuyQuantityBox.Text == "" || BuyPriceBox.Text == "")
            {
                MessageBox.Show("가격과 수량을 먼저 입력하세요", "Error", MessageBoxButtons.OK);
                BuyQuantityBox.Text = "";
                BuyPriceBox.Text = "";
            }
            else
            {
                if (BuyQuantityBox.Text.Equals("0"))
                {
                    MessageBox.Show("수량이 0 개입니다. 다시 시도해주세요", "Error", MessageBoxButtons.OK);
                    BuyQuantityBox.Text = "";
                    BuyAllCheck.Checked = false;
                    radioNowPrice2.Checked = false;
                    BuyPriceBox.Text = "";
                }
                else
                {
                    MessageBoxButtons button = MessageBoxButtons.YesNo;
                    string checkmessage = BuyStock.SelectedItem + "을 " + BuyQuantityBox.Text + "개 구매하시겠습니까?";
                    string caption = "알림";


                    DialogResult result = MessageBox.Show(checkmessage, "판매확인", button);

                    if (result.Equals(DialogResult.Yes)) //판매 확인버튼을 누를시
                    {
                        int selectedIndex = BuyStock.SelectedIndex;
                        int BuyQuantityCoin = int.Parse(BuyQuantityBox.Text);
                        int BuyPrice = int.Parse(BuyPriceBox.Text);

                        if (player.CurrentCapital < BuyQuantityCoin * BuyPrice)
                        {
                            MessageBox.Show(player.PlayerId + "님의 잔고보다 지출금액이 큽니다 다시 시도해주세요", "Error", MessageBoxButtons.OK);
                        }
                        else
                        {
                            reBuyQuantity = BuyQuantityCoin;
                            reBuyPrice = BuyPrice;
                            reBuyint = selectedIndex;

                            string resultmessage = player.PlayerId + "님의 지갑에" + BuyQuantityCoin * BuyPrice + "만큼 돈이 나갔습니다.";

                            if (checkCoinQuantity(selectedIndex) < 0)
                            {
                                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK);
                                BuyQuantityBox.Text = "";
                                BuyAllCheck.Checked = false;
                                radioNowPrice2.Checked = false;
                                BuyPriceBox.Text = "";
                            }
                            else
                            {
                                switch (selectedIndex)
                                {
                                    case 0:
                                        {
                                            if (BuyPrice < Ripple.StockCurrentPrice)
                                            {
                                                if (ReBuyTimer.Enabled)
                                                {
                                                    MessageBox.Show("이미 예약이 걸려있습니다. 다시입력해주세요.", "Reservation Error", MessageBoxButtons.OK);
                                                    buyReservation = true;
                                                }
                                                else
                                                {
                                                    player.CurrentCapital -= BuyQuantityCoin * BuyPrice; //지갑에 돈 감소
                                                    reBuyLabel.Text = Ripple.StockName + "코인을 " + reBuyPrice + "KRW에 " + reBuyQuantity + "개 매수 진행중";
                                                    buyReservation = true;
                                                }

                                            }
                                            else
                                            {
                                                player.RipCount += BuyQuantityCoin; //사용자 리플갯수 증가
                                                player.CurrentCapital -= BuyQuantityCoin * BuyPrice; //지갑에 돈 감소
                                                Ripple.Quantity -= BuyQuantityCoin;
                                                Ripple.BuyStock(BuyQuantityCoin);
                                                buyReservation = false;
                                            }
                                            break;
                                        }
                                    case 1:
                                        {
                                            if (BuyPrice < Tron.StockCurrentPrice)
                                            {
                                                if (ReBuyTimer.Enabled)
                                                {
                                                    MessageBox.Show("이미 예약이 걸려있습니다. 다시입력해주세요.", "Reservation Error", MessageBoxButtons.OK);
                                                    buyReservation = true;
                                                }
                                                else
                                                {
                                                    player.CurrentCapital -= BuyQuantityCoin * BuyPrice; //지갑에 돈 감소
                                                    reBuyLabel.Text = Tron.StockName + "코인을 " + reBuyPrice + "KRW에 " + reBuyQuantity + "개 매수 진행중";
                                                    buyReservation = true;
                                                }
                                            }
                                            else
                                            {
                                                player.TronCount += BuyQuantityCoin; //사용자 트론갯수 증가
                                                player.CurrentCapital -= BuyQuantityCoin * BuyPrice; //지갑에 돈 감소
                                                Tron.Quantity -= BuyQuantityCoin;
                                                Tron.BuyStock(BuyQuantityCoin);
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            if (BuyPrice < Eos.StockCurrentPrice)
                                            {
                                                if (ReBuyTimer.Enabled)
                                                {
                                                    MessageBox.Show("이미 예약이 걸려있습니다. 다시입력해주세요.", "Reservation Error", MessageBoxButtons.OK);
                                                    buyReservation = true;
                                                }
                                                else
                                                {
                                                    player.CurrentCapital -= BuyQuantityCoin * BuyPrice; //지갑에 돈 감소
                                                    reBuyLabel.Text = Eos.StockName + "코인을 " + reBuyPrice + "KRW에 " + reBuyQuantity + "개 매수 진행중";
                                                    buyReservation = true;
                                                }
                                            }
                                            else
                                            {
                                                player.EosCount += BuyQuantityCoin; //사용자 이오스갯수 증가
                                                player.CurrentCapital -= BuyQuantityCoin * BuyPrice; //지갑에 돈 감소
                                                Eos.Quantity -= BuyQuantityCoin;
                                                Eos.BuyStock(BuyQuantityCoin);
                                                buyReservation = false;
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            if (BuyPrice < Ada.StockCurrentPrice)
                                            {
                                                if (ReBuyTimer.Enabled)
                                                {
                                                    MessageBox.Show("이미 예약이 걸려있습니다. 다시입력해주세요.", "Reservation Error", MessageBoxButtons.OK);
                                                    buyReservation = true;
                                                }
                                                else
                                                {
                                                    player.CurrentCapital -= BuyQuantityCoin * BuyPrice; //지갑에 돈 감소
                                                    reBuyLabel.Text = Ada.StockName + "코인을 " + reBuyPrice + "KRW에 " + reBuyQuantity + "개 매수 진행중";
                                                    buyReservation = true;
                                                }
                                            }
                                            else
                                            {
                                                player.AdaCount += BuyQuantityCoin; //사용자 에이다갯수 증가
                                                player.CurrentCapital -= BuyQuantityCoin * BuyPrice; //지갑에 돈 감소
                                                Ada.Quantity -= BuyQuantityCoin;
                                                Ada.BuyStock(BuyQuantityCoin);
                                                buyReservation = false;
                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            if (BuyPrice < QTum.StockCurrentPrice)
                                            {
                                                if (ReBuyTimer.Enabled)
                                                {
                                                    MessageBox.Show("이미 예약이 걸려있습니다. 다시입력해주세요.", "Reservation Error", MessageBoxButtons.OK);
                                                    buyReservation = true;
                                                }
                                                else
                                                {
                                                    player.CurrentCapital -= BuyQuantityCoin * BuyPrice; //지갑에 돈 감소
                                                    reBuyLabel.Text = QTum.StockName + "코인을 " + reBuyPrice + "KRW에 " + reBuyQuantity + "개 매수 진행중";
                                                    buyReservation = true;
                                                }
                                            }
                                            else
                                            {
                                                player.QtumCount += BuyQuantityCoin; //사용자 퀀텀갯수 증가
                                                player.CurrentCapital -= BuyQuantityCoin * BuyPrice; //지갑에 돈 감소
                                                QTum.Quantity -= BuyQuantityCoin;
                                                QTum.BuyStock(BuyQuantityCoin);
                                                buyReservation = false;
                                            }
                                            break;
                                        }
                                    default: { break; }
                                }
                                if (!buyReservation)
                                {
                                    MessageBox.Show(resultmessage, caption, MessageBoxButtons.OK);
                                }
                                else if (buyReservation && ReBuyTimer.Enabled.Equals(false))
                                {
                                    ReBuyTimer.Enabled = true;
                                    MessageBox.Show(BuyPrice + "KRW에 구매예약 되었습니다. ", "예약", MessageBoxButtons.OK);
                                }
                                BuyQuantityBox.Text = "";
                                BuyAllCheck.Checked = false;
                                radioNowPrice2.Checked = false;
                                BuyPriceBox.Text = "";
                            }
                        }
                    }
                    else if (result.Equals(DialogResult.No))
                    {
                        MessageBox.Show("취소되었습니다.", caption, MessageBoxButtons.OK);
                    }
                }
            }
        }

        public int checkCoinQuantity(int i)
        {
            switch (i)
            {
                case 0: { return Ripple.Quantity; }
                case 1: { return Tron.Quantity; }
                case 2: { return Eos.Quantity; }
                case 3: { return Ada.Quantity; }
                case 4: { return QTum.Quantity; }
                default:
                    return 0;
            }
        } // 코인의 현재수량 반환

        public void Sell_Reservation(int index)
        {
            
            switch (index)
            {
                case 0:
                    {
                        if (Ripple.StockCurrentPrice > rePrice)
                        {
                            player.CurrentCapital += reQuantity * rePrice; //지갑에 돈 추가
                            Ripple.Quantity += reQuantity;
                            Ripple.SellStock(reQuantity);
                            ReservationTimer.Enabled = false;
                            reSellLabel.Text = "매도 완료";
                            MessageBox.Show("판매예약하였던" + Ripple.StockName + "코인 " + reQuantity + "개가 판매되었습니다", "ReSell", MessageBoxButtons.OK);
                        }
                        break;
                    }
                case 1:
                    {
                        if (Tron.StockCurrentPrice > rePrice)
                        {
                            player.CurrentCapital += reQuantity * rePrice; //지갑에 돈 추가
                            Tron.Quantity += reQuantity;
                            Tron.SellStock(reQuantity);
                            ReservationTimer.Enabled = false;
                            reSellLabel.Text = "매도 완료";
                            MessageBox.Show("판매예약하였던" + Tron.StockName + "코인 " + reQuantity + "개가 판매되었습니다", "ReSell", MessageBoxButtons.OK);
                        }
                        break;
                    }
                case 2:
                    {
                        if (Eos.StockCurrentPrice > rePrice)
                        {
                            player.CurrentCapital += reQuantity * rePrice; //지갑에 돈 추가
                            Eos.Quantity += reQuantity;
                            Eos.SellStock(reQuantity);
                            ReservationTimer.Enabled = false;
                            reSellLabel.Text = "매도 완료";
                            MessageBox.Show("판매예약하였던" + Eos.StockName + "코인 " + reQuantity + "개가 판매되었습니다", "ReSell", MessageBoxButtons.OK);

                        }
                        break;
                    }
                case 3:
                    {
                        if (Ada.StockCurrentPrice > rePrice)
                        {
                            player.CurrentCapital += reQuantity * rePrice; //지갑에 돈 추가
                            Ada.Quantity += reQuantity;
                            Ada.SellStock(reQuantity);
                            ReservationTimer.Enabled = false;
                            reSellLabel.Text = "매도 완료";
                            MessageBox.Show("판매예약하였던" + Ada.StockName + "코인 " + reQuantity + "개가 판매되었습니다", "ReSell", MessageBoxButtons.OK);

                        }
                        break;
                    }
                case 4:
                    {
                        if (QTum.StockCurrentPrice > rePrice)
                        {
                            player.CurrentCapital += reQuantity * rePrice; //지갑에 돈 추가
                            QTum.Quantity += reQuantity;
                            QTum.SellStock(reQuantity);
                            ReservationTimer.Enabled = false;
                            reSellLabel.Text = "매도 완료";
                            MessageBox.Show("판매예약하였던" + QTum.StockName + "코인 " + reQuantity + "개가 판매되었습니다", "ReSell", MessageBoxButtons.OK);
                        }
                        break;
                    }
                default:
                    break;
            }
           
        }//판매 예약 로직

        public void Buy_Reservation(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        if (Ripple.StockCurrentPrice < reBuyPrice)
                        {
                            player.RipCount += reBuyQuantity; //사용자 리플갯수 증가
                            Ripple.Quantity -= reBuyQuantity;
                            Ripple.BuyStock(reBuyQuantity);
                            ReBuyTimer.Enabled = false;
                            reBuyLabel.Text = "매수 완료";
                            MessageBox.Show("구매예약하였던" + Ripple.StockName + "코인 " + reQuantity + "개가 판매되었습니다", "ReSell", MessageBoxButtons.OK);
                        }
                        break;
                    }
                case 1:
                    {
                        if (Tron.StockCurrentPrice < reBuyPrice)
                        {
                            player.TronCount += reBuyQuantity; //사용자 리플갯수 증가
                            Tron.Quantity -= reBuyQuantity;
                            Tron.BuyStock(reBuyQuantity);
                            ReBuyTimer.Enabled = false;
                            reBuyLabel.Text = "매수 완료";
                            MessageBox.Show("구매예약하였던" + Tron.StockName + "코인 " + reQuantity + "개가 판매되었습니다", "ReSell", MessageBoxButtons.OK);
                        }
                        break;
                    }
                case 2:
                    {
                        if (Eos.StockCurrentPrice < reBuyPrice)
                        {
                            player.EosCount += reBuyQuantity; //사용자 리플갯수 증가
                            Eos.Quantity -= reBuyQuantity;
                            Eos.BuyStock(reBuyQuantity);
                            ReBuyTimer.Enabled = false;
                            reBuyLabel.Text = "매수 완료";
                            MessageBox.Show("구매예약하였던" + Eos.StockName + "코인 " + reQuantity + "개가 판매되었습니다", "ReSell", MessageBoxButtons.OK);
                        }
                        break;
                    }
                case 3:
                    {
                        if (Ada.StockCurrentPrice < reBuyPrice)
                        {
                            player.AdaCount += reBuyQuantity; //사용자 리플갯수 증가
                            Ada.Quantity -= reBuyQuantity;
                            Ada.BuyStock(reBuyQuantity);
                            ReBuyTimer.Enabled = false;
                            reBuyLabel.Text = "매수 완료";
                            MessageBox.Show("구매예약하였던" + Ada.StockName + "코인 " + reQuantity + "개가 판매되었습니다", "ReSell", MessageBoxButtons.OK);
                        }
                        break;
                    }
                case 4:
                    {
                        if (QTum.StockCurrentPrice < reBuyPrice)
                        {
                            player.QtumCount += reBuyQuantity; //사용자 리플갯수 증가
                            QTum.Quantity -= reBuyQuantity;
                            QTum.BuyStock(reBuyQuantity);
                            ReBuyTimer.Enabled = false;
                            reBuyLabel.Text = "매수 완료";
                            MessageBox.Show("구매예약하였던" + QTum.StockName + "코인 " + reQuantity + "개가 판매되었습니다", "ReSell", MessageBoxButtons.OK);
                        }
                        break;
                    }
                default:
                    break;
            }
        } //구매 예약 로직

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("금액을 입력해주세요", "Error", MessageBoxButtons.OK);
            }
            else
            {
                int addmoney = int.Parse(textBox1.Text);
                DialogResult result = MessageBox.Show(addmoney + "만큼 금액을 입금하시겠습니까?", "입금확인", MessageBoxButtons.YesNo);       
                if(result.Equals(DialogResult.Yes))
                {
                    player.InitialCapital += addmoney;
                    player.CurrentCapital += addmoney;
                    MessageBox.Show("입금이 완료되었습니다", "Cancel", MessageBoxButtons.OK);
                    textBox1.Text = "";
                }
                else if (result.Equals(DialogResult.No))
                {
                    MessageBox.Show("입금이 취소되었습니다", "Cancel", MessageBoxButtons.OK);
                }
            }
        } //입금버튼 클릭시

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("금액을 입력해주세요", "Error", MessageBoxButtons.OK);
            }
            else
            {
                int addmoney = int.Parse(textBox1.Text);
                DialogResult result = MessageBox.Show(addmoney + "KRW 만큼 금액을 출금하시겠습니까?", "입금확인", MessageBoxButtons.YesNo);
                if (result.Equals(DialogResult.Yes))
                {
                    player.InitialCapital -= addmoney;
                    player.CurrentCapital -= addmoney;
                    MessageBox.Show("출금이 완료되었습니다", "Cancel", MessageBoxButtons.OK);
                    textBox1.Text = "";
                }
                else if (result.Equals(DialogResult.No))
                {
                    MessageBox.Show("출금이 취소되었습니다", "Cancel", MessageBoxButtons.OK);
                }
            }
        } //출금버튼 클릭시

        private void textBox1_Leave(object sender, EventArgs e)
        {
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                int ascii = textBox1.Text[i];
                if (ascii < 48 || ascii > 57) // 아스키코드 이용 , 숫자만입력받았는지 확인
                {
                    MessageBox.Show("숫자만 입력하세요", "Error", MessageBoxButtons.OK);
                    textBox1.Text = "";
                    i = textBox1.Text.Length;
                }
                else { }
            }
        } // 금액입력 창에 숫자만입력

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Data를 저장후 종료하시겠습니까?", "Save", MessageBoxButtons.YesNo);
            if (result.Equals(DialogResult.Yes))
            {
                //----------------------------------------------DB 저장 구문-----------------------------------------------------
                string sql = "UPDATE USERINFO SET StartMoney = @StartMoney, EndMoney = @EndMoney ,Rip= @Rip, Tron = @Tron, Eos = @Eos, Ada = @Ada, QTum = @QTum WHERE Id=@Id";
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\giyeo\OneDrive\문서\logindata.mdf;Integrated Security=True;Connect Timeout=30");
                SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                
                sda.UpdateCommand = new SqlCommand(sql, con);
                sda.UpdateCommand.Parameters.Add("@Id", SqlDbType.VarChar).Value = player.PlayerId;
                sda.UpdateCommand.Parameters.Add("@StartMoney", SqlDbType.Int).Value = player.InitialCapital;
                sda.UpdateCommand.Parameters.Add("@EndMoney", SqlDbType.Int).Value = player.CurrentCapital;
                sda.UpdateCommand.Parameters.Add("@Rip", SqlDbType.Int).Value = player.RipCount;
                sda.UpdateCommand.Parameters.Add("@Tron", SqlDbType.Int).Value = player.TronCount;
                sda.UpdateCommand.Parameters.Add("@Eos", SqlDbType.Int).Value = player.EosCount;
                sda.UpdateCommand.Parameters.Add("@Ada", SqlDbType.Int).Value = player.AdaCount;
                sda.UpdateCommand.Parameters.Add("@QTum", SqlDbType.Int).Value = player.QtumCount;

                con.Open();
                int i = sda.UpdateCommand.ExecuteNonQuery();
                con.Close();
                //----------------------------------------------DB 저장 구문끝-----------------------------------------------------
                if (i == 1) // 데이터 저장 확인
                {

                    MessageBox.Show("저장이 완료되었습니다", "End", MessageBoxButtons.OK);
                    main.Run = false;
                    this.Close();
                }else
                {
                    MessageBox.Show("저장에 실패하였습니다. 다시시도해주세요", "End", MessageBoxButtons.OK);
                }
            }
            else if (result.Equals(DialogResult.No))
            {
                MessageBox.Show("취소하셨습니다.", "Cancel", MessageBoxButtons.OK);
            }
        } //데이터베이스를 통한 저장

        private void ReservationTimer_Tick(object sender, EventArgs e) //판매예약 타이머
        {
            Sell_Reservation(reSellint);
        }

        private void ReBuyTimer_Tick(object sender, EventArgs e) //구매예약 타이머
        {
            Buy_Reservation(reBuyint);
        }

        private void sellReButton_Click(object sender, EventArgs e) //판매예약 취소 버튼
        {
            if (ReservationTimer.Enabled)
            {
                switch (reSellint)
                {
                    case 0: { player.RipCount += reQuantity; break; }
                    case 1: { player.TronCount += reQuantity; break; }
                    case 2: { player.EosCount += reQuantity; break; }
                    case 3: { player.AdaCount += reQuantity; break; }
                    case 4: { player.QtumCount += reQuantity; break; }
                    default:
                        break;
                }

                reservation = false;
                ReservationTimer.Enabled = false;
                reSellLabel.Text = "매도 예약 취소";
                MessageBox.Show("판매예약이 취소되었습니다.", "ReSell", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("판매예약 내역이 없습니다.", "ReSell", MessageBoxButtons.OK);
            }

        }

        private void buyReButton_Click(object sender, EventArgs e) //구매 예약 취소 버튼
        {
            if (ReBuyTimer.Enabled)
            {
                player.CurrentCapital += reBuyQuantity * reBuyPrice;
                buyReservation = false;
                ReBuyTimer.Enabled = false;
                reBuyLabel.Text = "매수 예약 취소";
                MessageBox.Show("구매예약이 취소되었습니다.", "ReBuy", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("구매예약 내역이 없습니다.", "ReBuy", MessageBoxButtons.OK);
            }
        }

       
    }



}
