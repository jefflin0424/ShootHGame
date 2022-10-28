using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimatorTypeView
{
    defaultState,
    hitState,
}

public class BreastColliderControl : MonoBehaviour
{
    public SkinnedMeshRenderer breastRenderer;

    [SerializeField]
    ClothColliderControl clothColliderControl;

    [SerializeField]
    Animator playerAnimator;

    [SerializeField]
    AnimatorTypeView animatorState;

    AnimatorStateInfo stateinfo;
    AnimatorStateInfo stateinfo2;

    void Start()
    {
        playerAnimator = transform.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log($"incollider");

            AnimatorStateInfo stateinfo = playerAnimator.GetCurrentAnimatorStateInfo(0);//第一層
            AnimatorStateInfo stateinfo2 = playerAnimator.GetCurrentAnimatorStateInfo(1);//第二層

            //stateinfo.IsName("Hit2") &&  stateinfo.normalizedTime >= 1.0f

            clothColliderControl.SetValue(20);

            //if (stateinfo.IsName("Idle")) hitState(AnimatorTypeView.hitState);

            //ChangeRenderMaterial();//衣服透明函式
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
            {
            Debug.Log($"incollider");

            AnimatorStateInfo stateinfo = playerAnimator.GetCurrentAnimatorStateInfo(0);//第一層
            AnimatorStateInfo stateinfo2 = playerAnimator.GetCurrentAnimatorStateInfo(1);//第二層

            //stateinfo.IsName("Hit2") &&  stateinfo.normalizedTime >= 1.0f

            clothColliderControl.SetValue(20);

            //if (stateinfo.IsName("Idle")) hitState(AnimatorTypeView.hitState);

            //ChangeRenderMaterial();//衣服透明函式
        }
    }

    void ChangeRenderMaterial()
    {
        var count = breastRenderer.materials.Length;
        for (int i = 0; i < count; i++)
        {
            var material = breastRenderer.materials[i];
            var color = material.color;
            color.a -= 0.02f;

            if (color.a <= 0.02f)
            {
                color.a = 0f;//寫入參數
                material.color = color;
            }
            else
            {
                material.color = color;//新color.alpha值寫入原material.color
            }
        }
    }

    void hitState(AnimatorTypeView animatorState)
    {


        switch (animatorState)
        {
            case AnimatorTypeView.hitState:
                Debug.Log($"in hitState");
                int i = Random.Range(0, 3);
                Debug.Log($"{i}");

                playerAnimator.SetBool("ClothOpen", true);

                if (i == 0)
                {
                    playerAnimator.SetTrigger("inHit1");
                    playerAnimator.SetTrigger("inHit1Face");
                }
                else if (i == 1)
                {
                    playerAnimator.SetTrigger("inHit2");
                    playerAnimator.SetTrigger("inHit2Face");
                }
                else if (i == 2)
                {
                    playerAnimator.SetTrigger("inHit3");
                }

                break;

            case AnimatorTypeView.defaultState:

                break;
        }
    }
}