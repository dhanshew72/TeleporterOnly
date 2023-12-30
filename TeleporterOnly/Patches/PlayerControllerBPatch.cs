using GameNetcodeStuff;
using HarmonyLib;

namespace TeleporterOnly.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        private static void infiniteSprintPatch(ref float ___sprintMeter)
        {
            ___sprintMeter = 1f;
        }
    }
}
