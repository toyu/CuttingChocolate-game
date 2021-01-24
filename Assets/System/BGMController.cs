using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneType
{
    Title,
    StageSelect,
    Game,
    Clear,
    Fail,
}

public class BGMController : BaseSingleton<BGMController> 
{

    [SerializeField] private AudioSource source;

    [SerializeField] private AudioClip title;
    [SerializeField] private AudioClip stageSelect;
    [SerializeField] private AudioClip game;
    [SerializeField] private AudioClip clear;
    [SerializeField] private AudioClip fail;

    protected override void Awake()
    {
        base.Awake();
        source = GetComponent<AudioSource>();
    }

    public void ChangeBGM(SceneType sceneType)
    {
        AudioClip changeBGM = null;
        switch(sceneType)
        {
            case SceneType.Title:
                changeBGM = title;
                break;
            case SceneType.StageSelect:
                changeBGM = stageSelect;
                break;
            case SceneType.Game:
                changeBGM = game;
                break;
            case SceneType.Clear:
                changeBGM = clear;
                break;
            case SceneType.Fail:
                changeBGM = fail;
                break;
        }
        source.clip = changeBGM;
        source.Play();
    }
	
}
