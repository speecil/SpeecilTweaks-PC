using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.GameplaySetup;
using BeatSaberMarkupLanguage.MenuButtons;
using BeatSaberMarkupLanguage.ViewControllers;
using HMUI;
using IPA.Config.Data;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

namespace SpeecilTweaks.UI
{
    static class Butter
    {
        public static bool changed;
    }
    internal class STFlowCoordinator : FlowCoordinator
    {
        SpeecilTweaksViewController view = null;


        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {

            if (firstActivation)
            {
                SetTitle("Speecil Tweaks");
                showBackButton = true;

                if (view == null)
                    view = BeatSaberUI.CreateViewController<SpeecilTweaksViewController>();

                ProvideInitialViewControllers(view);
            }
            Butter.changed = Config.Instance.removeAllParticles;

        }

    protected override void BackButtonWasPressed(ViewController topViewController)
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
            BeatSaberUI.MainFlowCoordinator.DismissFlowCoordinator(this, null, ViewController.AnimationDirection.Horizontal);
            SpeecilTweaks.Config.Instance.Changed();
        }

        public void ShowFlow()
        {
            var _parentFlow = BeatSaberUI.MainFlowCoordinator.YoungestChildFlowCoordinatorOrSelf();

            BeatSaberUI.PresentFlowCoordinator(_parentFlow, this);
        }

        static STFlowCoordinator flow = null;
        static MenuButton button;

        public static void Initialize()
        {
            MenuButtons.instance.RegisterButton(button ??= new MenuButton("Speecil Tweaks", "Customise your game!", () => {
                if (flow == null)
                    flow = BeatSaberUI.CreateFlowCoordinator<STFlowCoordinator>();

                flow.ShowFlow();
            }, true));
        }

        public static void Deinit()
        {
            if (button != null)
                MenuButtons.instance.UnregisterButton(button);
        }
    }

    [HotReload(RelativePathToLayout = @"./settings.bsml")]
    [ViewDefinition("SpeecilTweaks.UI.settings.bsml")]
    class SpeecilTweaksViewController : BSMLAutomaticViewController
    {
        SpeecilTweaks.Config config = SpeecilTweaks.Config.Instance;

        void Patreon()
        {
            System.Diagnostics.Process.Start("https://www.patreon.com/speecil");
        }

        void Discord()
        {
            System.Diagnostics.Process.Start("https://discord.gg/p4RHvn8nNH");
        }
        string playText
        {
            get => config.playText;
            set => config.playText = value;
        }

        string practiceText
        {
            get => config.practiceText;
            set => config.practiceText = value;
        }

        string resultText
        {
            get => config.resultText;
            set => config.resultText = value;
        }

        string resultFailText
        {
            get => config.resultFailText;
            set => config.resultFailText = value;
        }

        Color menuButtonColour
        {
            get => config.menuButtonColour;
            set => config.menuButtonColour = value;
        }

        Color rBackColour
        {
            get => config.rBackColour;
            set => config.rBackColour = value;
        }

        Color rfBackColour
        {
            get => config.rfBackColour;
            set => config.rfBackColour = value;
        }
        Color pMenuColour
        {
            get => config.pMenuColour;
            set => config.pMenuColour = value;
        }

        Color pMenuBackColour
        {
            get => config.pMenuBackColour;
            set => config.pMenuBackColour = value;
        }

        bool playButtonActive
        {
            get => config.playButtonActive;
            set => config.playButtonActive = value;
        }

        bool practiceButtonActive
        {
            get => config.practiceButtonActive;
            set => config.practiceButtonActive = value;
        }

        bool removeAllParticles
        {
            get => config.removeAllParticles;
            set => config.removeAllParticles = value;
        }
        bool enablePMenuTweaks
        {
            get => config.enablePMenuTweaks;
            set => config.enablePMenuTweaks = value;
        }
        bool disableBlur
        {
            get => config.disableBlur;
            set => config.disableBlur = value;
        }

        bool disableRumble
        {
            get => config.disableRumble;
            set => config.disableRumble = value;
        }

        bool disableHitscore
        {
            get => config.disableHitscore;
            set => config.disableHitscore = value;
        }

        bool skipHealth
        {
            get => config.skipHealth;
            set => config.skipHealth = value;
        }

        bool cancelReset
        {
            get => config.cancelReset;
            set => config.cancelReset = value;
        }




    }

    public static class BsmlWrapper
    {
        static readonly bool hasBsml = IPA.Loader.PluginManager.GetPluginFromId("BeatSaberMarkupLanguage") != null;

        public static void EnableUI()
        {
            void wrap() => STFlowCoordinator.Initialize();

            if (hasBsml)
                wrap();
        }
        public static void DisableUI()
        {
            void wrap() => STFlowCoordinator.Deinit();

            if (hasBsml)
                wrap();
        }
    }
}