using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private const int RIGHT_GAME_BORDER_X = 210;
    
    [SerializeField] private float speed = 5f;
    // Update is called once per frame
    public void UpdateProjectile()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);

        if (transform.position.x >= RIGHT_GAME_BORDER_X)
        {
            gameObject.SetActive(false);
        }
    }
}
