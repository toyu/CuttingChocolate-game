using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class clearController : MonoBehaviour
{
    public void Select()
    {
        SceneManagerInstance.Instance.LoadScene("StageSelect");
    }

    public void Next()
    {
        PlayerController.stageKey += 1;
        if (PlayerController.stageKey > 2)
            PlayerController.stageKey = 0;

        SceneManagerInstance.Instance.LoadScene("Game");
    }
}
   

