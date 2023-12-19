using HarmonyLib;
using static UnityEngine.UI.Selectable;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Logger = BepInEx.Logging.Logger;

namespace Submerge.Patching;

[HarmonyPatch(typeof(uGUI_MainMenu))]
internal class MainMenu
{
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
    }

    public static void RightSideMenuHost()
    {
        Plugin.Logger.LogInfo("Button Host Pressed");
    }
}