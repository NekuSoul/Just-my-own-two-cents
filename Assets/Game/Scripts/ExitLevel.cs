using UnityEngine;
using System.Collections;

public class ExitLevel : MonoBehaviour 
{
	public string NextScene;

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
			Application.LoadLevel(NextScene);
		}
	}
}
