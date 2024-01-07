using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace App.Scripts.Infrastructure.Installers
{
    public class ConfigsInstaller : MonoInstaller
    {
        [SerializeField] private List<ScriptableObject> _configs;

        public override void InstallBindings()
        {
            BindConfigs();
        }

        private void BindConfigs()
        {
            for (int i = 0; i < _configs.Count; i++)
                Container.Bind(_configs[i].GetType()).FromInstance(_configs[i]).AsSingle();
        }
    }
}