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
        public int DungounFloor = 0;

        SceneName sceneName = new SceneName();
        //가장 메인으로 돌아가는 함수
        public void Program()
        {
            init();

            //몇층 던전인지 저장
            

            if(Player == null)
            {
                sceneName = SceneName.StartSetName;
            }
            while (true) {

                switch (sceneName){
                    case SceneName.Start :
                        start();
                        break;
                    case SceneName.StartSetName:
                        StartSetName();
                        break;
                    case SceneName.BattelStart:
                        BattelStart(Dungouns[DungounFloor]);
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
        }
        public string StartSetName()
        {
            Messages.Instance().ShowStartSetName();
            string Name = Console.ReadLine();
            return Name;

        }
        public void BattelStart(Dungoun dungoun)
        {
            Messages.Instance().ShowBattelStart(dungoun.monsters, Player);
            //로직 추가
            //키를 누를때 작동하는 부분을 추개해야 합니다.
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
            DungounFloor++;
            //로직 추가
        }
        public void BattlePlayerLose()
        {
            Messages.Instance().ShowBattlePlayerLose(Player.NowHP, Player);
            //로직 추가
        }
    }
}
