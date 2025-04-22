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
        None,Snail,RibbonPig, OrangeMushroom, EvilEye, ironHog, StoneGolem, Drake, JuniorBalrog, AnUnnamedPigeon
        //달팽이, 리본돼지, 주황버섯, 이블아이, 아이언호그, 스톤골렘, 드레이크, 주니어발록, 이름 모를 비둘기
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

        GameOver,//게임종료
    }


}
