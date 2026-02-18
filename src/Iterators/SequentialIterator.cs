using DesignPatternChallenge.Interfaces;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Iterators;

/// <summary>
/// Iterador concreto: percorre a coleção na ordem original (índice 0 até n-1).
/// </summary>
public class SequentialIterator : IIterator<Song>
{
    private readonly IReadOnlyList<Song> _source;
    private int _index = -1;

    public SequentialIterator(IReadOnlyList<Song> source)
    {
        _source = source ?? throw new ArgumentNullException(nameof(source));
    }

    public Song Current => _source[_index];

    public bool MoveNext()
    {
        _index++;
        return _index < _source.Count;
    }

    public void Reset() => _index = -1;
}
