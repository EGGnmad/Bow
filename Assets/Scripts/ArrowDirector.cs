using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDirector : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    public GameObject createArrow()
    {
        GameObject obj = Instantiate<GameObject>(prefab, prefab.transform.position, prefab.transform.rotation);
        obj.SetActive(true);
        obj.GetComponent<Rigidbody>().useGravity = false;

        return obj;
    }
}
