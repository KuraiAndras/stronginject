﻿using Microsoft.CodeAnalysis;
using System.Collections.Immutable;

namespace StrongInject.Generator
{
    internal abstract record Statement();
    internal sealed record DependencyCreationStatement(
        string VariableName,
        InstanceSource Source,
        ImmutableArray<string?> Dependencies) : Statement;
    internal sealed record DelegateCreationStatement(
        string VariableName,
        DelegateSource Source,
        ImmutableArray<Operation> InternalOperations,
        string InternalTargetName) : Statement()
    {
        public string DisposeActionsName { get; } = "disposeActions_" + VariableName;
    }
    internal sealed record DisposeActionsCreationStatement(string VariableName, ITypeSymbol Type) : Statement;
    internal sealed record SingleInstanceReferenceStatement(string VariableName, InstanceSource Source) : Statement;
    internal sealed record InitializationStatement(string VariableName, bool IsAsync) : Statement;
}
