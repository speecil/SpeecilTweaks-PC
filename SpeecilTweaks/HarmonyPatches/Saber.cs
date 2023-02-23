using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace SpeecilTweaks.HarmonyPatches
{
    internal class Saber
    {
        [HarmonyPatch]
        internal class Trail
        {
            [HarmonyPatch(typeof(SaberTrail))]
            [HarmonyPatch("LateUpdate")]
            internal class SaberTrailLateUpdate
            {
                internal static void Postfix(ref float ____trailDuration, ref float ____whiteSectionMaxDuration)
                {
                    if (Config.Instance.disableBlur)
                    {
                        ____trailDuration = 0.0f;
                        ____whiteSectionMaxDuration = 0.0f;
                    }
                    else
                    {

                    }

                }
            }
        }
    }
}
