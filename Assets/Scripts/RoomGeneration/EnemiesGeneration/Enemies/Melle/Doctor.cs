using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Doctor : MelleEnemy
{
    /// <summary>
    /// Initialization of the doctor
    /// </summary>

    public override void Initialize()
    {
    }

    private void Awake()
    {
        // any unique logic to this enemy
        enemyName = "Doctor";
        angle = 0;
        movementSpeed = 2f;

        InitializePathfinding();
        movement = GetComponent<EnemyMovement>();
        movementStrategy = GetComponent<ChasePlayerMovementStrategy>();
        
        if (movement == null)
        {
            Debug.LogError("Failed to add EnemyMovement component to the enemy.");
            return;
        }
        
        if (movementStrategy == null)
        {
            Debug.LogError("Failed to add ChasePlayerMovementStrategy component to the enemy.");
            return;
        }

        movement.Initialize(movementSpeed, movementStrategy);
        movementStrategy.Initialize();
        gameObject.name = enemyName;
        //particleSystem = GetComponentInChildren<ParticleSystem>();
        //particleSystem?.Stop();
        //particleSystem?.Play();
    }

    /**
    * \brief Update is called once per frame.
    *
    * Calls the Move method of the movement strategy, if it exists.
    */
    private void Update()
    {
        if (movementStrategy != null)
        {
            Move();
        }
    }
    
    // TODO: Just testing, must be deleted
    public void Move()
    {
        /*float startX = this.transform.parent.position.x - 2;
        float startY = this.transform.parent.position.y - 2;

        // �������� ���� ������� ������ �� ���
        float x = startX + Mathf.Cos(this.angle) * 1; // ����� ���� - 1
        float y = startY + Mathf.Sin(this.angle) * 1; // ����� ���� - 1

        // ������� ������� ������� ������
        this.transform.position = new Vector2(x, y);

        // ������� ������ ������� ������ �� ���
        this.angle += Time.deltaTime; // ��������� � �����, ��� ����� �������*/
        
        movementStrategy.Move();
    }
}