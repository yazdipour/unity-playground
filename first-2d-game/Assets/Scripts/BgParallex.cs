using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgParallex : MonoBehaviour
{
    public float speed = 0.2f;
    public float position;
    void Update()
    {
        position += speed;
        if (position > 0.3f) position = 0;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(position, 0);
    }
}
