﻿using Client.Main.Content;
using Client.Main.Models;
using System.Threading.Tasks;

namespace Client.Main.Objects.Player
{
    public class PlayerHelmObject : ModelObject
    {
        private PlayerClass _playerClass;
        public PlayerClass PlayerClass { get => _playerClass; set { _playerClass = value; OnChangePlayerClass(); } }

        public PlayerHelmObject()
        {
            RenderShadow = true;
        }
     
        private async void OnChangePlayerClass()
        {
            Model = await BMDLoader.Instance.Prepare($"Player/HelmClass{(int)PlayerClass:D2}.bmd");
            if (Model != null && Status == GameControlStatus.Error)
                Status = GameControlStatus.Ready;
        }
    }
}
