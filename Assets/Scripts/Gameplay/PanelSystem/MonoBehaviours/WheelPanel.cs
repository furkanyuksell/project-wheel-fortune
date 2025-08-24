using Gameplay.PanelSystem.Base;
using Gameplay.PanelSystem.Events;
using Gameplay.WheelSystem.Classes;
using Gameplay.WheelSystem.MonoBehaviours;
using UnityEngine;

namespace Gameplay.PanelSystem.MonoBehaviours
{
    public class WheelPanel : BasePanel
    {
        #region References
        [Header("References")]
        [SerializeField] private WheelListPresenter _presenter;
        #endregion

        #region Data
        private WheelDataModel _wheelDataModel;
        #endregion

        public void Initialize(WheelDataModel wheelDataModel)
        {
            _wheelDataModel = wheelDataModel;
            _presenter.Initialize();
        }

        protected override void OnPanelPrepare(IPanelEvent.OnPanelPrepare eventData)
        {
            _presenter.Prepare(_wheelDataModel.GetWheelDataSO(eventData.FortuneType), eventData.FortuneLevel);
        }


#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_presenter == null)
            {
                _presenter = GetComponentInChildren<WheelListPresenter>();
                if (_presenter == null)
                {
                    Debug.LogError("WheelListPresenter not found in WheelPanel. Please assign it in the inspector.");
                }
            }
        }
#endif
    }
}