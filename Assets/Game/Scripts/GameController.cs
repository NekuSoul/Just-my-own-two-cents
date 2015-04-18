using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public KeyCode RestartKey = KeyCode.R;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(RestartKey))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
