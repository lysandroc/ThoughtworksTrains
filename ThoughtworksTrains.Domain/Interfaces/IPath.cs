using System;

namespace ThoughtworksTrains.Domain.Interfaces
{
    public interface IPath : IEquatable<IPath>
    {
        INode Source { get; }
        INode Target { get; }
        Int64 Distance { get; }
    }
}