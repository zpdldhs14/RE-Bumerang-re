using UnityEngine;
using UnityEngine.UI;

public class buttonSound : MonoBehaviour
{
    public Button yourButton; // 사운드를 재생할 버튼
    public AudioSource audioSource; // 사운드를 재생할 AudioSource 컴포넌트
    public AudioClip clickSound; // 재생할 사운드 클립
    public Animator anim;

    void Start()
    {
        // 버튼의 클릭 이벤트에 사운드 재생 메서드를 추가합니다.
        yourButton.onClick.AddListener(PlayAnimationAndSound);
    }

    void PlayAnimationAndSound()
    {
        // 애니메이션을 재생합니다.
        anim.Play("button", -1, 0f);

        // 사운드를 재생합니다.
        audioSource.Play();
    }
}