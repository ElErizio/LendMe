using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollows : MonoBehaviour
{
    public NavMeshAgent agent;
    Animator anim;
    public Player player;

    public LayerMask whatIsGround, whatIsPlayer;


    // Almacena la velocidad original del enemigo
    private float originalSpeed = 20f; 

    // Para patrullar
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public Avatar walkAvatar;
    public AnimatorController walkController;

    // Para atacar
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public Avatar attackAvatar;
    public AnimatorController attackController;

    // Estados
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Update()
    {
        // Para revisar si el usuario está en el rango de vision del enemigo y de ataque
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        // Si el jugador no está en rango de vision ni de ataque patrulla
        if (!playerInSightRange && !playerInAttackRange)
        { 
            
        }

        // Si el jugador está dentro del rango de vision pero no en el de ataque, se activa el chase para seguirlo
        if (playerInSightRange && !playerInAttackRange) 
        { 
            if(anim.runtimeAnimatorController != walkController)
            {
                anim.runtimeAnimatorController = walkController;
                anim.avatar = walkAvatar;
            }
            ChasePlayer();
        }

        // Si el jugador está en rango de vision y de ataque, se activa para atacar
        if (playerInSightRange && playerInAttackRange)
        {
            if (anim.runtimeAnimatorController != attackController)
            {
                anim.runtimeAnimatorController = attackController;
                anim.avatar = attackAvatar;
            }
            AttackPlayer();
        } 
    }
    private void Awake()
    {
        player = FindAnyObjectByType<Player>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Patroll()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    { 
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        { 
            walkPointSet = true;
        }

    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.transform.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player.transform);

        if (!alreadyAttacked)
        {
            // 
            print("Lo ataca");
            player.RecibirDanio();

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage()
    {

        // Ralentizar al enemigo temporalmente
        originalSpeed = agent.speed; // Guardar la velocidad original
        agent.speed *= 0.5f; // Reducir la velocidad a la mitad
        Invoke("ResetSpeed", 2.0f); // Restablecer la velocidad después de 2 segundos
    }

    private void ResetSpeed()
    {
        agent.speed = originalSpeed; // Restablecer la velocidad original
    }
}
