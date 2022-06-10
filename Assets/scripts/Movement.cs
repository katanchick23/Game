using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class Movement : MonoBehaviour
{
    [SerializeField] private LayerMask _obstacleMask;
    [SerializeField] private float _step;
    
    public float duration;
    private Animator _animator;

    private void Start(){
        _animator = GetComponent <Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)){
            TryMove(Vector3.forward);
            _animator.SetBool("IsRunning", true);
            transform.DOMove(transform.position + Vector3.forward*1.25f,duration , false);
        }
        if (Input.GetKeyUp(KeyCode.W)){
            _animator.SetBool("IsRunning", false);
        }
        if(Input.GetKeyDown(KeyCode.S)){
            TryMove(Vector3.back);
            _animator.SetBool("IsRunning", true);   
            transform.DOMove(transform.position + Vector3.back*1.25f,duration , false);
        }
        if (Input.GetKeyUp(KeyCode.S)){
            _animator.SetBool("IsRunning", false);
        } 
        if(Input.GetKeyDown(KeyCode.D)){
            TryMove(Vector3.right);
            _animator.SetBool("IsRunning", true);
            transform.DOMove(transform.position + Vector3.right*1.25f,duration , false);
        }
        if (Input.GetKeyUp(KeyCode.D)){
            _animator.SetBool("IsRunning", false);
        } 
        
        if(Input.GetKeyDown(KeyCode.A)){
            TryMove(Vector3.left);
            _animator.SetBool("IsRunning", true);
            transform.DOMove(transform.position + Vector3.left*1.25f,duration , false);
        }
        if (Input.GetKeyUp(KeyCode.A)){
            _animator.SetBool("IsRunning", false);
        } 
    }
    
    private void TryMove(Vector3 direction)
    {
        var forwardRay = new Ray(transform.position, direction);

        if (Physics.Raycast(forwardRay, out RaycastHit hit, _step, _obstacleMask))
            return;

        transform.forward = direction;
        transform.Translate(direction * _step, Space.World);
    }
}