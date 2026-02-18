namespace DesignPatternChallenge.Interfaces;

/// <summary>
/// Interface do Aggregate no padrão Iterator: coleções que podem produzir
/// iteradores sem expor a estrutura interna.
/// </summary>
public interface IIterableCollection<T>
{
    /// <summary>Cria um iterador sequencial sobre a coleção.</summary>
    IIterator<T> CreateSequentialIterator();

    /// <summary>Nome da coleção (ex.: nome da playlist) para exibição.</summary>
    string Name { get; }
}
