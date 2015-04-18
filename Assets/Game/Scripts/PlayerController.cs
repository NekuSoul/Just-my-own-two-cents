using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public GameObject GroundPosition;
    public float JumpForce = 1f;
    public float MovementSpeed = 1f;
    public KeyCode UpKey = KeyCode.W;
    public KeyCode LeftKey = KeyCode.A;
    public KeyCode RightKey = KeyCode.D;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float movementX = (Input.GetKey(LeftKey) ? -1 : 0) + (Input.GetKey(RightKey) ? 1 : 0);
        transform.position += (Vector3)(new Vector2(movementX, 0) * MovementSpeed * Time.deltaTime);
        if (movementX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movementX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (IsPlayerOnGround() && Input.GetKeyDown(UpKey))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }

    bool IsPlayerOnGround()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(GroundPosition.transform.position, -Vector2.up, 0.1f);
        foreach (RaycastHit2D hit in hits)
        {
            if (Properties.ContainsProperty(hit.transform.gameObject, "Ground"))
            {
                transform.parent = hit.transform;
                return true;
            }
        }
        transform.parent = null;
        return false;
    }
}
