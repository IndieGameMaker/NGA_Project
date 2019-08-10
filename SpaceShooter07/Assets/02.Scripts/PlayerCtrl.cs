using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//주인공 캐릭터가 사용할 애니메이션 클립을 저장할 클래스 선언
[System.Serializable]  //객체직렬화 어트리뷰트
public class PlayerAnim
{
    public AnimationClip idle;
    public AnimationClip runForward;
    public AnimationClip runBackward;
    public AnimationClip runLeft;
    public AnimationClip runRight;
    public AnimationClip[] dies;
}

public class PlayerCtrl : MonoBehaviour
{
    private Transform tr;
    private Animation anim;
    public PlayerAnim playerAnim; //파스칼 표기법 - 변수명을 선언

    public float moveSpeed = 5.0f;
    public float rotSpeed  = 60.0f;

    public float hp = 100.0f;

    void Start()
    {
        //PlayerCtrl 스크립트가 포함된 게임오브젝트의 Transform 컴퍼넌트를 추출해서 할당
        tr = GetComponent<Transform>();  //컴포넌트의 캐쉬
        anim = GetComponent<Animation>(); //Animation 컴포넌트 캐취 처리(변수에 할당)

        anim.Play(playerAnim.idle.name); //"Idle" 반환
    }

    //매 프레임마다 호출 
    void Update()
    {
       float v = Input.GetAxis("Vertical");     // -1.0f ~ 0.0f ~ +1.0f //상하 화살표키
       float h = Input.GetAxis("Horizontal");   // -1.0f ~ 0.0f ~ +1.0f //좌우 화살표키
       float r = Input.GetAxis("Mouse X");      //마우스를 X축으로 이동했을 때의 값

    //    Debug.Log("v=" + v); //Console View 텍스트 출력
    //    Debug.Log("h=" + h);

        //이동로직
       Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);
       //벡터.normalized  => 정규화 벡터값(크기가 1인 벡터)
       tr.Translate(dir.normalized * Time.deltaTime * moveSpeed);

        //회전로직
        tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * r);

        //애니메이션 처리
        if (v >= 0.1f) //Up Arrow 전진
        {
            anim.CrossFade(playerAnim.runForward.name, 0.3f);
        }
        else if (v <= -0.1f) //Down Arrow 후진
        {
            anim.CrossFade(playerAnim.runBackward.name, 0.3f);
        }
        else if (h >= 0.1f)  //Right Arrow 오른쪽
        {
            anim.CrossFade(playerAnim.runRight.name, 0.3f);
        }
        else if (h <= -0.1f) //Left Arrow 왼쪽
        {
            anim.CrossFade(playerAnim.runLeft.name, 0.3f);
        }
        else
        {
            anim.CrossFade(playerAnim.idle.name, 0.3f);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (hp > 0.0f && coll.CompareTag("PUNCH"))
        {
            Debug.Log(coll.gameObject.name);
            hp -= 10.0f;
            if (hp <= 0.0f)
            {
                PlayerDie();
            }
        }
    }

    void PlayerDie()
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("MONSTER");
        foreach(var monster in monsters)
        {
            //monster.GetComponent<MonsterCtrl>().PlayerDie();
            monster.SendMessage("PlayerDie",SendMessageOptions.DontRequireReceiver);
        }
    }
}
