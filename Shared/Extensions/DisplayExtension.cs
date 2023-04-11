using System.Reflection;

namespace OnboardingBot.Shared.Extensions;

public static class DisplayExtensions
{
    /// <summary>
    ///     A generic extension method that aids in reflecting 
    ///     and retrieving any attribute that is applied to an `T`.
    /// </summary>
    public static TAttribute GetAttribute<TAttribute, T>(this T model) 
        where TAttribute : Attribute
    {
        return model.GetType()
            .GetMember(model.ToString())
            .First()
            .GetCustomAttribute<TAttribute>();
    }
}