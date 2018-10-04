using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Stock_Programming
{
    class Stock : ParentStock
    {
        DealSystem deal = new DealSystem();
        Main main = new Main();

        double pro = 0.001;
        
        public Stock(String name,String code,int price, int quantity) // 주식의 이름, 가격, 수량설정
        {
             
            this.StockName = name; 
            this.StockCurrentPrice = price;
            this.StockPreviousPrice = price;
            this.Quantity = quantity;
            this.StartQuantity = quantity;
            this.StockCode = code;
        }
        public Stock() { }

        public override void BuyStock(int Count) //구매 수량
        {
            if (this.Quantity > 0) // 수량이 0개 이상일때 구매가능
            {
                this.Quantity -= Count; // 구매한 만큼 수량감소
                deal.BuyVolume += Count; //구매자 수 증가

                StockVolume += Count; // 거래량 확인

                if (deal.BuyVolume > 1000) // 구매수량이 10개가 넘을때 가격 상승
                {
                    deal.BuyVolume = 0; // 구매수량 초기화
                    Updateprice(Count);
                }
            }
           
        }

        public override void SellStock(int Count) //판매 수량
        {
            this.Quantity += Count; // 판매자 만큼 수량 증가.
            if (this.Quantity > this.StartQuantity) this.Quantity = this.StartQuantity; // 초기수량을 넘지않게설정
            deal.SellVolume -= Count; // 구매자수 수량 감소

            StockVolume += Count; // 거래량 확인

            if (deal.SellVolume < -1000) // 판매수량이 10개가 넘을때 가격 하락
            {
                deal.BuyVolume = 0; // 판매수량 초기화
                Updateprice(-Count);
            }
        }

        public override void Updateprice(int Count)
        {
            double tmp;
            double update;
            // this.StockPreviousPrice = this.StockCurrentPrice;
            update = Count * pro / 100;

            if (this.StockCurrentPrice > 5000)
            {
                if (update > 0.1)
                {
                    update = 000.1;
                    tmp = this.StockCurrentPrice * (update); // 퍼센트 비율 상승   - 원금 * 110/100 = 10%  // 원금 + 원금*인원수*0.2/100 = 20%
                }
                else if (update < -0.1)
                {
                    update = -000.1;
                    tmp = this.StockCurrentPrice * (update); // 퍼센트 비율 상승   - 원금 * 110/100 = 10%  // 원금 + 원금*인원수*0.2/100 = 20%
                }
                else
                {
                    tmp = this.StockCurrentPrice * (update);
                }
            }

            else
            {
                if (update > 0.3)
                {
                    update = 000.3;
                    tmp = this.StockCurrentPrice * (update); // 퍼센트 비율 상승   - 원금 * 110/100 = 10%  // 원금 + 원금*인원수*0.2/100 = 20%
                }
                else if (update < -0.3)
                {
                    update = -000.3;
                    tmp = this.StockCurrentPrice * (update); // 퍼센트 비율 상승   - 원금 * 110/100 = 10%  // 원금 + 원금*인원수*0.2/100 = 20%
                }
                else
                {
                    tmp = this.StockCurrentPrice * (update);
                }
            }
            //1000명이상일때 1%씩 값이 변하게 계산
            this.StockCurrentPrice = this.StockCurrentPrice +(int)tmp; // 현재가격
        }



        public void UpdateVariance() // 가격 업데이트
        {
            this.Variance = Math.Round(((((double)this.StockCurrentPrice/(double)this.StockPreviousPrice)*100)-100), 2); // 소수점 2째자리까지 표현
            //(현재가격 /이전가격 *100 )-100 // 상승률
        }

        public void UpdateQuantity() //코인보충
        {
            if (this.Quantity < 100) this.Quantity = 10000;
        }
    }
}
