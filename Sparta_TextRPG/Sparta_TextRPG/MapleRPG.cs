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
        public List<Dungeon> Dungouns { get; set; }
        public List<Quest> Quests { get; set; }
        private Quest selectedQuestTemp;
        private int selectedQuestIndex = 0;
        public int floor = 0;

        SceneName sceneName = new SceneName();
        public string inputName;
        public ClassName inputClassName;
        public Skill? Skill;
        public Monster TargetMonster;
        public MapleRPG()
        {
            init();
        }
        //가장 메인으로 돌아가는 함수
        public void Program()
        {
            sceneName = SceneName.MainScene;

            while (true)
            {

                Console.Clear();//새로운 문구를 출력전 이전문구 삭제

                switch (sceneName)
                {
                    case SceneName.MainScene:
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
                    case SceneName.DungeonSelection:
                        DungeonSelection();
                        break;
                    case SceneName.BattleStart:
                        BattleStart();
                        break;
                    case SceneName.SelectSkill:
                        SellectSkill();
                        break;
                    case SceneName.BattleAttackPhase:
                        BattleAttackPhase();
                        break;
                    case SceneName.BattleAttackMonster:
                        BattleAttackMonster();
                        break;
                    case SceneName.BattleMonsterPhase:
                        //BattelMonsterPhase();
                        break;
                    case SceneName.BattlePlayerWin:
                        //BattlePlayerWin();
                        break;
                    case SceneName.BattlePlayerLose:
                        //BattlePlayerLose();
                        break;
                    case SceneName.NPC:
                        NPCText();
                        break;
                    case SceneName.QuestList:
                        QuestList();
                        break;
                    case SceneName.QuestInfo:
                        QuestInfo();
                        break;
                    case SceneName.AcceptingQuest:
                        AcceptingQuest();
                        break;
                    case SceneName.ViewAcceptedQuest:
                        ViewAcceptedQuest();
                        break;
                    case SceneName.Rest:
                        Rest();
                        break;
                    case SceneName.RestSuccess:
                        RestSuccess();
                        break;
                    case SceneName.RestFail:
                        RestFail();
                        break;
                    case SceneName.ShowShop:
                        ShowShop();
                        break;
                    case SceneName.SellItem:
                        SellItem();
                        break;
                    case SceneName.BuyItem:
                        BuyItem();
                        break;
                    case SceneName.NotEnoughMoney:
                        NotEnoughMoney();
                        break;

                }
            }
        }
        public void init()
        {
            Shop = new Shop();
            monsters = new List<Monster>();
            Dungouns = new List<Dungeon>();
            //Player(int Level, int Exp, int MaxHp, int NowHp, int MaxMP, int AttacPoint, int ArmorPoint, Inventory inventory,string Name,int Gold, List< Skill > SkillList, bool IsDead, int EvasionRate, int MaxExp, ClassName className)

            // public Skill(string name, int criticalRate, string text, int damage, int mana, int level, int coolTime,int targetCount)
            Skill normalAttack = new Skill("NormalAttck", 50, "일반공격입니다.", 50, 5, 1, 10, 1);
            Skill HeavyAttack = new Skill("HeavyAttack", 50, "강공격입니다.", 150, 50, 5, 10, 1);
            Skill doubleAttack = new Skill("DoubleAttack", 50, "더블공격입니다.", 100, 10, 10, 20, 1);

            Skill threeSnails = new Skill("ThreeSnails", 50, "달팽이의 껍질을 던져 원거리의 적을 공격한다.", 10, 10, 10, 2, 1);

            Skill slashBlast = new Skill("Slash Blast", 50, "MP를 소비하여 주위의 적 다수를 동시에 공격한다.", 100, 20, 10, 20, 1);
            Skill energyBolt = new Skill("Energy Bolt", 50, "적에게 닿으면 폭발하는 에너지 응집체를 발사한다.", 90, 20, 10, 20, 1);
            Skill arrowBlow = new Skill("Arrow Blow", 50, "적을 향해 화살을 연속 발사한다.", 50, 20, 10, 20, 1);
            Skill luckySeven = new Skill("Lucky Seven", 50, "표창을 던져 전방의 적들을 공격한다.", 150, 20, 10, 20, 1);
            Skill somersaultKick = new Skill("Somersault Kick", 50, "적을 향해 화살을 연속 발사한다.", 50, 20, 10, 20, 1);

            Skill Origin = new Skill("Origin", 80, "필살기!!!!", 500, 100, 20, 100, 3);

            List<Skill> MonsterSkillset = new List<Skill>() { normalAttack, HeavyAttack, doubleAttack };
            // 냄비뚜껑 , 노목 ,
            // 자쿰의 투구 , 파란색 가운 , 아이젠 , 혼테일의 목걸이
            // 메이플 아이템들
            // 엘릭서 , hp , mp

            //Player(int MaxHp,int MaxMP, int AttacPoint, int ArmorPoint, string Name ,int Gold, List<Skill> SkillList, bool IsDead, int EvasionRate, int MaxExp , ClassName className)
            Player = new Player(100, 200, 100, 200, "kim", 500, MonsterSkillset, false, 50, 500, ClassName.전사);
            Player.SkillList.Add(threeSnails);
            Player.SkillList.Add(slashBlast);
            Player.SkillList.Add(Origin);

            Player.ActiveQuests = new List<Quest>(); // 퀘스트 리스트 

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
            Shield potlid = new Shield("potlid", "앱솔루트 아대", 5000, ItemType.Shield, 50, 50);
            Shield nomok = new Shield("nomok", "노가다 목장갑", 50000, ItemType.Shield, 200, 200);

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


            List<Item> MonsterDorpItems = new List<Item>() { WoodSword, WoodBow, WoodStaff, WoodClaw, Woodknuckles };
            List<Item> BossDorpItems = new List<Item>() { zakumHelmet, horntailNecklace };

            monsters.Add(new Monster(1, 5, 10, 10, 5, 1, 100, MonsterSkillset, 10, MonsterName.Snail, MonsterDorpItems));
            monsters.Add(new Monster(2, 8, 15,  10, 8, 2, 150, MonsterSkillset, 10, MonsterName.OrangeMushroom, MonsterDorpItems));
            monsters.Add(new Monster(3, 10, 20, 10, 10, 2, 200, MonsterSkillset, 10, MonsterName.RibbonPig, MonsterDorpItems));
            monsters.Add(new Monster(4, 12, 23, 10, 12, 3, 230, MonsterSkillset, 15, MonsterName.EvilEye, MonsterDorpItems));
            monsters.Add(new Monster(5, 15, 30, 10, 15, 5, 250, MonsterSkillset, 25, MonsterName.ironHog, MonsterDorpItems));
            monsters.Add(new Monster(6, 20, 35, 10, 20, 7, 280, MonsterSkillset, 15, MonsterName.Drake, MonsterDorpItems));
            monsters.Add(new Monster(7, 30, 50, 10, 15, 12, 350, MonsterSkillset, 5, MonsterName.StoneGolem, MonsterDorpItems));
            monsters.Add(new Monster(8, 50, 80, 10, 15, 20, 500, MonsterSkillset, 15, MonsterName.JuniorBalrog, MonsterDorpItems));


            monsters.Add(new Monster(9, 10000, 1, 1, 10000, 10000, 10000, MonsterSkillset, 100, MonsterName.AnUnnamedPigeon, BossDorpItems));


            // Dungoun(string name, int level, List<Monster> monsters)
            Dungeon dungounLevel1 = new Dungeon("1층", 1, monsters.Skip(0).Take(3).ToList());
            Dungeon dungounLevel2 = new Dungeon("2층", 2, monsters.Skip(1).Take(3).ToList());
            Dungeon dungounLevel3 = new Dungeon("3층", 3, monsters.Skip(2).Take(3).ToList());
            Dungeon dungounLevel4 = new Dungeon("4층", 4, monsters.Skip(3).Take(3).ToList());
            Dungeon dungounLevel5 = new Dungeon("5층", 5, monsters.Skip(4).Take(3).ToList());
            Dungeon dungounLevel6 = new Dungeon("6층", 6, monsters.Skip(5).Take(3).ToList());
            Dungeon dungounLevel7 = new Dungeon("7층", 7, monsters.Skip(6).Take(2).ToList());
            Dungeon dungounLevel8 = new Dungeon("Boss", 8, monsters.Skip(8).ToList());
            //
            Dungouns.Add(dungounLevel1);
            Dungouns.Add(dungounLevel2);
            Dungouns.Add(dungounLevel3);


            //Quest(string name , string text , List<Item> reward , int gold , MonsterName target , int requestLevel)

            Quests = new List<Quest>
            {
                new Quest(
                    "달팽이 사냥",
                    "시작할 때 받는 달팽이 사냥 퀘스트입니다.",
                    new List<Item>(), // 빈 리스트
                    300,
                    MonsterName.Snail,
                    3,
                    1
                ),
                new Quest(
                    "아이언 호그 사냥",
                    "아이언호그를 사냥하는 퀘스트입니다.",
                    new List<Item>(),
                    600,
                    MonsterName.ironHog,
                    3,
                    5
                ),
                new Quest(
                    "정체 불명의 비둘기 사냥",
                    "정체 불명의 비둘기를 처치하는 퀘스트입니다.",
                    new List<Item>(),
                    1000,
                    MonsterName.AnUnnamedPigeon,
                    1,
                    10
                )
            };



            this.NPC = new NPC();


        }
        public void start()
        {
            Messages.Instance().ShowStart();

            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 1) sceneName = SceneName.ShowStatus;
            else if (inputNum == 2) sceneName = SceneName.ShowShop;
            else if (inputNum == 3) sceneName = SceneName.DungeonSelection;
            else if (inputNum == 4) sceneName = SceneName.NPC;
            else if (inputNum == 5) sceneName = SceneName.GameOver;

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
            if (inputNum == 1)
            {
                sceneName = SceneName.StartSetClass;
            }
            else if (inputNum == 2)
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

            sceneName = SceneName.MainScene;

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
                sceneName = SceneName.MainScene;
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

            if (inputNum == 1)
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

            string input = Console.ReadLine();
            int inputNum = int.Parse(input);
            if(inputNum <= player.Inventory.Count() && inputNum > 0)
            {
                //장착 매커니즘
                player.Equiped(player.Inventory.GetItemByIndex(inputNum-1),player);

                // 하고 화면 다시 출력
                //sceneName = SceneName.ManageEquipment;
            }
            else if (inputNum == 0)
            {
                sceneName = SceneName.ShowInventory;
            }

            else
            {
                Messages.Instance().ErrorMessage();
            }
        }
        public void ShowShop()
        {
            Messages.Instance().ShowShop(Player,Shop);

            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 1)
            {
                sceneName = SceneName.BuyItem;
            }
            else if (inputNum == 2)
            {
                sceneName = SceneName.SellItem;
            }
            else if (inputNum == 0)
            {
                sceneName = SceneName.MainScene;
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }
        }
        public void BuyItem() //플레이어 입장에서 사는 거
        {
            Messages.Instance().BuyItem(Player, Shop);

            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if(inputNum <= Shop.Inventory.Count() && inputNum > 0)
            {
                if(Shop.SellItem(Player, inputNum-1))
                {
                    sceneName = SceneName.BuyItem;
                }
                else
                {
                    sceneName = SceneName.NotEnoughMoney;
                }

            }
            else if (inputNum == 0)
            {
                sceneName= SceneName.ShowShop;
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }
        }
        public void SellItem() //플레이어 입장에서 파는 거
        {
            Messages.Instance().SellItem(Player, Shop);

            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum <= Player.Inventory.Count() && inputNum > 0)
            {
                Shop.BuyItem(Player, inputNum-1);
            }
            else if (inputNum == 0)
            {
                sceneName = SceneName.ShowShop;
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }
        }
        public void NotEnoughMoney()
        {
            Messages.Instance().NotEnoughMoney();

            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            sceneName = SceneName.BuyItem;
            
        }

        //미완
        public void DungeonSelection()
        {
            Messages.Instance().ShowDungeonSelection(Dungouns);
            string str = Console.ReadLine();
            int inputNum;

            if(int.TryParse(str , out inputNum))
            {
                if(inputNum < Dungouns.Count+1)
                {
                    floor = inputNum - 1;
                    sceneName = SceneName.BattleStart;
                }
                else if (inputNum == Dungouns.Count + 1)
                {
                    int a = 0;
                    //여기서 플레이어 상태보기
                }
                else if(inputNum == Dungouns.Count + 2)
                {
                    int a = 0;
                    //여기서 표션 사용
                }
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }
        }
        public void BattleStart()
        {
            Messages.Instance().ShowBattleStart(Dungouns[floor].monsters, Player);
            string str = Console.ReadLine();
            int num = int.Parse(str);
            if (num == 1)
            {
                sceneName = SceneName.SelectSkill;
            }
        }
        public void SellectSkill()
        {
            Messages.Instance().ShowSellectSkill(Dungouns[floor].monsters, Player);
            string str = Console.ReadLine();
            int num = int.Parse(str);
            if (num < Player.SkillList.Count + 1)
            {
                Skill = Player.SkillList[num - 1];
                sceneName = SceneName.BattleAttackPhase;
            }

        }
        public void BattleAttackPhase()// 던전에 이미 몬스터수가 정해짐
        {
            Messages.Instance().ShowBattleAttackPhase(Dungouns[floor].monsters, Player);
            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 0) // 0 입력 시 전 화면으로 돌아가기
            {
                sceneName = SceneName.BattleStart;
            }
            else if (inputNum <= Dungouns[floor].monsters.Count + 1) // 입력 시 대상 선택, 구현 몬하겠다 일단 넘기고
            {
                TargetMonster = Dungouns[floor].monsters[inputNum - 1];
                sceneName = SceneName.BattleAttackMonster;
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }
           
        }
        public void BattleAttackMonster()
        {

            this.Player.UseSkill(Skill);
            int Damage = TargetMonster.Hit(Skill, Player.AttackPoint);

            Messages.Instance().ShowBattleAttackMonster(TargetMonster, Player, Damage);

            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            bool isAllDeath = false; // 한 마리라도 살아있으면 true로 변경

            for (int i = 0; i < Dungouns[floor].monsters.Count; i++)
            {
                if (Dungouns[floor].monsters[i].IsDead == false)
                {
                    isAllDeath = true;
                }
            }
            if (isAllDeath = false)
            {
                sceneName = SceneName.BattlePlayerWin;
            }
            else
            {
                sceneName = SceneName.BattleStart;
            }
        }
        public void BattleMonsterPhase(List<Monster> monsters, Skill PlayerSKill, Player player)
        {
            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            //몬스터리스트 받아서 추가 = 모든 몬스터가 한 대 씩 때리기 때문.
            for (int i = 0; i < monsters.Count; i++)
            {
                Messages.Instance().ShowBattleMonsterPhase(monsters[i], Player, Player.SkillList[0]);
                player.NowHP -= (monsters[i].AttackPoint - player.ArmorPoint);
                // 데미지 공식 = 몬스터 공격력 - 플레이어 방어력

                if (player.IsDead = true)
                {
                    // 플레이어 사망 시 패배 씬으로 들어가기
                    sceneName = SceneName.BattlePlayerLose;
                }

                if (inputNum == 0)
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
                sceneName = SceneName.BattleAttackPhase;
            }

             
        }
        public void BattlePlayerWin(List<Monster> monsters, Player player)
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
                sceneName = SceneName.StartSetName;
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
        public void NPCText()   // 여관(NPC) 메뉴 보기
        {

            Messages.Instance().ShowNPC();
            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 0) // 0번 입력 시 메인 메뉴로 돌아가기
            {
                sceneName = SceneName.MainScene;
            }
            else if (inputNum == 1)
            {
                sceneName = SceneName.QuestList; // 퀘스트 씬으로 이동
            }
            else if (inputNum == 2)
            {
                sceneName = SceneName.Rest; // 휴식하기 씬으로 이동
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }
        }

        public void QuestList() // 퀘스트 목록 보기
        {
            // 수락하지 않은 퀘스트만 따로 추림
            List<Quest> availableQuests = Quests.Where(q => !Player.ActiveQuests.Contains(q)).ToList();

            Messages.Instance().ShowQuestList(availableQuests);

            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 0)
            {
                sceneName = SceneName.NPC;
            }
            else if (inputNum >= 1 && inputNum <= availableQuests.Count)
            {
                selectedQuestIndex = inputNum - 1;
                // 선택된 퀘스트는 필터링된 리스트에서 가져와야 함!
                selectedQuestTemp = availableQuests[selectedQuestIndex];
                sceneName = SceneName.QuestInfo;
            }
            else if (inputNum == availableQuests.Count + 1)
            {
                sceneName = SceneName.ViewAcceptedQuest;
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }
        }

        public void QuestInfo()
        {
            Quest selectedQuest = selectedQuestTemp;
            Messages.Instance().ShowQuestInfo(selectedQuest);

            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 0)
            {
                sceneName = SceneName.QuestList;
            }
            else if (inputNum == 1)
            {
                if (Player.ActiveQuests.Contains(selectedQuest))
                {
                    sceneName = SceneName.AlreadyAcceptedQuest;
                }
                else
                {
                    sceneName = SceneName.AcceptingQuest;
                }
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }
        }


        public void AcceptingQuest()    // 퀘스트 수락 알림 메시지
        {
            Quest selectedQuest = Quests[selectedQuestIndex];
            Player.ActiveQuests.Add(selectedQuest);

            Messages.Instance().ShowAcceptingQuest(selectedQuest.Name);  // 퀘스트 이름 넘겨주기
            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 0)  
            {
                sceneName = SceneName.QuestList; // 0번 입력 시 퀘스트 목록으로 돌아가기 
            }
            else
            {
                Messages.Instance().ErrorMessage(); // 이외 숫자 입력시 에러 메시지 출력
            }
        }


        public void ViewAcceptedQuest() // 수락한(진행 중인) 퀘스트 보기
        {
            Messages.Instance().ShowViewAcceptedQuest(Player.ActiveQuests);
            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 0)  // 0번 입력 시 퀘스트 목록으로 돌아가기 
            {
                sceneName = SceneName.QuestList;
            }
            else
            {
                Messages.Instance().ErrorMessage(); // 이외 숫자 입력시 에러 메시지 출력
            }
        }

        public void Rest()  // 휴식 
        {
            Messages.Instance().ShowRest(Player);
            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 0)  // 0번 입력 시 메인 메뉴로 돌아가기
            {
                sceneName = SceneName.MainScene;
            }
            else if (inputNum == 1) // 휴식 시도
            {
                bool healSuccess = NPC.Rest(Player);    // 골드 체크

                if (healSuccess)
                {
                    sceneName = SceneName.RestSuccess;  // 휴식 성공
                }
                else
                {
                    sceneName = SceneName.RestFail; // 휴식 실패
                }
            }                                                                   
            else
            {
                Messages.Instance().ErrorMessage(); // 이외 숫자 입력시 에러 메시지 출력
            }
        }

        public void RestSuccess()   // 휴식 성공
        {
            Messages.Instance().ShowRestSuccess(Player);  // 휴식 성공 메시지 출력
            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 0)  // 0번 입력 시 여관(NPC) 메뉴로 돌아가기
            {
                sceneName = SceneName.NPC;
            }
            else
            {
                Messages.Instance().ErrorMessage(); // 이외 숫자 입력시 에러 메시지 출력
            }
        }

        public void RestFail()  // 휴식 실패
        {
            Messages.Instance().ShowRestFail();  // 휴식 성공 메시지 출력
            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 0)  // 0번 입력 시 여관(NPC) 메뉴로 돌아가기
            {
                sceneName = SceneName.NPC;
            }
            else
            {
                Messages.Instance().ErrorMessage(); // 이외 숫자 입력시 에러 메시지 출력
            }

        }
    }
}
