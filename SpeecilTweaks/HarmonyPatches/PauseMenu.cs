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
    internal class PauseMenu
    {
        [HarmonyPatch]
        internal class PauseTweaks
        {
            [HarmonyPatch(typeof(PauseMenuManager))]
            [HarmonyPatch("Start")]
            internal class PauseMenuManagerShowMenu
            {
                internal static void Postfix()
                {   
                    if(Config.Instance.enablePMenuTweaks)
                    {   
                        GameObject songname = GameObject.Find("Wrapper/StandardGameplay/PauseMenu/Wrapper/MenuWrapper/Canvas/MainBar/LevelBarSimple/SongNameText");
                        songname.gameObject.GetComponentsInChildren<TextMeshProUGUI>().FirstOrDefault().color = Config.Instance.pMenuColour;
                        //
                        GameObject artist = GameObject.Find("Wrapper/StandardGameplay/PauseMenu/Wrapper/MenuWrapper/Canvas/MainBar/LevelBarSimple/AuthorNameText");
                        artist.gameObject.SetActive(false);
                        //
                        GameObject difftext = GameObject.Find("Wrapper/StandardGameplay/PauseMenu/Wrapper/MenuWrapper/Canvas/MainBar/LevelBarSimple/BeatmapDataContainer/DifficultyText");
                        difftext.gameObject.SetActive(false);
                        //
                        GameObject icon = GameObject.Find("Wrapper/StandardGameplay/PauseMenu/Wrapper/MenuWrapper/Canvas/MainBar/LevelBarSimple/BeatmapDataContainer/Icon");
                        icon.gameObject.SetActive(false);
                        //
                        GameObject bg = GameObject.Find("Wrapper/StandardGameplay/PauseMenu/Wrapper/MenuWrapper/Canvas/MainBar/LevelBarSimple/BG");
                        bg.gameObject.GetComponentInChildren<HMUI.ImageView>().color = Config.Instance.pMenuBackColour;
                    }

                }
            }
        }
    }
}