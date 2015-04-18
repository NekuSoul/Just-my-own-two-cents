using UnityEngine;
using System.Collections;

public class CentController : MonoBehaviour
{
    public float MovementSpeed = 1f;
    public KeyCode UpKey = KeyCode.UpArrow;
    public KeyCode DownKey = KeyCode.DownArrow;
    public KeyCode LeftKey = KeyCode.LeftArrow;
    public KeyCode RightKey = KeyCode.RightArrow;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float movementX = (Input.GetKey(LeftKey) ? -1 : 0) + (Input.GetKey(RightKey) ? 1 : 0);
        float movementY = (Input.GetKey(DownKey) ? -1 : 0) + (Input.GetKey(UpKey) ? 1 : 0);
        transform.position += (Vector3)(new Vector2(movementX, movementY) * MovementSpeed * Time.deltaTime);
    }
}
