using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Vector3 startPosition;
    public float startForwardSpeed;
    public float startSidewardSpeed;
    
    public LayerMask paddleTileLayer;

    void Start()
    {
        Reset();
    }

    void FixedUpdate()
    {
        // Check Collision with Paddle Tile
        // First do a RayCast so the right tile will get the collision
        // If a Raycast didn't hit maybe the SphereCast hit anyway
        Vector3 origin = transform.position;
        float radius = transform.localScale.x*GetComponent<SphereCollider>().radius;
        Vector3 direction = GetComponent<Rigidbody>().velocity;
        RaycastHit hit;
        float maxDistance = direction.magnitude*Time.deltaTime;
        if(Physics.Raycast(origin,direction,out hit, maxDistance, paddleTileLayer))
        {
            hit.collider.gameObject.GetComponent<PaddleTileCollisionHandler>().HandleBallCollision(gameObject);
        }
        else if(Physics.SphereCast(origin, radius, direction, out hit, maxDistance, paddleTileLayer))
        {
            hit.collider.gameObject.GetComponent<PaddleTileCollisionHandler>().HandleBallCollision(gameObject);
        }
    }

    public void Reset() 
    {
        transform.position = startPosition;
        Vector3 startForwardVelocity = transform.forward * (-1) * startForwardSpeed;
        Vector3 startSidewardVelocity = Quaternion.Euler(0,0,Random.Range(0,360)) * transform.up * startSidewardSpeed;
        gameObject.GetComponent<Rigidbody>().velocity = startForwardVelocity + startSidewardVelocity*0;
    }
}
