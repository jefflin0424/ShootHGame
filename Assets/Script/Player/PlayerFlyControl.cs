using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlyControl : MonoBehaviour
{
    [SerializeField]
    float move = 0.25f;

    [SerializeField]
    Transform playerTransform;

    [SerializeField]
    Transform rigTransform;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveControl();
    }

    void MoveControl()
    {
        var playerEuler = playerTransform.localRotation.eulerAngles;
        var rigEuler = rigTransform.localRotation.eulerAngles;

        if (Input.GetKey(KeyCode.W))
        {            
            rigEuler.x += 1f;//x減1度
            var rigXValue = rigEuler.x *-1;//做相反值

            Debug.Log($"{playerEuler.x}/{rigEuler.x}");

            Quaternion rigRotation = Quaternion.Euler(rigEuler);

            rigTransform.localRotation = Quaternion.Lerp(rigTransform.localRotation, rigRotation, 3);

            var localEuler = playerTransform.localEulerAngles;
            localEuler.x = rigXValue;
            playerTransform.localEulerAngles = localEuler;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rigEuler.x -= 1f; //x加1度
            var rigXValue = rigEuler.x * -1;//做相反值

            Quaternion rigRotation = Quaternion.Euler(rigEuler);

            rigTransform.localRotation = Quaternion.Lerp(rigTransform.localRotation, rigRotation, 3);

            var localEuler = playerTransform.localEulerAngles;
            localEuler.x = rigXValue;
            playerTransform.localEulerAngles = localEuler;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerEuler.y -= 0.5f;
            Quaternion playerRotation = Quaternion.Euler(playerEuler);

            playerTransform.localRotation = Quaternion.Lerp(playerTransform.localRotation, playerRotation, 3);//WASD旋轉            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerEuler.y += 0.5f;
            Quaternion playerRotation = Quaternion.Euler(playerEuler);

            playerTransform.localRotation = Quaternion.Lerp(playerTransform.localRotation, playerRotation, 3);//WASD旋轉
        }

        playerTransform.transform.Translate(playerTransform.forward * move * Time.deltaTime, Space.World);//控制器依自身座標持續前進
    }
}