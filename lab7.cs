using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lab7 : MonoBehaviour
{
    int[] itemIndexes = new int[4];
    [SerializeField] Image[] slots = new Image[4];
    [SerializeField] Image[] spheres = new Image[3];
    [SerializeField] Image equippdSlopt;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sphere")
        {
            Destroy(other.gameObject);
            int emptySlot = findEmptySlot();
            if (emptySlot != -1)
            {
                itemIndexes[emptySlot] = other.GetComponent<sphere>().GetID();
                Image slotsphere = Instantiate(spheres[other.GetComponent<sphere>().GetID() - 1]);
                slotsphere.GetComponent<RectTransform>().sizeDelta =
                    slots[emptySlot].GetComponent<RectTransform>().sizeDelta;
            }
        }
    }

    int findEmptySlot()
    {
        for (int i = 0; i < itemIndexes.Length; i++)
        {
            if (itemIndexes[i] == 0)
            {
                return i;
            }
        }
        return -1;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
