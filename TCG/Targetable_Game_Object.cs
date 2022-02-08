using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TCG
{
    public abstract class Targetable_Game_Object
    {
        public int Attack_Point { get; set; }
        public int hp;
        public int Hp {
            get
            {
                return hp;
            }
            set 
            {
                hp = value;
                if (hp <= 0)
                {
                    Die();
                }
            } }
        public abstract void Die();
    }
}
