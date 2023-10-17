using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] Rigidbody2D myRigid;

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("KYS"))
        {
            Destroy(gameObject);
        }
    }
}
