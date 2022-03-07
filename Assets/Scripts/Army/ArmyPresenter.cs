using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MAG.Army.View;
using MAG.Army.Model;
using MAG.Army.Spawnner;
using MAG.Army.HUD;

namespace MAG.Army.Presenter
{
    public class ArmyPresenter
    {
        private IArmyView armyView;
        private IArmyModel armyModel;
        private IArmySpawnner armySpawnner;
        private IArmyHUD armyHUD;

        public ArmyPresenter(IArmyView view, IArmyModel model, IArmySpawnner spawnner, IArmyHUD hud)
        {
            armyModel = model;
            armyView = view;
            armySpawnner = spawnner;
            armyHUD = hud;
        }

        public void Enable()
        {
            armyModel.OnSelectSoldier += armyView.SelectSoldier;
            armyModel.OnSpawnSoldier += armyView.SpawnSoldier;
            armyModel.OnSpawnSoldier += armyHUD.SpawnSoldier;
            armyModel.OnSetup += armyView.ArmySetup;
            armyModel.OnSetup += armyHUD.Setup;
            armyHUD.OnSelectSoldier += armyModel.OnSelectSoldierRaise;
            armySpawnner.OnClick += armyModel.OnSpawnSoldierRaise;
        }

        public void Disable()
        {
            armyModel.OnSelectSoldier -= armyView.SelectSoldier;
            armyModel.OnSpawnSoldier -= armyView.SpawnSoldier;
            armyModel.OnSpawnSoldier -= armyHUD.SpawnSoldier;
            armyModel.OnSetup -= armyView.ArmySetup;
            armyModel.OnSetup -= armyHUD.Setup;
            armyHUD.OnSelectSoldier -= armyModel.OnSelectSoldierRaise;
            armySpawnner.OnClick -= armyModel.OnSpawnSoldierRaise;
        }
    }
}
