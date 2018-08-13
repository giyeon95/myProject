using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Programming
{ 
    class DealSystem
    {
        Form1 form1;
        Virtual_Investor vit;
        Random random = new Random();

        private int buyVolume  = 0;
        private int sellVolume = 0;

        public DealSystem(Form1 from1)
        {
            this.form1 = from1;
        }
        public DealSystem(Virtual_Investor vit)
        {
            this.vit = vit;
        }
        
        public DealSystem()
        {

        }

         public void ExchangeSell(Stock coin, int i,Virtual_Investor vit) //판매루프
         { 
            int amount;
            
            switch (vit.Charactor)
            {
                case "Fightting": { amount = (vit.Wallet[i]/ random.Next(1, 3)); break;}
                case "MiddleFightting": { amount = (vit.Wallet[i]/ random.Next(1, 4)); break; }
                case "Normal": { amount = (vit.Wallet[i]/ random.Next(1, 5)); break; }
                case "MiddleUnder": { amount = (vit.Wallet[i]/ random.Next(1, 6)); break; }
                case "Under": { amount = (vit.Wallet[i]/ random.Next(1, 7)); break; }
                default:
                    amount = 0; break;
            }
            if (amount > 0) // 판매하는 코인의 개수가 0개이상일때
            {
                int sellCoinPrice;
                sellCoinPrice = coin.StockCurrentPrice * amount;

                vit.BuyPrice[i] = 0; //코인구매가격 초기화
                vit.n = 1; //n값 초기화
               
                vit.Funds += sellCoinPrice;
                vit.Wallet[i] -= amount; //지갑에 들어있는 코인개수 감소
                coin.SellStock(amount);
                if (vit.Wallet[i] == 0)
                {
                    vit.Benefit_pro(1, 0, i); //이익률계산 초기화
                }

            }
         }

        public void ExchangeBuy(Stock coin, int i,Virtual_Investor vit) //구매시장
        {
           
            int amount;
            switch (vit.Charactor) // 성격에 따른 코인 구매량
            { 
                case "Fightting": { amount = (vit.Funds / coin.StockCurrentPrice/ random.Next(1, 3)); break; } // 지갑에 있는돈 올인
                case "MiddleFightting": { amount = (vit.Funds / coin.StockCurrentPrice/ random.Next(1, 4)); break; }
                case "Normal": { amount = (vit.Funds / coin.StockCurrentPrice / random.Next(1, 5)); break; }
                case "MiddleUnder": { amount = (vit.Funds / coin.StockCurrentPrice / random.Next(1, 6)); break; }
                case "Under": { amount = (vit.Funds / coin.StockCurrentPrice / random.Next(1, 7)); break; }
                default:
                    amount = 0; break;
            }

            if (coin.Quantity > 0)
            {
                int buyCoinPrice;
                buyCoinPrice = coin.StockCurrentPrice * amount; //코인가격 * 수량
                
                vit.BuyPrice[i] = (coin.StockCurrentPrice+vit.BuyPrice[i])/vit.n; // 코인종류에따른 구매가격 저장
                vit.n++;
                vit.Benefit_pro(vit.BuyPrice[i], coin.StockCurrentPrice, i);
                vit.Benefit = (coin.StockCurrentPrice / vit.BuyPrice[i] * 100) - 100; // (코인현재가격/구매가격*100)-100
                vit.Wallet[i] += amount;
                coin.BuyStock(amount);
            }
        }

   

        public int BuyVolume { get => buyVolume; set => buyVolume = value; }
        public int SellVolume { get => sellVolume; set => sellVolume = value; }
    }
}
