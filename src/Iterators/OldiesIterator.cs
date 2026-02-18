using DesignPatternChallenge.Interfaces;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Iterators;

/// <summary>
/// Iterador concreto: percorre apenas músicas antigas (ano &lt; 2000) ordenadas por ano.
/// Exemplo de iterador com filtro e ordenação customizados.
/// </summary>
public class OldiesIterator : IIterator<Song>
{
    private readonly IReadOnlyList<Song> _oldies;
    private int _index = -1;

    public OldiesIterator(IReadOnlyList<Song> source, int yearThreshold = 2000)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        _oldies = source.Where(s => s.Year < yearThreshold).OrderBy(s => s.Year).ToList();
    }

    public Song Current => _oldies[_index];

    public bool MoveNext()
    {
        _index++;
        return _index < _oldies.Count;
    }

    public void Reset() => _index = -1;
}
