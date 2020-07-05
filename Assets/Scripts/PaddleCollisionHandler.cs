using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleCollisionHandler : MonoBehaviour
{
    public void HandleBallCollision(GameObject ball)
    {
        // Reflect the ball with same velocity
        Vector3 reflectionNormal = transform.rotation * Vector3.forward;
        Vector3 velocityBeforeCollision = ball.GetComponent<Rigidbody>().velocity;
        // Only reflect if the ball is flying towards the paddle (bug fix)
        // TODO: Ball passes through the paddle!
        if(Vector3.Dot(reflectionNormal,velocityBeforeCollision) < 0)
        {
            //Vector3 velocityAfterCollision = Vector3.Reflect(velocityBeforeCollision, reflectionNormal);
            Vector3 velocityAfterCollision = (-1)*Vector3.Dot(reflectionNormal,velocityBeforeCollision)*reflectionNormal;
            ball.GetComponent<Rigidbody>().velocity = velocityAfterCollision;
        }

        // Teleport the ball back, so it won't get stuck in the paddle
        float teleportMagnitude = ball.GetComponent<SphereCollider>().radius + GetComponent<BoxCollider>().size.z/1.9f;
        Vector3 oldBallPosition = ball.transform.position;
        ball.transform.position.Set(oldBallPosition.x,oldBallPosition.y, transform.position.z + teleportMagnitude);
    }
}
