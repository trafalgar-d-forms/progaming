using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExtraInfoMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject extraInfo;
    public bool showExtraInfo;

    // Start is called before the first frame update
    void Start()
    {
        showExtraInfo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            showExtraInfo = !showExtraInfo;
            extraInfo.SetActive(showExtraInfo);
        }
        if (showExtraInfo)
        {
            extraInfo.GetComponent<TextMeshProUGUI>().text = "x: " + Mathf.RoundToInt(player.transform.position.x) + "; y: " + Mathf.RoundToInt(player.transform.position.y) + "\n" + Mathf.RoundToInt(1.0f / Time.smoothDeltaTime) + " fps";
        }
    }
}
