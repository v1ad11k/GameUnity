using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DragonEgg : MonoBehaviour
{
    public static float bottomY = -30f; //���������� bottomY, ������� ����� ���������, �� ����� ���������� Y ����� ����� ������� ������� DragonEgg.

    void Start()
    {
    }
    private void OnTriggerEnter(Collider other) //�� �������� ������ OnTriggerEnter (Collision Other) ����� ������, ��� �� �������� ������, ����� ���������� ����������� � ��������, ������� �������� ��� Trigger.
    //� ����� ������ ����� ��������-��������� ����� ��������� ��������� Plane. ��� ������������ �������� ����������� ������������ Particle System (em.enabled = true), � ���� ���������� ��������� (rend.enabled = false).
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = true;
        Renderer rend;
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }
    void Update() //������ ������ Update ���������� ����������� ������� DragonEgg (Destroy(this.gameObject)), ���� ���� ������ ���� ������ -10f. ��� ��������� �������� ���������� �������� �������� �� ��������� ������� �����.
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
        }
    }
}
