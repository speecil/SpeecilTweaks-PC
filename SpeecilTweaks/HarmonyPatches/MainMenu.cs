using HarmonyLib;
using HMUI;
using IPA.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SpeecilTweaks.HarmonyPatches
{
    internal class MainMenu
    {
        [HarmonyPatch]
        internal class MenuText
        {
            [HarmonyPatch(typeof(MainMenuViewController))]
            [HarmonyPatch("DidActivate")]
            internal class MainMenuViewControllerDidActivate
            {
                internal static void Postfix(ref UnityEngine.UI.Button ____soloButton, ref UnityEngine.UI.Button ____multiplayerButton, ref UnityEngine.UI.Button ____campaignButton, ref UnityEngine.UI.Button ____partyButton, bool firstActivation)
                {
                    Plugin.Instance.inMulti = false;
                    ____soloButton.GetComponentInChildren<HMUI.CurvedTextMeshPro>(____soloButton.gameObject).color = (Config.Instance.menuButtonColour);
                    ____multiplayerButton.GetComponentInChildren<HMUI.CurvedTextMeshPro>(____multiplayerButton.gameObject).color = (Config.Instance.menuButtonColour);
                    ____campaignButton.GetComponentInChildren<HMUI.CurvedTextMeshPro>(____campaignButton.gameObject).color = (Config.Instance.menuButtonColour);
                    ____partyButton.GetComponentInChildren<HMUI.CurvedTextMeshPro>(____partyButton.gameObject).color = (Config.Instance.menuButtonColour);
                    if (firstActivation)
                    {
                        if (Config.Instance.removeAllParticles)
                        {
                            foreach (var dust in Resources.FindObjectsOfTypeAll<ParticleSystem>())
                                if (dust.name == "DustPS") dust.gameObject.SetActive(false);
                        }
                        else
                        {
                            foreach (var dust in Resources.FindObjectsOfTypeAll<ParticleSystem>())
                                if (dust.name == "DustPS") dust.gameObject.SetActive(true);
                        }
                    }
                }
            }
            [HarmonyPatch(typeof(DefaultScenesTransitionsFromInit))]
            [HarmonyPatch("TransitionToNextScene")]
            internal class DefaultScenesTransitionsFromInitTransitionToNextScene
            {
                internal static void Prefix(ref bool goStraightToMenu, bool goStraightToEditor)
                {
                    if (Config.Instance.skipHealth)
                    {
                        goStraightToMenu = true;
                    }
                }
            }
            [HarmonyPatch(typeof(SettingsFlowCoordinator))]
            [HarmonyPatch("CancelSettings")]
            internal class SettingsFlowCoordinatorCancelSettings
            {
                internal static void Prefix(ref MainSettingsModelSO ____mainSettingsModel)
                {
                    if (Config.Instance.cancelReset)
                    {
                        ____mainSettingsModel.Save();
                    }
                }
            }
        }
    }
}
