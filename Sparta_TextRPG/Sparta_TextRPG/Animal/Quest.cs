using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TextRPG
{
    internal class Quest
    {
        public string Name { get; set; }    // 퀘스트 이름
        public string Text { get; set; }    // 쿼스트 내용 텍스트
        public List<Item> Reward { get; set; }  // 퀘스트 아이템 보상
        public int Gold { get; set; }   // 퀘스트 골드 보상
        public int State { get; set; }  // 퀘스트 진행도
        public MonsterName Target { get; set; }  // 잡을 몬스터
        public int TargetCount { get; set; }  // 목표 마리수
        public int Count { get; set; }  // 잡은 마리수
        public int RequestLevel { get; set; }   // 퀘스트 요구 레벨

        // public void show() { }   //

        public Quest(string name , string text , List<Item> reward , int gold , MonsterName target, int TargetCount, int requestLevel) { 
            this.Name = name;
            this.Text = text;
            this.Reward = reward;
            this.Gold = gold;
            this.Target = target;
            this.TargetCount = TargetCount;
            this.Count = 0;
            this.RequestLevel = requestLevel;
        }

        // 진행도 확인 함수 추가
    }
}
