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
        public List<Dungeon> Dungeons { get; set; }
        public List<Quest> Quests { get; set; }
        private Quest selectedQuestTemp;
        private int selectedQuestIndex = 0;
        public int floor = 0;
        SceneName sceneName = new SceneName();        

        public string inputName;
        public ClassName inputClassName;
        public Skill? Skill;
        public Monster TargetMonster;
        public Dictionary<string, Skill> AllSkill = new Dictionary<string, Skill>();
        public List<Item> dorps;
        
        public MapleRPG()
        {
            init();
        }
        //가장 메인으로 돌아가는 함수
        public void Program()
        {
            sceneName = SceneName.StartSetName;
                while (true)
                {

                try {                    
                    Console.Clear();//새로운 문구를 출력전 이전문구 삭제
                    Messages.Instance().ConsoleSPMS();

                    switch (sceneName)
                    {
                        case SceneName.MainScene:
                            MainScene();
                            break;
                        case SceneName.StartSetName:
                            StartSetName();
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
                        case SceneName.LevelUp:
                            LevelUp();
                            break;
                        case SceneName.DungeonSelection:
                            DungeonSelection();
                            break;
                        case SceneName.BattleStart:
                            BattleStart();
                            break;
                        case SceneName.SelectSkill:
                            SelectSkill();
                            break;
                        case SceneName.BattleAttackPhase:
                            BattleAttackPhase();
                            break;
                        case SceneName.BattleAttackMonster:
                            BattleAttackMonster();
                            break;
                        case SceneName.BattleMonsterPhase:
                            BattleMonsterPhase();
                            break;
                        case SceneName.BattlePlayerWin:
                            BattlePlayerWin();
                            break;
                        case SceneName.BattlePlayerLose:
                            BattlePlayerLose();
                            break;
                        case SceneName.DrinkingPotion:
                            DrinkingPotion(Player);
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
                        case SceneName.QuestCompleted:
                            QuestCompleted();
                            break;
                        case SceneName.ReceiveQuestReward:
                            ReceiveQuestReward();
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
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

            }

        }
        public void init()
        {
            Shop = new Shop();
            monsters = new List<Monster>();
            Dungeons = new List<Dungeon>();
            dorps = new List<Item>();
            //Player(int Level, int Exp, int MaxHp, int NowHp, int MaxMP, int AttacPoint, int ArmorPoint, Inventory inventory,string Name,int Gold, List< Skill > SkillList, bool IsDead, int EvasionRate, int MaxExp, ClassName className)
            // 크확 데미지(배수) 마나 레벨 쿨타임 타겟수
            // public Skill(string name, int criticalRate, string text, int damage, int mana, int level, int coolTime,int targetCount)
            Skill normalAttack = new Skill("NormalAttck", 20, "일반공격입니다.", 1, 0, 1, 0, 1);
            Skill HeavyAttack = new Skill("HeavyAttack", 20, "강공격입니다.", 1.3f, 4, 5, 1, 1);
            Skill doubleAttack = new Skill("DoubleAttack", 20, "더블공격입니다.", 2, 5, 10, 2, 1);

            Skill threeSnails = new Skill("ThreeSnails", 20, "달팽이의 껍질을 던져 원거리의 적을 공격한다.", 1.2f, 4, 10, 1, 1);

            Skill PowerStrike = new Skill("Power Strike", 20, "MP를 소비하여 강하게 공격한다.", 1.5f, 5, 10, 2, 1);
            Skill energyBolt = new Skill("Energy Bolt", 20, "적에게 닿으면 폭발하는 에너지 응집체를 발사한다.", 1.7f, 8, 10, 2, 1);
            Skill arrowBlow = new Skill("Arrow Blow", 20, "적을 향해 화살을 연속 발사한다.", 1.5f, 5, 10, 2, 1);
            Skill luckySeven = new Skill("Lucky Seven", 20, "표창을 던져 전방의 적들을 공격한다.", 1.5f, 5, 10, 2, 1);
            Skill somersaultKick = new Skill("Somersault Kick", 20, "적을 향해 화살을 연속 발사한다.", 1.5f, 5, 10, 2, 1);

            Skill Origin = new Skill("Origin", 20, "필살기!!!!", 3f, 20, 20, 5, 3);

            AllSkill.Add("NormalAttck", normalAttack);
            AllSkill.Add("HeavyAttack", HeavyAttack);
            AllSkill.Add("DoubleAttack", doubleAttack);

            AllSkill.Add("ThreeSnails", threeSnails);

            AllSkill.Add("Slash Blast", PowerStrike);
            AllSkill.Add("Energy Bolt", energyBolt);
            AllSkill.Add("Arrow Blow", arrowBlow);
            AllSkill.Add("Lucky Seven", luckySeven);
            AllSkill.Add("Somersault Kick", somersaultKick);

            AllSkill.Add("Origin", Origin);
            List<Skill> MonsterSkillset = new List<Skill>() { normalAttack, HeavyAttack, doubleAttack };
            // 냄비뚜껑 , 노목
            // 자쿰의 투구 , 파란색 가운 , 아이젠 , 혼테일의 목걸이
            // 메이플 아이템들
            // 엘릭서 , hp , mp

             

            //Armor(string name, string text, int price, ItemType type,int armorPoint , bool isEquipped)
            Armor zakumHelmet = new Armor("ZakumHelmet", "자쿰의 투구    ", 10000, ItemType.Armor, 5);
            Armor horntailNecklace = new Armor("HorntailNecklace", "혼테일의 목걸이", 15000, ItemType.Armor, 7);
            Armor aijen = new Armor("Aijen", "아이젠         ", 1000, ItemType.Armor, 2);
            Armor blueGown = new Armor("BlueGown", "파란가운       ", 5000, ItemType.Armor, 4);

            // Armor 퀘스트 보상 전용 아이템
            Armor orangeMushroomHat = new Armor("OrangeMushroomHat", "주황버섯 모자", 300, ItemType.Armor, 1);
            Armor ironHogSteelArmor = new Armor("IronHogSteelArmor", "아이언호그 강철 갑옷", 1000, ItemType.Armor, 3);
            
            //Weapon(string name, string text, int price, ItemType type, int attackPoint, bool isEquipped)
            //Absolute Labs
            Weapon WoodSword = new Weapon("WoodSword", "나무 검", 500, ItemType.Weapon, 2);
            Weapon WoodBow = new Weapon("WoodBow", "나무 활", 500, ItemType.Weapon, 2);
            Weapon WoodStaff = new Weapon("WoodStaff", "나무 스테프", 500, ItemType.Weapon, 2);
            Weapon WoodClaw = new Weapon("WoodClaw", "나무 아대", 500, ItemType.Weapon, 2);
            Weapon Woodknuckles = new Weapon("Woodknuckles", "나무 너클", 500, ItemType.Weapon, 2);

            Weapon MapleSword = new Weapon("MapleSword", "메이플 검      ", 1000, ItemType.Weapon, 5);
            Weapon MapleBow = new Weapon("MapleBow", "메이플 활      ", 1000, ItemType.Weapon, 5);
            Weapon MapleStaff = new Weapon("MapleStaff", "메이플 스테프  ", 1000, ItemType.Weapon, 5);
            Weapon MapleClaw = new Weapon("MapleClaw", "메이플 아대    ", 1000, ItemType.Weapon, 5);
            Weapon Mapleknuckles = new Weapon("knuckles", "메이플 너클    ", 1000, ItemType.Weapon, 5);

            Weapon AbsoluteSword = new Weapon("AbsoluteSword", "앱솔루트 검    ", 5000, ItemType.Weapon, 8);
            Weapon AbsoluteBow = new Weapon("AbsoluteBow", "앱솔루트 활    ", 5000, ItemType.Weapon, 8);
            Weapon AbsoluteStaff = new Weapon("AbsoluteStaff", "앱솔루트 스테프", 5000, ItemType.Weapon, 8);
            Weapon AbsoluteClaw = new Weapon("AbsoluteClaw", "앱솔루트 아대  ", 5000, ItemType.Weapon, 8);
            Weapon Absoluteknuckles = new Weapon("Absoluteknuckles", "앱솔루트 너클  ", 5000, ItemType.Weapon, 8);

            // Weapon 퀘스트 보상 전용 아이템
            Weapon DrakeKnife = new Weapon("DrakeKnife", "드레이크의 송곳니 칼    ", 800, ItemType.Weapon, 4);

            // Shiled(string name, string text, int price, ItemType type, int attackPoint, int armorPoint, bool isEquipped)
            Shield potlid = new Shield("potlid", "냄비 뚜껑      ", 5000, ItemType.Shield, 8, 8);
            Shield nomok = new Shield("nomok", "노가다 목장갑  ", 1500, ItemType.Shield, 5, 5);


            //Potion(string name, string text, int price, ItemType type, int HealPoint)
            Potion HP = new Potion("HP", "체력회복 포션  ", 500, PotionType.HP, 100,ItemType.Potion);
            Potion MP = new Potion("MP", "마나회복 포션  ", 500, PotionType.MP, 100,ItemType.Potion);
            Potion Alixir = new Potion("Alixir", "엘릭서         ", 1000, PotionType.Alixir, 500, ItemType.Potion);

            Shop.Inventory.Add(nomok);
            Shop.Inventory.Add(potlid);

            Shop.Inventory.Add(aijen);
            Shop.Inventory.Add(blueGown);
            Shop.Inventory.Add(zakumHelmet);
            Shop.Inventory.Add(horntailNecklace);

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
            Shop.Inventory.Add(Alixir);


            List<Item> MonsterDorpItems = new List<Item>() { MapleSword, WoodBow, WoodStaff, WoodClaw, Woodknuckles };
            List<Item> BossDorpItems = new List<Item>() { zakumHelmet, horntailNecklace };
            //                   레벨경험치hp mp 공격력 방어력             회피율
            monsters.Add(new Monster(1, 5, 10, 10, 5, 1, 100, MonsterSkillset, 10, MonsterName.달팽이, MonsterDorpItems));
            monsters.Add(new Monster(2, 8, 12, 10, 6, 1, 100, MonsterSkillset, 10, MonsterName.슬라임, MonsterDorpItems));
            monsters.Add(new Monster(2, 8, 8, 10, 6, 1, 100, MonsterSkillset, 20, MonsterName.옥토퍼스, MonsterDorpItems));
            monsters.Add(new Monster(3, 10, 15, 10, 10, 2, 200, MonsterSkillset, 10, MonsterName.리본돼지, MonsterDorpItems));
            monsters.Add(new Monster(4, 12, 17,  10, 10, 2, 200, MonsterSkillset, 10, MonsterName.주황버섯, MonsterDorpItems));
            monsters.Add(new Monster(4, 12, 12, 10, 10, 2, 200, MonsterSkillset, 20, MonsterName.페어리, MonsterDorpItems));
            monsters.Add(new Monster(5, 15, 20, 10, 12, 2, 200, MonsterSkillset, 10, MonsterName.예티, MonsterDorpItems));
            monsters.Add(new Monster(5, 15, 20, 10, 12, 2, 200, MonsterSkillset, 10, MonsterName.페페, MonsterDorpItems));
            monsters.Add(new Monster(6, 18, 23, 10, 12, 3, 230, MonsterSkillset, 15, MonsterName.이블아이, MonsterDorpItems));
            monsters.Add(new Monster(6, 18, 15, 10, 17, 3, 230, MonsterSkillset, 15, MonsterName.루팡, MonsterDorpItems));
            monsters.Add(new Monster(7, 20, 28, 10, 15, 5, 250, MonsterSkillset, 25, MonsterName.아이언호그, MonsterDorpItems));
            monsters.Add(new Monster(8, 25, 30, 10, 15, 12, 350, MonsterSkillset, 15, MonsterName.스톤골렘, MonsterDorpItems));
            monsters.Add(new Monster(9, 30, 35, 10, 20, 7, 280, MonsterSkillset, 15, MonsterName.드레이크, MonsterDorpItems));
            monsters.Add(new Monster(15, 30, 50, 10, 20, 15, 280, MonsterSkillset, 15, MonsterName.돌의정령, MonsterDorpItems));
            monsters.Add(new Monster(10, 35, 50, 10, 25, 20, 500, MonsterSkillset, 15, MonsterName.머쉬맘, MonsterDorpItems));
            monsters.Add(new Monster(11, 40, 80, 10, 25, 20, 500, MonsterSkillset, 15, MonsterName.주니어발록, MonsterDorpItems));
            monsters.Add(new Monster(12, 50, 150, 10, 35, 20, 2000, MonsterSkillset, 15, MonsterName.핑크빈, MonsterDorpItems));
            monsters.Add(new Monster(13, 100, 200, 10, 45, 20, 10000, MonsterSkillset, 25, MonsterName.이름_모를_비둘기, BossDorpItems));


            // Dungoun(string name, int level, List<Monster> monsters)
            Dungeon dungounLevel1 = new Dungeon("1층  ", 1, monsters.Skip(0).Take(4).ToList());
            Dungeon dungounLevel2 = new Dungeon("2층  ", 2, monsters.Skip(2).Take(4).ToList());
            Dungeon dungounLevel3 = new Dungeon("3층  ", 3, monsters.Skip(4).Take(4).ToList());
            Dungeon dungounLevel4 = new Dungeon("4층  ", 4, monsters.Skip(6).Take(4).ToList());
            Dungeon dungounLevel5 = new Dungeon("5층  ", 5, monsters.Skip(8).Take(4).ToList());
            Dungeon dungounLevel6 = new Dungeon("6층  ", 6, monsters.Skip(10).Take(4).ToList());
            Dungeon dungounLevel7 = new Dungeon("7층  ", 7, monsters.Skip(12).Take(2).ToList());
            Dungeon dungounLevel8 = new Dungeon("Boss ", 8, monsters.Skip(14).Take(3).ToList());
            Dungeon dungounLevel9 = new Dungeon("Hiden", 9, monsters.Skip(17).ToList());
            //
            Dungeons.Add(dungounLevel1);
            Dungeons.Add(dungounLevel2);
            Dungeons.Add(dungounLevel3);
            Dungeons.Add(dungounLevel4);
            Dungeons.Add(dungounLevel5);
            Dungeons.Add(dungounLevel6);
            Dungeons.Add(dungounLevel7);
            Dungeons.Add(dungounLevel8);
            Dungeons.Add(dungounLevel9);

            for (int i = 0; i < Dungeons.Count; i++)
            {
                Dungeons[i].DungeonReset();
            }


            //Quest(string name , string text , List<Item> reward , int gold , MonsterName target , int requestLevel)

            Quests = new List<Quest>
            {
                new Quest(
                    "달팽이 처치하기",
                    "시작할 때 받는 달팽이 사냥 퀘스트입니다.         │\n│  달팽이 3 마리를 처치하세요.                      │",
                    new List<Item>(), // 아이템 보상
                    1000,             // 보상 골드
                    MonsterName.달팽이,    // 잡을 몬스터
                    0,                     // 목표 처치 수 
                    1                      // 퀘스트 요구 레벨
                ),
                new Quest(
                    "주황버섯 처치하기",
                    "주황버섯 5 마리를 처치하세요.",
                    new List<Item>() { orangeMushroomHat },
                    1500,
                    MonsterName.주황버섯,
                    5,
                    2
                ),
                new Quest(
                    "이블아이 처치하기",
                    "이블아이 4 마리를 처치하세요.",
                    new List<Item>(),
                    2000,
                    MonsterName.이블아이,
                    4,
                    4
                ),

                new Quest(
                    "아이언호그 처치하기",
                    "아이언호그 3 마리를 처치하세요.",
                    new List<Item> { ironHogSteelArmor } ,
                    5000,
                    MonsterName.아이언호그,
                    3,
                    5
                ),
                new Quest(
                    "드레이크 처치하기",
                    "드레이크 2 마리를 처치하세요.",
                    new List<Item>() { DrakeKnife },
                    7000,
                    MonsterName.드레이크,
                    2,
                    7
                ),
                new Quest(
                    "정체 불명의 비둘기 처치하기",
                    "정체 불명의 비둘기 1 마리를 처치하세요.",
                    new List<Item>(),
                    50000,
                    MonsterName.이름_모를_비둘기,
                    1,
                    10
                )
            };



            this.NPC = new NPC();


        }
        public void MainScene()
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
        public void StartSetName()
        {
            Messages.Instance().ShowStartSetName();
            inputName = Console.ReadLine();

            sceneName = SceneName.StartChackName;
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
            {   // hp , mp , 공격력, 방어력
                inputClassName = ClassName.전사;
                List<Skill> WarriorSkill = new List<Skill>();
                WarriorSkill.Add(AllSkill["NormalAttck"]);
                WarriorSkill.Add(AllSkill["HeavyAttack"]);
                WarriorSkill.Add(AllSkill["DoubleAttack"]);
                WarriorSkill.Add(AllSkill["ThreeSnails"]);
                WarriorSkill.Add(AllSkill["Slash Blast"]);
                WarriorSkill.Add(AllSkill["Origin"]);
                Player = new Player(100, 50, 10, 5, inputName, 10000, WarriorSkill, false, 20, 15, ClassName.전사);
            }
            else if (inputNum == 2)
            {
                inputClassName = ClassName.법사;
                List<Skill> MagicianSkill = new List<Skill>();
                MagicianSkill.Add(AllSkill["NormalAttck"]);
                MagicianSkill.Add(AllSkill["HeavyAttack"]);
                MagicianSkill.Add(AllSkill["DoubleAttack"]);
                MagicianSkill.Add(AllSkill["ThreeSnails"]);
                MagicianSkill.Add(AllSkill["Slash Blast"]);
                MagicianSkill.Add(AllSkill["Origin"]);
                Player = new Player(50, 75, 15, 0, inputName, 10000, MagicianSkill, false, 20, 15, ClassName.법사);
            }
            else if (inputNum == 3)
            {
                inputClassName = ClassName.궁수;
                List<Skill> ArchorSkill = new List<Skill>();
                ArchorSkill.Add(AllSkill["NormalAttck"]);
                ArchorSkill.Add(AllSkill["HeavyAttack"]);
                ArchorSkill.Add(AllSkill["DoubleAttack"]);
                ArchorSkill.Add(AllSkill["ThreeSnails"]);
                ArchorSkill.Add(AllSkill["Slash Blast"]);
                ArchorSkill.Add(AllSkill["Origin"]);
                Player = new Player(75, 50, 12, 3, inputName, 10000, ArchorSkill, false, 25, 15, ClassName.궁수);
            }
            else if (inputNum == 4)
            {
                inputClassName = ClassName.도적;
                List<Skill> LogSkill = new List<Skill>();
                LogSkill.Add(AllSkill["NormalAttck"]);
                LogSkill.Add(AllSkill["HeavyAttack"]);
                LogSkill.Add(AllSkill["DoubleAttack"]);
                LogSkill.Add(AllSkill["ThreeSnails"]);
                LogSkill.Add(AllSkill["Slash Blast"]);
                LogSkill.Add(AllSkill["Origin"]);
                Player = new Player(75, 50, 15, 3, inputName, 10000, LogSkill, false, 30, 15, ClassName.도적);
            }
            else if (inputNum == 5)
            {
                inputClassName = ClassName.해적;
                List<Skill> PirateSkill = new List<Skill>();
                PirateSkill.Add(AllSkill["NormalAttck"]);
                PirateSkill.Add(AllSkill["HeavyAttack"]);
                PirateSkill.Add(AllSkill["DoubleAttack"]);
                PirateSkill.Add(AllSkill["ThreeSnails"]);
                PirateSkill.Add(AllSkill["Slash Blast"]);
                PirateSkill.Add(AllSkill["Origin"]);
                Player = new Player(100, 50, 12, 5, inputName, 10000, PirateSkill, false, 20, 15, ClassName.해적);
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }

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
                if(false) sceneName = SceneName.DungeonSelection;
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
        public void BuyItem() // 플레이어 입장에서 사는 거
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
            Messages.Instance().SellItem(Player, Shop); //

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
        public void LevelUp()
        {
            Messages.Instance().LevelUp(Player);

            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
        }
        public void DungeonSelection()
        {
            Messages.Instance().ShowDungeonSelection(Dungeons);
            string str = Console.ReadLine();
            int inputNum;

            if(int.TryParse(str , out inputNum))
            {
                if(inputNum == 0)
                {
                    sceneName = SceneName.MainScene;
                }
                else if(inputNum < Dungeons.Count+1)
                {
                    floor = inputNum - 1;
                    Dungeons[floor].DungeonReset();
                    sceneName = SceneName.BattleStart;
                }
                else if (inputNum == Dungeons.Count + 1)
                {
                    sceneName = SceneName.ShowStatus;
                }
                else if(inputNum == Dungeons.Count + 2)
                {
                    sceneName = SceneName.DrinkingPotion;
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
            Player.CoolDounSkill();

            Messages.Instance().ShowBattleStart(Dungeons[floor].monsters, Player);
            string str = Console.ReadLine();
            int num = int.Parse(str);
            if (num == 1)
            {
                sceneName = SceneName.SelectSkill;
            }
        }
        public void SelectSkill()
        {
            Messages.Instance().ShowSellectSkill(Dungeons[floor].monsters, Player);
            string str = Console.ReadLine();
            int num = int.Parse(str);
            if (num < Player.SkillList.Count + 1)
            {
                // 로직수정
                if (Player.SkillList[num - 1].NowCoolTime == Player.SkillList[num - 1].CoolTime)
                {
                    Skill = Player.SkillList[num - 1];
                    sceneName = SceneName.BattleAttackPhase;
                }
                else
                {
                    sceneName = SceneName.SelectSkill;
                    Messages.Instance().CoolTimeError();
                }
            }

        }
        public void BattleAttackPhase()// 던전에 이미 몬스터수가 정해짐
        {
            Messages.Instance().ShowBattleAttackPhase(Dungeons[floor].monsters, Player);
            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 0) // 0 입력 시 전 화면으로 돌아가기
            {
                sceneName = SceneName.BattleStart;
            }
            else if (inputNum <= Dungeons[floor].monsters.Count + 1) 
            {
                TargetMonster = Dungeons[floor].monsters[inputNum - 1];
                if(!TargetMonster.IsDead) sceneName = SceneName.BattleAttackMonster;
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }
           
        }
        public void BattleAttackMonster()
        {
            int monsterbeforHP = TargetMonster.NowHP;

            this.Player.UseSkill(Skill);
            int Damage = TargetMonster.Hit(Skill, Player.AttackPoint);

            Item? drop = null;
            if (TargetMonster.IsDead) drop = TargetMonster.DropItem();

            if (drop != null) dorps.Add(drop);

            Messages.Instance().ShowBattleAttackMonster(TargetMonster, monsterbeforHP, Player, Damage);

            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            bool isAllDeath = true; // 한 마리라도 살아있으면 true로 변경


            for (int i = 0; i < Dungeons[floor].monsters.Count; i++)
            {
                if (Dungeons[floor].monsters[i].IsDead == false)
                {
                    isAllDeath = false;
                }
            }

            if (isAllDeath)
            {
                sceneName = SceneName.BattlePlayerWin;
            }
            else
            {
                sceneName = SceneName.BattleMonsterPhase;
                //sceneName = SceneName.BattleStart;
            }
        }
        public void BattleMonsterPhase()
        {
            Messages.Instance().ShowBattleMonsterPhase();
            for (int i = 0; i < Dungeons[floor].monsters.Count; i++)
            {
                // 몬스터 다음사용스킬 저장
                //몬스터 다음스킬 턴수 확인하고 공격턴인지 확인
                if (Dungeons[floor].monsters[i].IsDead == false)
                {
                    int PlayerBeforHP = Player.NowHP;
                    Messages.Instance().ShowBattleMonsterHitPhase(Dungeons[floor].monsters[i], PlayerBeforHP, Player, Player.Hit(monsters[i].SkillList[0], monsters[i].AttackPoint));                   
                }
            }
            Messages.Instance().ShowBattleMonsterEndPhase();
            if (Player.IsDead == true)
            {
                // 플레이어 사망 시 패배 씬으로 들어가기
                sceneName = SceneName.BattlePlayerLose;
                return;
            }

            string input = Console.ReadLine();
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();


            if (consoleKeyInfo!=null) // 반복문 종료 후 0 입력 시 다시 플레이어 공격 턴으로 이동
            {
                sceneName = SceneName.BattleStart;
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }


        }
        public void BattlePlayerWin()
        {
            Messages.Instance().ShowBattlePlayerWin(Dungeons[floor].monsters, Player.NowHP, Player , dorps);

            foreach (var monster in Dungeonss[floor].monsters)
            {
                //Player.AddExp(monster.Exp);

                if(Player.AddExp(monster.Exp))
                {
                    // 업했으면 씬을 레벨업 씬으로 이동
                    //sceneName = SceneName.LevelUp;

                    //사실 이게 가장 쉬운방법이긴해;
                    LevelUp();
                }



                Player.Gold += (monster.Gold);

                foreach (var quest in Player.ActiveQuests)  // 퀘스트 진행도 올리기
                {
                    if (quest.Target == monster.MonsterName && !quest.IsComplete())
                    {
                        quest.Count++; // 진행도 증가
                    }
                }
            }

            Messages.Instance().ShowBattlePlayerWinLest();

            foreach (var item in dorps)
            {
                Player.Inventory.Add(item);
            }
            dorps.Clear(); //드롭템 초기화

            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 0) // 0번 입력 시 시작 메뉴로 돌아가기
            {
                sceneName = SceneName.MainScene;
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }

        }
        public void BattlePlayerLose()
        {
            Messages.Instance().ShowBattlePlayerLose(Player.NowHP, Player);
            //로직 추가


            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 0) // 0번 입력 시 시작 메뉴로 돌아가기
            {
                // 체력 10퍼로 회복시키고
                sceneName = SceneName.MainScene;
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }
        }
        public void DrinkingPotion(Player player)
        {
            Messages.Instance().DrinkingPotion(player);
            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 0)
            {
                sceneName = SceneName.DungeonSelection;
            }
            else if (inputNum == 1)
            {
                
                Potion hpPotion = player.Inventory.Potions.Find(p => p.PotionType == PotionType.HP);

                if (hpPotion != null)
                {
                    if (player.NowHP == player.MaxHP)
                    {
                        Messages.Instance().Full(hpPotion.PotionType);
                    }
                    else
                    {
                        int beforeHp = player.NowHP;
                        player.Inventory.usePotion(PotionType.HP, player);
                        Messages.Instance().DrinkingPotion(Player, beforeHp, hpPotion.PotionType);
                    }
                }
                else
                {
                    Messages.Instance().NoPotion();
                }
            }
            else if (inputNum == 2)
            {
                Potion mpPotion = player.Inventory.Potions.Find(p => p.PotionType == PotionType.MP);

                if (mpPotion != null)
                {
                    if (player.NowMP == player.MaxMP)
                    {
                        Messages.Instance().Full(mpPotion.PotionType);
                    }
                    else
                    {
                        int beforeMp = player.NowMP;
                        player.Inventory.usePotion(PotionType.MP, player);
                        Messages.Instance().DrinkingPotion(player, beforeMp, mpPotion.PotionType);
                    }
                }
                else
                {
                    Messages.Instance().NoPotion();
                }
            }
            else if (inputNum == 3)
            {
                Potion Alixir = player.Inventory.Potions.Find(p => p.PotionType == PotionType.Alixir);

                if (Alixir != null)
                {
                    if (player.NowHP == player.MaxHP)
                    {
                        Messages.Instance().Full(Alixir.PotionType);
                    }
                    else
                    {
                        int beforeHp = player.NowHP;
                        player.Inventory.usePotion(PotionType.Alixir, player);
                        Messages.Instance().DrinkingPotion(player, beforeHp, PotionType.Alixir);
                    }
                }
                else
                {
                    Messages.Instance().NoPotion();
                }
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
        public void QuestList()
        {
            List<Quest> availableQuests = Quests
                .Where(q => !Player.ActiveQuests.Contains(q) && Player.Level >= q.RequestLevel)
                .ToList();

            List<Quest> lockedQuests = Quests
                .Where(q => !Player.ActiveQuests.Contains(q) && Player.Level < q.RequestLevel)
                .ToList();

            bool hasUnclaimedReward = Player.ActiveQuests
                .Any(q => q.IsComplete() && !q.IsRewarded);

            Messages.Instance().ShowQuestList(availableQuests, lockedQuests, hasUnclaimedReward);

            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 0)
            {
                sceneName = SceneName.NPC;
            }
            else if (inputNum >= 1 && inputNum <= availableQuests.Count)
            {
                selectedQuestIndex = inputNum - 1;
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
        public void QuestInfo() // 퀘스트 정보 표시
        {
            Quest selectedQuest = selectedQuestTemp;
            Messages.Instance().ShowQuestInfo(selectedQuest);

            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 0)  // 0번 입력 시 퀘스트 목록으로 돌아가기
            {
                sceneName = SceneName.QuestList;
            }
            else if (inputNum == 1) // 퀘스트 수락 완료 창
            {
                sceneName = SceneName.AcceptingQuest;
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }
        }
        public void AcceptingQuest()    // 퀘스트 수락할 때 메시지
        {
            List<Quest> availableQuests = Quests.Where(q => !Player.ActiveQuests.Contains(q)).ToList();
            Quest selectedQuest = availableQuests[selectedQuestIndex]; 
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
        public void QuestCompleted()    // 퀘스트 완료 창
        {
            Quest completedQuest = selectedQuestTemp;

            Messages.Instance().ShowQuestCompleted(completedQuest);

            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 1)
            {
                Player.Gold += completedQuest.Gold;
                foreach (var item in completedQuest.Reward)
                {
                    Player.Inventory.Add(item);
                }
                completedQuest.IsRewarded = true;

                sceneName = SceneName.ReceiveQuestReward;
            }
            else if (inputNum == 0)
            {
                sceneName = SceneName.ViewAcceptedQuest;
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }
        }
        public void ReceiveQuestReward()    // 보상 받기 창
        {
            Messages.Instance().ShowReceiveQuestRewards(selectedQuestTemp, Player.Gold);

            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 0)
            {
                sceneName = SceneName.ViewAcceptedQuest;
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }
        }
        public void ViewAcceptedQuest()
        {
            var selectableQuests = Player.ActiveQuests
                .Where(q => q.IsComplete() && !q.IsRewarded)
                .ToList();

            // 보상 받을 퀘스트가 하나라도 있으면 true
            bool hasRewardableQuest = selectableQuests.Count > 0;

            Messages.Instance().ShowViewAcceptedQuest(Player.ActiveQuests, hasRewardableQuest);

            string input = Console.ReadLine();
            int inputNum = int.Parse(input);

            if (inputNum == 0)
            {
                sceneName = SceneName.QuestList;
            }
            else if (inputNum >= 1 && inputNum <= selectableQuests.Count)
            {
                selectedQuestTemp = selectableQuests[inputNum - 1];
                selectedQuestIndex = Player.ActiveQuests.IndexOf(selectedQuestTemp);
                sceneName = SceneName.QuestCompleted;
            }
            else
            {
                Messages.Instance().ErrorMessage();
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
