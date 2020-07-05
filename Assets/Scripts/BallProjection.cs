using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallProjection : MonoBehaviour
{
    public GameObject sideWallProjection;
    public GameObject horizonatalWallProjection;
    public GameObject verticalWallProjection;

    // Update is called once per frame
    void Update()
    {
        sideWallProjection.transform.SetPositionAndRotation(new Vector3(0,0,transform.position.z),Quaternion.identity);
        horizonatalWallProjection.transform.SetPositionAndRotation(new Vector3(0,transform.position.y,0),Quaternion.identity);
        verticalWallProjection.transform.SetPositionAndRotation(new Vector3(transform.position.x,0,0),Quaternion.identity);
    }
}
