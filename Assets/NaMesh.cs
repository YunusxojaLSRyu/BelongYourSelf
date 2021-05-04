using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class NaMesh : MonoBehaviour {

public Transform target;
NavMeshAgent agent;

void Start (){
	agent = GetComponent<NavMeshAgent>();
	
}


void Update(){
	agent.SetDestination(target.position);
}
}