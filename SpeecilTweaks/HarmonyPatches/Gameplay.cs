using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using IPA.Utilities;
using SiraUtil;
using SiraUtil.Affinity;
using HarmonyLib.Public.Patching;

namespace SpeecilTweaks.HarmonyPatches
{
    internal class Gameplay
    {
        [HarmonyPatch]
        internal class gametweaks
        {
            [HarmonyPatch(typeof(GameplayCoreInstaller))]
            [HarmonyPatch("InstallBindings")]
            internal class GameplayCoreInstallerInstallBindings
            {
                internal static void Postfix()
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
            [HarmonyPatch(typeof(SaberClashEffect))]
            [HarmonyPatch("LateUpdate")]
            internal class SaberClashEffectLateUpdate
            {
                internal static void Postfix(ref ParticleSystem ____sparkleParticleSystem, ref ParticleSystem ____glowParticleSystem)
                {
                    if(Config.Instance.removeAllParticles)
                    {
                        ____sparkleParticleSystem.gameObject.SetActive(false);
                        ____glowParticleSystem.gameObject.SetActive(false);

                    }
                    else
                    {
                        ____sparkleParticleSystem.gameObject.SetActive(true);
                        ____glowParticleSystem.gameObject.SetActive(false);

                    }
                }
            }
            [HarmonyPatch(typeof(NoteCutParticlesEffect))]
            [HarmonyPatch("Awake")]
            internal class NoteCutParticlesEffectSpawnParticles
            {
                internal static void Postfix(ref ParticleSystem ____sparklesPS, ref ParticleSystem ____explosionPS, ref ParticleSystem ____explosionCorePS)
                {   
                    if (Config.Instance.removeAllParticles)
                    {
                        ____sparklesPS.gameObject.SetActive(false);
                        ____explosionPS.gameObject.SetActive(false);
                        ____explosionCorePS.gameObject.SetActive(false);
                    }
                    else
                    {
                        ____sparklesPS.gameObject.SetActive(true);
                        ____explosionPS.gameObject.SetActive(true);
                        ____explosionCorePS.gameObject.SetActive(true);
                    }

                }
            }
            [HarmonyPatch(typeof(BombExplosionEffect))]
            [HarmonyPatch("Awake")]
            internal class BombExplosionEffectAwake
            {
                internal static void Postfix(ref ParticleSystem ____debrisPS, ref ParticleSystem ____explosionPS)
                {
                    if (Config.Instance.removeAllParticles)
                    {
                        ____debrisPS.gameObject.SetActive(false);
                        ____explosionPS.gameObject.SetActive(false);
                    }
                    else
                    {
                        ____debrisPS.gameObject.SetActive(true);
                        ____explosionPS.gameObject.SetActive(true);
                    }

                }
            }
            [HarmonyPatch(typeof(ObstacleSaberSparkleEffect))]
            [HarmonyPatch("Awake")]
            internal class ObstacleSaberSparkleEffectManagerStart
            {
                internal static void Prefix(ref ParticleSystem ____sparkleParticleSystem)
                {
                    if (Config.Instance.removeAllParticles)
                    {
                        ____sparkleParticleSystem.gameObject.SetActive(false);
                    }
                    else
                    {
                        ____sparkleParticleSystem.gameObject.SetActive(true);
                    }

                }
            }
            [HarmonyPatch(typeof(FlyingScoreEffect))]
            [HarmonyPatch("RefreshScore")]
            internal class FlyingScoreEffectRefreshScore
            {
                internal static void Postfix(ref TextMeshPro ____text, ref Color ____color, ref SpriteRenderer ____maxCutDistanceScoreIndicator)
                {   
                    if (Config.Instance.disableHitscore)
                    {   
                        ____maxCutDistanceScoreIndicator.gameObject.SetActive(false);
                        ____text.SetText("");
                    }
                }
            }
        }
    }
}