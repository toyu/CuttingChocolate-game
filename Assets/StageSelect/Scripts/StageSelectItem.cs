using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class StageInfo
{
    [SerializeField] private string stageName;
    [SerializeField] private Sprite stageImage;
	[SerializeField] private int stageKey;

    public string StageName
    {
        get { return stageName; }
    }

    public Sprite StageImage
    {
        get { return stageImage; }
    }

    public int StageKey
    {
        get { return stageKey; }
    }
}

public class StageSelectItem : MonoBehaviour 
{
    [SerializeField] private StageInfo stageInfo;
    [SerializeField] private Image clearCheckImage;
    public Action<StageInfo> OnSelectStageItem;
    public AudioClip systemBtn;
    public bool IsClear
    {
        get
        {
            int stageKey = int.Parse(stageInfo.StageName.Substring(5, 3));
            return PlayerPrefs.GetInt(stageKey.ToString()) > 0;
        }
    }


    /** ボタンを押された時にステージの情報を渡す **/
    private void Start()
    {
        if(IsClear)
        {
            clearCheckImage.enabled = true;
        }
        else
        {
            clearCheckImage.enabled = false;
        }

        Button button = GetComponent<Button>();
        button.onClick.AddListener( () => 
        {
            SoundController.Instance.PlayOnShot(systemBtn);
            if(OnSelectStageItem != null)
            {
                PlayerController.stageKey = stageInfo.StageKey;
                OnSelectStageItem(this.stageInfo);
            }
        });
    }
}
