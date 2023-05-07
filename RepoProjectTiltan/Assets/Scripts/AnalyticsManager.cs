using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager Instance
    {
        get
        {
            return instance;
        }
        private set
        {
            instance = value;
        }
    }

    private static AnalyticsManager instance;

    public void ReportLevelLoaded(int levelNumber)
    {
        Dictionary<string, object> eventParameters = new Dictionary<string, object>();
        eventParameters.Add("LevelNumber", levelNumber);

        AnalyticsService.Instance.CustomData("LevelLoaded", eventParameters);
        
        AnalyticsService.Instance.Flush();
    }
    
    [ContextMenu("Initlialize UGS")]
    async void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log("First");
        await UnityServices.InitializeAsync();
        Debug.Log("Second");
        try
        {
            List<string> consentIdentifiers = await AnalyticsService.Instance.CheckForRequiredConsents();
            if (consentIdentifiers.Count > 0)
            {
                foreach (string consentIdentifier in consentIdentifiers)
                {
                    Debug.Log(consentIdentifier);
                }
            }
            else
            {
                Debug.Log("No need for any consent for analytics!");
            }
        }
        catch (ConsentCheckException exception)
        {
            Debug.LogError("Expection with checking constents! " + Environment.NewLine + exception.Message);
        }

        SceneManager.LoadScene("Main Scene");
    }
    
}
