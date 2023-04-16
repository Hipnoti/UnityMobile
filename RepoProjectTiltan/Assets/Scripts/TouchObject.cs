using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TouchObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool isMouseInsideObject = false;

    private void OnMouseUp()
    {
        if (isMouseInsideObject)
            spriteRenderer.color = Random.ColorHSV();
    }

    private void OnMouseEnter()
    {
        isMouseInsideObject = true;
    }
    
    private void OnMouseExit()
    {
        isMouseInsideObject = false;
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse is down on " + gameObject.name, gameObject.transform);
    }
}
