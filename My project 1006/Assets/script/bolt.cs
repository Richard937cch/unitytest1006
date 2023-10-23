using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolt : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;

    private void Update()
    {
        MoveBolt();
    }

    private void MoveBolt()
    {
        Vector3 newPosition = transform.position + Vector3.forward * speed * Time.deltaTime;
        transform.position = newPosition;
        
    }
    
    
}
