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
        달팽이,
        슬라임,
        옥토퍼스,
        리본돼지,
        주황버섯,
        페어리,
        예티,
        페페,
        이블아이,
        루팡,
        아이언호그,
        스톤골렘,
        드레이크,
        돌의정령,
        머쉬맘,
        주니어발록,
        핑크빈,
        이름_모를_비둘기,
        //달팽이, 리본돼지, 주황버섯, 이블아이, 아이언호그, 스톤골렘, 드레이크, 주니어발록, 이름 모를 비둘기
    }

    enum SceneName
    {
        None,
        MainScene,

        ShowStatus,
        ShowInventory,
        ManageEquipment,
        // 상태보기

        StartSetName,
        StartChackName,
        StartSetClass,
        Staters,
        Inventory,
        Shop,
        DungeonSelection,

        NPC,
        QuestList,
        QuestInfo,
        AcceptingQuest,
        QuestCompleted,
        ViewAcceptedQuest,
        Rest,
        RestSuccess,
        RestFail,

        BattleStart,
        BattleAttackPhase,
        SelectSkill,
        BattleAttackMonster,
        BattleMonsterPhase,
        BattlePlayerWin,
        LevelUp,
        BattlePlayerLose,
        DrinkingPotion,
        DrinkingHpPotion,
        DrinkingMpPotion,
        InDungeon,

        ShowShop,
        SellItem,
        BuyItem,
        NotEnoughMoney,

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

    enum PotionType
    {
        None,
        HP,
        MP,
        Alixir
    }
}
