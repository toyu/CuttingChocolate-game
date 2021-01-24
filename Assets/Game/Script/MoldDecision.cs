using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//型が被らないか判定するスクリプト
public class MoldDecision : MonoBehaviour {
    public int triggerCount = 0;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(triggerCount);
	}

    private void OnTriggerEnter(Collider other)
    {
        triggerCount++;
    }

    private void OnTriggerExit(Collider other)
    {
        triggerCount--;
    }
}
