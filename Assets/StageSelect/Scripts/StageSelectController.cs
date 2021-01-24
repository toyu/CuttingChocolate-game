using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectController : MonoBehaviour 
{
    private List<StageSelectItem> stageSelectItemList;
    private StageSelectViewer stageSelectViewer;
    private StageInfo curSelectInfo;

    private void Awake()
    {
        BGMController.Instance.ChangeBGM(SceneType.StageSelect);

		stageSelectViewer = GetComponentInChildren<StageSelectViewer>();
        stageSelectViewer.OnSelectViwerButton += () =>
        {
            SceneManager.LoadScene("Game");
        };

        stageSelectItemList = GetComponentsInChildren<StageSelectItem>().ToList();

        foreach(var stageSelectItem in stageSelectItemList)
        {
            
            /** 選択された際にViewに情報を渡す。 **/
            stageSelectItem.OnSelectStageItem += (StageInfo stageInfo) => 
            {
                curSelectInfo = stageInfo;
                Sprite img = curSelectInfo.StageImage;
                stageSelectViewer.SetViewrImg(img); 
            };
        }
    }

    public void BackToTitle()
    {
        SceneManagerInstance.Instance.LoadScene("Title");
    }



}
