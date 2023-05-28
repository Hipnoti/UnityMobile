using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;
    
    [SerializeField] private float speed = 30f;
    [SerializeField] private TextMeshProUGUI debugText;

    private List<Projectile> instantiatedProjectiles = new List<Projectile>();

    private void Start()
    {
        GameObject parentGO = new GameObject("Objects Pool");
        for (int i = 0; i < 50; i++)
        {
            Projectile instadProjectile = Instantiate(projectilePrefab, parentGO.transform);
            instadProjectile.gameObject.SetActive(false);
            instantiatedProjectiles.Add(instadProjectile);
        }
    }

    void Update()
    {
        // Vector3 currentAccelration = Vector3.zero;
        // //currentAccelration = Input.acceleration;
        // currentAccelration = Input.gyro.userAcceleration;

    //    transform.Translate(currentAccelration * (Time.deltaTime * speed));

        // debugText.text = currentAccelration.ToString();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Projectile projectileToPull = GetObjectFromPool();
            if (projectileToPull)
            {
                projectileToPull.gameObject.SetActive(true);
                Transform projectileTransform = projectileToPull.transform;
                projectileTransform.position = projectileSpawnPoint.position;
                projectileTransform.rotation = projectileSpawnPoint.rotation;
            }
        }

        foreach (Projectile projectile in instantiatedProjectiles)
        {
            if (projectile.gameObject.activeInHierarchy)
            {
                projectile.UpdateProjectile();
            }
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    Projectile GetObjectFromPool()
    {
        foreach (Projectile projectile in instantiatedProjectiles)
        {
            if (!projectile.gameObject.activeSelf)
                return projectile;
        }

        Debug.LogWarning("No object to pool! we need more objects." + Environment.NewLine + "Must construct additional objects");
        return null;
    }
}
