using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stock_Programming
{
    class Player
    {
        private string playerId; //플레이어 ID
        private int initialCapital; // 초기 자본
        private int currentCapital; // 현재 자본
        private float variance;  // 수익률
        private int ripCount; // 리플코인개수
        private int tronCount; // 트론코인 개수
        private int eosCount; //이오스코인 개수
        private int adaCount; // 에이다 코인 개수
        private int qtumCount; //퀀텀코인 개수


        public Player(string id, int inicap, int curcap, float var,int ripC,int tronC, int eosC, int adaC, int qtumC) // ID, 초기자본, 현재자본,수익률 ,코인양
        {
            this.PlayerId = id;
            this.InitialCapital = inicap;
            this.CurrentCapital = curcap;
            this.Variance = var;
            this.RipCount = ripC;
            this.TronCount = tronC;
            this.EosCount = eosC;
            this.AdaCount = adaC;
            this.QtumCount = qtumC;
        }

        public string PlayerId { get => playerId; set => playerId = value; }
        public int InitialCapital { get => initialCapital; set => initialCapital = value; }
        public int CurrentCapital { get => currentCapital; set => currentCapital = value; }
        public float Variance { get => variance; set => variance = value; }
        public int RipCount { get => ripCount; set => ripCount = value; }
        public int TronCount { get => tronCount; set => tronCount = value; }
        public int EosCount { get => eosCount; set => eosCount = value; }
        public int AdaCount { get => adaCount; set => adaCount = value; }
        public int QtumCount { get => qtumCount; set => qtumCount = value; }

    }
}

