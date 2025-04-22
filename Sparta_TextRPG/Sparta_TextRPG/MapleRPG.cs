using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sparta_TextRPG
{
    internal class MapleRPG
    {

        public Shop Shop { get; set; }
        public Player Player { get; set; }
        public NPC NPC { get; set; }
        public List<Monster> monsters { get; set; }
        public List<Dungoun> Dungouns { get; set; }

        SceneName sceneName = new SceneName();
        public string inputName;
        public ClassName inputClassName;
        public int floor = 0;


        public MapleRPG()
        {
            init();
        }
        //가장 메인으로 돌아가는 함수
        public void Program()
        {
            init();

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
                        BattelAttackPhase(Dungouns[floor].monsters);
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

                    case SceneName.NPC :

                        break;


                }
            }
        }
        public void init()
        {
            Skill nomalAttack = new Skill("nomalAttck", 50, "일반공격입니다.", 50, 5, 1, 10);
            Skill HeavyAttack = new Skill("nomalAttck", 50, "강공격입니다.", 150, 50, 5, 10);
            Skill doubleAttack = new Skill("nomalAttck", 50, "더블공격입니다.", 100, 10, 10, 20);


            monsters.Add(new Monster(1, 5, 10, 10, 10, 5, 1, new Inventory(), 100, new List<Skill>(), true, 100, MonsterName.Snail, new List<Item>()));
            monsters.Add(new Monster(2, 8, 15, 15, 10, 8, 2, new Inventory(), 150, new List<Skill>(), true, 10, MonsterName.OrangeMushroom, new List<Item>()));
            monsters.Add(new Monster(3, 10, 20, 20, 10, 10, 2, new Inventory(), 200, new List<Skill>(), true, 10, MonsterName.RibbonPig, new List<Item>()));
            monsters.Add(new Monster(4, 12, 23, 23, 10, 12, 3, new Inventory(), 230, new List<Skill>(), true, 15, MonsterName.EvilEye, new List<Item>()));
            monsters.Add(new Monster(5, 15, 30, 30, 10, 15, 5, new Inventory(), 250, new List<Skill>(), true, 25, MonsterName.ironHog, new List<Item>()));
            monsters.Add(new Monster(6, 20, 35, 35, 10, 20, 7, new Inventory(), 280, new List<Skill>(), true, 15, MonsterName.Drake, new List<Item>()));
            monsters.Add(new Monster(7, 30, 50, 50, 10, 15, 12, new Inventory(), 350, new List<Skill>(), true, 5, MonsterName.StoneGolem, new List<Item>()));
            monsters.Add(new Monster(8, 50, 80, 80, 10, 15, 20, new Inventory(), 500, new List<Skill>(), true, 15, MonsterName.JuniorBalrog, new List<Item>()));
            monsters.Add(new Monster(9, 10000, 1, 1, 1, 10000, 10000, new Inventory(), 10000, new List<Skill>(), true, 100, MonsterName.AnUnnamedPigeon, new List<Item>()));

        }
        public void start()
        {
            Messages.Instance().ShowStart();
            
        }
        public void BattelStart() { 
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
        public void BattelStart(Dungoun dungoun)
        {
            Messages.Instance().ShowBattelStart(dungoun.monsters, Player);
            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if(inputNum ==1)
            {
                sceneName = SceneName.BattelAttackPhase;
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }
        }
        public void BattelAttackPhase(List<Monster> monsters)// 던전에 이미 몬스터수가 정해짐
        {
            Messages.Instance().ShowBattelAttackPhase(monsters, Player);
            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if(inputNum == 0) // 0 입력 시 전 화면으로 돌아가기
            {
                sceneName = SceneName.BattelStart;
            }

            else if (inputNum <= monsters.Count+1) // 입력 시 대상 선택, 구현 몬하겠다 일단 넘기고
            {
                //monsters[inputNum-1]
                if (inputNum == 1)
                {
                    sceneName = SceneName.BattelAttackMonster;
                }
                else if (inputNum == 2)
                {
                    sceneName = SceneName.BattelAttackMonster;
                }
                else if (inputNum == 3)
                {
                    sceneName = SceneName.BattelAttackMonster;
                }
                else
                {
                    sceneName = SceneName.BattelAttackMonster;
                }
            }
            else
            {
                 Messages.Instance().ErrorMessage();
            }

            bool isAllDeath = false; // 한 마리라도 살아있으면 true로 변경

            for (int i = 0; i < monsters.Count; i++) 
            {
                if (monsters[i].IsDead == false)
                {
                    isAllDeath = true;
                }
            }

            if(isAllDeath = true)
            {
                // 승리 씬으로 들어가기
                sceneName = SceneName.BattlePlayerWin;
            }
        }
        public void BattelAttackMonster(Monster monster, Skill PlayerSkill)
        {
            Messages.Instance().ShowBattelAttackMonster(monster, Player, Player.SkillList[0]);
            //로직 추가
            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            Random random = new Random();
            double Deviation = Math.Ceiling((double)(random.Next(-1, 2) * PlayerSkill.Damage) / 10);
            // 데미지 편차 (-1~1)까지 랜덤 난수 생성후 데미지에 곱한 뒤 10으로 나눈 걸 올림

            if (monster.IsDead)
            {
                Messages.Instance().ErrorMessage(); // 죽어있다면 오류 메세지 출력

            }
            if (inputNum == 0) // 0 입력 시 몬스터 공격 턴으로 이동
            {
                sceneName = SceneName.BattelMonsterPhase;
            }
            else if(inputNum <= monsters.Count + 1)
            {
                Messages.Instance().ErrorMessage();
            }
            else
            {
                monster.NowHP -= PlayerSkill.Damage + (int)Deviation - monster.ArmorPoint;
                // 데미지 공식 = 플레이어 데미지 + 편차 - 몬스터 방어력
            }




        }
        public void BattelMonsterPhase(List<Monster> monsters,Skill PlayerSKill,Player player)
        {
            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            //몬스터리스트 받아서 추가 = 모든 몬스터가 한 대 씩 때리기 때문.
            for (int i = 0; i < monsters.Count; i++)
            {
                Messages.Instance().ShowBattelMonsterPhase(monsters[i], Player, Player.SkillList[0]);
                player.NowHP -= (monsters[i].AttackPoint - player.ArmorPoint);
                // 데미지 공식 = 몬스터 공격력 - 플레이어 방어력

                if (player.IsDead == true)
                {
                    // 플레이어 사망 시 패배 씬으로 들어가기
                    sceneName = SceneName.BattlePlayerLose;
                }

                if(inputNum == 0)
                {
                    continue;
                }
                else
                {
                    Messages.Instance().ErrorMessage();
                }

            }



            if (inputNum == 0) // 반복문 종료 후 0 입력 시 다시 플레이어 공격 턴으로 이동
            {
                sceneName = SceneName.BattelAttackPhase;
            }


        }
        public void BattlePlayerWin(List<Monster> monsters,Player player)
        {
            Messages.Instance().ShowBattlePlayerWin(monsters, Player.NowHP, Player);
            for (int i = 0; i < monsters.Count; i++)
            {
                player.Exp += monsters[i].Exp; // 경험치
                player.Gold += monsters[i].Gold; // 돈
                // 아이템 습득 로직
            }

            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 0) // 0번 입력 시 시작 메뉴로 돌아가기
            {
                sceneName= SceneName.StartSetName;
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }

        }
        public void BattlePlayerLose(Player player)
        {
            Messages.Instance().ShowBattlePlayerLose(Player.NowHP, Player);
            //로직 추가

            player.NowHP = 0;

            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 0) // 0번 입력 시 시작 메뉴로 돌아가기
            {
                sceneName = SceneName.StartSetName;
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }
        }
        


        public void NPC()//이름 수정
        {
            Messages.Instance().ShowNPC();
        }

        public void EnterDungoun()
        {
            Messages.Instance().ShowDungoun();
            
            string choice = Console.ReadLine();

            //
            //

            if (choice.CompareTo("1") == 0 )
            {
                // 던전 생성은 여기서x
                // 1누르면 1번저 던전과 입장하는 플레이어 정보
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
