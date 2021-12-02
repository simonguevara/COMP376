using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class GroundTrapScript : MonoBehaviour
{

    public int damage = 1;
    public float interval = 1.0f;

    private List<GameObject> inAreaList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("dealDamage", 0.0f, interval);
    }

    private void dealDamage()
    {
        for(int i =0; i < inAreaList.Count; i++)
        {
            GameObject obj = inAreaList[i];

            if (obj.CompareTag("Player"))
            {
                obj.GetComponent<PlayerSam>().TakeRadiationDamage(damage);
            }
            if (obj.CompareTag("Enemy"))
            {
                obj.GetComponent<EnemyScript>().takeDamage(damage);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("Enemy"))
        {
            inAreaList.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < inAreaList.Count; i++)
        {
            if (Object.ReferenceEquals(inAreaList[i], collision.gameObject)){ 
                inAreaList.RemoveAt(i);
            }
        }
    }
}
