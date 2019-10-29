using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class MoveAction : Action
{
    [SharedRequired]
    public SharedGameObject destination;

    public SharedGameObject target;

    NavMeshAgent agent;

    float margin;

    public override void OnStart()
    {
        target = GetDefaultGameObject(target.Value);

        agent = target.Value.GetComponent<NavMeshAgent>();

        margin = target.Value.GetComponent<CapsuleCollider>().radius;
        margin += destination.Value.GetComponent<CapsuleCollider>().radius;
    }

    public override TaskStatus OnUpdate()
    {
        var destinationPosition = destination.Value.transform.position;
        var targetPosition = target.Value.transform.position;

        // Colliderを考慮した移動先の座標
        var position = destinationPosition - ((destinationPosition - targetPosition).normalized * margin);

        return agent.SetDestination(position) ? TaskStatus.Success : TaskStatus.Failure;
    }
}