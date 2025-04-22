using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TextRPG
{
    internal class MapleRPG
    {
        //가장 메인으로 돌아가는 함수
        public void Program()
        {
            init();

            SceneName sceneName = new SceneName();

            while (true) {

                switch (sceneName){
                    case SceneName.Start :
                        start();
                        break;
                    case SceneName.NPC :

                        break;

                }
            }
        }
        public void init()
        {
            Dungoun.Add(new Dungoun("kim", 10, new List<Monster>()));   // new Linse<Monster>() : 몬스터 배열을 받아야 함
        }
        public void start()
        {
            Messages.Instance().ShowStart();
        }

        public void NPC()
        {
            Messages.Instance().ShowNPC();
        }

        public void EnterDungoun()
        {
            Messages.Instance().ShowDungoun();
            
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Dungoun = new dungoun("쉬운 던전", 1);
            }
            else if (choice == "2")
            {
                Dungoun = new dungoun("일반 던전", 2);
            }
            else if (choice == "3")
            {
                Dungoun = new dungoun("어려운 던전", 3);
            }
                

        }
    }
}
