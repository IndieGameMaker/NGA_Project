using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public AudioClip fireSfx;   //총소리 오디오 클립을 저장할 변수

    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        //마우스 왼쪽 버튼을 한번 클릭했을 때
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        //동적 총알(Bullet)을 생성 (생성할 객체, 위치, 회전)
        Instantiate(bullet, firePos.position, firePos.rotation);
        //총소리 발생 (소리를 중첩해서 발생)
        source.PlayOneShot(fireSfx);
    }
}
