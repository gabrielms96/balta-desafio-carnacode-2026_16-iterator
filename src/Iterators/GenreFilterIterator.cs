using DesignPatternChallenge.Interfaces;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Iterators;

/// <summary>
/// Iterador concreto: percorre apenas as músicas do gênero especificado.
/// Composição de filtro com iteração sequencial.
/// </summary>
public class GenreFilterIterator : IIterator<Song>
{
    private readonly IReadOnlyList<Song> _filtered;
    private int _index = -1;

    public GenreFilterIterator(IReadOnlyList<Song> source, string genre)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        _filtered = source.Where(s => string.Equals(s.Genre, genre, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public Song Current => _filtered[_index];

    public bool MoveNext()
    {
        _index++;
        return _index < _filtered.Count;
    }

    public void Reset() => _index = -1;
}
