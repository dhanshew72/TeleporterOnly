using BepInEx.Logging;
using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;

namespace TeleporterOnly.Patches
{

    [HarmonyPatch(typeof(RoundManager))]
    internal class RoundManagerPatch
    {

        [HarmonyPatch("SpawnSyncedProps")]
        [HarmonyPrefix]
        private static void teleporterStart(ref List<GameObject> ___spawnedSyncedObjects)
        {

            ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource("SpawnSyncedPropsClass");
            logger.LogInfo("SpawnSyncedPropsClass has been called");
            ___spawnedSyncedObjects.Add(new GameObject("Teleporter(Clone)"));
        }
    }
}
