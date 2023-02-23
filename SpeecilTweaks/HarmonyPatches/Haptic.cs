using HarmonyLib;
using Libraries.HM.HMLib.VR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace SpeecilTweaks.HarmonyPatches
{
    internal class Haptic
    {
        [HarmonyPatch]
        internal class DisableHaptic
        {
            [HarmonyPatch(typeof(NoteCutHapticEffect))]
            [HarmonyPatch("HitNote")]
            internal class NoteCutHapticEffectHitNote
            {
                internal static void Prefix(ref HapticPresetSO ____normalPreset)
                {
                    if (Config.Instance.disableRumble)
                    {
                        ____normalPreset._strength = 0.0f;
                    }
                }
            }
            [HarmonyPatch(typeof(SliderHapticFeedbackInteractionEffect))]
            [HarmonyPatch("Vibrate")]
            internal class SliderHapticFeedbackInteractionEffectVibrate
            {
                internal static void Prefix(ref HapticPresetSO ____hapticPreset)
                {
                    if (Config.Instance.disableRumble)
                    {
                        ____hapticPreset._strength = 0.0f;
                    }
                }
            }
            [HarmonyPatch(typeof(ObstacleSaberSparkleEffectManager))]
            [HarmonyPatch("Update")]
            internal class ObstacleSaberSparkleEffectManagerUpdate
            {
                internal static void Prefix(ref HapticPresetSO ____rumblePreset)
                {
                    if (Config.Instance.disableRumble)
                    {
                        ____rumblePreset._strength = 0.0f;
                    }
                }
            }
        }
    }
}
