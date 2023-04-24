using IPA.Config.Stores;
using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace SpeecilTweaks
{
    internal class Config
    {
        public static Config Instance { get; set; }
        public string playText = "Speecil!";
        public string practiceText = "Git Gud";
        public string resultText = "Well Done!";
        public string resultFailText = "You Suck!";
        public Color menuButtonColour = Color.cyan;
        public Color rBackColour = Color.green;
        public Color rfBackColour = Color.red;
        public Color pMenuColour = Color.magenta;
        public Color pMenuBackColour = Color.yellow;
        public bool playButtonActive = true;
        public bool practiceButtonActive = true;
        public bool removeAllParticles = false;
        public bool enablePMenuTweaks = false;
        public bool disableRumble = false;
        public bool disableHitscore = false;
        public bool skipHealth = false;
        public bool cancelReset = false;



        public virtual void Changed() => ApplyValues();

        public void ApplyValues()
        {
            if (!Plugin.enabled) return;
        }


    }
}