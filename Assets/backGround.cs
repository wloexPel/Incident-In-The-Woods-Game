using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class backGround : MonoBehaviour
{
    private float startPos, lenght;
    [SerializeField] private GameObject cam;
    [SerializeField] private float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        if (GetComponent<SpriteRenderer>() != null)
        {
            lenght = GetComponent<SpriteRenderer>().bounds.size.x;
        }
        else if (GetComponent<TilemapRenderer>() != null)
        {
            lenght = GetComponent<TilemapRenderer>().bounds.size.x;
        }
        else {
            lenght = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallaxEffect;
        float movement = cam.transform.position.x * (1 - parallaxEffect);
        
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
        if (movement > startPos + lenght-3)
        {
            startPos += lenght;
        }
        else if (movement < startPos - lenght+3)
        {
            startPos -= lenght;
        }
    }
}
