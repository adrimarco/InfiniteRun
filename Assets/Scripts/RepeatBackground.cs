using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    Vector3 startPosition;
    float repeatOffset;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        repeatOffset = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPosition.x - repeatOffset) {
            transform.Translate(repeatOffset, 0, 0);
        }
    }
}
