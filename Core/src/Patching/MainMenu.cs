using HarmonyLib;
using static UnityEngine.UI.Selectable;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Submerge.Patching;

[HarmonyPatch(typeof(uGUI_MainMenu))]
internal class MainMenuPatches
{
    [HarmonyPatch(nameof(uGUI_MainMenu.Awake))]
    [HarmonyPostfix]
    private static void AwakePatch(uGUI_MainMenu __instance)
    {
        var playButton = __instance.gameObject.GetComponentInChildren<MainMenuPrimaryOptionsMenu>().transform.Find("PrimaryOptions/MenuButtons/ButtonPlay").gameObject;
        var modManagerButton = Object.Instantiate(playButton);
        modManagerButton.GetComponent<RectTransform>().SetParent(playButton.transform.parent, false);
        modManagerButton.name = "Multiplayer";
        var text = modManagerButton.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "Multiplayer";
        Object.DestroyImmediate(text.gameObject.GetComponent<TranslationLiveUpdate>());
        modManagerButton.transform.SetSiblingIndex(1);
        var button = modManagerButton.GetComponent<Button>();
        button.onClick = new Button.ButtonClickedEvent();
        button.onClick.AddListener(null);
    }
}