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
        internal class MultiCheck
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
