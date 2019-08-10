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
    private WaitForSeconds ws;

    void Start()
    {
        ws = new WaitForSeconds(0.3f);

        monsterTr = GetComponent<Transform>();
        playerTr  = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
        StartCoroutine(CheckMonsterState());
    }

    //몬스터의 상태만 체크
    IEnumerator CheckMonsterState()
    {
        while(!isDie)
        {
            yield return ws;

            float dist = Vector3.Distance(monsterTr.position, playerTr.position);
            //몬스터와 주인공간의 거리가 공격사정거리 이내인 경우
            if (dist <= attackDist)
            {
                state = State.ATTACK;
            }
            //공격사정거리보다 크고 추적사정거리 이내인 경우
            else if (dist <= traceDist)
            {
                state = State.TRACE;
            }
            else
            {
                state = State.IDLE;
            }
        }
    }

    //몬스터의 상태값에 따른 몬스터의 행동을 정의
    IEnumerator MonsterAction()
    {
        while(!isDie)
        {
            
            yield return ws;
        }
    }
}
