using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DragonEgg : MonoBehaviour
{
    public static float bottomY = -30f; //переменная bottomY, которая будет указывать, на каком расстоянии Y нужно будет удалять объекты DragonEgg.
    public AudioSource audioSource;



    void Start()
    {
    }
    private void OnTriggerEnter(Collider other) //По названию метода OnTriggerEnter (Collision Other) можно понять, что он начинает работу, когда происходит пересечение с объектом, который работает как Trigger.
    //В нашем случае таким объектом-триггером будет выступать плоскость Plane. При срабатывании триггера запускается проигрывание Particle System (em.enabled = true), и яйцо становится невидимым (rend.enabled = false).
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = true;
        Renderer rend;
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();

    }
    void Update() //внутри метода Update происходит уничтожение объекта DragonEgg (Destroy(this.gameObject)), если яйцо падает ниже уровня -10f. Это позволяет избежать накопления ненужных объектов за пределами игровой сцены.
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            DragonPicker apScript = Camera.main.GetComponent<DragonPicker>();
            apScript.DragonEggDestroyed();

        }
    }
}
