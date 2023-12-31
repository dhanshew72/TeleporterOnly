using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using TeleporterOnly.Patches;

namespace TeleporterOnly
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class TeleporterOnly: BaseUnityPlugin
    {

        private const string modGUID = "Daran.TeleporterOnlyMod";
        private const string modName = "Teleporter Only Mod";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static TeleporterOnly Instance;

        internal ManualLogSource logger;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            logger = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            logger.LogInfo($"The {modGUID} mod has started");
            harmony.PatchAll(typeof(TeleporterOnly));
            harmony.PatchAll(typeof(GameNetworkManagerPatch));
        }
    }
}
