using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;


public class ObjectPool : MonoBehaviour
{
    public GameObject pool_object;
    public int count; 
    GameObject[] pool;


    public void Start()
    {
        pool = new GameObject[count];
        GameObject temp;
        for(int i = 0; i < pool.Length; i++)
        {
            temp = Instantiate(pool_object);
            temp.SetActive(false);
            pool[i] = temp;
        }  
    }


    public void OnDestroy()
    {
        Debug.Log("OnDestroy");
        for(int i = 0; i < pool.Length; i++)
        {
            Destroy(pool[i]);
        }
    }


    public GameObject[] Take(int take_count)
    {
        int counter = 0;
        GameObject[] sender = new GameObject[take_count];
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                sender[counter] = pool[i];
                counter++;
            }
        }
        while (counter < take_count)
        {
            sender[counter] = null;
            counter++;
        }

        return sender;
    }

    public GameObject Take_Single()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                return pool[i];
            }
        }
        return null;
    }
}
