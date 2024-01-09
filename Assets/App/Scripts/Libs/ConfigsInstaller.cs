using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace App.Scripts.Infrastructure.Installers
{
    public class ConfigsInstaller : MonoInstaller
    {
        [SerializeField] private List<ScriptableObject> _scriptableConfigs;
        [SerializeField] private List<MonoConfig> _monoConfigs;

        public override void InstallBindings()
        {
            BindConfigs();
        }

        private void BindConfigs()
        {
            for (int i = 0; i < _scriptableConfigs.Count; i++)
                Container.Bind(_scriptableConfigs[i].GetType()).FromInstance(_scriptableConfigs[i]).AsSingle();
            
            for (int i = 0; i < _monoConfigs.Count; i++)
                Container.Bind(_monoConfigs[i].GetType()).FromInstance(_monoConfigs[i]).AsSingle();

        }
    }
}