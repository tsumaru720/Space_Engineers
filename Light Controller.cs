using Sandbox.ModAPI.Interfaces;
using Sandbox.ModAPI.Ingame;

using System;
using System.Text;
using System.Collections.Generic;

using VRageMath;
using VRage.Game;


namespace Skeleton
{
    class Light_Cntroller : Skeleton
    {
        // The purpose of this script is to allow easy changing of light colour
        // on your ship or station. This currently only affects interior lights.
        //
        // This was originally written so my ship can have Red/Blue alert states
        // Call this script with argument red/blue to change all lights to red/blue.
        // You cam then change them to whatever colour you like when you return to normal.
        //
        // The only issue with this currently is that if you have different colour lights
        // in your normal state, then using this script will not keep previous colours.
        //
        // USAGE
        //
        // Call with either a keyword as an argument (red, blue, yellow)
        // Call with an RGB value (without spaces) such as 255,255,255

        Color LIGHT_COLOR = new Color(); 

        void Main(string argument)
        {
            if (argument.ToLower() == "red")
            {
                LIGHT_COLOR = new Color(255, 0, 0);
            }
            else if (argument.ToLower() == "blue")
            {
                LIGHT_COLOR = new Color(0, 0, 255);
            }
            else if (argument.ToLower() == "yellow")
            {
                LIGHT_COLOR = new Color(255, 160, 0);
            }
            else
            {
                string[] RGB = argument.Split(',');

                if (RGB.Length > 1)
                {
                    // Multiple elements, probably an RGB value :)
                    LIGHT_COLOR = new Color(Int32.Parse(RGB[0]), Int32.Parse(RGB[1]), Int32.Parse(RGB[2]));
                }
                else
                {
                    // Only one element, suggests an alias has been provided.
                    // Given We've got this far, looks like its an unknown colour alias

                    // Change lights to default (White) if there is a problem
                    LIGHT_COLOR = new Color(255, 255, 255);
                    Echo("Unknown colour alias provided");
                }
            }

            // We should now have a colour, lets set it!
            ColorLights(LIGHT_COLOR);
        }

        void ColorLights(Color NEW_COLOR)
        {
            var blocks = new List<IMyTerminalBlock>();
            GridTerminalSystem.GetBlocksOfType<IMyInteriorLight>(blocks);

            for (var i = 0; i < blocks.Count; i++)
            {
                var light = blocks[i] as IMyInteriorLight;
                if (light.CubeGrid == Me.CubeGrid)
                {
                    light.SetValue("Color", NEW_COLOR);
                }
            }
        }


    }
}
