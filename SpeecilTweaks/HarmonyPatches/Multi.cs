using HarmonyLib;

namespace SpeecilTweaks.HarmonyPatches
{
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
