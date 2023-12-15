using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyDragon : MonoBehaviour
{

    public GameObject dragonEggPrefab; // ������ ������ ��� ����
    public float speed = 1f; // ���������� �������� �������� �������
    public float timeBetweenEggDrops = 1f; // ���������� �������� ��������� ���
    public float leftRightDistance = 10f; // ���������� ���������� �� ����� � ������ ����� ������ �� ������� �������� ����������� �������� �������
    public float chanceDirections = 0.1f; // ���������� ����������� ��������� ����������� ��������
    void Start()
    {
    }
    void Update()
    {
        Vector3 pos = transform.position; //1
        pos.x += speed * Time.deltaTime; //2
        transform.position = pos; //3

        if (pos.x < -leftRightDistance) // ������� , ����� ������ �� ������ �� ����
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftRightDistance) 
        {
            speed = -Mathf.Abs(speed);
        }

    }

    private void FixedUpdate() // ����� ���������� ����������� ��������
    {
        if (Random.value < chanceDirections)
        {
            speed *= -1;
        }
    }

}
