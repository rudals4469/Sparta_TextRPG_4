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
        public string Target { get; set; }  // 잡을 몬스터
        public int RequestLevel { get; set; }   // 퀘스트 요구 레벨

        // public void show() { }   //

    }
}
