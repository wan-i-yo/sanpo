using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// スマホ用タップ動作 未実装
public class TapMove : MonoBehaviour {
    private NavMeshAgent agent;

    private RaycastHit hit;
    private Ray ray;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
