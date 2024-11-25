using System;
using System.Collections;
using Components;
using Data;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class QuestionController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI questionText;
        [SerializeField] private RectTransform answersContainer;
        [SerializeField] private AnswerItem answerItem;
        [SerializeField] private Animator firstOneAttacks;
        [SerializeField] private Animator secondOneAttacks;
        
        private QuestionData _questionData;
        public Action OnAnimationStarted;
        public Action OnAnimationEnded;

        public void Init(QuestionData questionData)
        {
            _questionData = questionData;
            foreach (var answer in questionData.Answers)
            {
                var item = Instantiate(answerItem, answersContainer);
                item.Init(answer);
                item.OnButtonClicked += AnswerSelected;
            }
        }

        private void AnswerSelected(string answer)
        {
            StartCoroutine(Animate(answer));
        }

        private IEnumerator Animate(string answer)
        {
            OnAnimationStarted?.Invoke();
            if (answer.Equals(_questionData.Answers[_questionData.RightAnswerIndex]))
            {
                firstOneAttacks.gameObject.SetActive(true);
                yield return new WaitForSeconds(1.5f);
                firstOneAttacks.gameObject.SetActive(false);
            }
            else
            {
                secondOneAttacks.gameObject.SetActive(true);
                yield return new WaitForSeconds(1.7f);
                secondOneAttacks.gameObject.SetActive(false);
            }
            OnAnimationEnded?.Invoke();
        }
    }
}
