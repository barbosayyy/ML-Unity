using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Policies;
using Unity.MLAgents.Sensors.Reflection;

public class DodgeTarget : Agent
{
    private BufferSensorComponent bufferSensor;

    private BehaviorParameters behaviorParameters;

    private VectorSensor vectorSensor;

    private Transform spawn;

    public float agentSpeed = 1.5f;

    public Dispenser dispenser;

    private void Awake()
    {
        behaviorParameters = gameObject.GetComponent<BehaviorParameters>();
        bufferSensor = GetComponent<BufferSensorComponent>();
        dispenser = GameObject.FindGameObjectWithTag("Dispenser").GetComponent<Dispenser>();
        spawn = transform;
    }
    private void Update()
    {
        AddReward(.01f);
    }

    public override void OnEpisodeBegin()
    {
        gameObject.transform.position = spawn.position;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);

        foreach (GameObject projectile in dispenser.projectilePool)
        { 
            sensor.AddObservation(projectile.activeInHierarchy);
            float[] vision = { projectile.transform.position.x, projectile.transform.position.y };
            bufferSensor.AppendObservation(vision);
        }
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float X = actions.ContinuousActions[0];

        transform.position += new Vector3(X, 0, 0) * agentSpeed * Time.deltaTime;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Projectile") || collision.collider.CompareTag("Border"))
        {
            Debug.Log("Hit Punishment");
            SetReward(-0.5f);
            EndEpisode();
            gameObject.transform.position = spawn.position;

            
        }
    }
}
