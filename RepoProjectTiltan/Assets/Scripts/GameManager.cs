using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] private GameObject _lightTouch;
    
    [Header("Touches")]
    [SerializeField] private TextMeshProUGUI textLogObjectToSpawn;
    [SerializeField] private Transform listOfTouchesPanelUI;
    [SerializeField] private Camera mainCamera;

    [Header("Gyro")] 
    [SerializeField] private TextMeshProUGUI currentGyroDebug;
    [SerializeField] private Transform watermelonTransform;
    
    // Update is called once per frame
    // void Update()
    // {
    //     for (int i = 0; i < Input.touchCount; i++)
    //     {
    //         Touch currentTouch = Input.touches[i];
    //         if (currentTouch.phase == TouchPhase.Began)
    //         {
    //             TextMeshProUGUI instadDebugLogText = Instantiate(textLogObjectToSpawn, listOfTouchesPanelUI);
    //             instadDebugLogText.text = "Touch at " + currentTouch.position.x + ',' + currentTouch.position.y;
    //         }
    //     }
    // }

    private void Start()
    {
        Input.gyro.enabled = true;
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            for(int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                if (touch.phase == TouchPhase.Began)
                {
                    Vector2 touchPos = mainCamera.ScreenToWorldPoint(touch.position);
                    Instantiate(_lightTouch, touchPos, Quaternion.identity);
                    
                }
            }

            
        }

        Gyroscope gyro = Input.gyro;
        currentGyroDebug.text = gyro.attitude.ToString();
        watermelonTransform.rotation = GyroToUnity(gyro.attitude);
    }
   
    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
    
}
