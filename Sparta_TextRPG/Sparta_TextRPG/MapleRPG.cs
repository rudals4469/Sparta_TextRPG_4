using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TextRPG
{
    internal class MapleRPG
    {
        public Shop Shop { get; set; }
        public Player Player { get; set; }
        public NPC NPC { get; set; }
        public List<Dungoun> Dungouns { get; set; }

        SceneName sceneName = new SceneName();
        public string inputName;
        public ClassName inputClassName;

        //가장 메인으로 돌아가는 함수
        public void Program()
        {
            init();
            if(Player == null)
            {
                sceneName = SceneName.StartSetName;
            }
            while (true) {

                Console.Clear();//새로운 문구를 출력전 이전문구 삭제

                switch (sceneName){
                    case SceneName.Start :
                        start();
                        break;
                    case SceneName.StartSetName:
                        inputName = StartSetName();                        
                        break;
                    case SceneName.StartChackName:
                        StartChackName();
                        break;
                    case SceneName.StartSetClass:
                        StartSetClass();
                        break;
                    case SceneName.BattelStart:
                        BattelStart();
                        break;
                    case SceneName.BattelAttackPhase:
                        BattelAttackPhase();
                        break;
                    case SceneName.BattelAttackMonster:
                        BattelAttackMonster();
                        break;
                    case SceneName.BattelMonsterPhase:
                        BattelMonsterPhase();
                        break;
                    case SceneName.BattlePlayerWin:
                        BattlePlayerWin();
                        break;
                    case SceneName.BattlePlayerLose:
                        BattlePlayerLose();
                        break;
                }
            }
        }
        public void init()
        {
           
        }
        public void start()
        {
            Messages.Instance().ShowStart();
            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 1) sceneName = SceneName.Staters;
            else if (inputNum == 2) sceneName = SceneName.Inventory;
            else if (inputNum == 3) sceneName = SceneName.Shop;
            else if (inputNum == 4) sceneName = SceneName.DungeonSelection;
            else if (inputNum == 5) return; //휴식
            else if (inputNum == 6) sceneName = SceneName.GameOver;
        }
        public string StartSetName()
        {
            Messages.Instance().ShowStartSetName();
            string Name = Console.ReadLine();

            sceneName = SceneName.StartChackName;

            return Name;
        }
        public void StartChackName()
        {
            Messages.Instance().ShowStartChackName(inputName);
            string input = Console.ReadLine();
            int inputNum = int.Parse(input);
            if(inputNum == 1)
            {
                sceneName = SceneName.StartSetClass;
            }
            else if(inputNum == 2)
            {
                sceneName = SceneName.StartSetName;
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }
        }
        public void StartSetClass()
        {
            Messages.Instance().ShowStartSetClass();
            string input = Console.ReadLine();
            int inputNum = int.Parse(input);
            if (inputNum == 1)
            {
                inputClassName = ClassName.전사;
            }
            else if (inputNum == 2)
            {
                inputClassName = ClassName.마법사;
            }
            else if (inputNum == 3)
            {
                inputClassName = ClassName.궁수;
            }
            else if (inputNum == 4)
            {
                inputClassName = ClassName.도적;
            }
            else if (inputNum == 5)
            {
                inputClassName = ClassName.해적;
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }
            // 플레이어 생성

            sceneName = SceneName.Start;

        }
        public void BattelStart()
        {
            Messages.Instance().ShowBattelStart(dungoun.monsters, Player);
            //로직 추가
        }
        public void BattelAttackPhase()
        {
            Messages.Instance().ShowBattelAttackPhase(dungoun.monsters, Player);
            //로직 추가
        }
        public void BattelAttackMonster()
        {
            //몬스터 받아서 추가
            Messages.Instance().ShowBattelAttackMonster(new Monster() , Player, Player.SkillList[0]);
            //로직 추가
        }
        public void BattelMonsterPhase()
        {
            //몬스터 받아서 추가
            Messages.Instance().ShowBattelMonsterPhase(new Monster(), Player, Player.SkillList[0]);
            //로직 추가
        }
        public void BattlePlayerWin()
        {
            Messages.Instance().ShowBattlePlayerWin(dungoun.monsters, Player.NowHP, Player);
            //로직 추가
        }
        public void BattlePlayerLose()
        {
            Messages.Instance().ShowBattlePlayerLose(Player.NowHP, Player);
            //로직 추가
        }
        
    }
}
