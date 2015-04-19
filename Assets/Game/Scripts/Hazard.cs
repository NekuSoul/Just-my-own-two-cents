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
			other.transform.localScale = new Vector3(other.transform.localScale.x, -1, 1);
			other.GetComponent<Rigidbody2D>().isKinematic = false;
			other.GetComponent<BoxCollider2D>().enabled = false;
			other.gameObject.GetComponent<PlayerController>().enabled = false;
			other.transform.parent = null;
			other.gameObject.GetComponent<PlayerController>().Dead = true;
			other.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
			other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
			GlobalAudioSource.PlayOneShot(GameOver);
			RestartSprite.GetComponent<SpriteRenderer>().enabled = true;
			RestartSprite.GetComponent<AlphaClipping>().AlphaClipPercentage = 0f;
		}

		// EnemyCollision
		if (other.gameObject.GetComponent<WalkingEnemy>() is WalkingEnemy)
		{
			if (!other.gameObject.GetComponent<WalkingEnemy>().Dead)
			{
				other.transform.localScale = new Vector3(-other.transform.localScale.x, -1, 1);
				other.GetComponent<Rigidbody2D>().isKinematic = false;
				other.GetComponent<BoxCollider2D>().enabled = false;
				other.transform.parent = null;
				other.gameObject.GetComponent<WalkingEnemy>().enabled = false;
				other.gameObject.GetComponent<WalkingEnemy>().Dead = true;
				other.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
				other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
				GlobalAudioSource.PlayOneShot(GameOver);
			}
		}
	}
}
