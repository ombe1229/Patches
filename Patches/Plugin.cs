using System;
using HarmonyLib;
using Features = Exiled.API.Features;
using Log = Exiled.API.Features.Log;
using Exiled.API.Enums;


namespace Patches
{
    public class Plugin : Features.Plugin<Configs>
    {
        public Harmony Harmony { get; private set; }

        public override string Name { get; } = "Patches";
        public override string Prefix { get; } = "Patches";
        public override string Author { get; } = "ombe1229";
        public override PluginPriority Priority { get; } = PluginPriority.Default;

        public override void OnEnabled()
        {
            if (!Config.IsEnabled) return;
            base.OnEnabled();
            try
            {
                Harmony = new Harmony($"com.ombe1229.Patches.{DateTime.Now.Ticks}");
                Harmony.PatchAll();
            }
            catch (Exception e)
            {
                Log.Error($"Patching failed: {e.ToString()}");
            }
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Harmony.UnpatchAll();
        }
    }
}