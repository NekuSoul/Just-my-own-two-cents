using UnityEngine;
using System.Collections;

public class Properties : MonoBehaviour
{
	public string[] PropertyCollection;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public bool ContainsProperty(string Property)
	{
		foreach (string s in PropertyCollection)
		{
			if(s==Property)
			{
				return true;
			}
		}
		return false;
	}

	public static bool ContainsProperty(GameObject Object,string Property)
	{
		Properties p = Object.GetComponent<Properties>();
		if(p==null)
		{
			return false;
		}
		else
		{
			return p.ContainsProperty(Property);
		}
	}
}
