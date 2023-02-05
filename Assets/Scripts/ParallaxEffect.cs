using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{

    private float length, startposX, startposY;
    public float parallaxFactor;
    public GameObject cam;
    
    // Start is called before the first frame update
    void Start()
    {

        startposY = transform.position.y;
        startposX = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    // Update is called once per frame
    void Update()
    {

        float temp = cam.transform.position.x * (1 - parallaxFactor);
        float distance = cam.transform.position.x * parallaxFactor;

        Vector3 newPosition = new Vector3(startposX + distance, startposY, transform.position.z);

        transform.position = newPosition;

        if (temp > startposX + (length)) startposX += length;
        else if (temp < startposX - (length)) startposX -= length;

    }
}
