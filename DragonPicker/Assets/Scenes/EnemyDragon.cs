using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyDragon : MonoBehaviour
{

    public GameObject dragonEggPrefab; // создаЄт префаб дл€ ийца
    public float speed = 1f; // определ€ет скорость движени€ объекта
    public float timeBetweenEggDrops = 1f; // определ€ет скорость генерации €иц
    public float leftRightDistance = 10f; // определ€ет рассто€ние от левых и правых краев экрана на котором мен€етс€ направление движени€ дракона
    public float chanceDirections = 0.1f; // ќпредел€ет веро€тность изменени€ направлени€ движени€
    void Start()
    {

        Invoke("DropEgg", 2f); // 1

    }

    void DropEgg() // 2
    {
        Vector3 myVector = new
        Vector3(0.0f, 5.0f, 0.0f);
        GameObject egg =
        Instantiate<GameObject>(dragonEggPrefab);
        egg.transform.position =
        transform.position + myVector;
        Invoke("DropEgg", timeBetweenEggDrops);
    }

    void Update()
    {
        Vector3 pos = transform.position; //1
        pos.x += speed * Time.deltaTime; //2
        transform.position = pos; //3

        if (pos.x < -leftRightDistance) // условие , чтобы дракон не улетал за кра€
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftRightDistance) 
        {
            speed = -Mathf.Abs(speed);
        }

    }

    private void FixedUpdate() // метод случайного направлени€ движени€
    {
        if (Random.value < chanceDirections)
        {
            speed *= -1;
        }
    }

}
