using Sandbox.ModAPI.Interfaces;
using Sandbox.ModAPI.Ingame;

using System;
using System.Text;
using System.Collections.Generic;

using VRageMath;
using VRage.Game;

namespace Skeleton
{
    class Projector_Damage_Detection : Skeleton
    {

        // Aim of this script is to detect if your ship is missing blocks using a projector
        // In combat, this usually means the block has been destroyed.

        struct buildProgress
        {
            public int currentBlocks;
            public int totalBlocks;
        }

        void Main(string argument)
        {

            var blocks = new List<IMyTerminalBlock>();
            GridTerminalSystem.GetBlocksOfType<IMyProjector>(blocks);

            //TODO Deal with multiple projectors on the same grid nicely
            //(You might have something projecting a projectile that where
            // having missing blocks is expected
            for (var i = 0; i < blocks.Count; i++)
            {
                var projector = blocks[i] as IMyProjector;

                if (projector.CubeGrid == Me.CubeGrid)
                {
                    if (projector.RemainingBlocks > 0)
                    {
                        Echo("ZOMG STUFF IS MISSING");
                    }
                    else
                    {
                        Echo("Nothing to see here, everything is fine");
                    }
                }
            }
        }


    }
}
