using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 resetPosition;
    private float resetWidth;
    // Start is called before the first frame update
    void Start()
    {
        resetPosition = transform.position;
        resetWidth = GetComponent<BoxCollider>().size.x / 2;//SpriteRenderer can be used to get the width instead
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < resetPosition.x - resetWidth)
        {
            transform.position = resetPosition;
        }
    }


}
