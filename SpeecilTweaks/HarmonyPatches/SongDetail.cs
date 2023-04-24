using HarmonyLib;

namespace SpeecilTweaks.HarmonyPatches
{
    internal class SongDetailsTweaks
    {
        [HarmonyPatch(typeof(StandardLevelDetailView))]
        [HarmonyPatch("RefreshContent")]
        internal class StandardLevelDetailViewRefreshContent
        {
            internal static void Postfix(ref UnityEngine.UI.Button ____actionButton, ref UnityEngine.UI.Button ____practiceButton)
            {
                if (!Plugin.Instance.inMulti)
                {
                    if (Config.Instance.playButtonActive)
                    {
                        ____actionButton.gameObject.SetActive(true);
                        ____actionButton.GetComponentInChildren<HMUI.CurvedTextMeshPro>(____actionButton.gameObject).SetText(Config.Instance.playText);
                    }
                    else
                    {
                        ____actionButton.gameObject.SetActive(false);
                    }
                    if (Config.Instance.practiceButtonActive)
                    {
                        ____practiceButton.gameObject.SetActive(true);
                        ____practiceButton.GetComponentInChildren<HMUI.CurvedTextMeshPro>(____practiceButton.gameObject).SetText(Config.Instance.practiceText);
                    }
                    else
                    {
                        ____practiceButton.gameObject.SetActive(false);
                    }
                }

            }
        }

        [HarmonyPatch(typeof(PracticeViewController))]
        [HarmonyPatch("DidActivate")]

        internal class PracticeViewControllerDidActivate
        {
            internal static void Postfix(ref UnityEngine.UI.Button ____playButton)
            {
                ____playButton.GetComponentInChildren<HMUI.CurvedTextMeshPro>(____playButton.gameObject).SetText(Config.Instance.practiceText);
            }
        }
    }
}
