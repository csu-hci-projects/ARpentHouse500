using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentController : MonoBehaviour
{
    public Transform agentPoint;
    NavMeshAgent agent;
    public GameObject arraw;
    public bool drawPath;
    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();


    }
    private void Update()
    {
        
        if (AgentManager.instance.Target != agentPoint|| AgentManager.instance.currentAgent!=gameObject) 
        {
            Destroy(transform.root.gameObject);
        }
        //return;
        Vector3[] path = GetPath();
       
        if (!drawPath)
        {

            for (int i = 0; i < path.Length; i++)
            {
                int next = Mathf.Clamp(i + 1, 0, path.Length - 1);
                float pathLength = Vector3.Distance(path[i], path[next]);
                int pathIndex = Mathf.FloorToInt(pathLength / 0.5f);
                Vector3 diretion = (path[next]- path[i]).normalized;
                for (int j = 0; j < pathIndex; j++)
                {
                    GameObject obj = Instantiate(arraw, transform);

                    obj.transform.position = path[i] + diretion * 0.5f * j;

                    obj.transform.LookAt(path[next]);
                    Vector3 euler = obj.transform.localEulerAngles;
                    euler.x = 90;
                    obj.transform.localEulerAngles = euler;
                }
            }
            drawPath = true;
        }
        for (int i = 0; i < path.Length; i++)
        {
            int next = Mathf.Clamp(i + 1, 0, path.Length - 1);

            Debug.DrawLine(path[i], path[next], Color.yellow);
        }

        NavMeshHit hit;
        if (!NavMesh.SamplePosition(transform.position, out hit, 1.0f, NavMesh.AllAreas)) 
        {
          transform.position =  hit.position;
        }
    }
    public Vector3[] showpath;
    Vector3[] GetPath()
    {
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(agentPoint.position, path);
        Vector3[] posArr = new Vector3[path.corners.Length + 2];
        posArr[0] = transform.position;
        posArr[posArr.Length - 1] = agentPoint.position;
        for (int i = 0; i < path.corners.Length; i++)
        {
            posArr[i + 1] = path.corners[i];
        }
        return posArr;
    }
}
