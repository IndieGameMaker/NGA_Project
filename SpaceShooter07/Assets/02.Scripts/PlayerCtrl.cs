using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Transform tr;

    void Start()
    {
        //PlayerCtrl 스크립트가 포함된 게임오브젝트의 Transform 컴퍼넌트를 추출해서 할당
        //tr = this.gameObject.GetComponent<Transform>();
        tr = GetComponent<Transform>();  //컴포넌트의 캐쉬
    }

    //매 프레임마다 호출 
    void Update()
    {
       float v = Input.GetAxis("Vertical");     // -1.0f ~ 0.0f ~ +1.0f //상하 화살표키
       float h = Input.GetAxis("Horizontal");   // -1.0f ~ 0.0f ~ +1.0f //좌우 화살표키

       Debug.Log("v=" + v); //Console View 텍스트 출력
       Debug.Log("h=" + h);

       Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);
       tr.Translate(dir.normalized * Time.deltaTime * 3.0f);

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
