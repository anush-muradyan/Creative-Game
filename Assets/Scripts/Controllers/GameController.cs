using Data;
using UnityEngine;

namespace Controllers
{
    public class GameController: MonoBehaviour
    {
        [SerializeField] private QuestionController questionController;
        [SerializeField] private QuestionsData questionsData;
        [SerializeField] private GameObject firstCharacter;
        [SerializeField] private GameObject secondCharacter;

        private void Start()
        {
            questionController.Init(questionsData.Data[0]);
            questionController.OnAnimationStarted += OnAnimationStarted;
            questionController.OnAnimationEnded += OnAnimationEnded;
        }

        private void OnAnimationEnded()
        {
            SetState(true);
        }

        private void OnAnimationStarted()
        {
            SetState(false);
        }

        private void SetState(bool setState)
        {
            firstCharacter.gameObject.SetActive(setState);
            secondCharacter.gameObject.SetActive(setState);
        }
    }
}