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
       
        void Main(string argument)
        {
            var blocks = new List<IMyTerminalBlock>();
            GridTerminalSystem.GetBlocksOfType<IMyProjector>(blocks);

            for (var i = 0; i < blocks.Count; i++)
            {
                var projector = blocks[i] as IMyProjector;

                if (projector.CubeGrid == Me.CubeGrid)
                {
                    string[] projectorDetails = projector.DetailedInfo.Split('\n');

                    // Abritrarily index 3 is build progress
                    // and 4, if complete, is "Complete!"

                    // Check if index 3 exists
                    if (projectorDetails.Length >= 3)
                    {
                        // We only care about the progress count
                        string[] buildProgressString = projectorDetails[3].Split(' ');
                        string[] buildProgress = buildProgressString[2].Split('/');
                        Echo("Progess: " + buildProgress[0] + " of " + buildProgress[1]);
                        Echo(Me.CustomName);
                    }
                }
            }
        }


    }
}
