using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Caculator
{
    public class CaculatorView : MonoBehaviour
    {
        public Button _AdditionButton;
        public Button _SubtractionButton;
        public Button _MultiplicationButton;
        public Button _DivisionButton;
        public TMP_Text _TextResults;
        public TMP_InputField _TextA;
        public TMP_InputField _TextB;
        [SerializeField]
        public NormalButton[] _NormalButtons;
    }
}
