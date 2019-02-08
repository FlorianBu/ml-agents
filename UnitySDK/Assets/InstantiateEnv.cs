using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnv : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform GameTable;
    public int TableAmount;
    void Start()
    {
        for (int i = 1; i < TableAmount; i++)
        {
            Instantiate(GameTable, new Vector3(0, 5*i, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
