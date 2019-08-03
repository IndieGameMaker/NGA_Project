using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    private int hitCount;
    //폭발효과 프리팹을 저장할 변수
    public GameObject expEffect;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            if (++hitCount == 3)
            {
                ExpBarrel();
            }
        }
    }

    public void ExpBarrel()
    {
        if (GetComponent<Rigidbody>() == null)
        {
            Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
            rb.AddForce(Vector3.up * 1500.0f);
            Destroy(this.gameObject, 2.0f);

            GameObject effect = Instantiate(expEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1.5f);
        }
    }
}
