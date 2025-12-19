using UnityEngine;

public static class ServiceLocator
{

    private static IInputService _input;
    private static IPhysicsService _physics;


    public static void RegisterInput(IInputService input) => _input = input;
    public static void RegisterPhysics(IPhysicsService physics) => _physics = physics;


    public static IInputService Input => _input;
    public static IPhysicsService Physics => _physics;




}
