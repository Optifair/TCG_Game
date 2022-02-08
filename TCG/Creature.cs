using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TCG
{
    public class Creature: Targetable_Game_Object
    {
        public Player Player { get;  set; }
        public string Name { get;  set; }
        public override void Die()
        {
            Player.Board.Remove(this);
        }

    }
}
