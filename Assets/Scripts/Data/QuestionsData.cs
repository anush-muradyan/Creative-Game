using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Questions Data Asset", menuName = "Questions Data Asset", order = 0)]
    public class QuestionsData : ScriptableObject
    {
        [SerializeField] private List<QuestionData> questionsData;

        public List<QuestionData> Data => questionsData;
    }

    [Serializable]
    public class QuestionData
    {
        [SerializeField] private string question;
        [SerializeField] private int rightAnswerIndex;
        [SerializeField] private List<string> answers;

        public string Question => question;
        public int RightAnswerIndex => rightAnswerIndex;
        public List<string> Answers => answers;
    }
}

