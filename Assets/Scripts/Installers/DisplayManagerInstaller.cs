using UnityEngine;
using Zenject;

public class DisplayManagerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<DisplayManager>().FromNewComponentOnNewGameObject().AsSingle();
    }
}