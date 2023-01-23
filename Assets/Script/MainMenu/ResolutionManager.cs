using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResolutionManager : MonoBehaviour
{
    [SerializeField] private Dropdown resDropdown;

    private Resolution[] resolutions;
    private List<Resolution> filteredRes;

    private float currentRefreshRate;
    private int currentResindex = 0;
    
    void Start()
    {
        resolutions = Screen.resolutions;
        filteredRes = new List<Resolution>();
        
        resDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currentRefreshRate)
            {
                filteredRes.Add(resolutions[i]);
            }
        }
        List<string> options = new List<string>();
        for (int i = 0; i < filteredRes.Count; i++)
        { 
            string resolutionOption = filteredRes[i].width + "x" + filteredRes[i].height+" "+filteredRes[i].refreshRate +" Hz";
            options.Add(resolutionOption);
            if (filteredRes[i].width == Screen.width && filteredRes[i].height == Screen.height)
            {
                currentResindex = i;
            }
        }
        resDropdown.AddOptions(options);
        resDropdown.value = currentResindex;
        resDropdown.RefreshShownValue();

    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filteredRes[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height,true);
    }
   

    
}
