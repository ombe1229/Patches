using Assets._Scripts.Dissonance;
using Exiled.API.Extensions;
using HarmonyLib;

namespace Patches.Patches
{
    [HarmonyPatch(typeof(DissonanceUserSetup), nameof(DissonanceUserSetup.CallCmdAltIsActive))]
    public class ScpSpeak
    {
        public static void Prefix(DissonanceUserSetup instance, bool value)
        {
            CharacterClassManager ccm = instance.gameObject.GetComponent<CharacterClassManager>();
            if (ccm.CurClass.GetTeam() == Team.SCP) instance.MimicAs939 = value;
        }
    }
}