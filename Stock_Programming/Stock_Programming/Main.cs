using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Stock_Programming
{
    class Main
    {
        
        Virtual_Investor []vit = new Virtual_Investor[500];
        String[] charactor = { "Fightting", "MiddleFightting", "Normal", "MiddleUnder", "Under" };
        Thread t;
        Random random;
        Form1 form1;

        private bool run;
        private bool startRoop = true;
        int basicmoney = 100000;

        public bool Run { get => run; set => run = value; }

        public Main(Form1 form1)
        {
            this.form1 = form1;
        }
        public Main()
        {
            
        }
        public String setCharactor(int i) { return charactor[i]; } //캐릭터 성격설정
        
        public void VirtualRun(Form1.TextDelegate textDelegate ,Stock rip,Stock trx,Stock eos,Stock ada, Stock qtum) // 가상캐릭터 객채생성
        {
            Run = true;
            random = new Random();
            t = new Thread(() =>
            {
                for (int i = 0; i < 500&& Run; i++) //  만명의 객체 생성
                {
                    int r = random.Next(0, 5);
                    string charactor = setCharactor(r); //성격설정
                    vit[i] = new Virtual_Investor(form1,i,charactor, textDelegate,basicmoney,rip,trx,eos,ada,qtum,100); // 가상객체 생성
                    System.Threading.Thread.Sleep(10);
                }
                form1.boolBuySell = true;
            });
            t.Start();
        }

        public void ChartUpdate(Chart StockChart, Stock coin) { StockChart.Series[coin.StockName].Points.Add(coin.StockCurrentPrice); }

        public void StockStore(Stock rip, Stock trx, Stock eos, Stock ada, Stock qtum,DealSystem dealsystem) // 주식시장 
        {
            foreach (var item in vit)
            {
                int i = random.Next(0, 5);
                int choice = random.Next(0, 2);
                if (choice.Equals(0) && item.Funds > 0) // 구매
                {
                    switch (i)
                    {
                        case 0: { dealsystem.ExchangeBuy(rip, i,item); break; }
                        case 1: { dealsystem.ExchangeBuy(trx, i,item); break; }
                        case 2: { dealsystem.ExchangeBuy(eos, i,item); break; }
                        case 3: { dealsystem.ExchangeBuy(ada, i, item); break; }
                        case 4: { dealsystem.ExchangeBuy(qtum, i, item); break; }
                        default: break;
                    }
                } else if(choice.Equals(1)) //판매
                {

                    if (startRoop)
                    {
                        int r =random.Next(0,4);
                        switch (r)
                        {
                            case 0: { dealsystem.ExchangeSell(rip, r, item); break; }
                            case 1: { dealsystem.ExchangeSell(trx, r, item); break; }
                            case 2: { dealsystem.ExchangeSell(eos, r, item); break; }
                            case 3: { dealsystem.ExchangeSell(ada, r, item); break; }
                            case 4: { dealsystem.ExchangeSell(qtum, r, item); break; }
                            default: break;
                        }
                        if(item.checkWallet().Equals(5))
                        startRoop = false;
                    }
                    else
                    {
                        int c = item.checkWallet(); //지갑에 있는돈 확인
                        switch (c)
                        {
                            case 0: { dealsystem.ExchangeSell(rip, c, item); break; }
                            case 1: { dealsystem.ExchangeSell(trx, c, item); break; }
                            case 2: { dealsystem.ExchangeSell(eos, c, item); break; }
                            case 3: { dealsystem.ExchangeSell(ada, c, item); break; }
                            case 4: { dealsystem.ExchangeSell(qtum, c, item); break; }
                            default: break;
                        }
                    }
                }
            }         
        }

        public void UpdateVirtualBenefit(Stock rip, Stock trx, Stock eos, Stock ada, Stock qtum)
        {
            foreach(var item in vit)
            {
                int c = item.checkWallet();
                if (!(item.BuyPrice[c] == 0))
                {
                    switch (c)
                    {
                        case 0: { item.Benefit = ((rip.StockCurrentPrice / item.BuyPrice[item.checkWallet()] * 100) - 100); break; }
                        case 1: { item.Benefit = ((trx.StockCurrentPrice / item.BuyPrice[item.checkWallet()] * 100) - 100); break; }
                        case 2: { item.Benefit = ((eos.StockCurrentPrice / item.BuyPrice[item.checkWallet()] * 100) - 100); break; }
                        case 3: { item.Benefit = ((ada.StockCurrentPrice / item.BuyPrice[item.checkWallet()] * 100) - 100); break; }
                        case 4: { item.Benefit = ((qtum.StockCurrentPrice / item.BuyPrice[item.checkWallet()] * 100) - 100); break; }
                        default: break;
                    }
                }
            } 
        }

        public void benefitSell(Stock rip, Stock trx, Stock eos, Stock ada, Stock qtum)
        {
            foreach (var item in vit)
            {
                if(item.Charactor.Equals("Fightting") && item.Benefit> random.Next(0, 10))
                {
                    switch (item.checkWallet())
                    {
                        case 0: {
                                item.Funds += item.Wallet[item.checkWallet()] * rip.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                rip.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                rip.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (rip.Quantity > rip.StartQuantity) rip.Quantity = rip.StartQuantity;
                                rip.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;

                            }//리플
                        case 1: {
                                item.Funds += item.Wallet[item.checkWallet()] * trx.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                trx.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                trx.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (trx.Quantity > trx.StartQuantity) trx.Quantity = trx.StartQuantity;
                                trx.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;

                            }//트론
                        case 2: {
                                item.Funds += item.Wallet[item.checkWallet()] * eos.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                eos.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                eos.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (eos.Quantity > eos.StartQuantity) eos.Quantity = eos.StartQuantity;
                                eos.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;

                            }//이오스
                        case 3: {
                                item.Funds += item.Wallet[item.checkWallet()] * ada.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                ada.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                ada.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (ada.Quantity > ada.StartQuantity) ada.Quantity = ada.StartQuantity;
                                ada.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;

                            }//에이다
                        case 4: {
                                item.Funds += item.Wallet[item.checkWallet()] * qtum.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                qtum.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                qtum.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (qtum.Quantity > qtum.StartQuantity) qtum.Quantity = qtum.StartQuantity;
                                qtum.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;
                            }//퀀텀
                        default:
                            break;
                    }
                }
                else if(item.Charactor.Equals("MiddleFightting") && item.Benefit> random.Next(3, 8))
                {
                    switch (item.checkWallet())
                    {
                        case 0:
                            {
                                item.Funds += item.Wallet[item.checkWallet()] * rip.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                rip.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                rip.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (rip.Quantity > rip.StartQuantity) rip.Quantity = rip.StartQuantity;
                                rip.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;
                            }//리플
                        case 1:
                            {
                                item.Funds += item.Wallet[item.checkWallet()] * trx.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                trx.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                trx.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (trx.Quantity > trx.StartQuantity) trx.Quantity = trx.StartQuantity;
                                trx.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;
                            }//트론
                        case 2:
                            {
                                item.Funds += item.Wallet[item.checkWallet()] * eos.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                eos.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                eos.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (eos.Quantity > eos.StartQuantity) eos.Quantity = eos.StartQuantity;
                                eos.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;

                            }//이오스
                        case 3:
                            {
                                item.Funds += item.Wallet[item.checkWallet()] * ada.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                ada.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                ada.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (ada.Quantity > ada.StartQuantity) ada.Quantity = ada.StartQuantity;
                                ada.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;
                            }//에이다
                        case 4:
                            {
                                item.Funds += item.Wallet[item.checkWallet()] * qtum.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                qtum.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                qtum.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (qtum.Quantity > qtum.StartQuantity) qtum.Quantity = qtum.StartQuantity;
                                qtum.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;
                            }//퀀텀
                        default:
                            break;
                    }
                }
                else if (item.Charactor.Equals("Normal") && item.Benefit > random.Next(0, 5))
                {
                    switch (item.checkWallet())
                    {
                        case 0:
                            {
                                item.Funds += item.Wallet[item.checkWallet()] * rip.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                rip.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                rip.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (rip.Quantity > rip.StartQuantity) rip.Quantity = rip.StartQuantity;
                                rip.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;
                            }//리플
                        case 1:
                            {
                                item.Funds += item.Wallet[item.checkWallet()] * trx.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                trx.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                trx.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (trx.Quantity > trx.StartQuantity) trx.Quantity = trx.StartQuantity;
                                trx.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;
                            }//트론
                        case 2:
                            {
                                item.Funds += item.Wallet[item.checkWallet()] * eos.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                eos.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                eos.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (eos.Quantity > eos.StartQuantity) eos.Quantity = eos.StartQuantity;
                                eos.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;

                            }//이오스
                        case 3:
                            {
                                item.Funds += item.Wallet[item.checkWallet()] * ada.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                ada.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                ada.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (ada.Quantity > ada.StartQuantity) ada.Quantity = ada.StartQuantity;
                                ada.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;
                            }//에이다
                        case 4:
                            {
                                item.Funds += item.Wallet[item.checkWallet()] * qtum.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                qtum.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                qtum.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (qtum.Quantity > qtum.StartQuantity) qtum.Quantity = qtum.StartQuantity;
                                qtum.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;
                            }//퀀텀
                        default:
                            break;
                    }
                }
                else if (item.Charactor.Equals("MiddleUnder") && item.Benefit < -random.Next(3, 8))
                {
                    switch (item.checkWallet())
                    {
                        case 0:
                            {
                                item.Funds += item.Wallet[item.checkWallet()] * rip.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                rip.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                rip.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (rip.Quantity > rip.StartQuantity) rip.Quantity = rip.StartQuantity;
                                rip.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;
                            }//리플
                        case 1:
                            {
                                item.Funds += item.Wallet[item.checkWallet()] * trx.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                trx.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                trx.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (trx.Quantity > trx.StartQuantity) trx.Quantity = trx.StartQuantity;
                                trx.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;
                            }//트론
                        case 2:
                            {
                                item.Funds += item.Wallet[item.checkWallet()] * eos.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                eos.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                eos.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (eos.Quantity > eos.StartQuantity) eos.Quantity = eos.StartQuantity;
                                eos.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;

                            }//이오스
                        case 3:
                            {
                                item.Funds += item.Wallet[item.checkWallet()] * ada.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                ada.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                ada.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (ada.Quantity > ada.StartQuantity) ada.Quantity = ada.StartQuantity;
                                ada.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;
                            }//에이다
                        case 4:
                            {
                                item.Funds += item.Wallet[item.checkWallet()] * qtum.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                qtum.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                qtum.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (qtum.Quantity > qtum.StartQuantity) qtum.Quantity = qtum.StartQuantity;
                                qtum.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;
                            }//퀀텀
                        default:
                            break;
                    }
                }
                else if (item.Charactor.Equals("Under") && item.Benefit < -random.Next(0, 10))
                {
                    switch (item.checkWallet())
                    {
                        case 0:
                            {
                                item.Funds += item.Wallet[item.checkWallet()] * rip.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                rip.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                rip.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (rip.Quantity > rip.StartQuantity) rip.Quantity = rip.StartQuantity;
                                rip.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;
                            }//리플
                        case 1:
                            {
                                item.Funds += item.Wallet[item.checkWallet()] * trx.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                trx.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                trx.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (trx.Quantity > trx.StartQuantity) trx.Quantity = trx.StartQuantity;
                                trx.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;
                            }//트론
                        case 2:
                            {
                                item.Funds += item.Wallet[item.checkWallet()] * eos.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                eos.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                eos.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (eos.Quantity > eos.StartQuantity) eos.Quantity = eos.StartQuantity;
                                eos.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;

                            }//이오스
                        case 3:
                            {
                                item.Funds += item.Wallet[item.checkWallet()] * ada.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                ada.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                ada.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (ada.Quantity > ada.StartQuantity) ada.Quantity = ada.StartQuantity;
                                ada.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;
                            }//에이다
                        case 4:
                            {
                                item.Funds += item.Wallet[item.checkWallet()] * qtum.StockCurrentPrice; //플레이어 자금 증가
                                item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.Benefit_pro(1, 0, 1); //이익률계산 초기화
                                qtum.Quantity += item.Wallet[item.checkWallet()]; //리플개수 증가
                                qtum.Updateprice(-item.Wallet[item.checkWallet()]); //가격 업데이트
                                if (qtum.Quantity > qtum.StartQuantity) qtum.Quantity = qtum.StartQuantity;
                                qtum.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = 0; //코인개수 0개
                                break;
                            }//퀀텀
                        default:
                            break;
                    }
                }


            }
        }

        public void benefitBuy(Stock rip, Stock trx, Stock eos, Stock ada, Stock qtum)
        {
            int sum;
            int count;
            foreach (var item in vit)
            {
                if (item.Charactor.Equals("Fightting") && item.Benefit < -random.Next(0, 10))
                {
                    switch (item.checkWallet())
                    {
                        case 0:
                            {
                                count = item.Funds / rip.StockCurrentPrice;
                                sum = count * rip.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = rip.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                rip.Quantity -= count; //리플개수 감소
                                rip.Updateprice(count); //가격 업데이트
                                rip.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//리플
                        case 1:
                            {
                                count = item.Funds / trx.StockCurrentPrice;
                                sum = count * trx.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = trx.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                trx.Quantity -= count; //리플개수 감소
                                trx.Updateprice(count); //가격 업데이트
                                trx.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//트론
                        case 2:
                            {
                                count = item.Funds / eos.StockCurrentPrice;
                                sum = count * eos.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = eos.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                eos.Quantity -= count; //리플개수 감소
                                eos.Updateprice(count); //가격 업데이트
                                eos.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//이오스
                        case 3:
                            {
                                count = item.Funds / ada.StockCurrentPrice;
                                sum = count * ada.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = ada.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                ada.Quantity -= count; //리플개수 감소
                                ada.Updateprice(count); //가격 업데이트
                                ada.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//에이다
                        case 4:
                            {
                                count = item.Funds / qtum.StockCurrentPrice;
                                sum = count * qtum.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = qtum.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                qtum.Quantity -= count; //리플개수 감소
                                qtum.Updateprice(count); //가격 업데이트
                                qtum.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//퀀텀
                        default:
                            break;
                    }
                }
                else if (item.Charactor.Equals("MiddleFightting") && item.Benefit < -random.Next(3, 8))
                {
                    switch (item.checkWallet())
                    {
                        case 0:
                            {
                                count = item.Funds / rip.StockCurrentPrice;
                                sum = count * rip.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = rip.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                rip.Quantity -= count; //리플개수 감소
                                rip.Updateprice(count); //가격 업데이트
                                rip.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//리플
                        case 1:
                            {
                                count = item.Funds / trx.StockCurrentPrice;
                                sum = count * trx.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = trx.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                trx.Quantity -= count; //리플개수 감소
                                trx.Updateprice(count); //가격 업데이트
                                trx.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//트론
                        case 2:
                            {
                                count = item.Funds / eos.StockCurrentPrice;
                                sum = count * eos.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = eos.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                eos.Quantity -= count; //리플개수 감소
                                eos.Updateprice(count); //가격 업데이트
                                eos.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//이오스
                        case 3:
                            {
                                count = item.Funds / ada.StockCurrentPrice;
                                sum = count * ada.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = ada.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                ada.Quantity -= count; //리플개수 감소
                                ada.Updateprice(count); //가격 업데이트
                                ada.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//에이다
                        case 4:
                            {
                                count = item.Funds / qtum.StockCurrentPrice;
                                sum = count * qtum.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = qtum.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                qtum.Quantity -= count; //리플개수 감소
                                qtum.Updateprice(count); //가격 업데이트
                                qtum.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//퀀텀
                        default:
                            break;
                    }
                }
                else if (item.Charactor.Equals("Normal") && item.Benefit < random.Next(0,5))
                {
                    switch (item.checkWallet())
                    {
                        case 0:
                            {
                                count = item.Funds / rip.StockCurrentPrice;
                                sum = count * rip.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = rip.StockCurrentPrice;
                                
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                rip.Quantity -= count; //리플개수 감소
                                rip.Updateprice(count); //가격 업데이트
                                rip.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//리플
                        case 1:
                            {
                                count = item.Funds / trx.StockCurrentPrice;
                                sum = count * trx.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = trx.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                trx.Quantity -= count; //리플개수 감소
                                trx.Updateprice(count); //가격 업데이트
                                trx.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//트론
                        case 2:
                            {
                                count = item.Funds / eos.StockCurrentPrice;
                                sum = count * eos.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = eos.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                eos.Quantity -= count; //리플개수 감소
                                eos.Updateprice(count); //가격 업데이트
                                eos.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//이오스
                        case 3:
                            {
                                count = item.Funds / ada.StockCurrentPrice;
                                sum = count * ada.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = ada.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                ada.Quantity -= count; //리플개수 감소
                                ada.Updateprice(count); //가격 업데이트
                                ada.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//에이다
                        case 4:
                            {
                                count = item.Funds / qtum.StockCurrentPrice;
                                sum = count * qtum.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = qtum.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                qtum.Quantity -= count; //리플개수 감소
                                qtum.Updateprice(count); //가격 업데이트
                                qtum.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//퀀텀
                        default:
                            break;
                    }
                }
                else if (item.Charactor.Equals("MiddleUnder") && item.Benefit > random.Next(3, 8))
                {
                    switch (item.checkWallet())
                    {
                        case 0:
                            {
                                count = item.Funds / rip.StockCurrentPrice;
                                sum = count * rip.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = rip.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                rip.Quantity -= count; //리플개수 감소
                                rip.Updateprice(count); //가격 업데이트
                                rip.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//리플
                        case 1:
                            {
                                count = item.Funds / trx.StockCurrentPrice;
                                sum = count * trx.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = trx.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                trx.Quantity -= count; //리플개수 감소
                                trx.Updateprice(count); //가격 업데이트
                                trx.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//트론
                        case 2:
                            {
                                count = item.Funds / eos.StockCurrentPrice;
                                sum = count * eos.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = eos.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                eos.Quantity -= count; //리플개수 감소
                                eos.Updateprice(count); //가격 업데이트
                                eos.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//이오스
                        case 3:
                            {
                                count = item.Funds / ada.StockCurrentPrice;
                                sum = count * ada.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = ada.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                ada.Quantity -= count; //리플개수 감소
                                ada.Updateprice(count); //가격 업데이트
                                ada.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//에이다
                        case 4:
                            {
                                count = item.Funds / qtum.StockCurrentPrice;
                                sum = count * qtum.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = qtum.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                qtum.Quantity -= count; //리플개수 감소
                                qtum.Updateprice(count); //가격 업데이트
                                qtum.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//퀀텀
                        default:
                            break;
                    }
                }
                else if (item.Charactor.Equals("Under") && item.Benefit > random.Next(0, 10))
                {
                    switch (item.checkWallet())
                    {
                        case 0:
                            {
                                count = item.Funds / rip.StockCurrentPrice;
                                sum = count * rip.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = rip.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                rip.Quantity -= count; //리플개수 감소
                                rip.Updateprice(count); //가격 업데이트
                                rip.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//리플
                        case 1:
                            {
                                count = item.Funds / trx.StockCurrentPrice;
                                sum = count * trx.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = trx.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                trx.Quantity -= count; //리플개수 감소
                                trx.Updateprice(count); //가격 업데이트
                                trx.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//트론
                        case 2:
                            {
                                count = item.Funds / eos.StockCurrentPrice;
                                sum = count * eos.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = eos.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                eos.Quantity -= count; //리플개수 감소
                                eos.Updateprice(count); //가격 업데이트
                                eos.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//이오스
                        case 3:
                            {
                                count = item.Funds / ada.StockCurrentPrice;
                                sum = count * ada.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = ada.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                ada.Quantity -= count; //리플개수 감소
                                ada.Updateprice(count); //가격 업데이트
                                ada.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//에이다
                        case 4:
                            {
                                count = item.Funds / qtum.StockCurrentPrice;
                                sum = count * qtum.StockCurrentPrice;
                                item.Funds -= sum; //살수있는 개수 *리플의현재가격 item.BuyPrice[item.checkWallet()] = 0;
                                item.n = 1;
                                item.BuyPrice[item.checkWallet()] = qtum.StockCurrentPrice;
                                item.Benefit_pro(item.BuyPrice[item.checkWallet()], rip.StockCurrentPrice, 1);
                                qtum.Quantity -= count; //리플개수 감소
                                qtum.Updateprice(count); //가격 업데이트
                                qtum.StockVolume += item.Wallet[item.checkWallet()]; // //코인 거래량 증가
                                item.Wallet[item.checkWallet()] = count; //코인개수 추가
                                break;
                            }//퀀텀
                        default:
                            break;
                    }
                }


            }
        }

    }


}
