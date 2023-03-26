using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    [SerializeField] private RectTransform mainCanvasRectTransform;
    [SerializeField] private Image targetImageToAffect;
    [SerializeField] private RectTransform targetImageRectTransform;

    [SerializeField] private Camera mainCamera;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            // if (touch.phase == TouchPhase.Began)
            // {
            //     if (targetImageToAffect != null)
            //     {
            //         targetImageToAffect.color = Random.ColorHSV();
            //     }
            // }
            // if (touch.phase == TouchPhase.Stationary)
            // {
            //     targetImageToAffect.transform.Rotate(Vector3.back * Time.deltaTime);
            // }
            
            if (touch.phase == TouchPhase.Moved)
            {
             //   Vector2 canvasTouchPoint;
               // targetImageRectTransform.anchoredPosition = mainCamera.ScreenToViewportPoint(touch.position);

            }
        }
    }
}
