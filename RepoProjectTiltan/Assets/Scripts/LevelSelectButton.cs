using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelSelectButton : MonoBehaviour
{
    public TextMeshProUGUI levelSelectText;
    
    [SerializeField] private int levelNumber;

    private void Awake()
    {
        levelSelectText.text = "Level " + levelNumber;
    }

    public void LoadLevel()
    {
        Debug.Log("LoadLevel from LevelSelectButton");
        GameManager.Instance.LoadLevel(levelNumber);
    }
    
}
