using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Brains/Enemy Basic")]
public class EnemyBasicBrain : CharacterBrain
{
    [SerializeField] private float wanderRadius = 2.0f;
    [SerializeField] private float wanderTimer = 5.0f;

    [SerializeField] private float timer = 0.0f;


    public override void Think(CharacterThinker character)
    {
        var movement = character.GetComponent<CharacterMovement>();

        timer += Time.deltaTime;

        if(timer > wanderTimer)
        {
            Vector3 destination = RandomDestination(character.transform);
            movement.Move(destination);
            timer = 0;
        }
    }

    private Vector3 RandomDestination(Transform transform)
    {
        Vector3 destination = Random.insideUnitSphere * wanderRadius;

        destination += transform.position;

        NavMeshHit hit;
        NavMesh.SamplePosition(destination, out hit, wanderRadius, -1);
        
        return hit.position;
    }
}
