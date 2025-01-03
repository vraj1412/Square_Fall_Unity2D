using System.Collections;
using System.Collections.Generic;
using DG.Tweening.CustomPlugins;
using UnityEngine;

public class ObjectSpool : MonoBehaviour
{

    public List<PrefabsObject> objects = new List<PrefabsObject>();
    public PrefabsObject prefab;
    public Transform prefabParent;

    public GamePlay Ref_GamePlay;

    public static ObjectSpool instance;

    #region Unity function
    public void Awake()
    {   
            instance = this;
    }

    void Start()
    {
        Ref_GamePlay = GamePlay.instance;
        InstanatiteCreate(25);

    }


    public void OnDestroy()
    {
        Destroy(gameObject);
    }
    #endregion

    #region Other Function

    public void InstanatiteCreate(int temp)
    {
        for (int i = 0; i < temp; i++)
        {
            objects.Add(Instantiate(prefab, prefabParent));
            objects[i].Deactive();
        }
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

        // Debug.Log("New One created");
        InstanatiteCreate(1);
        objects[objects.Count - 1].Active();
    }

    public void AllObjectsDeactive()
    {

        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].Deactive();
        }

    }
    #endregion
}
