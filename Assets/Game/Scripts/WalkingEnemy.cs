using UnityEngine;
using System.Collections;

public class WalkingEnemy : MonoBehaviour
{
    public GameObject GroundPosition;
    public GameObject AirCheckPosition;
    public GameObject AirhBehindCheckPosition;
    public bool Dead = false;
    public float MovementSpeed = 1f;
    public bool WalkingRight;

    // Use this for initialization
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        if (IsPlayerOnGround())
        {
            bool gapBehind = IsGapBehind() || IsWallAhead();
            bool gapAhead = IsGapAhead() || IsWallAhead();
            if (gapAhead && !IsGapBehind())
            {
                WalkingRight = !WalkingRight;
            }
            if (!(gapBehind && gapAhead))
            {
                float movementX = WalkingRight ? 1 : -1;
                transform.position += (Vector3)(new Vector2(movementX, 0) * MovementSpeed * Time.deltaTime);
                if (WalkingRight)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
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

    bool IsGapAhead()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(AirCheckPosition.transform.position, -Vector2.up, 0.5f);
        foreach (RaycastHit2D hit in hits)
        {
            if (Properties.ContainsProperty(hit.transform.gameObject, "Ground"))
            {
                transform.parent = hit.transform;
                return false;
            }
        }
        transform.parent = null;
        return true;
    }

    bool IsWallAhead()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.right * (WalkingRight ? 1 : -1), 0.25f);
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

    bool IsGapBehind()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(AirhBehindCheckPosition.transform.position, -Vector2.up, 0.5f);
        foreach (RaycastHit2D hit in hits)
        {
            if (Properties.ContainsProperty(hit.transform.gameObject, "Ground"))
            {
                transform.parent = hit.transform;
                return false;
            }
        }
        transform.parent = null;
        return true;
    }

    bool IsWallBehind()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.right * (WalkingRight ? -1 : 1), 0.25f);
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
