using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int TotalUseableMoldTimes { get; private set; }
    public Action OnGameClear;
    [SerializeField] private AudioClip kurinukiSE;

    private void Awake()
    {
        BGMController.Instance.ChangeBGM(SceneType.Game);

        PlayerController plCon = FindObjectOfType<PlayerController>();
        for (int i = 0; i < 5 ; i++ )
        {
            TotalUseableMoldTimes += plCon.limit[PlayerController.stageKey, i];
        }

        /** チョコを抜くたびにプログレスバーを進める **/
        plCon.OnCutChocolate += () =>
        {
            SoundController.Instance.PlayOnShot(kurinukiSE);
			int currentTotalUseableMoldTimes = 0;
            for (int i = 0; i < 5; i++)
            {
                currentTotalUseableMoldTimes += plCon.limit[PlayerController.stageKey, i];
            }

            int alreadyUsedMoldTimes = TotalUseableMoldTimes - currentTotalUseableMoldTimes;

            float totalUseableMoldTimesRatio =  alreadyUsedMoldTimes / (float)TotalUseableMoldTimes;
            progressBar progress_bar =  FindObjectOfType<progressBar>();
            progress_bar.num = totalUseableMoldTimesRatio;

            bool isGameClear = totalUseableMoldTimesRatio >= 1.0f;
            if(isGameClear)
            {
                BGMController.Instance.ChangeBGM(SceneType.Clear);
                if(OnGameClear != null)
                {
                    SaveStageClearData(0);
                    OnGameClear();
                }
            }
        };
            
    }

    /** 対象のステージをクリアしたデータのセーブを行う。 **/
    private void SaveStageClearData(int targetStageKey)
    {
        string keyName = targetStageKey.ToString();
        PlayerPrefs.SetInt(keyName,1);
    }

}
