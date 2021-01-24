using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetLimit(int limit)
    {
        GetComponent<UnityEngine.UI.Text>().text = (limit).ToString();
    }
}
