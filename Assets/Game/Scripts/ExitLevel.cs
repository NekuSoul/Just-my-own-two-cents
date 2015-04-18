using UnityEngine;
using System.Collections;

public class ExitLevel : MonoBehaviour
{
    public string NextScene;
    public AudioClip ExitSound;
    public AudioSource GlobalAudioSource;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() is PlayerController)
        {
            other.gameObject.GetComponent<PlayerController>().enabled = false;
            GlobalAudioSource.PlayOneShot(ExitSound);
            Invoke("ChangeLevel", 1f);
        }
    }

    void ChangeLevel()
    {
        Application.LoadLevel(NextScene);
    }
}
