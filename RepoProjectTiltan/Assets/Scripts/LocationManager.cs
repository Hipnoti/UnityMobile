using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI debugText;
    private bool startedLocationProcess = false;
    private float timeLeftUntilTimeout = 15f;
    
    public void StartLocationProcess()
    {
        if (Input.location.isEnabledByUser)
        {
            startedLocationProcess = true;
            Input.location.Start();
        }
        else
        {
            debugText.text = "Location services are off!";
        }
    }

    private void Update()
    {
        if (startedLocationProcess)
        {
            switch (Input.location.status)
            {
                case LocationServiceStatus.Stopped:
                    debugText.text = "Stopped!";
                    startedLocationProcess = false;
                    break;
                case LocationServiceStatus.Initializing:
                    timeLeftUntilTimeout -= Time.deltaTime;
                    if (timeLeftUntilTimeout <= 0)
                    {
                        debugText.text = "Time out!!!";
                        startedLocationProcess = false;
                    }
                    break;
                case LocationServiceStatus.Running:
                    debugText.text = "Got Location!";
                    DoSomethingWithLocation();
                    break;
                case LocationServiceStatus.Failed:
                    debugText.text = "Failed!";
                    startedLocationProcess = false;
                    break;
            }
        }
    }

    private void DoSomethingWithLocation()
    {
        LocationInfo currentLocationInfo = Input.location.lastData;
        debugText.text = currentLocationInfo.longitude + ", " + currentLocationInfo.altitude + ", " +
                         currentLocationInfo.latitude;
    }
}
