using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere : MonoBehaviour
{
    [SerializeField] int ID;
    [SerializeField] Material[] materials;

    sphere(int id)
    {
        ID= id;
    }

    private void Start()
    {
        switch (ID)
        {
            case 1:
                this.GetComponent<MeshRenderer>().material.color = Color.red; break;
            case 2:
                this.GetComponent<MeshRenderer>().material.color = Color.blue; break;
            case 3:
                this.GetComponent<MeshRenderer>().material.color = Color.green; break;
            default:
                break;
        }
    }

    public int GetID()
    {
        return ID;
    }
}
