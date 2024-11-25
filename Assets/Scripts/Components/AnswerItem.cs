using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Components
{
    public class AnswerItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI answerText;
        [SerializeField] private Button button;

        public Action<string> OnButtonClicked;
        public void Init(string answer)
        {
            answerText.text = answer;
            button.onClick.AddListener(()=>OnButtonClicked?.Invoke(answer));
        }

    }
}