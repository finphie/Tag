using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class WarpAction : Action
{
    [SharedRequired]
    public SharedGameObject destination;

    public SharedGameObject target;

    NavMeshAgent agent;

    public override void OnStart()
    {
        target = GetDefaultGameObject(target.Value);

        agent = target.Value.GetComponent<NavMeshAgent>();
    }

    public override TaskStatus OnUpdate()
    {
        var destinationPosition = destination.Value.transform.position;

        // プレイヤーとの距離が近い場合はワープしない。
        if (Vector3.Distance(target.Value.transform.position, destinationPosition) < 5)
            return TaskStatus.Failure;

        // ワープ先のプレイヤーとの距離
        var distance = Random.Range(5, 10);

        // 角度
        var angle = Random.Range(0, 180) * Mathf.Deg2Rad;

        // 角度と距離から座標を計算
        var position = new Vector3(distance * Mathf.Cos(angle), destinationPosition.y, distance * Mathf.Sin(angle));

        // ワープ先の座標がNavMesh範囲外の場合
        if (!NavMesh.SamplePosition(position, out var hit, 4.0F, NavMesh.AllAreas))
            return TaskStatus.Failure;

        // ワープ実行
        if (agent.Warp(hit.position))
        {
            // プレイヤーの方向を見る
            target.Value.transform.LookAt(destination.Value.transform);

            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}