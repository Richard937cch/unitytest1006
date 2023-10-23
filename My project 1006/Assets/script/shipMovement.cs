using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMovement : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 100f;
    public float verticalInput;
    private float movement = 0f;
    private float movement1 = 0f;

    public GameObject objectToSpawn;

    public float delay = 1.5f;
    float timer=0;


    private void FixedUpdate()
    {
        movement = 0f;
        movement1 = 0f;
        timer += Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            movement += 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement -= 1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement1 += 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement1 -= 1f;
        }


        if (Input.GetKey(KeyCode.Space) )
        {
            
       
            if (timer > delay)
            {
                GameObject newObject = Instantiate(objectToSpawn);
                newObject.transform.position = transform.position;
                //newObject.transform.position[0] += 0.65f;
                //enabled = false;
                timer =0;
            }
            
            
        }


        Vector3 moveDirection = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * new Vector3(movement1, 0, movement);
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + moveDirection * speed * Time.fixedDeltaTime);

        if (movement != 0f)
        {
            Vector3 targetRotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y - 90f, 0) * new Vector3(0, movement * rotationSpeed * Time.fixedDeltaTime, 0);
            GetComponent<Rigidbody>().MoveRotation(Quaternion.Lerp(GetComponent<Rigidbody>().rotation, Quaternion.Euler(targetRotation), 10f * Time.fixedDeltaTime));
        }
    }
}
