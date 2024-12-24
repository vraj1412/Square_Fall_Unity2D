using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ObjectPooling : MonoBehaviour
{

    public List<PrefabeObject> objects = new List<PrefabeObject>();
    public PrefabeObject prefab;
    public Transform prefabParent;


    void Start()
    {
        InstanatiteCreate(25);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActiveObject();
        }

    }

    public void InstanatiteCreate(int temp)
    {
        for (int i = 0; i < temp; i++)
        {
            generateObject();
        }
    }

    public void generateObject()
    {
        PrefabeObject obj =  Instantiate(prefab, prefabParent);
        obj.Deactive();
        objects.Add(obj);
    }


    public void ActiveObject()
    {
       
        for (int i = 0; i < objects.Count; i++)
        {
            if (!objects[i].isActive)
            {
                objects[i].Active();
                return;
            }
        }
        InstanatiteCreate(1);
        objects[objects.Count - 1].Active();
    }


}
