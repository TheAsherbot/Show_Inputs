using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TheAshBot.UI
{
    public class OptionsMenu : MonoBehaviour
    {

        private const string OPTIONS_DATA_PATH = "SavedData\\";
        private const string OPTIONS_DATA_NAME = "Option";




        [SerializeField] private GameObject window;
        [SerializeField] private InputManager inputManager;


        [Header("Buttons")]
        [SerializeField] private UIButton quitButton;
        [SerializeField] private UIButton resuneButton;


        [Header("Sceen Resolution")]
        [SerializeField] private TMP_Dropdown resolutionDropdown;
        [SerializeField] private Toggle fullScreenToggle;


        [SerializeField] private Toggle lightenOnPressToggle;
        [SerializeField] private TMP_Dropdown controllerTypeDropdown;

        private double currentRefressRate;
        private List<Resolution> resolutionList;
        private List<Resolution> filteredResolutionList;

        private bool isOpen;


        private void Awake()
        {
            inputManager.OnOptions += Options;
            fullScreenToggle.onValueChanged.AddListener(SetFullScreen);
            resolutionDropdown.onValueChanged.AddListener(SetResolution);
            lightenOnPressToggle.onValueChanged.AddListener(SetLightenOnPress);
            controllerTypeDropdown.onValueChanged.AddListener(SetControllerTypeDropdown);
            quitButton.OnMouseEndClickUI += Quit;
            resuneButton.OnMouseEndClickUI += Resume;
        }

        private void Start()
        {
            DisplayResolutions();

            TryLoadOptions();
        }


        #region Buttons

        private void SetFullScreen(bool isFullScreen)
        {
            Screen.fullScreen = isFullScreen;

            Save();
        }

        private void SetResolution(int resolutionIndex)
        {
            Resolution resolution = filteredResolutionList[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

            Save();
        }
        private void SetLightenOnPress(bool lightenWhenPressed)
        {
            inputManager.SetLightWhenPressed(lightenWhenPressed);
            Save();
        }
        
        private void SetControllerTypeDropdown(int controllerTypeIndex)
        {
            inputManager.SetInputType((InputManager.InputType)controllerTypeIndex);
            Save();
        }

        private void Quit()
        {
            Application.Quit();
        }

        private void Resume()
        {
            isOpen = false;
            window.SetActive(isOpen);
        }

        private void Options()
        {
            isOpen = !isOpen;
            window.SetActive(isOpen);
        }

        #endregion


        #region Save; Load

        public bool TryLoadOptions()
        {
            controllerTypeDropdown.ClearOptions();
            controllerTypeDropdown.AddOptions(new List<string> { InputManager.InputType.XBox360.ToString(), InputManager.InputType.XBox1.ToString() });
            resolutionDropdown.RefreshShownValue();


            SaveOptionsData optionsData = SaveSystem.LoadJson<SaveOptionsData>(SaveSystem.RootPath.Resources, OPTIONS_DATA_PATH, OPTIONS_DATA_NAME);

            if (optionsData == null)
            {
                // Nothing was found
                this.LogFakeError("Nothing was found");
                return false;
            }

            resolutionDropdown.value = optionsData.filteredResolutionIndex;
            fullScreenToggle.isOn = optionsData.isFullScreened;
            lightenOnPressToggle.isOn = optionsData.lightenOnPress;
            controllerTypeDropdown.value = optionsData.controllerInputType;
            return true;
        }

        public void Save()
        {
            SaveOptionsData saveOptionsData = new SaveOptionsData()
            {
                isFullScreened = fullScreenToggle.isOn,
                filteredResolutionIndex = resolutionDropdown.value,
                lightenOnPress = lightenOnPressToggle.isOn,
                controllerInputType = controllerTypeDropdown.value,
            };

            SaveSystem.SaveJson(saveOptionsData, SaveSystem.RootPath.Resources, OPTIONS_DATA_PATH, OPTIONS_DATA_NAME, true);
        }

        #endregion


        private void DisplayResolutions()
        {
            resolutionList = Screen.resolutions.ToList();
            filteredResolutionList = new List<Resolution>();

            currentRefressRate = Screen.currentResolution.refreshRateRatio.value;
            resolutionDropdown.ClearOptions();

            for (int i = 0; i < resolutionList.Count; i++)
            {
                if (resolutionList[i].refreshRateRatio.value == currentRefressRate)
                {
                    filteredResolutionList.Add(resolutionList[i]);
                }
            }

            List<string> screenResolutionStringList = new List<string>();

            int currentResolutionIndex = 0;
            for (int i = 0; i < filteredResolutionList.Count; i++)
            {
                string screenResolutionString = filteredResolutionList[i].width + " x " + filteredResolutionList[i].height;
                screenResolutionStringList.Add(screenResolutionString);

                if (filteredResolutionList[i].width == Screen.currentResolution.width && filteredResolutionList[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }

            resolutionDropdown.AddOptions(screenResolutionStringList);
            resolutionDropdown.SetValueWithoutNotify(currentResolutionIndex);
            resolutionDropdown.RefreshShownValue();
        }



        private class SaveOptionsData
        {
            public bool isFullScreened;
            public int filteredResolutionIndex;

            public bool lightenOnPress;
            public int controllerInputType;
        }


    }
}