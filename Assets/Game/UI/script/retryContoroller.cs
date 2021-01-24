using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class retryContoroller : MonoBehaviour {

	public void Retry()
    {
        SceneManagerInstance.Instance.LoadScene("Game");
    }

    public void Back()
    {
        gameObject.SetActive(false);
    }
}
