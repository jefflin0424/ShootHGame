using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimatorUnderTypeView
{
    defaultState,
    hitState,
}

public class UnderColliderControl : MonoBehaviour
{
    [SerializeField]
    Animator playerAnimator;

    [SerializeField]
    AnimatorUnderTypeView animatorState;

    AnimatorStateInfo stateinfo;
    AnimatorStateInfo stateinfo2;

    void Start()
    {
        //playerAnimator = transform.GetComponent<Animator>();
    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"inTrigger");

        AnimatorStateInfo stateinfo = playerAnimator.GetCurrentAnimatorStateInfo(0);//第一層
        AnimatorStateInfo stateinfo2 = playerAnimator.GetCurrentAnimatorStateInfo(1);//第二層

        //stateinfo.IsName("Hit2") &&  stateinfo.normalizedTime >= 1.0f

        if (stateinfo.IsName("Idle")) hitState(AnimatorTypeView.hitState);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"outTrigger");

        AnimatorStateInfo stateinfo = playerAnimator.GetCurrentAnimatorStateInfo(0);//第一層
        AnimatorStateInfo stateinfo2 = playerAnimator.GetCurrentAnimatorStateInfo(1);//第二層

        if (stateinfo2.IsName("inpush")) hitState(AnimatorTypeView.defaultState);
    }

    void hitState(AnimatorTypeView animatorState)
    {


        switch (animatorState)
        {
            case AnimatorTypeView.hitState:
                Debug.Log($"in hitState");

                playerAnimator.SetBool("InPush", true);
                //playerAnimator.SetTrigger("inHit1Face");               

                break;

            case AnimatorTypeView.defaultState:
                Debug.Log($"out hitState");
                playerAnimator.SetBool("InPush", false);

                break;
        }
    }
}