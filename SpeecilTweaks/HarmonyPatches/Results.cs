using HarmonyLib;
using System.Linq;
using UnityEngine;

namespace SpeecilTweaks.HarmonyPatches
{
    internal class ResultsTweaks
    {
        [HarmonyPatch(typeof(ResultsViewController))]
        [HarmonyPatch("SetDataToUI")]
        internal class ResultsViewControllerSetDataToUI
        {
            internal static void Postfix(ref UnityEngine.GameObject ____clearedBannerGo, ref UnityEngine.GameObject ____failedBannerGo)
            {
                ____clearedBannerGo.GetComponentInChildren<HMUI.CurvedTextMeshPro>().SetText(Config.Instance.resultText);
                ____failedBannerGo.GetComponentInChildren<HMUI.CurvedTextMeshPro>().SetText(Config.Instance.resultFailText);
                ____clearedBannerGo.GetComponentsInChildren<HMUI.ImageView>().FirstOrDefault().color = Config.Instance.rBackColour;
                ____failedBannerGo.GetComponentsInChildren<HMUI.ImageView>().FirstOrDefault().color = Config.Instance.rfBackColour;
                ____failedBannerGo.GetComponentsInChildren<HMUI.CurvedTextMeshPro>().FirstOrDefault().color = Color.white;
            }
        }

    }
}
