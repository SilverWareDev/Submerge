using HarmonyLib;
using Submerge.Network;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Submerge.Patching
{
    // TODO: Cleanup

    [HarmonyPatch(typeof(uGUI_MainMenu))]
    public class MainMenuPatch
    {
        public static string ip = "127.0.0.1";
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
            var saveHeaderText = saveHeader.GetComponent<TextMeshProUGUI>();
            saveHeaderText.SetText("Host");

            var devEmail = GameObject.Find("Menu canvas/Panel/MainMenu/RightSide/Home/EmailBox");
            var joinServer = Object.Instantiate(devEmail);
            devEmail.SetActive(false);
            joinServer.name = "JoinServer";
            joinServer.transform.SetParent(saveMenu.transform, false);
            joinServer.transform.localPosition = new Vector3(-400, 450, 0);

            // TODO: Change join server menu text
        }

        public static void MButtonMethod()
        {
            Plugin.Logger.LogInfo("Button Pressed");
            MainMenuRightSide.main.OpenGroup("SavedGames");
        }
        public static void ConnectToServer()
        {
            // Connects two or three times, needs debugging

            var joinServerHandler = GameObject.Find("Menu canvas/Panel/MainMenu/RightSide/SavedGames/JoinServer");
            var joinServerString = joinServerHandler.GetComponentInChildren<MainMenuEmailHandler>();

            ip = joinServerString.email;

            NetworkManager.ConnectToServer(ip, 7777);
        }
    }

    [HarmonyPatch(typeof(MainMenuEmailHandler))]
    public class EmailSubPatch
    {
        [HarmonyPatch(nameof(MainMenuEmailHandler.Subscribe))]
        [HarmonyPostfix]
        private static void EmailPatch(MainMenuEmailHandler __instance)
        {
            MainMenuPatch.ConnectToServer();
        }
    }
}
