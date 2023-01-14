using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resDropdown;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
