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
        public Dungoun dungoun { get; set; }
        public List<Monster> monsters { get; set; }

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
                }
            }
        }
        public void init()
        {
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
    }
}
