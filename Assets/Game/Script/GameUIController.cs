using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : MonoBehaviour 
{
    [SerializeField] private GameObject clearPupup;
    [SerializeField] private GameObject bobne;
    [SerializeField] private GameObject gauge;


    private void Start()
    {
        clearPupup.SetActive(false);
        bobne.SetActive(false);

        GameController gameCon = FindObjectOfType<GameController>();
        gameCon.OnGameClear += () =>
        {
            Destroy(gauge.gameObject);
            clearPupup.gameObject.SetActive(true);
            bobne.gameObject.SetActive(true);
        };
    }

}
