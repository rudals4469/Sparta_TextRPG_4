using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

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
            sceneName = SceneName.ManageEquipment;
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
                    case SceneName.ShowStatus:
                        ShowStatus();
                        break;
                    case SceneName.ShowInventory:
                        ShowInventory();
                        break;
                    case SceneName.ManageEquipment:
                        ManageEquipment(Player);
                        break;
                    case SceneName.BattelStart:
                        BattelStart();
                        break;
                    case SceneName.BattelAttackPhase:
                        BattelAttackPhase(Dungouns[floor].monsters);
                        break;
                    case SceneName.BattelAttackMonster:
                        //BattelAttackMonster();
                        break;
                    case SceneName.BattelMonsterPhase:
                        //BattelMonsterPhase();
                        break;
                    case SceneName.BattlePlayerWin:
                        //BattlePlayerWin();
                        break;
                    case SceneName.BattlePlayerLose:
                        //BattlePlayerLose();
                        break;
                    case SceneName.NPC :
                        NPCText();
                        break;
                    case SceneName.Quest:
                        break;
                    case SceneName.Rest:
                        Rest();
                        break;
                }
            }
        }
        public void init()
        {
            Shop = new Shop();
            monsters = new List<Monster>();
            Dungouns = new List<Dungoun>();
            //Player(int Level, int Exp, int MaxHp, int NowHp, int MaxMP, int AttacPoint, int ArmorPoint, Inventory inventory,string Name,int Gold, List< Skill > SkillList, bool IsDead, int EvasionRate, int MaxExp, ClassName className)

            // public Skill(string name, int criticalRate, string text, int damage, int mana, int level, int coolTime,int targetCount)
            Skill normalAttack = new Skill("NormalAttck", 50, "일반공격입니다.", 50, 5, 1, 10,1);
            Skill HeavyAttack = new Skill("HeavyAttack", 50, "강공격입니다.", 150, 50, 5, 10,1);
            Skill doubleAttack = new Skill("DoubleAttack", 50, "더블공격입니다.", 100, 10, 10, 20,1);
            
            Skill threeSnails = new Skill("ThreeSnails", 50, "달팽이의 껍질을 던져 원거리의 적을 공격한다.", 10, 10, 10, 2, 1);

            Skill slashBlast = new Skill("Slash Blast", 50, "MP를 소비하여 주위의 적 다수를 동시에 공격한다.", 100, 20, 10, 20, 1);
            Skill energyBolt = new Skill("Energy Bolt", 50, "적에게 닿으면 폭발하는 에너지 응집체를 발사한다.", 90, 20, 10, 20, 1);
            Skill arrowBlow = new Skill("Arrow Blow", 50, "적을 향해 화살을 연속 발사한다.", 50, 20, 10, 20, 1);
            Skill luckySeven = new Skill("Lucky Seven", 50, "표창을 던져 전방의 적들을 공격한다.", 150, 20, 10, 20, 1);
            Skill somersaultKick = new Skill("Somersault Kick", 50, "적을 향해 화살을 연속 발사한다.", 50, 20, 10, 20, 1);

            Skill Origin =new Skill("Origin", 80, "필살기!!!!", 500, 100, 20, 100, 3);

            List<Skill> MonsterSkillset = new List<Skill>() { normalAttack, HeavyAttack, doubleAttack };
            // 냄비뚜껑 , 노목 ,
            // 자쿰의 투구 , 파란색 가운 , 아이젠 , 혼테일의 목걸이
            // 메이플 아이템들
            // 엘릭서 , hp , mp

            Player = new Player(100, 200, 100, 200, new Inventory(), "kim", 500, MonsterSkillset, false, 50, 500, ClassName.전사);

            //Armor(string name, string text, int price, ItemType type,int armorPoint , bool isEquipped)
            Armor zakumHelmet = new Armor("ZakumHelmet", "자쿰의 투구", 10000, ItemType.Armor, 100);
            Armor horntailNecklace = new Armor("HorntailNecklace", "혼테일의 목걸이", 15000, ItemType.Armor, 150);
            Armor aijen = new Armor("Aijen", "아이젠", 1000, ItemType.Armor, 40);
            Armor blueGown = new Armor("BlueGown", "파란가운", 5000, ItemType.Armor, 80);

            //Weapon(string name, string text, int price, ItemType type, int attackPoint, bool isEquipped)
            //Absolute Labs
            Weapon WoodSword = new Weapon("WoodSword", "나무 검", 500, ItemType.Weapon, 50);
            Weapon WoodBow = new Weapon("WoodBow", "나무 활", 500, ItemType.Weapon, 50);
            Weapon WoodStaff = new Weapon("WoodStaff", "나무 스테프", 500, ItemType.Weapon, 50);
            Weapon WoodClaw = new Weapon("WoodClaw", "나무 아대", 500, ItemType.Weapon, 50);
            Weapon Woodknuckles = new Weapon("Woodknuckles", "나무 너클", 500, ItemType.Weapon, 50);

            Weapon MapleSword = new Weapon("MapleSword", "메이플 검", 1000, ItemType.Weapon, 100);
            Weapon MapleBow = new Weapon("MapleBow", "메이플 활", 1000, ItemType.Weapon, 100);
            Weapon MapleStaff = new Weapon("MapleStaff", "메이플 스테프", 1000, ItemType.Weapon, 100);
            Weapon MapleClaw = new Weapon("MapleClaw", "메이플 아대", 1000, ItemType.Weapon, 100);
            Weapon Mapleknuckles = new Weapon("knuckles", "메이플 너클", 1000, ItemType.Weapon, 100);

            Weapon AbsoluteSword = new Weapon("AbsoluteSword", "앱솔루트 검", 5000, ItemType.Weapon, 200);
            Weapon AbsoluteBow = new Weapon("AbsoluteBow", "앱솔루트 활", 5000, ItemType.Weapon, 200);
            Weapon AbsoluteStaff = new Weapon("AbsoluteStaff", "앱솔루트 스테프", 5000, ItemType.Weapon, 200);
            Weapon AbsoluteClaw = new Weapon("AbsoluteClaw", "앱솔루트 아대", 5000, ItemType.Weapon, 200);
            Weapon Absoluteknuckles = new Weapon("Absoluteknuckles", "앱솔루트 너클", 5000, ItemType.Weapon, 200);

            // Shiled(string name, string text, int price, ItemType type, int attackPoint, int armorPoint, bool isEquipped)
            Shiled potlid = new Shiled("potlid", "앱솔루트 아대", 5000, ItemType.Shield, 50,50);
            Shiled nomok = new Shiled("nomok", "노가다 목장갑", 50000, ItemType.Shield, 200,200);

            //Potion(string name, string text, int price, ItemType type, int HealPoint)
            Potion HP = new Potion("HP", "체력회복 포션", 500, ItemType.Potion, 100);
            Potion MP = new Potion("MP", "마나회복 포션", 500, ItemType.Potion, 100);


            //엘릭서 추가
            Shop.Inventory.Add(aijen);
            Shop.Inventory.Add(blueGown);

            Shop.Inventory.Add(MapleSword);
            Shop.Inventory.Add(MapleBow);
            Shop.Inventory.Add(MapleStaff);
            Shop.Inventory.Add(MapleClaw);
            Shop.Inventory.Add(Mapleknuckles);

            Shop.Inventory.Add(AbsoluteSword);
            Shop.Inventory.Add(AbsoluteBow);
            Shop.Inventory.Add(AbsoluteStaff);
            Shop.Inventory.Add(AbsoluteClaw);
            Shop.Inventory.Add(Absoluteknuckles);

            Shop.Inventory.Add(HP);
            Shop.Inventory.Add(MP);


            List<Item> MonsterDorpItems = new List<Item>() {WoodSword, WoodBow, WoodStaff, WoodClaw, Woodknuckles };
            List<Item> BossDorpItems = new List<Item>() { zakumHelmet , horntailNecklace };

            monsters.Add(new Monster(1, 5, 10, 10, 10, 5, 1, new Inventory(), 100, MonsterSkillset, true, 100, MonsterName.Snail, MonsterDorpItems));
            monsters.Add(new Monster(2, 8, 15, 15, 10, 8, 2, new Inventory(), 150, MonsterSkillset, true, 10, MonsterName.OrangeMushroom, MonsterDorpItems));
            monsters.Add(new Monster(3, 10, 20, 20, 10, 10, 2, new Inventory(), 200, MonsterSkillset, true, 10, MonsterName.RibbonPig, MonsterDorpItems));
            monsters.Add(new Monster(4, 12, 23, 23, 10, 12, 3, new Inventory(), 230, MonsterSkillset, true, 15, MonsterName.EvilEye, MonsterDorpItems));
            monsters.Add(new Monster(5, 15, 30, 30, 10, 15, 5, new Inventory(), 250, MonsterSkillset, true, 25, MonsterName.ironHog, MonsterDorpItems));
            monsters.Add(new Monster(6, 20, 35, 35, 10, 20, 7, new Inventory(), 280, MonsterSkillset , true, 15, MonsterName.Drake, MonsterDorpItems));
            monsters.Add(new Monster(7, 30, 50, 50, 10, 15, 12, new Inventory(), 350, MonsterSkillset, true, 5, MonsterName.StoneGolem, MonsterDorpItems));
            monsters.Add(new Monster(8, 50, 80, 80, 10, 15, 20, new Inventory(), 500, MonsterSkillset, true, 15, MonsterName.JuniorBalrog, MonsterDorpItems));

            monsters.Add(new Monster(9, 10000, 1, 1, 1, 10000, 10000, new Inventory(), 10000, MonsterSkillset, true, 100, MonsterName.AnUnnamedPigeon, BossDorpItems));

            // Dungoun(string name, int level, List<Monster> monsters)
            Dungoun dungounLevel1 = new Dungoun("1층", 1, monsters);
            Dungoun dungounLevel2 = new Dungoun("2층", 2, monsters.Skip(0).Take(4).ToList());
            Dungoun dungounLevel3 = new Dungoun("3층", 3, monsters.Skip(2).Take(5).ToList());
            Dungoun dungounLevel4 = new Dungoun("4층", 4, monsters.Skip(2).Take(7).ToList());
            Dungoun dungounLevel5 = new Dungoun("5층", 5, monsters.Skip(4).Take(7).ToList());
            Dungoun dungounLevel6 = new Dungoun("6층", 6, monsters.Skip(5).Take(8).ToList());
            Dungoun dungounLevel7 = new Dungoun("7층", 7, monsters.Skip(6).Take(8).ToList());
            Dungoun dungounLevel8 = new Dungoun("Boss", 8, monsters.Skip(8).ToList());
            //
            Dungouns.Add(dungounLevel1);
            Dungouns.Add(dungounLevel2);
            Dungouns.Add(dungounLevel3);



            //Quest(string name , string text , List<Item> reward , int gold , MonsterName target , int requestLevel)
            Quest quest1 = new Quest("기초퀘스트" , "시작할때 받는 달팽이 사냥 퀘스트입니다." , MonsterDorpItems , 500 , MonsterName.Snail ,3 ,10);
            Quest quest2 = new Quest("중간퀘스트", "아이언호그 사냥 퀘스트입니다.", MonsterDorpItems, 500, MonsterName.ironHog, 3, 10);
            Quest quest3 = new Quest("최종퀘스트", "정체 불명의 비둘기 사냥 퀘스트입니다.", BossDorpItems, 500, MonsterName.AnUnnamedPigeon, 3, 10);

            this.NPC = new NPC();
        }
        public void start()
        {
            Messages.Instance().ShowStart();

            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 1) sceneName = SceneName.ShowStatus;
            else if (inputNum == 2) sceneName = SceneName.Inventory; // 사실 필요없을 듯 합니다
            else if (inputNum == 3) sceneName = SceneName.Shop;
            else if (inputNum == 4) sceneName = SceneName.DungeonSelection;
            else if (inputNum == 5) return; //휴식
            else if (inputNum == 6) sceneName = SceneName.GameOver;
        }
        public void BattelStart() {
            Messages.Instance().ShowStart();
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
        public void ShowStatus() 
        {
            Messages.Instance().ShowStatus(Player);

            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 1)
            {
                sceneName = SceneName.ShowInventory;
            }
            else if (inputNum == 0)
            {
                sceneName = SceneName.Start;
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }
        }
        public void ShowInventory()
        {
            Messages.Instance().ShowInventory(Player);

            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if(inputNum == 1)
            {
                sceneName = SceneName.ManageEquipment;
            }
            else if (inputNum == 0)
            {
                sceneName = SceneName.ShowStatus;
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }

        }

        public void ManageEquipment(Player player)
        {
            Messages.Instance().ManageEquipment(Player);

            // 장착 매커니즘 
            //player.Equiped(player);

            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 0)
            {
                sceneName = SceneName.ShowInventory;
            }

            else
            {
                Messages.Instance().ErrorMessage();
            }
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

                if (player.IsDead = true)
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



        public void NPCText() //이름 수정
        {

            Messages.Instance().ShowNPC();
            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 0) // 0번 입력 시 시작 메뉴로 돌아가기
            {
                sceneName = SceneName.StartSetName;
            }
            else if (inputNum == 1)
            {
                sceneName = SceneName.Quest; // 퀘스트 씬으로 이동
            }
            else if (inputNum == 2) 
            {
                sceneName = SceneName.Rest; // 힐 씬으로 이동
            }
        }


        public void Rest()
        {
            Messages.Instance().ShowRest(Player);
            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 0)  // 0번 입력 시 시작 메뉴로 돌아가기
            {
                sceneName = SceneName.StartSetName;
            }
            else if (inputNum == 1) // 휴식 시도
            {
                bool healSuccess = NPC.Rest(Player);    // 골드 체크

                if (healSuccess)
                {
                    Messages.Instance().ShowHeal();  // 휴식 성공 메시지 출력
                }
                else
                {
                    Messages.Instance().ShowNoHeal();   // 휴식 실패 메시지 출력
                }
            }
            else
            {
                Messages.Instance().ErrorMessage(); // 이외 숫자 입력시 에러 메시지 출력
            }
        }

        /*

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

        */
    }
}
