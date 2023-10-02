using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EnemyMovement : MonoBehaviour{

    public float rotationSpeed;
    public float moveSpeed;

    [SerializeField] float shakeIntesity;
    [SerializeField] float shakeTime;
    private float shakeTimer;

    private Vector2 direction;
    [SerializeField] private GameObject targetPlayer;

    [SerializeField] CinemachineVirtualCamera virtualCamera;

    private void Update(){

        direction = targetPlayer.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        Vector2 targetPos = targetPlayer.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if(shakeTimer > 0){
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f){
                CinemachineBasicMultiChannelPerlin basicMultiChanelPerlin =
                    virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                basicMultiChanelPerlin.m_AmplitudeGain = 0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Torch")){
            StartCoroutine(HittedByTorch());
        }
    }

    IEnumerator HittedByTorch(){
        moveSpeed = 0;
        CinemachineBasicMultiChannelPerlin basicMultiChanelPerlin = 
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        basicMultiChanelPerlin.m_AmplitudeGain = shakeIntesity;
        shakeTimer = shakeTime;

        yield return new WaitForSeconds(2f);
        moveSpeed = 5;
    }
}