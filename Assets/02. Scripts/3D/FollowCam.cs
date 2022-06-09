using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target; //추적할 타겟 게임오브젝트의 transform 변수 
    public float dist = 10.0f; //카메라와의 일정 거리
    public float height = 5.0f; //카메라의 높이 설정
    public float dampRotate = 5.0f; //부드러운 회전을 위한 변수

    private Transform tr; //카메라 자신의 변수


    // Start is called before the first frame update
    void Start()
    {
        //카메라 자신 transform 컴포넌트를 tr에 할당
        tr = gameObject.GetComponent<Transform>();
        
    }

    //Update 함수 호출 이후 한번씩 호출되는 함수인 LateUpdate 사용
    //추적할 타겟의 이동이 종료된 이후에 카메라가 추적하기 위해 LateUpdate 사용
    void FixedUpdate()
    {
        //카메라 Y축을 타겟의 Y축 회전각도로 부드럽게 회전
        float currYAngle = Mathf.LerpAngle(tr.eulerAngles.y, target.eulerAngles.y, dampRotate * Time.deltaTime);

        Quaternion rot = Quaternion.Euler(0, currYAngle, 0);

        tr.position = target.position - (rot * Vector3.forward * dist) + (Vector3.up * height);



        //카메라가 타겟 바라보게 설정
         tr.LookAt(target);
        
    }


}
