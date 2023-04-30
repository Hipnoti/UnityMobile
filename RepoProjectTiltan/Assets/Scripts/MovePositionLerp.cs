using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePositionLerp : MonoBehaviour
{

    [SerializeField] private Transform targetTransform;
    [SerializeField] private float lerpDuration;
    
    private Vector3 startingPosition;
    private bool movingTowardsTarget = false;
    
    private float sumTimePassed = 0;
    
    void Start()
    {
        startingPosition = transform.position;
        movingTowardsTarget = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingTowardsTarget)
        {
            sumTimePassed += Time.deltaTime;
           transform.position = Vector3.Lerp(startingPosition, targetTransform.position, sumTimePassed/lerpDuration);
           if (sumTimePassed >= lerpDuration)
               movingTowardsTarget = false;
        }
    }
}
