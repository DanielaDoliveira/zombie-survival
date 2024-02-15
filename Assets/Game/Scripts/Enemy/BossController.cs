
using com.Daniela.Player;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace com.Daniela.Enemy
{
  public class BossController : MonoBehaviour, IEnemyBehaviour, IDead
  {
    private Transform _target;
    private NavMeshAgent _agent;
    private Status _status;
    private EnemyAnimations _animations;
    private CharacterMovement boss_movement;
    public GameObject MedicineKitPrefab;
    public Slider BossBar;
    public Image SliderImage;
    public Color MaxLifeColor, MinLifeColor;
    void Start()
    {
      _target = GameObject.FindWithTag("Jogador").transform;
      _animations = GetComponent<EnemyAnimations>();
      _agent = GetComponent<NavMeshAgent>();
      _status = GetComponent<Status>();
      BossBar.maxValue = _status.StartLife;
      BossBar.value = _status.StartLife;
      SliderImage.color = MaxLifeColor;

      _agent.speed = _status.Speed;
      boss_movement = GetComponent<CharacterMovement>();

    }

    private void Update()
    {
      _agent.SetDestination(_target.position);
      _animations.EnemyMove(_agent.velocity.magnitude);
      if (_agent.hasPath)
      {
        CheckAttack();
      }
    }

    private bool CanAttack()
    {
      bool is_checked = _agent.remainingDistance <= _agent.stoppingDistance;
      return is_checked;
    }
    private void CheckAttack()
    {
      if (CanAttack())
      {
        _animations.EnemyAttack(true);
        Vector3 direction = _target.position - transform.position;
        boss_movement.CalculateRotation(direction);
      }
      else
      {
        _animations.EnemyAttack(false);
      }
    }


    public void EnemyAttackPlayer()
    {
      int damage = Random.Range(30, 40);
      _target.GetComponent<PlayerLife>().TakeLife(damage);
      Quaternion invertedPos = Quaternion.LookRotation(-transform.forward);
      BloodControl player = GameObject.FindGameObjectWithTag("Jogador").GetComponent<BloodControl>();
      player.BloodParticle(transform.position, invertedPos);

    }

    public void TakeLife(int damage)
    {
      _status.Life -= damage;
      UpdateInterface();
      if (_status.Life <= 0)
      {
        Dead();
      }
    }

    public void Dead()
    {
      _animations.EnemyDie();
      boss_movement.Death();
      this.enabled = false;
      _agent.enabled = false;
      Instantiate(MedicineKitPrefab, transform.position, Quaternion.identity);
      Destroy(gameObject, 2);
    }
    void UpdateInterface()
    {
      BossBar.value = _status.Life;
      float life_percent = (float)_status.Life / _status.StartLife;
      Color life_color = Color.Lerp(MinLifeColor, MaxLifeColor, life_percent);
      SliderImage.color = life_color;
    }
  }
}