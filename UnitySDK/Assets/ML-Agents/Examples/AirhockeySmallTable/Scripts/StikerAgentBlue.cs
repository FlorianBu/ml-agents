using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using System;


public class StikerAgentBlue : Agent {

    //PuckController puckController;


    public float Acceleration = 1000;
    public float triangleacc = 0.01f;
    //public List<Rigidbody> ObservedRigidbodies;
    private Rigidbody rStriker;
    private Rigidbody PuckRB;
    
    public GameObject Puck;

    public GameObject Striker;
    private Vector3 desiredPosition;
    private Vector3 startPosition;

    private Vector3 helpstrikerVelocity = Vector3.zero;


    private bool checktime = false;
    private float FixedUpdatetime = 0;
    private float Updatetime = 0;
    //testing variables
    private float netouttime;
    private float netinputtime = 0;
    private float timeStart = 0;

    private int counter = 0;
    private int netcounter = 0;
    public GameObject desiredPos;
    

    void Start()
    {
        rStriker = Striker.gameObject.GetComponent<Rigidbody>();
        PuckRB = Puck.gameObject.GetComponent<Rigidbody>();
        //puckController = Puck.GetComponent<PuckController>();
        Application.targetFrameRate = 300;
    }

    public override void AgentReset()
    {
        //float randomX = UnityEngine.Random.Range(-30f, -10f);
        float randomZ = UnityEngine.Random.Range(-4f, 4f);
        float randomX = UnityEngine.Random.Range(-16f, -5f);
        float randomPos = UnityEngine.Random.Range(-2f, 2f);
        
        PuckRB.position = new Vector3((14f+ randomPos), 0.05f, gameObject.transform.position.z);
        PuckRB.velocity = new Vector3(randomX,0,randomZ);
        if(Striker.gameObject.tag == "StrikerBlue")
        {
            rStriker.position = new Vector3(2f, 0.25f, 0f + gameObject.transform.position.z);
            rStriker.velocity = Vector3.zero;
        }
        if (Striker.gameObject.tag == "StrikerRed")
        {
            rStriker.position = new Vector3(14f, 0.25f, 0f + gameObject.transform.position.z);
            rStriker.velocity = Vector3.zero;
        }

        /*if (Puck.position.x <= 12)
        {
            //goal
            //this.transform.position = Vector3.zero;
            //PuckRB.position = new Vector3(1f, 1f, 1f);
            Puck.position = new Vector3(68.2f, 44.64f, 112.5f);
            PuckRB.velocity = Vector3.zero;
            
        }else if (Puck.position.x >=)
        */
    }
    /*
    public void FixedUpdate()
    {
        float agenttime = Time.time;
        float agentdeltatime = Time.deltaTime;
        //Debug.Log("Time for Net: " + timeStart);
        Debug.Log("Agent act Time: " + agenttime);
        Debug.Log("Agent delta Time: " + agentdeltatime);
    }*/
    
    private void MovementFunction()
    {

    }
    public static Vector3 changeZ(Vector3 v, float z)
    {
        return new Vector3(v.x, v.y, z);
    }

    

    public void FixedUpdate()
    {
        Vector3 route = desiredPosition - startPosition;
        Vector3 routeNormalized = route.normalized;
        Debug.Log("Vector" + route);
        Debug.Log("Normalized Vector" + routeNormalized);
        double path = Math.Sqrt(route[0] * route[0] + route[2] * route[2]);
        //we want to reach the position in 10 ms
        //double velocity = route / 0.01f;
        helpstrikerVelocity.x = route.x / 0.1f;
        helpstrikerVelocity.z = route.z / 0.1f;
        rStriker.velocity = helpstrikerVelocity;

    }

    /*
    public void FixedUpdate()
    {

        //fixedupdate is called every 0.0333seconds = 300 fps
        //
        //max position
        //half of it is max velocity and change of velocity
        //until then constant acceleration
        //afterwards same constant negative acceleration
        if (checktime == true)
        {
            FixedUpdatetime = Time.time;
            Debug.Log("Fixed Update" + FixedUpdatetime);
        }
        Vector3 route = desiredPosition - startPosition;
            double path = Math.Sqrt(route[0] * route[0] + route[2] * route[2]);

            float midway = Mathf.Abs((route[2] / 2));
            //currentPos = Math.Sqrt(rStriker.position.x * rStriker.position.x


            if (Striker.transform.position.z == desiredPosition.z)
            {
                rStriker.velocity = Vector3.zero;
            Debug.Log("ZERO ");
        }
            //positive direction
            else if (Striker.transform.position.z < desiredPosition.z)
            {
            Debug.Log("positive Direction ");
            //accelerate
            if (Striker.transform.position.z <= (desiredPosition.z) / 2)
                {
                Debug.Log("positive Direction acc");
                helpstrikerVelocity.z = rStriker.velocity.z + triangleacc;
                rStriker.velocity = helpstrikerVelocity;
                //changeZ(rStriker.velocity, rStriker.velocity.z + 0.05f);
                }
                //deaccelerate
                else if (Striker.transform.position.z > (desiredPosition.z / 2))
                {
                Debug.Log("positive Direction deacc");
                helpstrikerVelocity.z = rStriker.velocity.z - triangleacc;
                rStriker.velocity = helpstrikerVelocity;

                //changeZ(rStriker.velocity, rStriker.velocity.z - 0.05f);
            }
        }
            //negative direction
            else if (Striker.transform.position.z > desiredPosition.z)
            {
                Debug.Log("negative Direction ");
            //accelerate
                if (Striker.transform.position.z > (desiredPosition.z / 2))
                {
                helpstrikerVelocity.z = rStriker.velocity.z - triangleacc;
                rStriker.velocity = helpstrikerVelocity;
                //changeZ(rStriker.velocity, rStriker.velocity.z - 0.05f);
                Debug.Log("negative Direction acc");
            }
                //deaccelerate
                else if (Striker.transform.position.z <= (desiredPosition.z / 2))
                {
                helpstrikerVelocity.z = rStriker.velocity.z + triangleacc;
                rStriker.velocity = helpstrikerVelocity;
                //changeZ(rStriker.velocity, rStriker.velocity.z - + 0.05f);
                Debug.Log("negative Direction deacc");
            }
            }
            if(desiredPosition.z != 0)
        {
            counter += 1;
            if(counter >= 10)
            {

            }
        }
        
    }     */
          
            

    /*else if (rStriker.position[0] < midway[0] && rStriker.position[2] < midway[2])
    {

        helpstrikerVelocity[0] = rStriker.velocity[0] + triangleacc * route[0];
        helpstrikerVelocity[2] = rStriker.velocity[2] + triangleacc * route[2];
        rStriker.velocity = helpstrikerVelocity;
    }
    else if (rStriker.position[0] >= midway[0] && rStriker.position[2] >= midway[2])
    {
        helpstrikerVelocity[0] = rStriker.velocity[0] - triangleacc * route[0];
        helpstrikerVelocity[2] = rStriker.velocity[2] - triangleacc * route[2];
        rStriker.velocity = helpstrikerVelocity;
    }*/
    //helpstrikerVelocity[0] = route[0];
    //helpstrikerVelocity[2] = route[2];
    //rStriker.velocity = helpstrikerVelocity;



    //1d triangle drive
    //desiredZ input
    //startZ input

    //}
    //}
    public override void CollectObservations()
    {


        //AddVectorObs(rStriker.position.x);



        //normalize inputs:
        //max z position 3.6, -3.6
        //max x position 18, 0

        if (checktime == true)
        {
            netinputtime = Time.time;
            float prenetinputtime = netinputtime;
            Debug.Log("netinputtime" + netinputtime);
            if (netinputtime == prenetinputtime)
            {
                netcounter += netcounter;
            }
            else
            {
                Debug.Log("netinputcounter (" + netinputtime + "):" + netcounter);
                netcounter = 0;
            }
        }

        AddVectorObs(((Puck.transform.position.x)/18f));
        AddVectorObs(((Puck.transform.position.z)/3.6f));
        AddVectorObs(((Striker.transform.position.x)/4));
        AddVectorObs(((Striker.transform.position.z)/3.6f));
        AddVectorObs(PuckRB.velocity.x);
        AddVectorObs(PuckRB.velocity.z);
        AddVectorObs(rStriker.velocity.x);
        AddVectorObs(rStriker.velocity.z);




        /*AddVectorObs(((PuckRB.position.x)/18f));
        AddVectorObs(((PuckRB.position.z)/3.6f));
        AddVectorObs(((PuckRB.position.x)/4));
        AddVectorObs(((rStriker.position.z)/3.6f));
        AddVectorObs(PuckRB.velocity.x);
        AddVectorObs(PuckRB.velocity.z);
        AddVectorObs(PuckRB.velocity.x);
        AddVectorObs(PuckRB.velocity.z);
        */


        //AddVectorObs(rStriker.position.z);
        //AddVectorObs(rStriker.velocity.x);
        //AddVectorObs(rStriker.velocity.z);
        //AddVectorObs(PuckRB.position.x);
        //AddVectorObs(PuckRB.position.z);

    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        //print(vectorAction[0]);
        //print(vectorAction[1]);
        // scored goal
        if (checktime == true)
        {
            float nettime = Time.deltaTime * 1000 - timeStart;
            netouttime = Time.time;
            float prenetouttime = netouttime;
            Debug.Log("netoutputtime" + netouttime);
            if (netinputtime == prenetouttime)
            {
                netcounter += netcounter;
            }
            else
            {
                Debug.Log("netoutcounter (" + netouttime + "):" + netcounter);
                netcounter = 0;
            }
        }


        if ((Puck.transform.position.x)>= 18f)
        {
            AddReward(1.0f);
            //PuckRB.position = new Vector3(68.2f, 44.64f, 112.5f);
            //PuckRB.velocity = Vector3.zero;
            Done();
        }

        // Time penalty
        //gets called every 10ms -> WE DONT WANT TO PUNISH TOO HARD, therefore a negative reward of -0.1 per second should be suitable
        AddReward(-0.0001f);
        

        if ((Puck.transform.position.x)<=  0f)
        {
            AddReward(-1.0f);
            //PuckRB.position = new Vector3(68.2f, 44.64f, 112.5f);
            //PuckRB.velocity = Vector3.zero;
            Done();
        }
        if(PuckRB.velocity.x >=-0.8 && PuckRB.velocity.x <= 0.8 && PuckRB.velocity.z <=0.5 &&PuckRB.velocity.z >= -0.5)
        {
            AgentReset();
        }
        /*
        if(PuckRB.velocity.x >= -0.1 && PuckRB.velocity.x <= 0.1)
        {
            AgentReset();
        }*/
        /*Vector3 dirToGo = Vector3.zero;

        int action = Mathf.FloorToInt(vectorAction[0]);

        switch (action)
        {
            case 0:
                dirToGo = Vector3.zero;
                break;
            case 1:
                dirToGo = Vector3.forward * 1f;
                break;
            case 2:
                dirToGo = Vector3.forward * -1f;
                break;
            case 3:
                dirToGo = Vector3.right * 1f;
                break;
            case 4:
                dirToGo = Vector3.right * -1f;
                break;
        }*/

        //rBody.AddForce(dirToGo * Acceleration, ForceMode.Force);


        

        // Actions, size = 2
        //control script einfügen über tcp
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = Mathf.Clamp(vectorAction[0], -1, 1);
        controlSignal.z = Mathf.Clamp(vectorAction[1], -1, 1);

        //to move directly
        //rStriker.AddForce(controlSignal * 3, ForceMode.VelocityChange);

        
        
        
        //to get the position as output
        //transform normalized positions to absolute
        //desiredPosition.x = (controlSignal.x * 51f) + 26f;
        //desiredPosition.x = (0.5f *UnityEngine.Random.Range(0.1f, 0.3f) * 51f) + 26f; ;
        desiredPosition.x =  1f + (controlSignal.x + 1);
        desiredPosition.y = 0.25f;
        desiredPosition.z = (controlSignal.z * 2.25f);
        startPosition = Striker.transform.position;
        //startPosition = new Vector3(2f, 0.25f, 0f);
        //rStriker.MovePosition(transform.position + controlSignal * Time.deltaTime * 100);
        //rStriker.MovePosition(rStriker.position + controlSignal * Time.deltaTime * 50);
        //rStriker.AddForce(controlSignal * speed);

        //rStriker.AddForce(controlSignal * Acceleration, ForceMode.Acceleration);
        desiredPos.transform.position = desiredPosition;

    }
    /*void OnCollisionEnter(Collision c)
    {
        float force = 2000f;
        float strikervelocity = (float)Math.Sqrt(rStriker.velocity.x * rStriker.velocity.x + rStriker.velocity.z * rStriker.velocity.z);
        //Console.WriteLine(strikervelocity);
        if (strikervelocity > 1)
        {

        }
        if (c.gameObject.tag == "Puck")
        {
            Vector3 dir = c.contacts[0].point - transform.position;
            dir = dir.normalized;
            dir[1] = 0;
            //c.gameObject.GetComponent<Rigidbody>().AddForce(dir * force);
            c.gameObject.GetComponent<Rigidbody>().AddForce(dir * strikervelocity  * 10);
            rStriker.velocity = Vector3.zero;

        }
    }*/
}
