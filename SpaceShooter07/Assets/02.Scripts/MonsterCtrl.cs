using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    //몬스터의 상태
    public enum State
    {
        IDLE,
        TRACE,
        ATTACK,
        DIE
    }

    //몬스터의 상태를 저장할 변수
    public State state = State.IDLE;

    public float attackDist = 2.0f;
    public float traceDist  = 10.0f;
    public bool isDie       = false;

    private Transform monsterTr;
    private Transform playerTr;

    // Start is called before the first frame update
    void Start()
    {
        monsterTr = GetComponent<Transform>();
        playerTr  = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
