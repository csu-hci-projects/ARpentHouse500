using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    public static AgentManager instance { get; private set; }
    public GameObject Agent;
    public Transform Target;
    public Transform[] Targets;
    public float time=0.5f;

    public GameObject currentAgent;
    private void Awake()
    {
        instance = this;
    }
    
    private void Update()
    {
        if (Target == null) 
        {
            foreach (var item in Targets)
            {
                item.gameObject.SetActive(false);
            }
            //timer = 0;
            return;
        }
    }
    public void SetTarget(int index) 
    {
        
        foreach (var item in Targets)
        {
            item.gameObject.SetActive(false);
        }
        Target = Targets[index];
        Target.gameObject.SetActive(true);
        if (currentAgent != null)
        {
            Destroy(currentAgent.gameObject);

        }
        Vector3 initPos = transform.position;
        initPos.y = -1f;
        GameObject agent = GameObject.Instantiate(Agent, initPos, Quaternion.identity);
        currentAgent = agent;
        agent.GetComponent<AgentController>().agentPoint = Target;
        agent.SetActive(true);
    }
}

