using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

// PLAYER TEMPORAIRE POUR TESTER L'IA @Antho
public class TrashPlayer : MonoBehaviour
{
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out hit))
            {
                if (hit.collider.GetComponent<TrashGround>())
                    agent.SetDestination(hit.point);

            }
        }

        //agent.SetDestination(Camera.main.ScreenToWorldPoint());
    }
}
