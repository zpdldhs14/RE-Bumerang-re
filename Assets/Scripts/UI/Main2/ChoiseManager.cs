using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiseManager : MonoBehaviour
{

    public static ChoiseManager instance;
    private AudioManager theAudio;
    private string question;
    private List<string> answersList;

    public GameObject go; //평소에 비활성화 목적으로 선언. setActive

    public TextMeshProUGUI question_Text;
    public TextMeshProUGUI[] answer_Text;

    public GameObject[] answer_Panel;

    public Animator anim;

    public string keySound;
    public string enterSound;

    public bool choiceing; // 대기.
    private bool keyInput; // 키처리 활성화.

    private int count; //배열의 크기
    private int result; // 선택한 선택창

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    // Start is called before the first frame update
    void Start()
    {
        theAudio = FindAnyObjectByType<AudioManager>();
        answersList = new List<string>();
        for(int i = 0; i < answer_Text.Length; i++)
        {
            answer_Text[i].text = "";
            answer_Panel[i].SetActive(false);
        }
        question_Text.text = "";
    }

    public void ShowChoise(Choise _choise)
    {
        go.SetActive(true);
        result = 0;
        question = _choise.question;
        for(int i = 0; i < _choise.answers.Length; i++)
        {
            answersList.Add(_choise.answers[i]);
            answer_Panel[i].SetActive(true);
            count = i;
        }
        anim.SetBool("Apper",true);
        Selection();
        StartCoroutine(ChoiceCoroutine());
    }

    public int GetResult()
    {
        return result;
    }

    public void ExitChoice()
    {
        question_Text.text = "";
        for (int i = 0; i <= count; i++)
        {
            answer_Text[i].text = "";
            answer_Panel[i].SetActive(false);
        }

        anim.SetBool("Apper", false);
        choiceing = false;
        answersList.Clear();
        go.SetActive(false);


    }

    IEnumerator ChoiceCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(TypingQuestion());
        StartCoroutine(TypingAnswer_1());
        if(count >= 1)
            StartCoroutine(TypingAnswer_2());
        if (count >= 2)
            StartCoroutine(TypingAnswer_3());
        if (count >= 3)
            StartCoroutine(TypingAnswer_4());

        yield return new WaitForSeconds(0.5f);
        keyInput = true;

    }

    IEnumerator TypingQuestion()
    {
        for(int i = 0; i < question.Length; i++)
        {
            question_Text.text += question[i];
            yield return waitTime;
        }
    }
    IEnumerator TypingAnswer_1()
    {
        yield return new WaitForSeconds(0.4f);
        for (int i = 0; i < answersList[0].Length; i++)
        {
            answer_Text[0].text += answersList[0][i];
            yield return waitTime;
        }
    }
    IEnumerator TypingAnswer_2()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < answersList[1].Length; i++)
        {
            answer_Text[1].text += answersList[1][i];
            yield return waitTime;
        }
    }
    IEnumerator TypingAnswer_3()
    {
        yield return new WaitForSeconds(0.6f);
        for (int i = 0; i < answersList[2].Length; i++)
        {
            answer_Text[2].text += answersList[2][i];
            yield return waitTime;
        }
    }
    IEnumerator TypingAnswer_4()
    {
        yield return new WaitForSeconds(0.7f);
        for (int i = 0; i < answersList[3].Length; i++)
        {
            answer_Text[3].text += answersList[3][i];
            yield return waitTime;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(keyInput)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                if(result > 0)
                    result--;
                else
                    result = count;
                Selection();
            }
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(result < count)
            {
                result++;
            }
            else{
                result = 0;
            }
            Selection();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            keyInput = false;
            ExitChoice();
        }

    }

    public void Selection()
    {
        Color color = answer_Panel[0].GetComponent<Image>().color;
        color.a = 0.75f;
        for(int i = 0; i <= count; i++)
        {
            answer_Panel[i].GetComponent<Image>().color = color;
        }
        color.a = 1f;
        answer_Panel[result].GetComponent<Image>().color = color;
    }
}
