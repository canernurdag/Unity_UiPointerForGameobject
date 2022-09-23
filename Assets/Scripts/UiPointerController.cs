using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caner.UiManagement
{
    public class UiPointerController : MonoBehaviour
    {
        #region Cache
        [SerializeField] private Transform _referenceTransform;
        [SerializeField] private List<Transform> _targetTransformList = new List<Transform>();
        [SerializeField] private Canvas _parentCanvas;
        [SerializeField] private GameObject _uiPointerPrefabGameObect;

        #endregion

        #region Buffer
        private List<UiPointer> _uiPointerList = new List<UiPointer>();
        #endregion
        
        private void Start()
        {
            InitUiPointerList();
        }
        
        private void InitUiPointerList()
        {
            for (int i = 0; i < _targetTransformList.Count; i++)
            {
                GameObject _uiPointerGameObject = Instantiate(_uiPointerPrefabGameObect);
                _uiPointerGameObject.transform.SetParent(_parentCanvas.transform);

                UiPointer uiPointer = _uiPointerGameObject.GetComponent<UiPointer>();

                if (uiPointer != null) _uiPointerList.Add(uiPointer);
                uiPointer.SetTargetTransform(_targetTransformList[i]);
                uiPointer.SetReferenceTransform(_referenceTransform);
            }
        }


        #region Set Functions
        public void SetTargetTransforms(List<Transform> targetTransformList)
        {
            _targetTransformList = targetTransformList;
        }
        #endregion

   
    }
}
