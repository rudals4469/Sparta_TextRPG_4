using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TextRPG
{
    internal class MapleRPG
    {
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

        }
        public void start()
        {
            Messages.Instance().ShowStart();
        }
    }
}
