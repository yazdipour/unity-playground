using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class CameraSystem : MonoBehaviour
{
    private GameObject player;
    public float minX = -4;
    public float maxX = 4;
    public float minY = 0;
    public float maxY = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        float x = Mathf.Clamp(player.transform.position.x, minX, maxX);
        float y = Mathf.Clamp(player.transform.position.y, minY, maxY);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
