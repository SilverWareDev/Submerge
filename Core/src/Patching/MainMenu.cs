using HarmonyLib;
using static UnityEngine.UI.Selectable;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Logger = BepInEx.Logging.Logger;
using Riptide;
using Submerge.Core.src.Network.Riptide;
using Riptide.Transports;

namespace Submerge.Patching;

[HarmonyPatch(typeof(uGUI_MainMenu))]
public class MainMenu
{
    static Server server = new Server();

    private static GameObject SavedGamesPrefab;

    [HarmonyPatch(nameof(uGUI_MainMenu.Awake))]
    [HarmonyPostfix]
    private static void AwakePatch(uGUI_MainMenu __instance)
    {
        var playButton = __instance.gameObject.GetComponentInChildren<MainMenuPrimaryOptionsMenu>().transform.Find("PrimaryOptions/MenuButtons/ButtonPlay").gameObject;
        var _playButton = Object.Instantiate(playButton);
        _playButton.GetComponent<RectTransform>().SetParent(playButton.transform.parent, false);
        _playButton.name = "Multiplayer_Play";
        var textPlay = _playButton.GetComponentInChildren<TextMeshProUGUI>();
        textPlay.text = "Multiplayer_Play";
        Object.DestroyImmediate(textPlay.gameObject.GetComponent<TranslationLiveUpdate>());
        _playButton.transform.SetSiblingIndex(1);
        var buttonPlayMethod = _playButton.GetComponent<Button>();
        buttonPlayMethod.onClick = new Button.ButtonClickedEvent();
        buttonPlayMethod.onClick.AddListener(() => RightSideMenuJoin());

        var hostButton = __instance.gameObject.GetComponentInChildren<MainMenuPrimaryOptionsMenu>().transform.Find("PrimaryOptions/MenuButtons/ButtonPlay").gameObject;
        var modManagerButton = Object.Instantiate(playButton);
        modManagerButton.GetComponent<RectTransform>().SetParent(playButton.transform.parent, false);
        modManagerButton.name = "Multiplayer_Host";
        var textHost = modManagerButton.GetComponentInChildren<TextMeshProUGUI>();
        textHost.text = "Multiplayer_Host";
        Object.DestroyImmediate(textHost.gameObject.GetComponent<TranslationLiveUpdate>());
        modManagerButton.transform.SetSiblingIndex(1);
        var buttonHostMethod = modManagerButton.GetComponent<Button>();
        buttonHostMethod.onClick = new Button.ButtonClickedEvent();
        buttonHostMethod.onClick.AddListener(() => RightSideMenuHost());
    }

    public static void RightSideMenuJoin()
    {
        Plugin.Logger.LogInfo("Button Join Pressed");
        Client client = new Client();
        client.Connect("127.0.0.1:7777");
    }

    public static void RightSideMenuHost()
    {
        Plugin.Logger.LogInfo("Button Host Pressed");
        server.Start(7777, 8);
    }

    private static void FixedUpdate()
    {
        server.Update();
        Plugin.Logger.LogInfo("Server Updated");
    }
}