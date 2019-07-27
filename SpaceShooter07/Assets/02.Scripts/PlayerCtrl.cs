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

       Debug.Log("v=" + v); //Console View 텍스트 출력
       Debug.Log("h=" + h);

        //이동로직
       Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);
       //벡터.normalized  => 정규화 벡터값(크기가 1인 벡터)
       tr.Translate(dir.normalized * Time.deltaTime * moveSpeed);

        //회전로직
        tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * r);

    //    tr.Translate(Vector3.forward * v * Time.deltaTime * 3.0f);
    //    tr.Translate(Vector3.right * h * Time.deltaTime * 3.0f);

       /* 단위벡터, 유닛벡터, 정규화벡터 : 방향만을 가리키는 벡터 (크기 1인 벡터)
       Vector3.forward = Vector3(0, 0, 1)
       Vector3.up      = Vector3(0, 1, 0)
       Vector3.right   = Vector3(1, 0, 0)

       Vector3.one     = Vector3(1, 1, 1)
       Vector3.zero    = Vector3(0, 0, 0)       
       */



    }


}
