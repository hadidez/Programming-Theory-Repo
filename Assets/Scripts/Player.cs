using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Player : MonoBehaviour
{
    protected string _mName;
    protected int _age;
    protected NavMeshAgent _agent;
    [SerializeField] protected float _walkSpeed;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected Transform _target;
    [SerializeField] protected Transform _indicator;

  
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _indicator.gameObject.SetActive(false);
    }

    private void Start()
    {
        //define On selected player change event method
        PlayerManager.Instance.OnSelectedPlayerChaned += _OnSelectedPlayerChaned;
    }

    private void LateUpdate()
    {
        float speed = _agent.velocity.magnitude;
        _animator.SetFloat("walkSpeed", speed);
    }

    //when selected player changed ...
    private void _OnSelectedPlayerChaned(object sender, System.EventArgs e)
    {
        _indicator.gameObject.SetActive(false);
    }

    //virtual moving function ...
    public virtual void Move(Vector3 target)
    {
        if(target!=null)
        {
            _agent.speed = _walkSpeed;
            _agent.destination = target;
        }
    }

    //abstract attack function ...
    protected abstract void Attack(GameObject target);

    //virtual walk function ...
    protected virtual void Walk()
    {
        Debug.Log("i can walking..."); 
    }

    public void Select()
    {
        _indicator.gameObject.SetActive(true);
    }
   
}
