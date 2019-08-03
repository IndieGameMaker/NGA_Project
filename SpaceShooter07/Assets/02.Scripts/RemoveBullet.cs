using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;

    //충돌이 발생하면 1번 호출됨
    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "BULLET")
        {
            //충돌한 접점 정보를 추출
            ContactPoint[] points = coll.contacts;
            //스파크이펙트를 동적으로 생성  Instantiate(객체, 위치, 각도);
            //Quaternion.LookRotation(벡터) --> 벡터의 각도를 쿼터니언 타입으로 변환(산출)
            GameObject spark = Instantiate(sparkEffect
                                        , points[0].point
                                        , Quaternion.LookRotation(points[0].normal));
            
            //Destroy(삭제할 객체, 지연시간)
            Destroy(spark, 0.6f);

            Destroy(coll.gameObject);
        }
    }
}
