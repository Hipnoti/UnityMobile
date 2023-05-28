using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private const string stringConst = "This log string hopefully won't take too much memory";
    
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

    public int calculateFramesInterval = 10;
    
    [SerializeField] private GameObject _lightTouch;
    [SerializeField] private int numberOfObjectsInstantiated;
    
    [Header("Touches")]
    [SerializeField] private TextMeshProUGUI textLogObjectToSpawn;
    [SerializeField] private Transform listOfTouchesPanelUI;
    [SerializeField] private Camera mainCamera;

    [Header("Gyro")] 
    [SerializeField] private TextMeshProUGUI currentGyroDebug;
    [SerializeField] private Transform watermelonTransform;

    [Header("Spaceship")]
    [SerializeField] AssetReference fountainReference;
    [SerializeField] private Transform spaceShipTransform;



    private int calculateframesTimer = 0;


    private float timeLeft = 3;

    private ResourceRequest resourceRequest;
    
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
        Debug.Log("This is another line of code!");

      //  resourceRequest = Resources.LoadAsync<GameObject>("FountainWithLOD");
      AsyncOperationHandle handle = fountainReference.LoadAssetAsync<GameObject>();
      handle.Completed += HandleOnCompleted;
      
    }

    private void HandleOnCompleted(AsyncOperationHandle obj)
    {
       Debug.Log(obj.Status == AsyncOperationStatus.Succeeded);
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

       // Debug.Log("The player position is " + spaceShipTransform.position);

        calculateframesTimer++;
        if (calculateframesTimer >= calculateFramesInterval)
        {
            CalculateObjectsSpawned();
            calculateframesTimer = 0;
        }

        if (resourceRequest != null)
        {
            if (resourceRequest.isDone)
            {
                Instantiate(resourceRequest.asset);

                resourceRequest = null;
            }
        }
        
        // if (fountainReference != null)
        // {
        //     if (fountainReference.IsDone)
        //     {
        //         Instantiate(fountainReference.Asset);
        //
        //         fountainReference = null;
        //     }
        // }
     //   Debug.Log("This log string hopefully won't take too much memory");
    }

    void CalculateObjectsSpawned()
    {
        RotateTween[] rotateTweens = FindObjectsByType<RotateTween>(FindObjectsSortMode.None);
            
        Debug.Log("We found " + rotateTweens.Length + " Objects of RotateTween type");
    }
    
  
    
}
