using System;

namespace Stock_Programming
{
    class Virtual_Investor
    {
        private string charactor;
        private string investorName;
        private double benefit; //이익률 %로 표현
        private int funds; // 기본 자금 표현
        private int[] wallet = new int[6]; // 가지고있는 주식 수량 [0] : rip, [1] : trx, [2] : eos, [3] : ada, [4] : qtum
        private int[] buyPrice = new int[6]; //구매값
        
        private int code; //개인 코드값
 
        public int n = 1;
        public int tmpPrice;


        
        Random random = new Random();
        Form1 form1;
        DealSystem dealsystem;
        Form1.TextDelegate textDelegate;

        public Virtual_Investor(Form1 form1,int i, string charactor, Form1.TextDelegate textDelegate,int fund ,Stock rip,Stock trx, Stock eos,Stock ada,Stock qtum,int w)
        {
            this.Funds = fund; // 초기자금 설정
            this.form1 = form1; // form1의 데이터를 가져오기
            this.textDelegate = textDelegate; //Delegate 선언
            dealsystem = new DealSystem(this); // DealSystem에 현재 객체 정보를전달
            this.InvestorName = "Virtual_"+ i; //Virtual 고유 이름
            this.Charactor = charactor; // 성격 저장
            this.code = i;
            for (int c = 0; c < 5; c++)
            {
                this.wallet[c] = w;
            }


            this.form1.Invoke(textDelegate, "성격이" + Charactor + "인객체 생성\n"); //객체생성확인Log
                                                                             //fightting,middleFightting, Normal, middleUnder, Under
    
        }
        public Virtual_Investor(DealSystem deal)
        {
            this.dealsystem = deal;
        }

        public int checkWallet()
        {
            if (Wallet[0] > 0) { return 0; }
            else if (Wallet[1] > 0) { return 1; }
            else if (Wallet[2] > 0) { return 2; }
            else if (Wallet[3] > 0) { return 3; }
            else if (Wallet[4] > 0) { return 4; }
            else { return 5; } // 지갑에 수량이 있는지 없는지 확인
        }

        public double Benefit_pro(int startFund, int presentFund, int i) //초기자본과 현재 자본을 매개변수로 전달
        {
            double tmp;
            tmpPrice = startFund ;
            
                tmp = (double)(((presentFund / startFund) * 100) - 100); // 이익값 / 초기값 *100 = 수익률 %로 표현 
            
            return tmp;
        }

 

        public double Benefit { get => benefit; set => benefit = value; }
        public int Funds { get => funds; set => funds = value; }
        public int Code { get => code; set => code = value; }
        public string InvestorName { get => investorName; set => investorName = value; }
        public string Charactor { get => charactor; set => charactor = value; }
 
        public int[] BuyPrice { get => buyPrice; set => buyPrice = value; }
        public int[] Wallet { get => wallet; set => wallet = value; }
    }
}
