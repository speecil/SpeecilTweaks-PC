using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeecilTweaks.HarmonyPatches
{
    internal class Multi
    {
        [HarmonyPatch]
        internal class ButtonText
        {
            [HarmonyPatch(typeof(LobbySetupViewController))]
            [HarmonyPatch("DidActivate")]
            internal class LobbySetupViewControllerDidActivate
            {
                internal static void Postfix()
                {
                    Plugin.Instance.inMulti = true;
                }
            }
        }
    }
}
