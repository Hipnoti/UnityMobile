using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CanvasGroupCompanion : MonoBehaviour
{

    [SerializeField] private CanvasGroup _canvasGroup;
    
    void Start()
    {
        AudioSource source;
        
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.DOFade(1, 10f).SetEase(Ease.Linear).OnKill(TweenKilled).OnComplete(FadeCompleted);
    }

    void FadeCompleted()
    {
        Debug.Log("The fade is complete!");
        _canvasGroup.interactable = true;
    }

    [ContextMenu("Stop Tween")]
    void StopTween()
    {
        _canvasGroup.DOKill(true);
    }

    void TweenKilled()
    {
        Debug.Log("F");
    }
}
