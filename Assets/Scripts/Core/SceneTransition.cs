using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private GameObject fadeObject;
    [SerializeField] private float transitionDuration = 2f;
    [SerializeField] private string targetSceneName;
    [SerializeField] private bool isVisited = false;
    [SerializeField] private Collider2D transitionCollider;

    private void Start()
    {
        if (isVisited && transitionCollider != null)
        {
            transitionCollider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isVisited = true;
            StartTransition();
        }
    }

    private void StartTransition()
    {
        if (fadeObject != null)
        {
            fadeObject.SetActive(true);
            UiManager.Instance.FadeAlphaOne(fadeObject, transitionDuration);
        }
        StartCoroutine(ChangeSceneWithDelay());
    }

    private IEnumerator ChangeSceneWithDelay()
    {
        yield return new WaitForSeconds(transitionDuration);
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            SceneManager.LoadScene(targetSceneName);
        }
    }

    public void SetTargetScene(string sceneName)
    {
        targetSceneName = sceneName;
    }

    public void SetTransitionDuration(float duration)
    {
        transitionDuration = duration;
    }
} 