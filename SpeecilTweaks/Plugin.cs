using HarmonyLib;
using IPA;
using IPA.Config.Stores;
using SpeecilTweaks.UI;
using System.Reflection;
using IPALogger = IPA.Logging.Logger;

namespace SpeecilTweaks
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        public bool inMulti = false;
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }

        internal static bool enabled { get; private set; } = true;

        public static Harmony harmony;

        [Init]
        public void Init(IPA.Config.Config conf, IPALogger logger)
        {
            Instance = this;
            Log = logger;

            Config.Instance = conf.Generated<Config>();

            harmony = new Harmony("Speecil.BeatSaber.SpeecilTweaks");
        }

        [OnEnable]
        public void OnEnable()
        {
            bool inMulti = false;
            enabled = true;
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            Config.Instance.ApplyValues();
            BsmlWrapper.EnableUI();
        }

        [OnDisable]
        public void OnDisable()
        {
            enabled = false;

            harmony.UnpatchSelf();
            BsmlWrapper.DisableUI();
        }
    }
}