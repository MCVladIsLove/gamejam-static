using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FactoriesInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind(typeof(WindowFactory), typeof(FileIconFactory)).FromNew().AsSingle();
    }
}
