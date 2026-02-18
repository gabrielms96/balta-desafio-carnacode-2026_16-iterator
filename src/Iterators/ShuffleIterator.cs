using DesignPatternChallenge.Interfaces;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Iterators;

/// <summary>
/// Iterador concreto: percorre a coleção em ordem aleatória (shuffle).
/// A ordem é definida na criação do iterador, permitindo múltiplas iterações independentes.
/// </summary>
public class ShuffleIterator : IIterator<Song>
{
    private readonly IReadOnlyList<Song> _shuffled;
    private int _index = -1;

    public ShuffleIterator(IReadOnlyList<Song> source, Random? random = null)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        random ??= new Random();
        _shuffled = source.OrderBy(_ => random.Next()).ToList();
    }

    public Song Current => _shuffled[_index];

    public bool MoveNext()
    {
        _index++;
        return _index < _shuffled.Count;
    }

    public void Reset() => _index = -1;
}
