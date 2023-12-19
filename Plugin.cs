using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Riptide;
using Riptide.Utils;
using System.Reflection;
using UWE;

namespace Submerge
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public new static ManualLogSource Logger { get; private set; }

        private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

        public void Awake()
        {
            // plugin startup logic
            Logger = base.Logger;

            // register harmony patches, if there are any
            Harmony.CreateAndPatchAll(Assembly, $"{PluginInfo.PLUGIN_GUID}");
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            RiptideLogger.Initialize(Plugin.Logger.LogInfo, Plugin.Logger.LogInfo, Plugin.Logger.LogWarning, Plugin.Logger.LogError, true);

            Server server = new Server();
        }
    }
}
