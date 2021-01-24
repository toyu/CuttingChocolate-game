using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour 
{
    private void Start()
    {
        BGMController.Instance.ChangeBGM(SceneType.Title); 
    }
    /** stage select へ遷移する **/
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SceneManagerInstance.Instance.LoadScene("StageSelect");
        }
    }

}
