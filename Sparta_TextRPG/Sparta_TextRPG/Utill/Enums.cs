using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TextRPG
{
    enum ClassName
    {
        None,
        전사,
        마법사,
        궁수,
        해적,
        도적,

    }
    enum SkillName
    {
        None,
    }

    enum MonsterName
    {
        None,
    }

    enum SceneName
    {
        None,
        Start,


        StartSetName,
        StartChackName,
        StartSetClass,
        Staters,
        Inventory,
        Shop,
        DungeonSelection,
        //힐링

        BattelStart,
        BattelAttackPhase,
        BattelAttackMonster,
        BattelMonsterPhase,
        BattlePlayerWin,
        BattlePlayerLose,
        NPC,
        InDungeon,

        GameOver,//게임종료

    }

    enum ItemType
    {
        None,
        Weapon,
        Armor,
        Shield,
        Potion,
    }
}
