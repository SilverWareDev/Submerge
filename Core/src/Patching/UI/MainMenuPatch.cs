using HarmonyLib;
using Submerge.Network;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// whar
namespace Submerge.Patching;

[HarmonyPatch(typeof(uGUI_MainMenu))]
public class MainMenuPatch
{
    private static GameObject SavedGamesPrefab;

    [HarmonyPatch(nameof(uGUI_MainMenu.Awake))]
    [HarmonyPostfix]
    private static void AwakePatch(uGUI_MainMenu __instance)
    {
        var playButton = __instance.gameObject.GetComponentInChildren<MainMenuPrimaryOptionsMenu>().transform.Find("PrimaryOptions/MenuButtons/ButtonPlay").gameObject;
        var M_playButton = Object.Instantiate(playButton);
        M_playButton.GetComponent<RectTransform>().SetParent(playButton.transform.parent, false);
        M_playButton.name = "ButtonMultiplayer";
        var MtextPlay = M_playButton.GetComponentInChildren<TextMeshProUGUI>();
        MtextPlay.text = "Multiplayer";
        Object.DestroyImmediate(MtextPlay.gameObject.GetComponent<TranslationLiveUpdate>());
        M_playButton.transform.SetSiblingIndex(1);
        var MbuttonPlayMethod = M_playButton.GetComponent<Button>();
        MbuttonPlayMethod.onClick = new Button.ButtonClickedEvent();
        MbuttonPlayMethod.onClick.AddListener(() => MButtonMethod());

        playButton.SetActive(false);

        var saveMenu = GameObject.Find("Menu canvas/Panel/MainMenu/RightSide/SavedGames");

        var saveHeader = GameObject.Find("Menu canvas/Panel/MainMenu/RightSide/SavedGames/Header");
        var headerText = saveHeader.GetComponent<TextMeshProUGUI>();
        headerText.SetText("Host");

        var devEmail = GameObject.Find("Menu canvas/Panel/MainMenu/RightSide/Home/EmailBox");
        var joinServer = Object.Instantiate(devEmail);
        joinServer.name = "JoinServer";
        joinServer.transform.SetParent(saveMenu.transform, false);
        joinServer.transform.localPosition = new Vector3(-400, 500, 0);
        joinServer.SetActive(true);
    }

    public static void MButtonMethod()
    {
        Plugin.Logger.LogInfo("Button Pressed");
        MainMenuRightSide.main.OpenGroup("SavedGames");
    }

    /*public static void RightSideMenuJoin()
    {
        RiptideClient.CurrentClient.Connect("INSTERTIPHERE:7777");

        RiptideClient.CurrentClient.Connected += (sender, args) => Internal.SaveManager.CreateSaveClient();
    }

    public static void RightSideMenuHost()
    {
        RiptideServer.CurrentServer.Start(7777, 8);

        Internal.SaveManager.CreateSaveHost();
    }*/
}
