using UnityEngine;
using System.Collections;

public class Hazard : MonoBehaviour
{
	public AudioClip GameOver;
	public AudioSource GlobalAudioSource;
	public GameObject RestartSprite;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.GetComponent<PlayerController>() is PlayerController)
		{
			other.gameObject.GetComponent<PlayerController>().enabled = false;
			other.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
			GlobalAudioSource.PlayOneShot(GameOver);
			RestartSprite.GetComponent<SpriteRenderer>().enabled = true;
		}
	}
}
