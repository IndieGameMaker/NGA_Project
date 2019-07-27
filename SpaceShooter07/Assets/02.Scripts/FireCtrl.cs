using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;

    void Update()
    {
        //마우스 왼쪽 버튼을 한번 클릭했을 때
        if (Input.GetMouseButtonDown(0))
        {
            //동적 총알(Bullet)을 생성 (생성할 객체, 위치, 회전)
            Instantiate(bullet, firePos.position, firePos.rotation);
        }
    }
}
