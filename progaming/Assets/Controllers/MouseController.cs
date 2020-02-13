using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public GameObject cursorBlockOver;
    public GameObject cursorBlockClick;
    Vector3 lastFramePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenuController.isGamePause)
        {
            Vector3 currentFramePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Cursor Block Controller
            cursorBlockOver.transform.position = new Vector2(Mathf.RoundToInt(currentFramePosition.x), Mathf.RoundToInt(currentFramePosition.y));
            if (Input.GetMouseButtonDown(0))
            {
                cursorBlockClick.SetActive(true);
                cursorBlockClick.transform.position = cursorBlockOver.transform.position;
            }
            if (Input.GetMouseButtonDown(1))
            {
                cursorBlockClick.SetActive(false);
            }

            // Screen Dragging
            if (Input.GetMouseButton(2))
            {
                Camera.main.GetComponent<CameraController>().isFollowing = false;
            }
            else
            {
                Camera.main.GetComponent<CameraController>().isFollowing = true;
            }
            if (Input.GetMouseButton(2) && Camera.main.GetComponent<CameraController>().isFollowing == false) // Middle Mouse Button
            {
                Vector3 diff = lastFramePosition - currentFramePosition;
                Camera.main.transform.Translate(diff);
            }

            lastFramePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
