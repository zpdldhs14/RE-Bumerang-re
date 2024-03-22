using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class typingeffect : MonoBehaviour
{
    public TMP_Text text;
    private string m_text = "경비원 시간표에 적혀있는 샤워시간에 열쇠를 훔쳐야 겠다...";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_typing());
    }

    IEnumerator _typing()
    {
        for(int i = 0; i <= m_text.Length; i++)
        {
            //subtring(start index, length)
            text.text = m_text.Substring(0, i);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
