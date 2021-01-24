using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class optionContoroller : MonoBehaviour {

   

   
    public void Select()
    {
        SceneManagerInstance.Instance.LoadScene("StageSelect");
    }

    public void Retry()
    {
        transform.Find("Retry").gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
