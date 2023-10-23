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

    private void FixedUpdate()
    {
        movement = 0f;
        movement1 = 0f;

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

        Vector3 moveDirection = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * new Vector3(movement1, 0, movement);
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + moveDirection * speed * Time.fixedDeltaTime);

        if (movement != 0f)
        {
            Vector3 targetRotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y - 90f, 0) * new Vector3(0, movement * rotationSpeed * Time.fixedDeltaTime, 0);
            GetComponent<Rigidbody>().MoveRotation(Quaternion.Lerp(GetComponent<Rigidbody>().rotation, Quaternion.Euler(targetRotation), 10f * Time.fixedDeltaTime));
        }
    }
}
