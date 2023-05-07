using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
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

    private static GameManager instance;
    
    [SerializeField] private GameObject _lightTouch;
    
    [Header("Touches")]
    [SerializeField] private TextMeshProUGUI textLogObjectToSpawn;
    [SerializeField] private Transform listOfTouchesPanelUI;
    [SerializeField] private Camera mainCamera;

    [Header("Gyro")] 
    [SerializeField] private TextMeshProUGUI currentGyroDebug;
    [SerializeField] private Transform watermelonTransform;

    public void LoadLevel(int levelNumber)
    {
        //Actually load the level with SceneManager
        Debug.Log("We have chosen level " + levelNumber);
        AnalyticsManager.Instance.ReportLevelLoaded(levelNumber);
    }

    private void Awake()
    {
        Instance = this;
    }

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
            //  currentGyroDebug.text = gyro.attitude.ToString();
        watermelonTransform.rotation =
            new Quaternion(gyro.attitude.z, gyro.attitude.y, gyro.attitude.x, gyro.attitude.w);
    }
   
  
    
}
