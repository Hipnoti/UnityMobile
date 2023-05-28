using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        for (int i = 0; i < 40; i++)
        {
            Projectile instadProjectile = Instantiate(projectilePrefab);
            instadProjectile.transform.SetParent(parentGO.transform);
            instadProjectile.gameObject.SetActive(false);
            instantiatedProjectiles.Add(instadProjectile);
        }
    }

    void Update()
    {
        Vector3 currentAccelration = Vector3.zero;
        //currentAccelration = Input.acceleration;
        currentAccelration = Input.gyro.userAcceleration;

        transform.Translate(currentAccelration * (Time.deltaTime * speed));

        // debugText.text = currentAccelration.ToString();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Projectile projectileToPull = GetObjectFromPool();
            if (projectileToPull != null)
            {
                projectileToPull.gameObject.SetActive(true);
                projectileToPull.transform.position = projectileSpawnPoint.position;
                projectileToPull.transform.rotation = projectileSpawnPoint.rotation;
            }
        }
    }

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
