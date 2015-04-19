using UnityEngine;
using System.Collections;

public class AlphaClipping : MonoBehaviour
{
    public float AlphaClipPercentage = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (AlphaClipPercentage < 2)
        {
            AlphaClipPercentage += Time.deltaTime;
            SpriteRenderer s = GetComponent<SpriteRenderer>();
            s.material.SetFloat("_AlphaClip", AlphaClipPercentage * 0.75f);
        }
    }
}
