using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MovePositionTween : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float duration;
  //  [SerializeField] private AnimationCurve curve;
    [SerializeField] private Ease tweenEase;

    [SerializeField] private float curveDebugTime;
    // Start is called before the first frame update
    void Start()
    {
        // transform.DOMove(targetTransform.position, duration).SetEase(tweenEase).SetDelay(2f)
        //     .SetLoops(-1, LoopType.Yoyo);
        transform.DOScale(Vector3.one * 5, duration);
    }
}
