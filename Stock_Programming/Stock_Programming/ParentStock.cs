using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Programming
{
   abstract class ParentStock
    { 
        private String stockName; //주식이름
        private int stockCurrentPrice; // 현재가격
        private int stockPreviousPrice; // 이전가격
        private int stockDate; // 날짜
        private int priceUpdate; //주식의 구매자수
        private int stockVolume; // 주식의 거래량
        private int startQuantity; // 주식의 초기 수량
        private int quantity; // 현재 주식의 수량
        private double variance; //변동폭
        private String stockCode; //주식의 코드번호

        public string StockName { get => stockName; set => stockName = value; }
        public int StockCurrentPrice { get => stockCurrentPrice; set => stockCurrentPrice = value; }
        public int StockPreviousPrice { get => stockPreviousPrice; set => stockPreviousPrice = value; }
        public int PriceUpdate { get => priceUpdate; set => priceUpdate = value; }
        public int StockDate { get => stockDate; set => stockDate = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Variance { get => variance; set => variance = value; }
        public string StockCode { get => stockCode; set => stockCode = value; }
        public int StockVolume { get => stockVolume; set => stockVolume = value; }
        public int StartQuantity { get => startQuantity; set => startQuantity = value; }

        abstract public void Updateprice(int Count); // 주식가격 업데이트식
        abstract public void BuyStock(int Count); // 주식 구매시
        abstract public void SellStock(int Count); // 주식 판매시
        
        

    }
}
