using System;

namespace Stock_Programming
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.StockChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.StockGroup = new System.Windows.Forms.GroupBox();
            this.sellReButton = new System.Windows.Forms.Button();
            this.buyReButton = new System.Windows.Forms.Button();
            this.SellBox = new System.Windows.Forms.GroupBox();
            this.SellAllCheck = new System.Windows.Forms.CheckBox();
            this.radioNowPrice1 = new System.Windows.Forms.RadioButton();
            this.SellButton = new System.Windows.Forms.Button();
            this.sumLabelSell = new System.Windows.Forms.Label();
            this.SellStock = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SellPriceBox = new System.Windows.Forms.TextBox();
            this.SellQuantityBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.BuyBox = new System.Windows.Forms.GroupBox();
            this.BuyAllCheck = new System.Windows.Forms.CheckBox();
            this.radioNowPrice2 = new System.Windows.Forms.RadioButton();
            this.BuyButton = new System.Windows.Forms.Button();
            this.sumLabelBuy = new System.Windows.Forms.Label();
            this.BuyStock = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BuyPriceBox = new System.Windows.Forms.TextBox();
            this.BuyQuantityBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.playerBox = new System.Windows.Forms.GroupBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.pNowLabel = new System.Windows.Forms.Label();
            this.pStartLabel = new System.Windows.Forms.Label();
            this.pIdLabel = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.qtumCountLabel = new System.Windows.Forms.Label();
            this.adaCountLabel = new System.Windows.Forms.Label();
            this.eosCountLabel = new System.Windows.Forms.Label();
            this.tronCountLabel = new System.Windows.Forms.Label();
            this.ripCountLabel = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.pVarLabel = new System.Windows.Forms.Label();
            this.GridView = new System.Windows.Forms.DataGridView();
            this.codeData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tradeData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.buyOrSellTimer = new System.Windows.Forms.Timer(this.components);
            this.UpdateBenefit = new System.Windows.Forms.Timer(this.components);
            this.charactorSell = new System.Windows.Forms.Timer(this.components);
            this.charactorBuy = new System.Windows.Forms.Timer(this.components);
            this.ReservationTimer = new System.Windows.Forms.Timer(this.components);
            this.ReBuyTimer = new System.Windows.Forms.Timer(this.components);
            this.reBuyLabel = new System.Windows.Forms.Label();
            this.reSellLabel = new System.Windows.Forms.Label();
            this.picture = new System.Windows.Forms.PictureBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.StockChart)).BeginInit();
            this.StockGroup.SuspendLayout();
            this.SellBox.SuspendLayout();
            this.BuyBox.SuspendLayout();
            this.playerBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stock Vital Invest Programming";
            // 
            // StockChart
            // 
            chartArea2.Name = "ChartArea1";
            this.StockChart.ChartAreas.Add(chartArea2);
            this.StockChart.Dock = System.Windows.Forms.DockStyle.Top;
            legend2.Name = "Legend1";
            this.StockChart.Legends.Add(legend2);
            this.StockChart.Location = new System.Drawing.Point(3, 21);
            this.StockChart.Name = "StockChart";
            this.StockChart.Size = new System.Drawing.Size(598, 418);
            this.StockChart.TabIndex = 1;
            this.StockChart.Text = "chart1";
            // 
            // StockGroup
            // 
            this.StockGroup.Controls.Add(this.sellReButton);
            this.StockGroup.Controls.Add(this.buyReButton);
            this.StockGroup.Controls.Add(this.SellBox);
            this.StockGroup.Controls.Add(this.StockChart);
            this.StockGroup.Controls.Add(this.BuyBox);
            this.StockGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.StockGroup.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.StockGroup.Location = new System.Drawing.Point(0, 30);
            this.StockGroup.Name = "StockGroup";
            this.StockGroup.Size = new System.Drawing.Size(604, 732);
            this.StockGroup.TabIndex = 2;
            this.StockGroup.TabStop = false;
            this.StockGroup.Text = "Stock Exchange";
            // 
            // sellReButton
            // 
            this.sellReButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.sellReButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sellReButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sellReButton.Location = new System.Drawing.Point(346, 445);
            this.sellReButton.Name = "sellReButton";
            this.sellReButton.Size = new System.Drawing.Size(117, 38);
            this.sellReButton.TabIndex = 11;
            this.sellReButton.Text = "매도예약취소";
            this.sellReButton.UseVisualStyleBackColor = false;
            this.sellReButton.Click += new System.EventHandler(this.sellReButton_Click);
            // 
            // buyReButton
            // 
            this.buyReButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buyReButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buyReButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buyReButton.Location = new System.Drawing.Point(478, 445);
            this.buyReButton.Name = "buyReButton";
            this.buyReButton.Size = new System.Drawing.Size(117, 38);
            this.buyReButton.TabIndex = 16;
            this.buyReButton.Text = "매수예약취소";
            this.buyReButton.UseVisualStyleBackColor = false;
            this.buyReButton.Click += new System.EventHandler(this.buyReButton_Click);
            // 
            // SellBox
            // 
            this.SellBox.Controls.Add(this.SellAllCheck);
            this.SellBox.Controls.Add(this.radioNowPrice1);
            this.SellBox.Controls.Add(this.SellButton);
            this.SellBox.Controls.Add(this.sumLabelSell);
            this.SellBox.Controls.Add(this.SellStock);
            this.SellBox.Controls.Add(this.label7);
            this.SellBox.Controls.Add(this.label8);
            this.SellBox.Controls.Add(this.label9);
            this.SellBox.Controls.Add(this.SellPriceBox);
            this.SellBox.Controls.Add(this.SellQuantityBox);
            this.SellBox.Controls.Add(this.label10);
            this.SellBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SellBox.Location = new System.Drawing.Point(3, 479);
            this.SellBox.Name = "SellBox";
            this.SellBox.Size = new System.Drawing.Size(598, 125);
            this.SellBox.TabIndex = 4;
            this.SellBox.TabStop = false;
            this.SellBox.Text = "Stock Sell";
            // 
            // SellAllCheck
            // 
            this.SellAllCheck.AutoSize = true;
            this.SellAllCheck.Location = new System.Drawing.Point(368, 43);
            this.SellAllCheck.Name = "SellAllCheck";
            this.SellAllCheck.Size = new System.Drawing.Size(59, 21);
            this.SellAllCheck.TabIndex = 14;
            this.SellAllCheck.Text = "100%";
            this.SellAllCheck.UseVisualStyleBackColor = true;
            this.SellAllCheck.CheckedChanged += new System.EventHandler(this.SellAllCheck_CheckedChanged);
            // 
            // radioNowPrice1
            // 
            this.radioNowPrice1.AutoSize = true;
            this.radioNowPrice1.Location = new System.Drawing.Point(255, 77);
            this.radioNowPrice1.Name = "radioNowPrice1";
            this.radioNowPrice1.Size = new System.Drawing.Size(65, 21);
            this.radioNowPrice1.TabIndex = 13;
            this.radioNowPrice1.TabStop = true;
            this.radioNowPrice1.Text = "시장가";
            this.radioNowPrice1.UseVisualStyleBackColor = true;
            this.radioNowPrice1.CheckedChanged += new System.EventHandler(this.radioNowPrice1_CheckedChanged);
            // 
            // SellButton
            // 
            this.SellButton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.SellButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SellButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SellButton.Location = new System.Drawing.Point(478, 20);
            this.SellButton.Name = "SellButton";
            this.SellButton.Size = new System.Drawing.Size(114, 60);
            this.SellButton.TabIndex = 10;
            this.SellButton.Text = "매도";
            this.SellButton.UseVisualStyleBackColor = false;
            this.SellButton.Click += new System.EventHandler(this.SellButton_Click);
            // 
            // sumLabelSell
            // 
            this.sumLabelSell.AutoSize = true;
            this.sumLabelSell.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sumLabelSell.Location = new System.Drawing.Point(365, 83);
            this.sumLabelSell.Name = "sumLabelSell";
            this.sumLabelSell.Size = new System.Drawing.Size(0, 15);
            this.sumLabelSell.TabIndex = 12;
            // 
            // SellStock
            // 
            this.SellStock.BackColor = System.Drawing.SystemColors.Info;
            this.SellStock.FormattingEnabled = true;
            this.SellStock.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SellStock.Location = new System.Drawing.Point(93, 37);
            this.SellStock.Name = "SellStock";
            this.SellStock.Size = new System.Drawing.Size(121, 25);
            this.SellStock.TabIndex = 2;
            this.SellStock.TextChanged += new System.EventHandler(this.SellStock_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(203, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "KRW";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(9, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 23);
            this.label8.TabIndex = 3;
            this.label8.Text = "주식선택";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(9, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 23);
            this.label9.TabIndex = 10;
            this.label9.Text = "주문가격";
            // 
            // SellPriceBox
            // 
            this.SellPriceBox.Location = new System.Drawing.Point(93, 73);
            this.SellPriceBox.Name = "SellPriceBox";
            this.SellPriceBox.Size = new System.Drawing.Size(104, 25);
            this.SellPriceBox.TabIndex = 9;
            this.SellPriceBox.Leave += new System.EventHandler(this.SellPriceBox_Leave);
            // 
            // SellQuantityBox
            // 
            this.SellQuantityBox.Location = new System.Drawing.Point(288, 37);
            this.SellQuantityBox.Name = "SellQuantityBox";
            this.SellQuantityBox.Size = new System.Drawing.Size(74, 25);
            this.SellQuantityBox.TabIndex = 6;
            this.SellQuantityBox.Leave += new System.EventHandler(this.SellQuantityBox_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(238, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 23);
            this.label10.TabIndex = 7;
            this.label10.Text = "수량";
            // 
            // BuyBox
            // 
            this.BuyBox.Controls.Add(this.BuyAllCheck);
            this.BuyBox.Controls.Add(this.radioNowPrice2);
            this.BuyBox.Controls.Add(this.BuyButton);
            this.BuyBox.Controls.Add(this.sumLabelBuy);
            this.BuyBox.Controls.Add(this.BuyStock);
            this.BuyBox.Controls.Add(this.label5);
            this.BuyBox.Controls.Add(this.label2);
            this.BuyBox.Controls.Add(this.label4);
            this.BuyBox.Controls.Add(this.BuyPriceBox);
            this.BuyBox.Controls.Add(this.BuyQuantityBox);
            this.BuyBox.Controls.Add(this.label3);
            this.BuyBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BuyBox.Location = new System.Drawing.Point(3, 604);
            this.BuyBox.Name = "BuyBox";
            this.BuyBox.Size = new System.Drawing.Size(598, 125);
            this.BuyBox.TabIndex = 3;
            this.BuyBox.TabStop = false;
            this.BuyBox.Text = "Stock Buy";
            // 
            // BuyAllCheck
            // 
            this.BuyAllCheck.AutoSize = true;
            this.BuyAllCheck.Location = new System.Drawing.Point(368, 43);
            this.BuyAllCheck.Name = "BuyAllCheck";
            this.BuyAllCheck.Size = new System.Drawing.Size(59, 21);
            this.BuyAllCheck.TabIndex = 15;
            this.BuyAllCheck.Text = "100%";
            this.BuyAllCheck.UseVisualStyleBackColor = true;
            this.BuyAllCheck.CheckedChanged += new System.EventHandler(this.BuyAllCheck_CheckedChanged);
            // 
            // radioNowPrice2
            // 
            this.radioNowPrice2.AutoSize = true;
            this.radioNowPrice2.Location = new System.Drawing.Point(255, 77);
            this.radioNowPrice2.Name = "radioNowPrice2";
            this.radioNowPrice2.Size = new System.Drawing.Size(65, 21);
            this.radioNowPrice2.TabIndex = 13;
            this.radioNowPrice2.TabStop = true;
            this.radioNowPrice2.Text = "시장가";
            this.radioNowPrice2.UseVisualStyleBackColor = true;
            this.radioNowPrice2.CheckedChanged += new System.EventHandler(this.radioNowPrice2_CheckedChanged);
            // 
            // BuyButton
            // 
            this.BuyButton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BuyButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuyButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BuyButton.Location = new System.Drawing.Point(478, 20);
            this.BuyButton.Name = "BuyButton";
            this.BuyButton.Size = new System.Drawing.Size(114, 60);
            this.BuyButton.TabIndex = 10;
            this.BuyButton.Text = "매수";
            this.BuyButton.UseVisualStyleBackColor = false;
            this.BuyButton.Click += new System.EventHandler(this.BuyButton_Click);
            // 
            // sumLabelBuy
            // 
            this.sumLabelBuy.AutoSize = true;
            this.sumLabelBuy.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sumLabelBuy.Location = new System.Drawing.Point(365, 83);
            this.sumLabelBuy.Name = "sumLabelBuy";
            this.sumLabelBuy.Size = new System.Drawing.Size(182, 15);
            this.sumLabelBuy.TabIndex = 12;
            this.sumLabelBuy.Text = "(12주*3000KRW) = 36000KRW";
            // 
            // BuyStock
            // 
            this.BuyStock.BackColor = System.Drawing.SystemColors.Info;
            this.BuyStock.FormattingEnabled = true;
            this.BuyStock.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BuyStock.Location = new System.Drawing.Point(93, 37);
            this.BuyStock.Name = "BuyStock";
            this.BuyStock.Size = new System.Drawing.Size(121, 25);
            this.BuyStock.TabIndex = 2;
            this.BuyStock.TextChanged += new System.EventHandler(this.BuyStock_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "KRW";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(9, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "주식선택";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(9, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "주문가격";
            // 
            // BuyPriceBox
            // 
            this.BuyPriceBox.Location = new System.Drawing.Point(93, 73);
            this.BuyPriceBox.Name = "BuyPriceBox";
            this.BuyPriceBox.Size = new System.Drawing.Size(104, 25);
            this.BuyPriceBox.TabIndex = 9;
            this.BuyPriceBox.Leave += new System.EventHandler(this.BuyPriceBox_Leave);
            // 
            // BuyQuantityBox
            // 
            this.BuyQuantityBox.Location = new System.Drawing.Point(288, 37);
            this.BuyQuantityBox.Name = "BuyQuantityBox";
            this.BuyQuantityBox.Size = new System.Drawing.Size(74, 25);
            this.BuyQuantityBox.TabIndex = 6;
            this.BuyQuantityBox.Leave += new System.EventHandler(this.BuyQuantityBox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(238, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "수량";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(610, 453);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "매도 예약 품목 :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(610, 432);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 12);
            this.label13.TabIndex = 25;
            this.label13.Text = "매수 예약 품목 :";
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(610, 529);
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(400, 221);
            this.LogBox.TabIndex = 3;
            this.LogBox.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(610, 512);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "Log";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(610, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 15);
            this.label12.TabIndex = 6;
            this.label12.Text = "Stock Chart";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label20.Location = new System.Drawing.Point(18, 213);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 17);
            this.label20.TabIndex = 7;
            this.label20.Text = "금액 :";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(16, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 51);
            this.button1.TabIndex = 9;
            this.button1.Text = "입금하기";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(112, 250);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 51);
            this.button2.TabIndex = 10;
            this.button2.Text = "출금하기";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(66, 213);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 11;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label21.Location = new System.Drawing.Point(167, 217);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 17);
            this.label21.TabIndex = 12;
            this.label21.Text = " KRW";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label23.Location = new System.Drawing.Point(13, 77);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(90, 21);
            this.label23.TabIndex = 15;
            this.label23.Text = "소유 자금 :";
            // 
            // playerBox
            // 
            this.playerBox.Controls.Add(this.saveButton);
            this.playerBox.Controls.Add(this.pNowLabel);
            this.playerBox.Controls.Add(this.pStartLabel);
            this.playerBox.Controls.Add(this.pIdLabel);
            this.playerBox.Controls.Add(this.label27);
            this.playerBox.Controls.Add(this.label26);
            this.playerBox.Controls.Add(this.textBox1);
            this.playerBox.Controls.Add(this.button1);
            this.playerBox.Controls.Add(this.label20);
            this.playerBox.Controls.Add(this.groupBox1);
            this.playerBox.Controls.Add(this.button2);
            this.playerBox.Controls.Add(this.label23);
            this.playerBox.Controls.Add(this.label21);
            this.playerBox.Controls.Add(this.label25);
            this.playerBox.Controls.Add(this.pVarLabel);
            this.playerBox.Location = new System.Drawing.Point(1044, 51);
            this.playerBox.Name = "playerBox";
            this.playerBox.Size = new System.Drawing.Size(319, 322);
            this.playerBox.TabIndex = 16;
            this.playerBox.TabStop = false;
            this.playerBox.Text = "Giyeon Index";
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.ControlText;
            this.saveButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.saveButton.Location = new System.Drawing.Point(214, 203);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(98, 112);
            this.saveButton.TabIndex = 22;
            this.saveButton.Text = "저장후  종료";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // pNowLabel
            // 
            this.pNowLabel.AutoSize = true;
            this.pNowLabel.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pNowLabel.Location = new System.Drawing.Point(109, 77);
            this.pNowLabel.Name = "pNowLabel";
            this.pNowLabel.Size = new System.Drawing.Size(98, 21);
            this.pNowLabel.TabIndex = 22;
            this.pNowLabel.Text = "100000KRW";
            // 
            // pStartLabel
            // 
            this.pStartLabel.AutoSize = true;
            this.pStartLabel.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pStartLabel.Location = new System.Drawing.Point(109, 47);
            this.pStartLabel.Name = "pStartLabel";
            this.pStartLabel.Size = new System.Drawing.Size(17, 21);
            this.pStartLabel.TabIndex = 21;
            this.pStartLabel.Text = "-";
            // 
            // pIdLabel
            // 
            this.pIdLabel.AutoSize = true;
            this.pIdLabel.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pIdLabel.Location = new System.Drawing.Point(109, 17);
            this.pIdLabel.Name = "pIdLabel";
            this.pIdLabel.Size = new System.Drawing.Size(25, 21);
            this.pIdLabel.TabIndex = 20;
            this.pIdLabel.Text = "ID";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label27.Location = new System.Drawing.Point(29, 17);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(74, 21);
            this.label27.TabIndex = 18;
            this.label27.Text = "User ID :";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label26.Location = new System.Drawing.Point(13, 47);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(90, 21);
            this.label26.TabIndex = 17;
            this.label26.Text = "시작 자본 :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.qtumCountLabel);
            this.groupBox1.Controls.Add(this.adaCountLabel);
            this.groupBox1.Controls.Add(this.eosCountLabel);
            this.groupBox1.Controls.Add(this.tronCountLabel);
            this.groupBox1.Controls.Add(this.ripCountLabel);
            this.groupBox1.Controls.Add(this.label37);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Location = new System.Drawing.Point(6, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 89);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "보유 코인";
            // 
            // qtumCountLabel
            // 
            this.qtumCountLabel.AutoSize = true;
            this.qtumCountLabel.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.qtumCountLabel.Location = new System.Drawing.Point(206, 38);
            this.qtumCountLabel.Name = "qtumCountLabel";
            this.qtumCountLabel.Size = new System.Drawing.Size(28, 17);
            this.qtumCountLabel.TabIndex = 26;
            this.qtumCountLabel.Text = "0개";
            // 
            // adaCountLabel
            // 
            this.adaCountLabel.AutoSize = true;
            this.adaCountLabel.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.adaCountLabel.Location = new System.Drawing.Point(206, 17);
            this.adaCountLabel.Name = "adaCountLabel";
            this.adaCountLabel.Size = new System.Drawing.Size(28, 17);
            this.adaCountLabel.TabIndex = 25;
            this.adaCountLabel.Text = "0개";
            // 
            // eosCountLabel
            // 
            this.eosCountLabel.AutoSize = true;
            this.eosCountLabel.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.eosCountLabel.Location = new System.Drawing.Point(74, 58);
            this.eosCountLabel.Name = "eosCountLabel";
            this.eosCountLabel.Size = new System.Drawing.Size(28, 17);
            this.eosCountLabel.TabIndex = 24;
            this.eosCountLabel.Text = "0개";
            // 
            // tronCountLabel
            // 
            this.tronCountLabel.AutoSize = true;
            this.tronCountLabel.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tronCountLabel.Location = new System.Drawing.Point(74, 38);
            this.tronCountLabel.Name = "tronCountLabel";
            this.tronCountLabel.Size = new System.Drawing.Size(28, 17);
            this.tronCountLabel.TabIndex = 23;
            this.tronCountLabel.Text = "0개";
            // 
            // ripCountLabel
            // 
            this.ripCountLabel.AutoSize = true;
            this.ripCountLabel.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ripCountLabel.Location = new System.Drawing.Point(72, 17);
            this.ripCountLabel.Name = "ripCountLabel";
            this.ripCountLabel.Size = new System.Drawing.Size(28, 17);
            this.ripCountLabel.TabIndex = 22;
            this.ripCountLabel.Text = "0개";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label37.Location = new System.Drawing.Point(148, 38);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(52, 17);
            this.label37.TabIndex = 21;
            this.label37.Text = "QTum :";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label36.Location = new System.Drawing.Point(160, 17);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(40, 17);
            this.label36.TabIndex = 20;
            this.label36.Text = "Ada :";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label35.Location = new System.Drawing.Point(29, 58);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(37, 17);
            this.label35.TabIndex = 19;
            this.label35.Text = "Eos :";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label34.Location = new System.Drawing.Point(24, 38);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(44, 17);
            this.label34.TabIndex = 18;
            this.label34.Text = "Tron :";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label33.Location = new System.Drawing.Point(13, 17);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(53, 17);
            this.label33.TabIndex = 17;
            this.label33.Text = "Ripple :";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label25.Location = new System.Drawing.Point(29, 107);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(74, 21);
            this.label25.TabIndex = 16;
            this.label25.Text = "수익 률 :";
            this.label25.Visible = false;
            // 
            // pVarLabel
            // 
            this.pVarLabel.AutoSize = true;
            this.pVarLabel.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pVarLabel.Location = new System.Drawing.Point(109, 107);
            this.pVarLabel.Name = "pVarLabel";
            this.pVarLabel.Size = new System.Drawing.Size(32, 21);
            this.pVarLabel.TabIndex = 23;
            this.pVarLabel.Text = "0%";
            this.pVarLabel.Visible = false;
            // 
            // GridView
            // 
            this.GridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.GridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeData,
            this.priceData,
            this.upData,
            this.tradeData});
            this.GridView.Location = new System.Drawing.Point(612, 49);
            this.GridView.Name = "GridView";
            this.GridView.ReadOnly = true;
            this.GridView.RowHeadersWidth = 80;
            this.GridView.RowTemplate.Height = 23;
            this.GridView.Size = new System.Drawing.Size(398, 376);
            this.GridView.TabIndex = 20;
            // 
            // codeData
            // 
            this.codeData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.codeData.HeaderText = "Code";
            this.codeData.Name = "codeData";
            this.codeData.ReadOnly = true;
            // 
            // priceData
            // 
            this.priceData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.priceData.HeaderText = "가격";
            this.priceData.Name = "priceData";
            this.priceData.ReadOnly = true;
            // 
            // upData
            // 
            this.upData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.upData.HeaderText = "상승폭";
            this.upData.Name = "upData";
            this.upData.ReadOnly = true;
            // 
            // tradeData
            // 
            this.tradeData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tradeData.HeaderText = "거래량";
            this.tradeData.Name = "tradeData";
            this.tradeData.ReadOnly = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // buyOrSellTimer
            // 
            this.buyOrSellTimer.Interval = 3000;
            this.buyOrSellTimer.Tick += new System.EventHandler(this.buyOrSellTimer_Tick);
            // 
            // UpdateBenefit
            // 
            this.UpdateBenefit.Tick += new System.EventHandler(this.UpdateBenefit_Tick);
            // 
            // charactorSell
            // 
            this.charactorSell.Tick += new System.EventHandler(this.charactorSell_Tick);
            // 
            // charactorBuy
            // 
            this.charactorBuy.Tick += new System.EventHandler(this.charactorBuy_Tick);
            // 
            // ReservationTimer
            // 
            this.ReservationTimer.Tick += new System.EventHandler(this.ReservationTimer_Tick);
            // 
            // ReBuyTimer
            // 
            this.ReBuyTimer.Tick += new System.EventHandler(this.ReBuyTimer_Tick);
            // 
            // reBuyLabel
            // 
            this.reBuyLabel.AutoSize = true;
            this.reBuyLabel.Location = new System.Drawing.Point(709, 432);
            this.reBuyLabel.Name = "reBuyLabel";
            this.reBuyLabel.Size = new System.Drawing.Size(29, 12);
            this.reBuyLabel.TabIndex = 26;
            this.reBuyLabel.Text = "없음";
            // 
            // reSellLabel
            // 
            this.reSellLabel.AutoSize = true;
            this.reSellLabel.Location = new System.Drawing.Point(709, 453);
            this.reSellLabel.Name = "reSellLabel";
            this.reSellLabel.Size = new System.Drawing.Size(29, 12);
            this.reSellLabel.TabIndex = 27;
            this.reSellLabel.Text = "없음";
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.Color.Transparent;
            this.picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture.Image = ((System.Drawing.Image)(resources.GetObject("picture.Image")));
            this.picture.Location = new System.Drawing.Point(1044, 400);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(319, 350);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture.TabIndex = 28;
            this.picture.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("문체부 쓰기 정체", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.Location = new System.Drawing.Point(1262, 544);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 21);
            this.label17.TabIndex = 36;
            this.label17.Text = "By. 기연";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("문체부 쓰기 정체", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label16.Location = new System.Drawing.Point(1255, 432);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 21);
            this.label16.TabIndex = 35;
            this.label16.Text = "비트코인";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("문체부 쓰기 정체", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.Location = new System.Drawing.Point(1235, 503);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 21);
            this.label15.TabIndex = 34;
            this.label15.Text = "감사합니다";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("문체부 쓰기 정체", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.Location = new System.Drawing.Point(1220, 465);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 21);
            this.label14.TabIndex = 33;
            this.label14.Text = "위로 가즈아!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 762);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.reSellLabel);
            this.Controls.Add(this.reBuyLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.GridView);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.StockGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playerBox);
            this.Controls.Add(this.picture);
            this.Name = "Form1";
            this.Text = "Stock";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StockChart)).EndInit();
            this.StockGroup.ResumeLayout(false);
            this.SellBox.ResumeLayout(false);
            this.SellBox.PerformLayout();
            this.BuyBox.ResumeLayout(false);
            this.BuyBox.PerformLayout();
            this.playerBox.ResumeLayout(false);
            this.playerBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart StockChart;
        private System.Windows.Forms.GroupBox StockGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BuyQuantityBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox BuyStock;
        private System.Windows.Forms.Button BuyButton;
        private System.Windows.Forms.GroupBox BuyBox;
        private System.Windows.Forms.RadioButton radioNowPrice2;
        private System.Windows.Forms.Label sumLabelBuy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox BuyPriceBox;
        private System.Windows.Forms.GroupBox SellBox;
        private System.Windows.Forms.Button SellButton;
        private System.Windows.Forms.Label sumLabelSell;
        private System.Windows.Forms.ComboBox SellStock;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox SellPriceBox;
        private System.Windows.Forms.TextBox SellQuantityBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox SellAllCheck;
        private System.Windows.Forms.CheckBox BuyAllCheck;
        private System.Windows.Forms.RichTextBox LogBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox playerBox;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeData;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceData;
        private System.Windows.Forms.DataGridViewTextBoxColumn upData;
        private System.Windows.Forms.DataGridViewTextBoxColumn tradeData;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer buyOrSellTimer;
        private System.Windows.Forms.Label pIdLabel;
        private System.Windows.Forms.Label pVarLabel;
        private System.Windows.Forms.Label pNowLabel;
        private System.Windows.Forms.Label pStartLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label qtumCountLabel;
        private System.Windows.Forms.Label adaCountLabel;
        private System.Windows.Forms.Label eosCountLabel;
        private System.Windows.Forms.Label tronCountLabel;
        private System.Windows.Forms.Label ripCountLabel;
        private System.Windows.Forms.RadioButton radioNowPrice1;
        private System.Windows.Forms.Timer UpdateBenefit;
        private System.Windows.Forms.Timer charactorSell;
        private System.Windows.Forms.Timer charactorBuy;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button sellReButton;
        private System.Windows.Forms.Button buyReButton;
        private System.Windows.Forms.Timer ReservationTimer;
        private System.Windows.Forms.Timer ReBuyTimer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label reSellLabel;
        private System.Windows.Forms.Label reBuyLabel;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
    }
}

