using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class AirhockeyAcademy : Academy {


    public GameObject TablePrefab;
    public Brain AirhockeyBrain1;
    private int Dimension = 0;


    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void InitializeAcademy()
    {
        for (int i = 0; i <= Dimension; i++)
        {
            GameObject AgentObj = Instantiate(TablePrefab, new Vector3(0, 5 * Dimension, 0), Quaternion.identity);
            Agent Agent = AgentObj.GetComponentInChildren<Agent>();
            Agent.GiveBrain(AirhockeyBrain1);
            Agent.AgentReset();
        }
    }


}
