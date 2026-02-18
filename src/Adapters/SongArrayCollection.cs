using DesignPatternChallenge.Interfaces;
using DesignPatternChallenge.Iterators;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Adapters;

/// <summary>
/// Adapter: permite tratar um array de músicas como IIterableCollection,
/// com interface uniforme independente do tipo de coleção (array, lista, fila).
/// </summary>
public class SongArrayCollection : IIterableCollection<Song>
{
    private readonly Song[] _songs;
    public string Name { get; } = "Array de músicas";

    public SongArrayCollection(Song[] songs)
    {
        _songs = songs ?? throw new ArgumentNullException(nameof(songs));
    }

    public IIterator<Song> CreateSequentialIterator() =>
        new SequentialIterator(_songs.ToList());
}
