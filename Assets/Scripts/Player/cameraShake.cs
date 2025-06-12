using UnityEngine;

public class cameraShake : MonoBehaviour
{
    public Transform cameraTransform; // 카메라의 위치를 저장하기 위한 변수
    public float shakeAmount = 0.1f; // 흔들림의 강도

    Vector3 originalPosition; // 원래 카메라 위치
    bool isShaking = false; // 흔들림 여부

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform; // 기본 카메라를 사용하도록 설정
        }
    }

    void Update()
    {
        if (isShaking)
        {
            float offsetX = Random.Range(-1f, 1f) * shakeAmount; // 랜덤한 X 방향 흔들림
            float offsetY = Random.Range(-1f, 1f) * shakeAmount; // 랜덤한 Y 방향 흔들림

            cameraTransform.localPosition = originalPosition + new Vector3(offsetX, offsetY, 0); // 카메라 위치 변경
        }
    }

    public void Shake()
    {
        originalPosition = cameraTransform.localPosition; // 현재 카메라 위치 저장
        isShaking = true; // 흔들림 효과 시작
    }

    public void StopShake()
    {
        isShaking = false; // 흔들림 효과 정지
        cameraTransform.localPosition = originalPosition; // 원래의 카메라 위치로 돌아감
    }
}
