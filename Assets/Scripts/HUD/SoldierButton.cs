using MAG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MAG.Army.HUD
{
    public class SoldierButton : MonoBehaviour
    {
        private Button button;
        [SerializeField]
        private Image icon;
        [SerializeField]
        private Text text;

        private int soldiers;
        private string key;
        private IArmyHUD hud;

        public void Setup(ArmyEntry entry, IArmyHUD hud)
        {
            button = GetComponent<Button>();
            key = entry.data.key;
            icon.sprite = entry.data.icon;
            soldiers = entry.maxSoldiers;
            this.hud = hud;

            button.onClick.AddListener(OnClick);

            UpdateText();
        }

        private void OnClick()
        {
            hud.SelectSoldier(key);
        }

        public void SpawnSoldier(string key)
        {
            if (!string.Equals(this.key, key))
                return;

            soldiers--;
            if (soldiers <= 0)
            {
                soldiers = 0;
                button.enabled = false;
            }

            UpdateText();
        }

        private void UpdateText()
        {
            text.text = soldiers.ToString();
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(OnClick);
        }
    }
}
