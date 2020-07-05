using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        characterController.detectCollisions = false;
        characterController.enableOverlapRecovery = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;
        movement += transform.up * Input.GetAxis("Vertical") * speed * Time.deltaTime;
        movement += transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        characterController.Move(movement);
    }
}
