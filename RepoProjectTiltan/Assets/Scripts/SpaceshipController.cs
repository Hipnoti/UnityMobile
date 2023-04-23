using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    [SerializeField] private TextMeshProUGUI debugText;   
    void Update()
    {
        Vector3 currentAccelration = Vector3.zero;
            //currentAccelration = Input.acceleration;
            currentAccelration = Input.gyro.userAcceleration;

            currentAccelration.z = -currentAccelration.z;
        transform.Translate(currentAccelration * (Time.deltaTime * speed));

        debugText.text = currentAccelration.ToString();
    }
}
