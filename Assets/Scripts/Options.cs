using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Options : MonoBehaviour
{
    public Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    public Slider Sensitivity;
    public static float sensVal = 100f;
    private void Start()
    {
        Sensitivity.value = sensVal;

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> option = new List<string>();

        int currentResolutionindex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string options = resolutions[i].width + " x " + resolutions[i].height;
            option.Add(options);

            if(resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionindex = i;
            }
        }

        resolutionDropdown.AddOptions(option);
        resolutionDropdown.value = currentResolutionindex;
        resolutionDropdown.RefreshShownValue();

        this.gameObject.SetActive(false);

    }

    private void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            this.gameObject.SetActive(false);
        }
    }
    public void FullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void WindowedScreen()
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
    }

    public void close()
    {
        this.gameObject.SetActive(false);
    }

    public void quality(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);
    }

    public void Resolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void Sensitive()
    {
        sensVal = Sensitivity.value;
    }
}
