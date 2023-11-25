/*
 * Networked version of a player
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongRaylib
{
    public class NetPlayer : Player
    {
        short id = -1; // not initialized

        NetPlayer(short id) : base()
        {
            this.id = id;
        }
        public short GetID()
        {
            return id;
        }
    }
}
