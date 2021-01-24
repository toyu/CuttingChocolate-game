using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーの操作に関するスクリプト
public class PlayerController : MonoBehaviour {

    private GameObject cursorMold;
    public GameObject[] stageList = new GameObject[3], cursorMoldList = new GameObject[5], cuttingMoldList = new GameObject[5], moldLimitText = new GameObject[5];
    static public int stageKey = 2;
    private int moldKey = 0;
    public int[,] limit = { 
        {2,2,4,4,4},
        {1,2,2,1,2},
        {1,1,2,1,1},};
    private RaycastHit hit;
    private Ray ray;

    /** カット成功通知 **/
    public Action OnCutChocolate;

    // Use this for initialization
    void Start () {
        Instantiate(stageList[stageKey], new Vector3(0, 0, 0), new Quaternion(0, 180, 0, 0));
        cursorMold = Instantiate(cursorMoldList[moldKey], Input.mousePosition, new Quaternion(0, 0, 0, 0)) as GameObject;

        for(int i = 0; i < 5; i++)
        {
            moldLimitText[i].GetComponent<SetText>().SetLimit(limit[stageKey, i]);
        }
    }
	
	// Update is called once per frame
	void Update () {
        //型をカーソルに追従させる
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, 100f);
        cursorMold.transform.position = new Vector3(hit.point.x, cursorMoldList[moldKey].transform.localScale.y / 2f + 0.25f, hit.point.z);

        //左クリックしたとき型が被らないかつ枠外にはみ出なければ、カーソルの位置でチョコを切り抜く(置く)
        if (Input.GetMouseButtonDown(0) && cursorMold.GetComponent<MoldDecision>().triggerCount == 0 && hit.collider != null && hit.collider.tag == "chocolate" && limit[stageKey, moldKey] > 0)
        {
            Instantiate(cuttingMoldList[moldKey], cursorMold.transform.position, cursorMold.transform.rotation);

            limit[stageKey, moldKey]--;
            moldLimitText[moldKey].GetComponent<SetText>().SetLimit(limit[stageKey, moldKey]);

            if(OnCutChocolate != null)
            {
                OnCutChocolate();
            }
        }

        //右クリックしたときカーソルの型を回転
        if (Input.GetMouseButton(1))
        {
            cursorMold.transform.Rotate(new Vector3(0, 90f, 0) * Time.deltaTime, Space.World);
        }
	}

    //ボタンが押されたとき呼び出され型を切り替える
    public void ChangeMold(int k)
    {
        moldKey = k;

        Vector3 moldPosition = cursorMold.transform.position;
        Destroy(cursorMold.gameObject);
        cursorMold = Instantiate(cursorMoldList[k], moldPosition, new Quaternion(0, 180, 0, 0)) as GameObject;
    }
}
