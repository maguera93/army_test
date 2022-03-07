using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using MAG.Army.Model;
using MAG.Army.View;
using MAG.Army.Spawnner;
using MAG.Army.Presenter;
using MAG.Army.HUD;

namespace MAG.Core
{
    [Serializable]
    public class ArmyEntry
    {
        public SoldierData data;
        public int maxSoldiers;
    }

    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private List<ArmyEntry> entries;

        private ArmyPresenter armyPresenter;

        public void Awake()
        {
            ArmyModel armyModel = new ArmyModel();
            ArmyView armyView = GetComponentInChildren<ArmyView>();
            ArmySpawnner armySpawnner = GetComponentInChildren<ArmySpawnner>();
            ArmyHUD armyHUD = GetComponentInChildren<ArmyHUD>();

            armyPresenter = new ArmyPresenter(armyView, armyModel, armySpawnner, armyHUD);
            armyPresenter.Enable();
            armyModel.Setup(entries);
        }

        private void OnDisable()
        {
            armyPresenter.Disable();
        }
    }
}