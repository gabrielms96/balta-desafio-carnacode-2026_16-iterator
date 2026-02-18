using DesignPatternChallenge.Interfaces;
using DesignPatternChallenge.Iterators;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Collections;

/// <summary>
/// Playlist que NÃO expõe a estrutura interna. Acesso apenas via iteradores.
/// </summary>
public class Playlist : IPlaylistCollection
{
    public string Name { get; set; }
    private readonly List<Song> _songs = new();

    public Playlist(string name) => Name = name;

    public void AddSong(Song song) => _songs.Add(song);

    public IIterator<Song> CreateSequentialIterator() =>
        new SequentialIterator(_songs.ToList());

    public IIterator<Song> CreateShuffleIterator() =>
        new ShuffleIterator(_songs.ToList());

    public IIterator<Song> CreateGenreIterator(string genre) =>
        new GenreFilterIterator(_songs.ToList(), genre);

    public IIterator<Song> CreateOldiesIterator(int yearThreshold = 2000) =>
        new OldiesIterator(_songs.ToList(), yearThreshold);
}
