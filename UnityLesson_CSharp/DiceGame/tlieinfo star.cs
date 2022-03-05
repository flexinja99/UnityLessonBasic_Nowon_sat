using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    internal class TileInfo_star : TileInfo
    {
        public int starValue = 3;

        public override void TileEvent()
        {
            base.TileEvent();
            starValue++;// 플레이어가 획득할 수 있는 샛별 증가
        }
    }
}