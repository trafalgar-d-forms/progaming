using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public bool isFollowing;

    // Start is called before the first frame update
    void Start()
    {
        isFollowing = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        const int orthographicSizeMin = 2;
        const int orthographicSizeMax = 8;

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Camera.main.orthographicSize++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Camera.main.orthographicSize--;
        }
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, orthographicSizeMin, orthographicSizeMax);
        if (isFollowing)
        {
            this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        }
    }
}
