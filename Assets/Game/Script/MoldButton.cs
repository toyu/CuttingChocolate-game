using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoldButton : MonoBehaviour {
    public int key, limit;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        player.GetComponent<PlayerController>().ChangeMold(key);
    }
}
