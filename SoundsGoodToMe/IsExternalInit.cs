// Dummy class to fix c#9 init feature:
// https://developercommunity.visualstudio.com/content/problem/1244809/error-cs0518-predefined-type-systemruntimecompiler.html

// ReSharper disable once CheckNamespace
namespace System.Runtime.CompilerServices
{
    // ReSharper disable once UnusedType.Global
    internal static class IsExternalInit {}
}