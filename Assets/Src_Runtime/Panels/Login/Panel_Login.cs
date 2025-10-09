using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GJ {

    public class Panel_Login : MonoBehaviour, IPanelAsset {

        PanelType IPanelAsset.Type => PanelType.Login;

        [SerializeField] Button btn_start;
        [SerializeField] Button btn_exitGame;

        [SerializeField] TextMeshProUGUI txt_title;

        public Action OnStartHandle;
        public Action OnExitGameHandle;

        public void Ctor() {
            btn_start.onClick.AddListener(() => {
                OnStartHandle?.Invoke();
            });

            btn_exitGame.onClick.AddListener(() => {
                OnExitGameHandle?.Invoke();
            });
        }

        public void Init() {
            
        }

        public void Close() {
            btn_start.onClick.RemoveAllListeners();
            GameObject.Destroy(gameObject);
        }

    }

}