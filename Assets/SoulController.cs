using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoulController : MonoBehaviour
{
    private Animator animator;
    public float speed = 3f;
    private float moveSpeed = 3f;
    private bool move;
    private bool isPointingBack;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        if (SceneManager.GetActiveScene().name == "Darkness")
        {
            animator.SetBool("Idle", true);
        }
        else
        {
            StartCoroutine(StartAnimationSequence());
        }
    }

    private IEnumerator StartAnimationSequence()
    {
        yield return StartCoroutine(IdleCoroutine());
        yield return StartCoroutine(WalkCoroutine());
        yield return StartCoroutine(PointToBackCoroutine());
        yield return StartCoroutine(WalkCoroutine());
        TurnOff();
    }

    private IEnumerator IdleCoroutine()
    {
        animator.SetBool("Idle", true);
        yield return new WaitForSeconds(2f);
        animator.SetBool("Idle", false);
    }

    private IEnumerator WalkCoroutine()
    {
        yield return new WaitForSeconds(0f);
        animator.SetBool("Walk", true);
        move = true;
        yield return new WaitForSeconds(10f);
        animator.SetBool("Walk", false);
        move = false;
    }

    private IEnumerator PointToBackCoroutine()
    {
        animator.SetBool("PointBack", true);
        yield return new WaitForSecondsRealtime(3f);
        animator.SetBool("PointBack", false);
    }


    private void Update()
    {
        if (move && !isPointingBack)
        {
            moveSpeed = speed * Time.deltaTime;
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * moveSpeed);
    }

    private void TurnOff()
    {
        gameObject.SetActive(false);
    }
}
