using MelonLoader;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UWE;
using System;

#nullable disable
namespace Submerge.Patching
{
    public class MainMenu
    {
        private static GameObject _StartButtonPrefab;

        public static GameObject CreateButton(UnityAction btnListener = null)
        {
            string buttonText = "Multiplayer";

            GameObject sideButton = UnityEngine.Object.Instantiate(StartButtonPrefab,
                StartButtonPrefab.transform.parent);
            sideButton.name = string.Format("CustomBtn_{0}", Guid.NewGuid().ToString());
            sideButton.transform.SetSiblingIndex(3);
            Button component1 = sideButton.GetComponent<Button>();
            component1.onClick.RemoveAllListeners();
            if (btnListener != null)
            {
                component1.onClick.AddListener(btnListener);
            }

            TextMeshProUGUI component2 = sideButton.transform.Find("Circle/Bar/Text")
                .GetComponent<TextMeshProUGUI>();
            component2.SetText(buttonText, true);
            component2.GetComponent<TranslationLiveUpdate>().translationKey = buttonText;

            MelonLogger.Msg("Multiplayer Button created!");

            return sideButton;
        }

        public static GameObject StartButtonPrefab
        {
            get
            {
                if (UnityEngine.Object.Equals(_StartButtonPrefab, null))
                    _StartButtonPrefab =
                        GameObject.Find("Menu canvas/Panel/MainMenu/PrimaryOptions/MenuButtons/ButtonPlay");
                return _StartButtonPrefab;
            }
        }
    }
}