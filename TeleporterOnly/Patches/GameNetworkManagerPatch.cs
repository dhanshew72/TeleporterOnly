using BepInEx.Logging;
using HarmonyLib;
using System.Collections.Generic;

namespace TeleporterOnly.Patches
{

    [HarmonyPatch(typeof(GameNetworkManager))]
    internal class GameNetworkManagerPatch
    {
        [HarmonyPatch("ResetUnlockablesListValues")]
        [HarmonyPrefix]
        private static void teleporterStart()
        {
            ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource("LoadUnlockablesPatch");
            logger.LogInfo("Modifying unlockables to start with teleporters");
            List<UnlockableItem> unlockablesList = StartOfRound.Instance.unlockablesList.unlockables;
            if (unlockablesList != null)
            {
                for (int i = 0; i < unlockablesList.Count; i++)
                {
                    if (unlockablesList[i].unlockableName == "Teleporter" || unlockablesList[i].unlockableName == "Inverse Teleporter")
                    {
                        logger.LogInfo($"Unlocking {unlockablesList[i].unlockableName}");
                        unlockablesList[i].hasBeenUnlockedByPlayer = true;
                        unlockablesList[i].alreadyUnlocked = true;
                        unlockablesList[i].alwaysInStock = false;
                    }
                }
            }
            else
            { 
                logger.LogError("What the fuck how is it null?");
            }
        }
    }
}
