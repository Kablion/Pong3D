using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleTileCollisionHandler : MonoBehaviour
{
    public Vector2 tilePosition;

    public float addedSpeed;

    public float speedMultiplier;

    public Animator animator;

    public void HandleBallCollision(GameObject ball)
    {
        // Generell Paddle-Ball Collision
        transform.parent.gameObject.GetComponent<PaddleCollisionHandler>().HandleBallCollision(ball);

        // Tile dependent Ball Collision
        // Increase speed Of ball 
        // in appropriate direction 
        // considering the tile's position
        Vector3 addedVelocity = Vector3.forward + (Vector3)tilePosition*2;
        addedVelocity.Normalize();
        addedVelocity *= addedSpeed;
        //addedVelocity *= ball.GetComponent<Rigidbody>().velocity.magnitude*speedMultiplier;
        ball.GetComponent<Rigidbody>().AddForce(addedVelocity,ForceMode.VelocityChange);

        // Animate the Hit
        animator.SetTrigger("HitTrigger");
    }
}
