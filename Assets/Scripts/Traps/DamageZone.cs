using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] int damage;

    //List<GameObject> objectsInRange = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Entity>() && other.GetComponent<DamageOverTime>() == null)
        {
            other.gameObject.AddComponent<DamageOverTime>().Init(damage);
            //objectsInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Entity>() && other.GetComponent<DamageOverTime>() != null)
        {
            Destroy(other.GetComponent<DamageOverTime>());
            //objectsInRange.Add(other.gameObject);
        }
        //objectsInRange.Remove(other.gameObject);
    }
}
